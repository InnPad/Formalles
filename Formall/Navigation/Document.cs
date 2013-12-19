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
    using Formall.Linq;
    using Formall.Persistence;
    using Formall.Reflection;
        
    public abstract class Document : Segment, IDocument, ISegment
    {
        private IDictionary _internal;
        private IDocument _document;

        protected Document(IDocument document, ISegment parent)
            : base(parent)
        {
            _document = document;
        }

        protected dynamic Content
        {
            get { return _document.Content; }
        }

        #region - IDocument -

        object IDocument.Content
        {
            get { return _document.Content; }
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
