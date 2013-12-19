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

    public class Model : Prototype
    {
        private Collection<Action> _actions;
        private Collection<Field> _fields;

        public Collection<Action> Actions
        {
            get { return _actions ?? (_actions = new Collection<Action>(null, (action) => { return action.Name; })); }
        }

        public Collection<Field> Fields
        {
            get { return _fields ?? (_fields = new Collection<Field>(null, (field) => { return field.Name; })); }
        }

        public string Store
        {
            get;
            set;
        }
    }
}
