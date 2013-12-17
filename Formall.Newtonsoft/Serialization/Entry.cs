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
    
    internal abstract class Entry : IEntry
    {
        #region - operators -
        /*
        [CLSCompliant(false)]
        public static explicit operator sbyte?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Boolean.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator bool(Token value)
        {
        }

        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.DateTimeOffset.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator DateTimeOffset(JToken value);
        public static explicit operator bool?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Int64.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator long(JToken value);
        public static explicit operator DateTime?(JToken value);
        public static explicit operator DateTimeOffset?(JToken value);
        public static explicit operator decimal?(JToken value);
        public static explicit operator double?(JToken value);
        public static explicit operator char?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Int32.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator int(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Int16.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator short(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.UInt16.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        [CLSCompliant(false)]
        public static explicit operator ushort(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Char.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        [CLSCompliant(false)]
        public static explicit operator char(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Byte.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator byte(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.SByte.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        [CLSCompliant(false)]
        public static explicit operator sbyte(JToken value);
        public static explicit operator int?(JToken value);
        public static explicit operator short?(JToken value);
        [CLSCompliant(false)]
        public static explicit operator ushort?(JToken value);
        public static explicit operator byte?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.DateTime.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator DateTime(JToken value);
        public static explicit operator long?(JToken value);
        public static explicit operator float?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Decimal.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator decimal(JToken value);
        [CLSCompliant(false)]
        public static explicit operator uint?(JToken value);
        [CLSCompliant(false)]
        public static explicit operator ulong?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Double.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator double(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Single.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator float(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.String.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator string(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.UInt32.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        [CLSCompliant(false)]
        public static explicit operator uint(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.UInt64.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        [CLSCompliant(false)]
        public static explicit operator ulong(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Byte[].
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator byte[](JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Guid.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator Guid(JToken value);
        public static explicit operator Guid?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.TimeSpan.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator TimeSpan(JToken value);
        public static explicit operator TimeSpan?(JToken value);
        //
        // Summary:
        //     Performs an explicit conversion from Newtonsoft.Json.Linq.JToken to System.Uri.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The result of the conversion.
        public static explicit operator Uri(JToken value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Boolean to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(bool value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(bool? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Byte to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(byte value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(byte? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Byte[] to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(byte[] value);
        //
        // Summary:
        //     Performs an implicit conversion from System.DateTime to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(DateTime value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(DateTime? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.DateTimeOffset to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(DateTimeOffset value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(DateTimeOffset? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Decimal to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(decimal value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(decimal? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Double to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(double value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(double? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Single to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(float value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(float? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Guid to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(Guid value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(Guid? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Int32 to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(int value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(int? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(long value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(long? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.SByte to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(sbyte value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(sbyte? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Int16 to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(short value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(short? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.String to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(string value);
        //
        // Summary:
        //     Performs an implicit conversion from System.TimeSpan to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(TimeSpan value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(TimeSpan? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.UInt32 to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(uint value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(uint? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.UInt64 to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(ulong value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(ulong? value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Uri to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        public static implicit operator JToken(Uri value);
        //
        // Summary:
        //     Performs an implicit conversion from System.UInt16 to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(ushort value);
        //
        // Summary:
        //     Performs an implicit conversion from System.Nullable<T> to Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   value:
        //     The value to create a Newtonsoft.Json.Linq.JValue from.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JValue initialized with the specified value.
        [CLSCompliant(false)]
        public static implicit operator JToken(ushort? value);
        */
        #endregion - operators -

        public static implicit operator JToken(Entry token)
        {
            return token != null ? token.Token : null;
        }

        public static implicit operator Entry(JToken json)
        {
            if (json == null)
            {
                return null;
            }

            switch (json.Type)
            {
                case JTokenType.Array:
                    return (Collection)(json as JArray);

                case JTokenType.Boolean:
                    return (Value)(json as JValue);

                case JTokenType.Bytes:
                    return (Value)(json as JValue);

                case JTokenType.Comment:
                    return (Value)(json as JValue);

                case JTokenType.Constructor:
                    return (Value)(json as JValue);

                case JTokenType.Date:
                    return (Value)(json as JValue);

                case JTokenType.Float:
                    return (Value)(json as JValue);

                case JTokenType.Guid:
                    return (Value)(json as JValue);

                case JTokenType.Integer:
                    return (Value)(json as JValue);

                case JTokenType.None:
                    return (Value)(json as JValue);

                case JTokenType.Null:
                    return (Value)(json as JValue);
                    /*
                case JTokenType.Object:
                    return (Dictionary)(json as JObject);

                case JTokenType.Property:
                    return (Property)(json as JProperty);

                case JTokenType.Raw:
                    return (Raw)(json as JRaw);
                    */
                case JTokenType.String:
                    return (Value)(json as JValue);

                case JTokenType.TimeSpan:
                    return (Value)(json as JValue);

                case JTokenType.Undefined:
                    return (Value)(json as JValue);

                case JTokenType.Uri:
                    return (Value)(json as JValue);
            }

            return null;
        }


        private readonly JProperty _property;

        protected Entry(JProperty property)
        {
            _property = property;
        }

        public abstract JToken Token { get; }

        public abstract EntryType Type { get; }

        #region - IEntry -

        public string Name
        {
            get { return _property.Name; }
        }

        public string Path
        {
            get { return _property.Path; }
        }

        EntryType IEntry.Type
        {
            get { return this.Type; }
        }

        #endregion - IEntry -

        string IEntry.Name
        {
            get { throw new NotImplementedException(); }
        }

        string IEntry.Path
        {
            get { throw new NotImplementedException(); }
        }

        object IEntry.Value
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
    }
}
