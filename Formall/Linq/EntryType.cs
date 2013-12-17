using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    public class EntryType : IEquatable<EntryType>
    {
        public static implicit operator int(EntryType type)
        {
            return type != null ? type._name.GetHashCode() : 0;
        }

        public static implicit operator string(EntryType type)
        {
            return type != null ? type._name : null;
        }

        public static readonly EntryType None = new EntryType("None");

        public static readonly EntryType Binary = new EntryType("Binary");

        public static readonly EntryType Boolean = new EntryType("Boolean");

        public static readonly EntryType Byte = new EntryType("Byte");

        public static readonly EntryType Collection = new EntryType("Collection");

        public static readonly EntryType Comment = new EntryType("Comment");

        public static readonly EntryType Constructor = new EntryType("Constructor");

        public static readonly EntryType Date = new EntryType("Date");

        public static readonly EntryType Decimal = new EntryType("Decimal");

        public static readonly EntryType Double = new EntryType("Double");

        public static readonly EntryType Function = new EntryType("Function");

        public static readonly EntryType Guid = new EntryType("Guid");

        public static readonly EntryType Int16 = new EntryType("Int16");

        public static readonly EntryType Int32 = new EntryType("Int32");

        public static readonly EntryType Int64 = new EntryType("Int64");

        public static readonly EntryType Integer = new EntryType("Integer");

        public static readonly EntryType List = new EntryType("List");

        public static readonly EntryType Money = new EntryType("Money");

        public static readonly EntryType Null = new EntryType("Null");

        public static readonly EntryType Number = new EntryType("Number");

        public static readonly EntryType Object = new EntryType("Object");

        public static readonly EntryType Property = new EntryType("Property");

        public static readonly EntryType Raw = new EntryType("Raw");

        public static readonly EntryType RegEx = new EntryType("RegEx");

        public static readonly EntryType SByte = new EntryType("SByte");

        public static readonly EntryType Single = new EntryType("Single");

        public static readonly EntryType String = new EntryType("String");

        public static readonly EntryType TimeSpan = new EntryType("TimeSpan");

        public static readonly EntryType Undefined = new EntryType("Undefined");

        public static readonly EntryType UInt16 = new EntryType("UInt16");
        
        public static readonly EntryType UInt32 = new EntryType("UInt32");

        public static readonly EntryType UInt64 = new EntryType("UInt64");

        public static readonly EntryType Unit = new EntryType("Unit");

        public static readonly EntryType Uri = new EntryType("Uri");

        private string _name;

        private EntryType(string name)
        {
            _name = name;
        }
    
        public override string ToString()
        {
            return _name;
        }

        bool IEquatable<EntryType>.Equals(EntryType other)
        {
            return (other != null && (object.Equals(this, other) || this._name == other._name));
        }
    }
}
