using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    using Formall.Persistence;
    using Formall.Reflection;
        
    internal class Document : Segment, IDocument, ISegment
    {
        private IDocument _document;
        private ISegment _parent;

        public Document(IDocument document, string name, ISegment parent)
            : base(name, parent)
        {
            _document = document;
            _parent = parent;
        }

        protected Stream Content
        {
            get { return _document.Content; }
        }

        #region - IDocument -

        Stream IDocument.Content
        {
            get { return _document.Content; }
        }

        public ContentType ContentType
        {
            get { return _document.ContentType; }
        }

        IDocumentContext IDocument.Context
        {
            get { return _document.Context; }
        }

        string IDocument.Key
        {
            get { return _document.Key; }
        }

        Metadata IDocument.Metadata
        {
            get { return _document.Metadata; }
        }

        #endregion - IDocument -
    }
}
