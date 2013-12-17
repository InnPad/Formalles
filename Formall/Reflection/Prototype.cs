using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Dynamic;
using System.Linq.Expressions;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;
    using Formall.Reflection;


    public abstract class Prototype : Document
    {
        private IDictionary _data;
        private IDocument _document;
        private ISegment _parent;

        protected Prototype(IDocument document, ISegment parent)
            : base(document, parent)
        {
            _parent = parent;
            _document = document;
        }

        protected IDictionary Data
        {
            get
            {
                var entity = _document as IEntity;
                return entity != null ? entity.Data : null;
            }
        }

        public Guid Identity
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
    }
}
