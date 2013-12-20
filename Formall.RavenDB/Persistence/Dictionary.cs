using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;
    using Raven.Imports.Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Serialization;
    using Raven.Json.Linq;

    internal class Dictionary : IDictionary
    {
        private readonly RavenJObject _object;
        private readonly Model _model;

        public Dictionary(RavenJObject obj, Model model)
        {
            _object = obj;
            _model = model;
        }

        #region - IDictionary -

        Model IDictionary.Model
        {
            get { throw new NotImplementedException(); }
        }

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
            _object.Add(key, RavenDocumentContext.Import(value));
        }

        bool IDictionary<string, IEntry>.ContainsKey(string key)
        {
            return _object.ContainsKey(key);
        }

        bool IDictionary<string, IEntry>.Remove(string key)
        {
            return _object.Remove(key);
        }

        bool IDictionary<string, IEntry>.TryGetValue(string key, out IEntry value)
        {
            RavenJToken token;
            if (_object.TryGetValue(key, out token))
            {
                value = (Entry)token;
                return value != null;
            }
            value = null;
            return false;
        }

        ICollection<string> IDictionary<string, IEntry>.Keys
        {
            get { return _object.Keys; }
        }

        ICollection<IEntry> IDictionary<string, IEntry>.Values
        {
            get { return _object.Values().Select(o => (Entry)o).OfType<IEntry>().ToList(); }
        }

        IEntry IDictionary<string, IEntry>.this[string key]
        {
            get
            {
                return (Entry)_object[key];
            }
            set
            {
                _object[key] = RavenDocumentContext.Import(value);
            }
        }

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            _object.Add(item.Key, RavenDocumentContext.Import(item.Value));
        }

        void ICollection<KeyValuePair<string, IEntry>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            RavenJToken token;
            return _object.TryGetValue(item.Key, out token) && RavenDocumentContext.Import(item.Value) == token;
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
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
            RavenJToken token;
            if (_object.TryGetValue(item.Key, out token) && token == RavenDocumentContext.Import(item.Value))
                return _object.Remove(item.Key);
            return false;
        }

        IEnumerator<KeyValuePair<string, IEntry>> IEnumerable<KeyValuePair<string, IEntry>>.GetEnumerator()
        {
            return _object.Select(o => new KeyValuePair<string, IEntry>(o.Key, (Entry)o.Value)).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _object.Select(o => (Entry)o.Value).GetEnumerator();
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return (_object as IDynamicMetaObjectProvider).GetMetaObject(parameter);
        }

        Prototype IObject.Prototype
        {
            get { return _model; }
        }

        TObject IObject.ToObject<TObject>()
        {   
            return ToObject<TObject>(new JsonConverter[0]);
        }

        public TObject ToObject<TObject>(JsonConverter[] converters)
        {
            var jsonSerializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                ContractResolver = /*new CamelCasePropertyNamesContractResolver()*/ new DefaultContractResolver()
            };
            
            if (converters != null)
            {
                foreach (var converter in converters)
                {
                    jsonSerializer.Converters.Add(converter);
                }
            }
            
            return (TObject)jsonSerializer.Deserialize(new RavenJTokenReader(_object), typeof(TObject));
        }

        void IObject.WriteJson(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                WriteJson(writer);
            }
        }

        public void WriteJson(TextWriter writer)
        {
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;
                _object.WriteTo(jsonWriter);
            }
        }

        #endregion - IDictionary -


        void IObject.WriteJson(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
