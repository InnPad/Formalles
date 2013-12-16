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

    public class Unit : DataType, IDictionary, IDocument, IEntry, IFileSystem, ISegment
    {
        private static readonly object _lock = new object();
        private static Model _model;
        
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

        private IDictionary _internal;
        private IDocument _document;

        internal Unit(IDocument document)
        {
            _document = document;
        }

        private IDictionary InternalDictionary
        {
            get { return _internal ?? (_internal = (_document.Content as IDictionary) ?? new Dictionary(GetModel())); }
        }

        public double Factor
        {
            get;
            set;
        }

        #region - ICollection -

        void ICollection<KeyValuePair<string, IEntry>>.Add(KeyValuePair<string, IEntry> item)
        {
            InternalDictionary.Add(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.Clear()
        {
            InternalDictionary.Clear();
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Contains(KeyValuePair<string, IEntry> item)
        {
            return InternalDictionary.Contains(item);
        }

        void ICollection<KeyValuePair<string, IEntry>>.CopyTo(KeyValuePair<string, IEntry>[] array, int arrayIndex)
        {
            InternalDictionary.CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<string, IEntry>>.Count
        {
            get { return InternalDictionary.Count; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.IsReadOnly
        {
            get { return InternalDictionary.IsReadOnly; }
        }

        bool ICollection<KeyValuePair<string, IEntry>>.Remove(KeyValuePair<string, IEntry> item)
        {
            return InternalDictionary.Remove(item);
        }

        #endregion - ICollection -

        #region - IDictionary -

        Model IDictionary.Model
        {
            get { return GetModel(); }
        }

        T IDictionary.Value<T>(string name)
        {
            return InternalDictionary.Value<T>(name);
        }

        void IDictionary<string, IEntry>.Add(string key, IEntry value)
        {
            InternalDictionary.Add(key, value);
        }

        bool IDictionary<string, IEntry>.ContainsKey(string key)
        {
            return InternalDictionary.ContainsKey(key);
        }

        ICollection<string> IDictionary<string, IEntry>.Keys
        {
            get { return InternalDictionary.Keys; }
        }

        bool IDictionary<string, IEntry>.Remove(string key)
        {
            return InternalDictionary.Remove(key);
        }

        bool IDictionary<string, IEntry>.TryGetValue(string key, out IEntry value)
        {
            return InternalDictionary.TryGetValue(key, out value);
        }

        ICollection<IEntry> IDictionary<string, IEntry>.Values
        {
            get { return InternalDictionary.Values; }
        }

        IEntry IDictionary<string, IEntry>.this[string key]
        {
            get { return InternalDictionary[key]; }
            set { InternalDictionary[key] = value; }
        }

        #endregion - IDictionary -

        #region - IDocument -

        object IDocument.Content
        {
            get { return InternalDictionary; }
        }

        Guid IDocument.Id
        {
            get { return _document.Id; }
        }

        string IDocument.Key
        {
            get { return _document.Key; }
        }

        Metadata IDocument.Metadata
        {
            get { return _document.Metadata; }
        }

        #endregion - IDocument -

        #region - DynamicMetaObjectProvider -

        DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return InternalDictionary.GetMetaObject(parameter);
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
            return InternalDictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        #endregion - IEnumerable -

        #region - IFileSystem -

        DateTime IFileSystem.CreationTime
        {
            get { throw new NotImplementedException(); }
        }

        string IFileSystem.FullName
        {
            get { return this.Name; }
        }

        DateTime IFileSystem.LastAccessTime
        {
            get { throw new NotImplementedException(); }
        }

        DateTime IFileSystem.LastWriteTime
        {
            get { throw new NotImplementedException(); }
        }

        #endregion - IFileSystem -

        #region - ISegment -

        string ISegment.Name
        {
            get { return this.Name.Split('/').Last(); }
        }

        ISegment ISegment.Parent
        {
            get { return Schema.Current.ParentOf(this); }
        }

        string ISegment.Path
        {
            get { return this.Name; }
        }

        List<ISegment> ISegment.Children
        {
            get { return null; }
        }

        #endregion - ISegment -

        #region - IObject -

        DataType IObject.DataType
        {
            get { return GetModel(); }
        }

        TObject IObject.ToObject<TObject>()
        {
            return InternalDictionary.ToObject<TObject>();
        }

        void IObject.WriteJson(Stream stream)
        {
            InternalDictionary.WriteJson(stream);
        }

        void IObject.WriteJson(TextWriter writer)
        {
            InternalDictionary.WriteJson(writer);
        }

        #endregion - IObject -
    }
}
