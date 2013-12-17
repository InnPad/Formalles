using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;

    public class Model : Prototype//, IRepository
    {
        private static readonly object _lock = new object();
        private static Model _model;
        
        private IDocument _document;
        private IList<Action> _actions;
        private IList<Field> _fields;

        internal Model(IDocument document, ISegment parent)
            : base(document, parent)
        {
            _document = document;
        }

        private IDataContext DataContext
        {
            get { throw new NotFiniteNumberException(); }
        }

        public IList<Action> Actions
        {
            get { return _actions ?? (_actions = new List<Action>()); }
            set { _actions = value; }
        }

        public IList<Field> Fields
        {
            get { return _fields ?? (_fields = new List<Field>()); }
            set { _fields = value; }
        }

        public string Store
        {
            get;
            set;
        }

        protected override Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = new Model(null, null));
                    throw new NotImplementedException();
                }
            }

            return model;
        }
    }
}
