using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    internal static class EntryTypeExtensions
    {
        public static EntryType ToEntryType(this JTokenType type)
        {
            switch (type)
            {
                case JTokenType.None:
                    return EntryType.None;
                case JTokenType.Object:
                    return EntryType.Object;
                case JTokenType.Array:
                    return EntryType.List;
                case JTokenType.Constructor:
                    return EntryType.Constructor;
                case JTokenType.Property:
                    return EntryType.Property;
                case JTokenType.Comment:
                    return EntryType.Comment;
                case JTokenType.Integer:
                    return EntryType.Integer;
                case JTokenType.Float:
                    return EntryType.Decimal;
                case JTokenType.String:
                    return EntryType.String;
                case JTokenType.Boolean:
                    return EntryType.Boolean;
                case JTokenType.Null:
                    return EntryType.Null;
                case JTokenType.Undefined:
                    return EntryType.Undefined;
                case JTokenType.Date:
                    return EntryType.Date;
                case JTokenType.Raw:
                    return EntryType.Raw;
                case JTokenType.Bytes:
                    return EntryType.Binary;
                case JTokenType.Guid:
                    return EntryType.Guid;
                case JTokenType.Uri:
                    return EntryType.Uri;
                case JTokenType.TimeSpan:
                    return EntryType.TimeSpan;
            }
            return EntryType.None;
        }
    }
}
