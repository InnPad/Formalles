using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall
{
    public class Area : IDocument, IEdmx, IFileSystem, ISegment
    {
        private static Model _model;
        private IDocument _document;
        private List<ISegment> _children;

        public string Name
        {
            get;
            set;
        }

        public Text Summary
        {
            get;
            set;
        }

        public Text Title
        {
            get;
            set;
        }

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

        XDocument IDocument.ToXml()
        {
            return _document.ToXml();
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

        #region - IEdmx -

        XElement IEdmx.ToEdmx()
        {
            throw new NotImplementedException();
        }

        #endregion - IEdmx -

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
            get { return _children ?? (_children = new List<ISegment>()); }
        }

        #endregion - ISegment -
    }
}
