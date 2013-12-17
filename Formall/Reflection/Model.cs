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
        
        private Collection<Action> _actions;
        private Collection<Field> _fields;

        internal Model(IEntity entity, ISegment parent)
            : base(entity, parent)
        {
        }

        private IDataContext DataContext
        {
            get { throw new NotFiniteNumberException(); }
        }

        public Collection<Action> Actions
        {
            get { return _actions ?? (_actions = new Collection<Action>(Data["Actions"].Value as IDictionary, (action) => { return action.Name; })); }
        }

        public Collection<Field> Fields
        {
            get { return _fields ?? (_fields = new Collection<Field>(Data["Fields"].Value as IDictionary, (field) => { return field.Name; })); }
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
