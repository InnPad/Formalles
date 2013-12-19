using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Persistence;
    using Formall.Reflection;
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;
    using Raven.Json.Linq;

    internal class Document : IDocument
    {
        public static implicit operator JsonDocument(Document document)
        {
            return document._document;
        }

        private readonly JsonDocument _document;
        private readonly Metadata _metadata;
        private readonly Repository _repository;
        private readonly Guid _id;

        public Document(JsonDocument document, Repository repository)
        {
            _document = document;
            _repository = repository;
        }

        public Document(RavenJObject obj, RavenJObject metadata, Repository repository)
        {
            _document = new JsonDocument { DataAsJson = obj, Metadata = metadata };
            _repository = repository;
        }

        public Document(RavenJObject obj, Repository repository)
            : this(obj, obj.Value<RavenJObject>("@metadata"), repository)
        {
        }

        public dynamic Data
        {
            get { throw new NotImplementedException(); }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public Model Model
        {
            get { return _repository.Model; }
        }

        public IRepository Repository
        {
            get { return _repository; }
        }

        public IResult Delete()
        {
            return _repository.Delete(_id);
        }

        public IResult Refresh()
        {
            throw new NotImplementedException();
        }

        public IResult Patch(IDictionary data)
        {
            return _repository.Patch(_id, data);
        }

        public IResult Update(IDictionary data)
        {
            return _repository.Update(_id, data);
        }

        #region - IDocument -

        object IDocument.Content
        {
            get { return this.Data; }
        }

        IDocumentContext IDocument.Context
        {
            get { return _repository.Context; }
        }

        public string Key
        {
            get { throw new NotImplementedException(); }
        }

        Metadata IDocument.Metadata
        {
            get { return _metadata; }
        }

        #endregion - IDocument -
    }
}
