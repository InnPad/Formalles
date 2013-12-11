using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall
{
    internal class Document : IDocument
    {
        public static implicit operator XDocument(Document document)
        {
            return document != null ? document._document : null;
        }

        private readonly XDocument _document;
        private readonly Model _model;

        public Document(XDocument document, Model model)
        {
            _document = document;
            _model = model;
        }

        public Document(IDocument document, Model model)
            : this(new XDocument(), model)
        {
            // deep copy document in _document
        }

        public Document(IDocument document)
            : this(document, document.Model)
        {
        }

        #region - ICollection -

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, IEntry>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<KeyValuePair<string, IEntry>>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Remove(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        #endregion - ICollection -

        #region - IDictionary -

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, IEntry>.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        ICollection<string> IDictionary<string, IEntry>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<string, IEntry>.Remove(string key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, IEntry>.TryGetValue(string key, out IEntry value)
        {
            throw new NotImplementedException();
        }

        ICollection<IEntry> IDictionary<string, IEntry>.Values
        {
            get { throw new NotImplementedException(); }
        }

        IEntry IDictionary<string, IEntry>.this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion - IDictionary -

        #region - IDocument -

        public Model Model
        {
            get { return _model; }
        }

        #endregion - IDocument -

        #region - IEntry -

        DataType IEntry.Type
        {
            get { return _model; }
        }

        #endregion - IEntry -

        #region - IEnumerable -

        IEnumerator<KeyValuePair<string, IEntry>> IEnumerable<KeyValuePair<string, IEntry>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable -

        #region - IValidatable -

        IEnumerable<ValidationResult> IValidatable.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion - IValidatable -
    }
}
