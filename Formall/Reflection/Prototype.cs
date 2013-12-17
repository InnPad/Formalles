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
        private IEntity _entity;
        private ISegment _parent;

        protected Prototype(IEntity entity, ISegment parent)
            : base(entity as IDocument, parent)
        {
            _parent = parent;
            _entity = entity;
        }

        protected IDictionary Data
        {
            get
            {
                return _entity.Data;
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
