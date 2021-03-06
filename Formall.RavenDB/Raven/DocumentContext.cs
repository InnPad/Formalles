﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Raven
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Client;
    using global::Raven.Client.Indexes;
    using global::Raven.Json.Linq;
    using global::Raven.Imports.Newtonsoft.Json;

    public abstract class DocumentContext : IDocumentContext
    {
        private static readonly object _lock = new object();

        private static IDocumentStore _store;

        private readonly string _name;

        protected DocumentContext(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
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

        protected abstract IDocumentStore CreateDocumentStore();

        protected virtual void InitializeDocumentStore(IDocumentStore store)
        {
            //store.Conventions.IdentityPartsSeparator = "/";
            store.Conventions.SaveEnumsAsIntegers = false;

            store.Initialize();

            new RavenDocumentsByEntityName().Execute(store);
        }

        public IDocument Import(IDocument document)
        {
            throw new NotImplementedException();
        }

        public IDocument Import(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Import(TextReader reader)
        {
            IDocument document;

            using (var jsonReader = new JsonTextReader(reader))
            {
                document = new Document(RavenJObject.Load(jsonReader));
            }

            return document;
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

        public IDocument[] Read(int startIndex, int pageSize)
        {
            return DocumentStore.DatabaseCommands
                .GetDocuments(startIndex, pageSize)
                .Select(o => new Document(o))
                .ToArray();
        }


        public IDocument Load(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public IDocument Load(Stream stream)
        {
            throw new NotImplementedException();
        }

        void IDocumentContext.Store(string key, IDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
