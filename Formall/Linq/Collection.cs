using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Reflection;

    public class Collection<T> : Dictionary, IDictionary<string, T>, ICollection<T>, IEnumerable<T>
        where T : class
    {
        private readonly Func<T, string> _keyGetter;

        public Collection(IDictionary source, Func<T, string> keyGetter)
            : base(source)
        {
            _keyGetter = keyGetter;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        #region - IDictionary<string, T> -

        void IDictionary<string, T>.Add(string key, T value)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, T>.TryGetValue(string key, out T value)
        {
            throw new NotImplementedException();
        }

        ICollection<T> IDictionary<string, T>.Values
        {
            get { throw new NotImplementedException(); }
        }

        public new T this[string key]
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

        #endregion - IDictionary<string, T> -

        #region - ICollection<KeyValuePair<string, T>> -

        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
        {
            throw new NotImplementedException();
        }

        #endregion - ICollection<KeyValuePair<string, T>> -

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
