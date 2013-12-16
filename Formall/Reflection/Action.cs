using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Formall.Reflection
{
    using Formall.Linq;

    public class Action : IDictionary, IEntry
    {
        private static readonly object _lock = new object();
        private static Model _model;
        private IDictionary _dictionary;

        private static Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = new Model(null));
                    throw new NotImplementedException();
                }
            }

            return model;
        }

        internal Action(IDictionary dictionary)
        {
            _dictionary = dictionary;
        }

        public string Name
        {
            get;
            set;
        }

        public XElement ToXElement()
        {
            throw new NotImplementedException();
        }

        #region - ICollection -

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            _dictionary.Add(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.Clear()
        {
            _dictionary.Clear();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            return _dictionary.Contains(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<string, IEntry>>.Count
        {
            get { return _dictionary.Count; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.IsReadOnly
        {
            get { return _dictionary.IsReadOnly; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Remove(KeyValuePair<string, IEntry> item)
        {
            return _dictionary.Remove(item);
        }

        #endregion - ICollection -

        #region - IDictionary -

        Model IDictionary.Model
        {
            get { return GetModel(); }
        }

        T IDictionary.Value<T>(string name)
        {
            return _dictionary.Value<T>(name);
        }

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
            _dictionary.Add(key, value);
        }

        bool IDictionary<string, IEntry>.ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        ICollection<string> IDictionary<string, IEntry>.Keys
        {
            get { return _dictionary.Keys; }
        }

        bool IDictionary<string, IEntry>.Remove(string key)
        {
            return _dictionary.Remove(key);
        }

        bool IDictionary<string, IEntry>.TryGetValue(string key, out IEntry value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        ICollection<IEntry> IDictionary<string, IEntry>.Values
        {
            get { return _dictionary.Values; }
        }

        IEntry IDictionary<string, IEntry>.this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary[key] = value; }
        }

        #endregion - IDictionary -

        #region - DynamicMetaObjectProvider -

        DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return _dictionary.GetMetaObject(parameter);
        }

        #endregion - DynamicMetaObjectProvider -

        #region - IEntry -

        string IEntry.Name
        {
            get { return this.Name.Split('/').Last(); }
        }

        string IEntry.Path
        {
            get { return this.Name; }
        }

        EntryType IEntry.Type
        {
            get { return EntryType.Object; }
        }

        #endregion - IEntry -

        #region - IEnumerable -

        IEnumerator<KeyValuePair<string, IEntry>> IEnumerable<KeyValuePair<string, IEntry>>.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion - IEnumerable -

        #region - IObject -

        DataType IObject.DataType
        {
            get { return GetModel(); }
        }

        TObject IObject.ToObject<TObject>()
        {
            return _dictionary.ToObject<TObject>();
        }

        void IObject.WriteJson(Stream stream)
        {
            _dictionary.WriteJson(stream);
        }

        void IObject.WriteJson(TextWriter writer)
        {
            _dictionary.WriteJson(writer);
        }

        #endregion - IObject -
    }
}
