using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace Formall.Json
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq.Expressions;
    
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
            return token != null ? token.Json : null;
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

                case JTokenType.Object:
                    return (Dictionary)(json as JObject);

                case JTokenType.Property:
                    return (Property)(json as JProperty);

                case JTokenType.Raw:
                    return (Raw)(json as JRaw);

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

        protected Entry()
        {
        }

        protected abstract JToken Json { get; }

        //
        // Summary:
        //     Get the first child token of this token.
        public virtual IEntry First
        {
            get { return (Entry)Json.First; }
        }

        //
        // Summary:
        //     Gets a value indicating whether this token has child tokens.
        public bool HasValues
        {
            get { return Json.HasValues; }
        }

        //
        // Summary:
        //     Get the last child token of this token.
        public IEntry Last
        {
            get { return (Entry)Json.Last; }
        }

        //
        // Summary:
        //     Gets the next sibling token of this node.
        public IEntry Next
        {
            get { return (Entry)Json.Next; }
        }

        //
        // Summary:
        //     Gets or sets the parent.
        public JContainer Parent
        {
            get { return Json.Parent; }
        }

        //
        // Summary:
        //     Gets the path of the JSON token.
        public string Path
        {
            get { return Json.Path; }
        }

        //
        // Summary:
        //     Gets the previous sibling token of this node.
        public IEntry Previous
        {
            get { return (Entry)Json.Previous; }
        }

        //
        // Summary:
        //     Gets the root Newtonsoft.Json.Linq.JToken of this Newtonsoft.Json.Linq.JToken.
        public IEntry Root
        {
            get { return (Entry)Json.Root; }
        }

        //
        // Summary:
        //     Gets the node type for this Newtonsoft.Json.Linq.JToken.
        public JTokenType Type
        {
            get { return Json.Type; }
        }

        // Summary:
        //     Gets the Newtonsoft.Json.Linq.JToken with the specified key.
        public IEntry this[object key]
        {
            get { return (Entry)Json[key]; }
            set { Json[key] = (Entry)value; }
        }

        // Summary:
        //     Adds the specified content immediately after this token.
        //
        // Parameters:
        //   content:
        //     A content object that contains simple content or a collection of content
        //     objects to be added after this token.
        public void AddAfterSelf(object content)
        {
            Json.AddAfterSelf(content);
        }

        //
        // Summary:
        //     Adds the specified content immediately before this token.
        //
        // Parameters:
        //   content:
        //     A content object that contains simple content or a collection of content
        //     objects to be added before this token.
        public void AddBeforeSelf(object content)
        {
            Json.AddBeforeSelf(content);
        }

        //
        // Summary:
        //     Returns a collection of the sibling tokens after this token, in document
        //     order.
        //
        // Returns:
        //     A collection of the sibling tokens after this tokens, in document order.
        public IEnumerable<IEntry> AfterSelf()
        {
            return Json.AfterSelf().Select(o => (Entry)o);
        }

        //
        // Summary:
        //     Returns a collection of the ancestor tokens of this token.
        //
        // Returns:
        //     A collection of the ancestor tokens of this token.
        public IEnumerable<IEntry> Ancestors()
        {
            return Json.Ancestors().Select(o => (Entry)o);
        }

        //
        // Summary:
        //     Returns a collection of the sibling tokens before this token, in document
        //     order.
        //
        // Returns:
        //     A collection of the sibling tokens before this token, in document order.
        public IEnumerable<IEntry> BeforeSelf()
        {
            return Json.BeforeSelf().Select(o => (Entry)o);
        }

        //
        // Summary:
        //     Returns a collection of the child tokens of this token, in document order.
        //
        // Returns:
        //     An System.Collections.Generic.IEnumerable<T> of Newtonsoft.Json.Linq.JToken
        //     containing the child tokens of this Newtonsoft.Json.Linq.JToken, in document
        //     order.
        public virtual JEnumerable<JToken> Children()
        {
            return Json.Children();
        }

        //
        // Summary:
        //     Returns a collection of the child tokens of this token, in document order,
        //     filtered by the specified type.
        //
        // Type parameters:
        //   T:
        //     The type to filter the child tokens on.
        //
        // Returns:
        //     A Newtonsoft.Json.Linq.JEnumerable<T> containing the child tokens of this
        //     Newtonsoft.Json.Linq.JToken, in document order.
        public JEnumerable<T> Children<T>() where T : JToken
        {
            return Json.Children<T>();
        }

        //
        // Summary:
        //     Creates a new instance of the Newtonsoft.Json.Linq.JToken. All child tokens
        //     are recursively cloned.
        //
        // Returns:
        //     A new instance of the Newtonsoft.Json.Linq.JToken.
        public IEntry DeepClone()
        {
            return (Entry)Json.DeepClone();
        }

        //
        // Summary:
        //     Compares the values of two tokens, including the values of all descendant
        //     tokens.
        //
        // Parameters:
        //   t1:
        //     The first Newtonsoft.Json.Linq.JToken to compare.
        //
        //   t2:
        //     The second Newtonsoft.Json.Linq.JToken to compare.
        //
        // Returns:
        //     true if the tokens are equal; otherwise false.
        public static bool DeepEquals(IEntry t1, IEntry t2)
        {
            return JToken.DeepEquals((JToken)t1, (JToken)t2);
        }

        //
        // Summary:
        //     Creates a Newtonsoft.Json.Linq.JToken from an object.
        //
        // Parameters:
        //   o:
        //     The object that will be used to create Newtonsoft.Json.Linq.JToken.
        //
        // Returns:
        //     A Newtonsoft.Json.Linq.JToken with the value of the specified object
        public static IEntry FromObject(object o)
        {
            return (Entry)JToken.FromObject(o);
        }

        //
        // Summary:
        //     Creates a Newtonsoft.Json.Linq.JToken from an object using the specified
        //     Newtonsoft.Json.JsonSerializer.
        //
        // Parameters:
        //   o:
        //     The object that will be used to create Newtonsoft.Json.Linq.JToken.
        //
        //   jsonSerializer:
        //     The Newtonsoft.Json.JsonSerializer that will be used when reading the object.
        //
        // Returns:
        //     A Newtonsoft.Json.Linq.JToken with the value of the specified object
        public static JToken FromObject(object o, JsonSerializer jsonSerializer)
        {
            return (Entry)FromObject(o, jsonSerializer);
        }

        //
        // Summary:
        //     Creates a Token from a System.IO.TextReader.
        //
        // Parameters:
        //   reader:
        //     An System.IO.TextReader positioned at the token to read into this Token.
        //
        // Returns:
        //     An Token that contains the token and its descendant
        //     tokens that were read from the reader. The runtime type of the token is determined
        //     by the token type of the first token encountered in the reader.
        public static Entry Load(TextReader reader)
        {
            Entry token;

            using (var jsonReader = new JsonTextReader(reader))
            {
                token = JToken.Load(jsonReader);
            }

            return token;
        }

        //
        // Summary:
        //     Load a Newtonsoft.Json.Linq.JToken from a string that contains JSON.
        //
        // Parameters:
        //   json:
        //     A System.String that contains JSON.
        //
        // Returns:
        //     A Newtonsoft.Json.Linq.JToken populated from the string that contains JSON.
        public static Entry Parse(string json)
        {
            return JToken.Parse(json);
        }

        //
        // Summary:
        //     Creates a IToken from a Newtonsoft.Json.JsonReader.
        //
        // Parameters:
        //   reader:
        //     An Newtonsoft.Json.JsonReader positioned at the token to read into this Newtonsoft.Json.Linq.JToken.
        //
        // Returns:
        //     An Newtonsoft.Json.Linq.JToken that contains the token and its descendant
        //     tokens that were read from the reader. The runtime type of the token is determined
        //     by the token type of the first token encountered in the reader.
        public static Entry ReadFrom(TextReader reader)
        {
            Entry token;

            using (var jsonReader = new JsonTextReader(reader))
            {
                token = JToken.Load(jsonReader);
            }

            return token;
        }

        //
        // Summary:
        //     Removes this token from its parent.
        public void Remove()
        {
            Json.Remove();
        }

        //
        // Summary:
        //     Replaces this token with the specified token.
        //
        // Parameters:
        //   value:
        //     The value.
        public void Replace(IEntry value)
        {
            // TODO:
            Json.Replace((Entry)value);
        }

        //
        // Summary:
        //     Selects the token that matches the object path.
        //
        // Parameters:
        //   path:
        //     The object path from the current Newtonsoft.Json.Linq.JToken to the Newtonsoft.Json.Linq.JToken
        //     to be returned. This must be a string of property names or array indexes
        //     separated by periods, such as Tables[0].DefaultView[0].Price in C# or Tables(0).DefaultView(0).Price
        //     in Visual Basic.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JToken that matches the object path or a null reference
        //     if no matching token is found.
        public IEntry SelectToken(string path)
        {
            return (Entry)Json.SelectToken(path);
        }

        //
        // Summary:
        //     Selects the token that matches the object path.
        //
        // Parameters:
        //   path:
        //     The object path from the current Newtonsoft.Json.Linq.JToken to the Newtonsoft.Json.Linq.JToken
        //     to be returned. This must be a string of property names or array indexes
        //     separated by periods, such as Tables[0].DefaultView[0].Price in C# or Tables(0).DefaultView(0).Price
        //     in Visual Basic.
        //
        //   errorWhenNoMatch:
        //     A flag to indicate whether an error should be thrown if no token is found.
        //
        // Returns:
        //     The Newtonsoft.Json.Linq.JToken that matches the object path.
        public IEntry SelectToken(string path, bool errorWhenNoMatch)
        {
            return (Entry)Json.SelectToken(path, errorWhenNoMatch);
        }

        //
        // Summary:
        //     Creates the specified .NET type from the Newtonsoft.Json.Linq.JToken.
        //
        // Type parameters:
        //   T:
        //     The object type that the token will be deserialized to.
        //
        // Returns:
        //     The new object created from the JSON value.
        public T ToObject<T>()
        {
            return Json.ToObject<T>();
        }

        //
        // Summary:
        //     Creates the specified .NET type from the Newtonsoft.Json.Linq.JToken.
        //
        // Parameters:
        //   objectType:
        //     The object type that the token will be deserialized to.
        //
        // Returns:
        //     The new object created from the JSON value.
        public object ToObject(Type objectType)
        {
            return Json.ToObject(objectType);
        }

        //
        // Summary:
        //     Returns the indented JSON for this token.
        //
        // Returns:
        //     The indented JSON for this token.
        public override string ToString()
        {
            return Json.ToString(Formatting.Indented);
        }

        //
        // Summary:
        //     Gets the Newtonsoft.Json.Linq.JToken with the specified key converted to
        //     the specified type.
        //
        // Parameters:
        //   key:
        //     The token key.
        //
        // Type parameters:
        //   T:
        //     The type to convert the token to.
        //
        // Returns:
        //     The converted token value.
        public virtual T Value<T>(object key)
        {
            return Json.Value<T>(key);
        }

        //
        // Summary:
        //     Returns a collection of the child values of this token, in document order.
        //
        // Type parameters:
        //   T:
        //     The type to convert the values to.
        //
        // Returns:
        //     A System.Collections.Generic.IEnumerable<T> containing the child values of
        //     this Newtonsoft.Json.Linq.JToken, in document order.
        public virtual IEnumerable<T> Values<T>()
        {
            return Json.Values<T>();
        }

        //
        // Summary:
        //     Writes this token to a Newtonsoft.Json.JsonWriter.
        //
        // Parameters:
        //   writer:
        //     A Newtonsoft.Json.JsonWriter into which this method will write.
        //
        //   converters:
        //     A collection of Newtonsoft.Json.JsonConverter which will be used when writing
        //     the token.
        public void WriteTo(TextWriter writer)
        {
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                Json.WriteTo(jsonWriter);
            }
        }
    }
}
