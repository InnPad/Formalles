using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Reflection;
    using Formall.Navigation;

    internal class Entry : IEntry
    {
        private readonly Field _field;
        private object _value;
        private EntryType _entryType;
        private Prototype _dataType;

        public Entry(Field field)
        {
            _entryType = EntryType.Undefined;

            var typeName = field.Type;
            var typeDocument = Schema.Current.Read(typeName);
            var typeMetadata = typeDocument.Metadata;
        }

        public Field Field
        {
            get { return _field; }
        }

        public string Name
        {
            get { return _field.Name; }
        }

        public string Path
        {
            get { return (_field.Model as ISegment).Path; }
        }

        public EntryType Type
        {
            get { return _entryType; }
        }

        public object Value
        {
            get { return _value; }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
