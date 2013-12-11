using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Dynamo
{
    using Amazon.DynamoDBv2.DocumentModel;
    using Amazon.DynamoDBv2.Model;
    using DynamoDBDocument = Amazon.DynamoDBv2.DocumentModel.Document;

    internal class Document : IDocument, IDictionary<string, IToken>, ICollection<KeyValuePair<string, IToken>>, IEnumerable<KeyValuePair<string, IToken>>, IEnumerable
    {
        public static implicit operator DynamoDBDocument(Document document)
        {
            return document != null ? document._dynamo : null;
        }

        public static implicit operator Document(DynamoDBDocument dynamo)
        {
            return dynamo != null ? new Document(dynamo) : null;
        }

        private readonly DynamoDBDocument _dynamo;

        public Document(DynamoDBDocument dynamo)
        {
            _dynamo = dynamo;
        }

        #region - ICollection -

        void ICollection<KeyValuePair<string, IToken>>.Add(KeyValuePair<string, IToken> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, IToken>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, IToken>>.Contains(KeyValuePair<string, IToken> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, IToken>>.CopyTo(KeyValuePair<string, IToken>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        int ICollection<KeyValuePair<string, IToken>>.Count
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<string, IToken>>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        bool ICollection<KeyValuePair<string, IToken>>.Remove(KeyValuePair<string, IToken> item)
        {
            throw new NotImplementedException();
        }

        #endregion - ICollection -

        #region - IDictionary -

        void IDictionary<string, IToken>.Add(string key, IToken value)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, IToken>.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        ICollection<string> IDictionary<string, IToken>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<string, IToken>.Remove(string key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, IToken>.TryGetValue(string key, out IToken value)
        {
            throw new NotImplementedException();
        }

        ICollection<IToken> IDictionary<string, IToken>.Values
        {
            get { throw new NotImplementedException(); }
        }

        IToken IDictionary<string, IToken>.this[string key]
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

        #endregion - IDictionary -

        #region - IDocument -

        #endregion - IDocument -

        #region - IEnumerable -

        IEnumerator<KeyValuePair<string, IToken>> IEnumerable<KeyValuePair<string, IToken>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion - IEnumerable -
    }
}