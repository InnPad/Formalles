using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Persistence
{
    using Formall.Navigation;
    using Formall.Reflection;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Document;
    using Raven.Client.Embedded;
    using Raven.Client.Indexes;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;
    using Raven.Json.Linq;

    public class RavenDocumentContext : IDataContext
    {
        private readonly object _lock = new object();

        private readonly DocumentStoreConfig _config;
        private readonly string _name;
        private DocumentStoreBase _store;
        private readonly Schema _schema;
        private readonly ConcurrentDictionary<string, Repository> _repositories;

        private RavenDocumentContext(Schema schema)
        {
            _schema = schema;
            _repositories = new ConcurrentDictionary<string, Repository>();
        }

        public RavenDocumentContext(string name, Schema schema)
            : this(schema)
        {
            _name = name;

            var document = schema[name];

            if (document == null)
            {
                // log error
            }
            else
            {
                var entity = document as IEntity;

                if (entity == null)
                {
                    // log error
                }
                else
                {
                    _config = entity.Get<DocumentStoreConfig>();
                }
            }
        }

        public RavenDocumentContext(Schema schema, object config)
            : this(schema)
        {
            var serializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                ContractResolver = new DefaultContractResolver()
            };

            _config = (DocumentStoreConfig)serializer.Deserialize(new RavenJTokenReader(RavenJObject.FromObject(config)), typeof(DocumentStoreConfig));
            _name = _config.Name;
        }

        internal protected IDocumentStore DocumentStore
        {
            get
            {
                var store = _store;

                if (store == null)
                {
                    //
                    // lock and check again
                    
                    lock (_lock)
                    {
                        store = _store;

                        if (store == null)
                        {
                            if (_config == null)
                            {
                                // error already logged
                            }
                            else try
                                {
                                    //
                                    // create new instance if doesn't exist

                                    var apiKey = _config.ApiKey + '/' + _config.Secret;

                                    if (_config.Embeddable)
                                    {
                                        store = new EmbeddableDocumentStore
                                        {
                                            //ApiKey = apiKey,
                                            //ConnectionStringName = _config.Name,
                                            DataDirectory = _config.DataDirectory
                                        };
                                    }
                                    else
                                    {
                                        store = new DocumentStore
                                        {
                                            //ApiKey = apiKey,
                                            //ConnectionStringName = _config.Name,
                                            Url = _config.Url
                                        };
                                    }

                                    if (store != null)
                                    {
                                        //
                                        // define store conventions

                                        //store.Conventions.IdentityPartsSeparator = "/";
                                        store.Conventions.SaveEnumsAsIntegers = false;

                                        //
                                        // initialize store instance

                                        store.Initialize();

                                        //
                                        // create index by entity name

                                        new RavenDocumentsByEntityName().Execute(store);
                                    }
                                }
                                catch (Exception e)
                                {
                                    // log exception
                                }
                                finally
                                {
                                    // save store instance
                                    _store = store;
                                }
                        }
                    }
                }

                return store;
            }
        }

        IRepository IDataContext.CreateRepository(string name)
        {
            return this.Repository(name);
        }

        internal Entity Import(IEntity source)
        {
            var metadata = new RavenJObject();
            metadata["@id"] = source.Metadata.Key;
            metadata["Raven-Entity-Name"] = source.Metadata.Type;
            
            var data = RavenJObject.FromObject(source.Data);

            var entity = new Entity(source.Id, data, metadata, Repository(source.Metadata.Type));

            return entity;
        }

        IEntity IDataContext.Import(IEntity entity)
        {
            return this.Import(entity);
        }

        #region - IDocumentContext -

        public IResult Delete(string key)
        {
            DocumentStore.DatabaseCommands.Delete(key, null);
            return null;
        }

        public IDocument Import(Stream stream)
        {
            IDocument document;

            using (var reader = new StreamReader(stream))
            {
                document = Import(reader);
            }

            return document;
        }

        public IDocument Import(TextReader reader)
        {
            throw new NotImplementedException();
        }

        IDocument IDocumentContext.Import(IDocument document)
        {
            return this.Import(document as IEntity);
        }

        public IDocument[] Read(int skip, int take)
        {
            var documents = DocumentStore.DatabaseCommands.GetDocuments(skip, take);

            return documents.Select(o => new Entity(Entity.ParseId(o.Key), o.DataAsJson, o.Metadata, Repository(o.Metadata.Value<string>("Raven-Entity-Name")))).OfType<IDocument>().ToArray();
        }

        public IDocument Read(string key)
        {
            var document = DocumentStore.DatabaseCommands.Get(key);
            var data = document.DataAsJson;
            var metadata = document.Metadata;

            throw new NotImplementedException();
        }

        public IDocument[] Read(string keyPrefix, int skip, int take)
        {
            throw new NotImplementedException();
        }

        internal Repository Repository(string name)
        {
            Repository repository;

            if (!_repositories.TryGetValue(name, out repository))
            {
                var segment = _schema.Query(name, "*").FirstOrDefault();

                string keyPrefix = null;
                Model model = null;

                if (segment != null)
                {
                    var entity = segment as Entity<Model>;
                    if (entity != null)
                    {
                        model = (Model)entity;

                        keyPrefix = model.Name + '/';

                        for (var baseType = model.BaseType; baseType != null; )
                        {
                            segment = segment.Parent;
                            if (segment != null)
                            {
                                entity = segment as Entity<Model>;
                                var baseModel = (Model)entity;
                                keyPrefix = baseModel.Name + '/' + keyPrefix;
                            }

                        }
                    }
                }

                repository = _repositories.AddOrUpdate(name, new Repository(keyPrefix, model, this), (key, previous) =>
                {
                    // log info to track worst cases
                    return previous;
                });
            }

            return repository;
        }

        public IResult Store(ref IDocument document)
        {
            var entity = document as Entity;

            if (entity == null)
            {
                var metadata = new RavenJObject();
                metadata["@id"] = document.Metadata.Key;
                metadata["Raven-Entity-Name"] = document.Metadata.Type;

                var source = document as IEntity;

                var data = RavenJObject.FromObject(source.Data);

                entity = new Entity(source.Id, data, metadata, new Repository(document.Metadata.Key.Exclude(1, '/') + '/', null, this));

                //entity = Import(document as IEntity);
                
                document = entity;
            }

            var result = DocumentStore.DatabaseCommands.Put(entity.Key, null, entity.Data, entity.Metadata);

            return new SuccessResult
            {
                Data = new { Key = result.Key, Etag = result.ETag }
            };
        }

        #endregion - IDocumentContext -
    }
}
