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

    internal class Value : Entry
    {
        public static implicit operator JValue(Value value)
        {
            return value != null ? value._value : null;
        }

        private readonly JValue _value;
        private readonly Prototype _prototype;

        public Value(JProperty property, Prototype prototype)
            : base(property)
        {
            _prototype = prototype;
            _value = property.Value as JValue;
        }

        public override JToken Token
        {
            get { return _value; }
        }

        public override EntryType Type
        {
            get
            {
                switch (_value.Type)
                {
                    case JTokenType.Boolean:
                        return EntryType.Boolean;

                    case JTokenType.Bytes:
                        return EntryType.Binary;

                    case JTokenType.Comment:
                        return EntryType.Comment;

                    case JTokenType.Constructor:
                        return EntryType.Constructor;

                    case JTokenType.Date:
                        return EntryType.Date;

                    case JTokenType.Float:
                        return EntryType.Decimal;

                    case JTokenType.Guid:
                        return EntryType.Double;

                    case JTokenType.Integer:
                        return EntryType.Integer;

                    case JTokenType.None:
                        return EntryType.None;

                    case JTokenType.Null:
                        return EntryType.Null;

                    case JTokenType.Object:
                        return EntryType.Object;

                    case JTokenType.Raw:
                        return EntryType.Raw;

                    case JTokenType.String:
                        return EntryType.String;

                    case JTokenType.TimeSpan:
                        return EntryType.TimeSpan;

                    case JTokenType.Undefined:
                        return EntryType.Undefined;

                    case JTokenType.Uri:
                        return EntryType.Uri;
                }
                return EntryType.Undefined;
            }
        }

        #region - IObject -

        public Prototype Prototype
        {
            get { return _prototype; }
        }

        /*TObject IObject.ToObject<TObject>()
        {
            return _value.ToObject<TObject>();
        }*/

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
                _value.WriteTo(jsonWriter);
            }
        }

        #endregion - IObject -
    }
}
