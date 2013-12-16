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
    using Formall.Reflection;
    
    internal class Dictionary : IDictionary
    {
        private readonly Dictionary<string, IEntry> _internal;
        private readonly Model _model;

        public Dictionary(Model model)
        {
            _model = model;
            _internal = new Dictionary<string, IEntry>();
        }

        #region  - IDictionary -

        public Model Model
        {
            get { return _model; }
        }

        T IDictionary.Value<T>(string name)
        {
            IEntry value;
            if (_internal.TryGetValue(name, out value) && value is T)
                return (T)value;
            return default(T);
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
                return _internal[key];
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
            throw new NotImplementedException();
        }

        #endregion  - IDynamicMetaObjectProvider -

        #region - IObject -

        DataType IObject.DataType
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
    }
}
