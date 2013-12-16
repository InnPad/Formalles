using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Linq;
    using Formall.Persistence;
    using Formall.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;
    
    internal class Dictionary : IDictionary
    {
        public static implicit operator JObject(Dictionary value)
        {
            return value != null ? value._object : null;
        }

        private readonly JObject _object;
        private readonly Model _model;

        public Dictionary(JObject json, Model model)
        {
            _object = json;
            _model = model;
        }

        #region - ICollection -

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            _object.Add(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.Clear()
        {
            //_document.Clear();
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            //return _document.Contains(item);
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            //_document.CopyTo(array, arrayIndex);
            throw new NotImplementedException();
        }

        int ICollection<KeyValuePair<string, IEntry>>.Count
        {
            get { return _object.Count; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Remove(KeyValuePair<string, IEntry> item)
        {
            //return _document.Remove(item);
            throw new NotImplementedException();
        }

        #endregion - ICollection -

        #region - IDictionary -

        Model IDictionary.Model
        {
            get { return _model; }
        }

        T IDictionary.Value<T>(string name)
        {
            return _object.Value<T>(name);
        }

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
            //_object.Add(key, value);
            throw new NotImplementedException();
        }

        bool IDictionary<string, IEntry>.ContainsKey(string key)
        {
            //return _object.ContainsKey(key);
            throw new NotImplementedException();
        }

        ICollection<string> IDictionary<string, IEntry>.Keys
        {
            get { return Array.AsReadOnly(_object.Properties().Select(o => o.Name).ToArray()); }
        }

        bool IDictionary<string, IEntry>.Remove(string key)
        {
            return _object.Remove(key);
        }

        bool IDictionary<string, IEntry>.TryGetValue(string key, out IEntry value)
        {
            //return _object.TryGetValue(key, out value);
            throw new NotImplementedException();
        }

        ICollection<IEntry> IDictionary<string, IEntry>.Values
        {
            get { return Array.AsReadOnly(_object.Properties().Select(o => (IEntry)null/*o.Value*/).ToArray()); }
        }

        IEntry IDictionary<string, IEntry>.this[string key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion - IDictionary -

        #region - DynamicMetaObjectProvider -

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return (_object as IDynamicMetaObjectProvider).GetMetaObject(parameter);
        }

        #endregion - DynamicMetaObjectProvider -

        #region - IEnumerable -

        IEnumerator<KeyValuePair<string, IEntry>> IEnumerable<KeyValuePair<string, IEntry>>.GetEnumerator()
        {
            return _object.Properties().Select(o => new KeyValuePair<string, IEntry>(o.Name, (IEntry)null/*o.Value*/)).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _object.GetEnumerator();
        }

        #endregion - IEnumerable -

        #region - IObject -

        public DataType DataType
        {
            get { return _model; }
        }

        TObject IObject.ToObject<TObject>()
        {
            return _object.ToObject<TObject>();
        }

        /// <summary>
        /// Writes this in JSON format to a System.IO.Stream.
        /// </summary>
        /// <param name="stream">A System.IO.Stream into which this method will write.</param>
        public void WriteJson(Stream stream)
        {
            using (var streamWriter = new StreamWriter(stream))
            {
                WriteJson(streamWriter);
            }
        }

        /// <summary>
        /// Writes this in JSON format to a System.IO.TextWriter.
        /// </summary>
        /// <param name="writer">A System.IO.TextWriter into which this method will write.</param>
        public virtual void WriteJson(TextWriter writer)
        {
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                _object.WriteTo(jsonWriter);
            }
        }

        #endregion - IObject -
    }
}
