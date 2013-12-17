using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Linq;
    using Formall.Persistence;
    using Formall.Reflection;
    using Formall.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class Document : IDocument
    {
        private readonly Metadata _metadata;
        private readonly Model _model;
        private JsonObject _dictionary;

        public Document(JObject document, Metadata metadata, Model model)
        {
            _dictionary = new JsonObject(document, model);
            _metadata = metadata;
            _model = model;
        }

        public JsonObject Content
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }

        #region - IDocument -

        object IDocument.Content
        {
            get { return this.Content; }
        }

        public Guid Id
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public Metadata Metadata
        {
            get;
            set;
        }

        #endregion - IDocument -


        IDocumentContext IDocument.Context
        {
            get { throw new NotImplementedException(); }
        }

        string IDocument.Key
        {
            get { throw new NotImplementedException(); }
        }

        Metadata IDocument.Metadata
        {
            get { throw new NotImplementedException(); }
        }
    }
}
