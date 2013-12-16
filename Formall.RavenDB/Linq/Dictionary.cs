using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Persistence;
    using Formall.Reflection;
    using Raven.Json.Linq;

    internal class Dictionary : IDictionary
    {
        private readonly RavenJObject _object;

        public Dictionary(RavenJObject obj)
        {
            _object = obj;
        }

        public Model Model
        {
            get { throw new NotImplementedException(); }
        }

        T IDictionary.Value<T>(string name)
        {
            return _object.Value<T>(name);
        }

        public void Add(string key, IEntry value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out IEntry value)
        {
            throw new NotImplementedException();
        }

        public ICollection<IEntry> Values
        {
            get { throw new NotImplementedException(); }
        }

        public IEntry this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<string, IEntry> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, IEntry>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public System.Dynamic.DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)
        {
            throw new NotImplementedException();
        }

        public DataType DataType
        {
            get { throw new NotImplementedException(); }
        }

        public TObject ToObject<TObject>()
        {
            throw new NotImplementedException();
        }

        public void WriteJson(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        public void WriteJson(System.IO.TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
