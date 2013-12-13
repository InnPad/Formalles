using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall
{
    public class Error : IDocument, IFileSystem, ISegment
    {
        private static Model _model;
        private IDocument _document;

        public string Name
        {
            get;
            set;
        }

        public Text Message
        {
            get;
            set;
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

        public Model Model
        {
            get { return _model; }
        }

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
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

        IEntry IDocument.this[string name]
        {
            get { return _document[name]; }
        }

        Guid IDocument.Id
        {
            get { return _document.Id; }
        }

        string IDocument.Key
        {
            get { return _document.Key; }
        }

        Metadata IDocument.Metadata
        {
            get { return _document.Metadata; }
        }

        Model IDocument.Model
        {
            get { return _model; }
        }

        IDictionary IDocument.ToObject()
        {
            return _document.ToObject();
        }

        TObject IDocument.ToObject<TObject>()
        {
            return _document.ToObject<TObject>();
        }

        System.Xml.Linq.XDocument IDocument.ToXml()
        {
            throw new NotImplementedException();
        }

        void IDocument.WriteJson(TextWriter writer)
        {
            _document.WriteJson(writer);
        }

        void IDocument.WriteJson(Stream stream)
        {
            _document.WriteJson(stream);
        }

        #endregion - IDocument -

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

        #region - IFileSystem -

        DateTime IFileSystem.CreationTime
        {
            get { throw new NotImplementedException(); }
        }

        string IFileSystem.FullName
        {
            get { return this.Name; }
        }

        DateTime IFileSystem.LastAccessTime
        {
            get { throw new NotImplementedException(); }
        }

        DateTime IFileSystem.LastWriteTime
        {
            get { throw new NotImplementedException(); }
        }

        #endregion - IFileSystem -

        #region - ISegment -

        string ISegment.Name
        {
            get { return this.Name.Split('/').Last(); }
        }

        ISegment ISegment.Parent
        {
            get { return Schema.Current.ParentOf(this); }
        }

        string ISegment.Path
        {
            get { return this.Name; }
        }

        List<ISegment> ISegment.Children
        {
            get { return null; }
        }

        #endregion - ISegment -
    }
}
