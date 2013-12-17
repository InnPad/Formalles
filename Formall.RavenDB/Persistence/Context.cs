using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
using Formall.Reflection;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Indexes;
using Raven.Json.Linq;
using System.IO;
using System.Xml;

    internal class Context : IDataContext, IDocumentContext
    {
        public static RavenJToken Import(IEntry entry)
        {
            throw new NotImplementedException();
        }

        private readonly object _lock = new object();

        private IDocumentStore _store;

        public Context(RavenStore store)
        {
        }

        internal protected IDocumentStore DocumentStore
        {
            get
            {
                var store = _store;

                // return without locking if already exist
                if (store != null)
                    return store;

                // lock and check again
                lock (_lock)
                {
                    // create new instance if doesn't exist
                    store = _store ?? (_store = CreateDocumentStore());

                    InitializeDocumentStore(store);

                    // save store instance
                    _store = store;
                }

                return store;
            }
        }

        protected IDocumentStore CreateDocumentStore()
        {
            return null;
        }

        protected virtual void InitializeDocumentStore(IDocumentStore store)
        {
            //store.Conventions.IdentityPartsSeparator = "/";
            store.Conventions.SaveEnumsAsIntegers = false;

            store.Initialize();

            new RavenDocumentsByEntityName().Execute(store);
        }

        public IRepository CreateRopository(Model model)
        {
            throw new NotImplementedException();
        }

        public Document Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        #region - IDocumentContext -

        public IResult Delete(string key)
        {
            throw new NotImplementedException();
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
            return Import(document);
        }

        public IDocument[] Read(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public IDocument Read(string key)
        {
            throw new NotImplementedException();
        }

        public IDocument[] Read(string keyPrefix, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public IResult Store(ref IDocument document)
        {
            var myDocument = document as Document;

            if (myDocument == null)
            {
                myDocument = Import(document);
                document = myDocument;
            }

            var jsonDocument = (JsonDocument)myDocument;

            var result = _store.DatabaseCommands.Put(myDocument.Key, null, jsonDocument.DataAsJson, jsonDocument.Metadata);

            return new SuccessResult
            {
                Data = new { Key = result.Key, Etag = result.ETag }
            };
        }

        #endregion - IDocumentContext -
    }
}
