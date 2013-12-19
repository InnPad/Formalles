
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Linq;
    using Formall.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class Collection : Entry, ICollection, IObject
    {
        public static implicit operator JArray(Collection value)
        {
            return value != null ? value._array : null;
        }

        private readonly JArray _array;
        private readonly Prototype _dataType;
        private readonly System.Collections.Generic.List<Entry> _items;

        public Collection(JProperty property, JArray array, Prototype dataType)
            : base(property)
        {
            _array = array;
            _dataType = dataType;
            _items = new System.Collections.Generic.List<Entry>();
        }

        public override JToken Token
        {
            get { throw new NotImplementedException(); }
        }

        public override EntryType Type
        {
            get { throw new NotImplementedException(); }
        }

        public XElement ToXElement()
        {
            throw new NotImplementedException();
        }

        #region - ICollection -

        IList<T> ICollection.MakeGeneric<T>()
        {
            throw new NotImplementedException();
        }

        TObject[] ICollection.ToArray<TObject>()
        {
            return _array.Values<TObject>().ToArray();
        }

        XElement ICollection.ToXElement()
        {
            return ToXElement();
        }

        void ICollection<IEntry>.Add(IEntry item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IEntry>.Clear()
        {
            _array.Clear();
        }

        bool ICollection<IEntry>.Contains(IEntry item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IEntry>.CopyTo(IEntry[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<IEntry>.Count
        {
            get { return _array.Count; }
        }

        bool ICollection<IEntry>.IsReadOnly
        {
            get { return _array.IsReadOnly; }
        }

        bool ICollection<IEntry>.Remove(IEntry item)
        {
            throw new NotImplementedException();
        }

        #endregion - ICollection -

        #region - IEnumerable -

        IEnumerator<IEntry> IEnumerable<IEntry>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable -

        #region - IList -

        int IList<IEntry>.IndexOf(IEntry item)
        {
            throw new NotImplementedException();
        }

        void IList<IEntry>.Insert(int index, IEntry item)
        {
            throw new NotImplementedException();
        }

        void IList<IEntry>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEntry IList<IEntry>.this[int index]
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

        #endregion - IList -

        #region - IObject -

        public Prototype Prototype
        {
            get { return _dataType; }
        }

        TObject IObject.ToObject<TObject>()
        {
            return _array.ToObject<TObject>();
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
                Token.WriteTo(jsonWriter);
            }
        }

        #endregion - IObject -
    }
}
