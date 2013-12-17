using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Navigation;
    using Formall.Reflection;

    public class Dictionary : IDictionary
    {
        private readonly IDictionary<string, IEntry> _internal;
        private readonly Model _model;

        public Dictionary(Model model, IDictionary<string, IEntry> source = null)
        {
            _model = model;
            _internal = source ?? new Dictionary<string, IEntry>();
        }

        protected virtual IEntry CreateEntry(string name)
        {
            var field = _model.Fields.FirstOrDefault(o => o.Name == name) ?? _model.Fields.FirstOrDefault(o => string.Equals(o.Name, name, StringComparison.OrdinalIgnoreCase));

            return new Entry(field);
        }

        protected virtual object GetDefaultValue(string key)
        {
            return null;
        }

        private object GetValue(string key)
        {
            IEntry entry;

            if (_internal.TryGetValue(key, out entry))
            {
                return entry.Value;
            }

            return GetDefaultValue(key);
        }

        public object SetValue(string key, object value)
        {
            IEntry entry;
            if (!_internal.TryGetValue(key, out entry))
            {
                entry = CreateEntry(key);
                _internal.Add(key, entry);
            }

            entry.Value = value;

            return entry;
        }

        public override string ToString()
        {
            var message = new StringWriter();
            foreach (var item in _internal)
                message.WriteLine("{0}:\t{1}", item.Key, item.Value);
            return message.ToString();
        }

        public object WriteMethodInfo(string methodInfo)
        {
            Console.WriteLine(methodInfo);
            return 42; // because it is the answer to everything
        }

        #region  - IDictionary -

        public Model Model
        {
            get { return _model; }
        }

        public void Add(string key, IEntry value)
        {
            _internal.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _internal.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return _internal.Keys; }
        }

        public bool Remove(string key)
        {
            return _internal.Remove(key);
        }

        public bool TryGetValue(string key, out IEntry value)
        {
            return TryGetValue(key, out value);
        }

        public ICollection<IEntry> Values
        {
            get { return _internal.Values; }
        }

        public IEntry this[string key]
        {
            get
            {
                var dictionary = _internal as IDictionary;

                if (dictionary != null)
                {
                    return dictionary[key];
                }

                IEntry entry;
                if (_internal.TryGetValue(key, out entry))
                    return entry;

                entry = CreateEntry(key);

                _internal.Add(key, entry);

                return entry;
            }
            set
            {
                _internal[key] = value;
            }
        }

        #endregion  - IDictionary -

        #region - ICollection -

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            (_internal as ICollection<KeyValuePair<string, IEntry>>).Add(item);
        }

        public void Clear()
        {
            (_internal as ICollection<KeyValuePair<string, IEntry>>).Clear();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            return (_internal as ICollection<KeyValuePair<string, IEntry>>).Contains(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            (_internal as ICollection<KeyValuePair<string, IEntry>>).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _internal.Count; }
        }

        public bool IsReadOnly
        {
            get { return (_internal as ICollection<KeyValuePair<string, IEntry>>).IsReadOnly; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Remove(KeyValuePair<string, IEntry> item)
        {
            return (_internal as ICollection<KeyValuePair<string, IEntry>>).Remove(item);
        }

        #endregion - ICollection -

        #region - IEnumerable -

        IEnumerator<KeyValuePair<string, IEntry>> IEnumerable<KeyValuePair<string, IEntry>>.GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _internal.GetEnumerator();
        }

        #endregion - IEnumerable -

        #region  - IDynamicMetaObjectProvider -

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, this);
        }

        #endregion  - IDynamicMetaObjectProvider -

        #region - IObject -

        Prototype IObject.Prototype
        {
            get { return _model; }
        }

        public TObject ToObject<TObject>()
        {
            throw new NotImplementedException();
        }

        public void WriteJson(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void WriteJson(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion - IObject -

        #region = MetaObject =

        private class MetaObject : System.Dynamic.DynamicMetaObject
        {
            private readonly Dictionary _dictionary;

            public MetaObject(Expression expression, Dictionary value)
                : base(expression, BindingRestrictions.Empty, value)
            {
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                // Method call in the containing class:
                string methodName = "GetValue";

                // One parameter
                Expression[] parameters = new Expression[]
                {
                    Expression.Constant(binder.Name)
                };

                DynamicMetaObject getValue = new DynamicMetaObject(
                    Expression.Call(
                        Expression.Convert(Expression, LimitType),
                        typeof(Dictionary).GetMethod(methodName),
                        parameters),
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                return getValue;
            }

            public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
            {
                var paramInfo = new StringBuilder();
                paramInfo.AppendFormat("Calling {0}(", binder.Name);
                foreach (var item in args)
                    paramInfo.AppendFormat("{0}, ", item.Value);
                paramInfo.Append(")");

                var parameters = new Expression[]
                {
                    Expression.Constant(paramInfo.ToString())
                };

                DynamicMetaObject methodInfo = new DynamicMetaObject(
                    Expression.Call(
                    Expression.Convert(Expression, LimitType),
                    typeof(Dictionary).GetMethod("WriteMethodInfo"),
                    parameters),
                    BindingRestrictions.GetTypeRestriction(Expression, LimitType));
                return methodInfo;
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                // Method to call in the containing class:
                string methodName = "SetValue";

                // setup the binding restrictions.
                var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);

                // setup the parameters:
                var args = new Expression[2];
                // First parameter is the name of the property to Set
                args[0] = Expression.Constant(binder.Name);
                // Second parameter is the value
                args[1] = Expression.Convert(value.Expression, typeof(object));

                // Setup the 'this' reference
                var self = Expression.Convert(Expression, LimitType);

                // Setup the method call expression
                var methodCall = Expression.Call(self, typeof(Dictionary).GetMethod(methodName), args);

                // Create a meta object to invoke Set later:
                var setValue = new DynamicMetaObject(methodCall, restrictions);

                // return that dynamic object
                return setValue;
            }
        }

        #endregion = MetaObject =
    }
}
