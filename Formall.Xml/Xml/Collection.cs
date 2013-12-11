using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Formall.Xml
{
    internal class Collection : Entry, ICollection
    {
        public static implicit operator XElement(Collection collection)
        {
            return collection != null ? collection._element : null;
        }

        private readonly XElement _element;
        private readonly DataType _type;

        public Collection(XElement element, DataType type)
        {
            _element = element;
            _type = type;
        }

        public Collection(XElement element, DataType type, ICollection collection)
            : this(element, type)
        {
            // deep copy document in _document
        }

        public Collection(XElement element, ICollection collection)
            : this(element, collection.Type, collection)
        {
        }

        public override DataType Type
        {
            get { return _type; }
        }

        #region - ICollection -

        void ICollection<IEntry>.Add(IEntry item)
        {
            throw new NotImplementedException();
        }

        void ICollection<IEntry>.Clear()
        {
            throw new NotImplementedException();
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
            get { throw new NotImplementedException(); }
        }

        bool ICollection<IEntry>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<IEntry>.Remove(IEntry item)
        {
            throw new NotImplementedException();
        }

        #endregion - ICollection -

        #region - IEntry -

        #endregion - IEntry -

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

        #region - IValidatable -

        IEnumerable<ValidationResult> IValidatable.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion - IValidatable -
    }
}
