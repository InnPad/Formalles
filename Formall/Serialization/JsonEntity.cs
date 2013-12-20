using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Serialization
{
    using Formall.Linq;
    using Formall.Persistence;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    public class JsonEntity : IEntity
    {
        private readonly Guid _id;
        private JObject _data;
        private Metadata _metadata;

        public JsonEntity(Guid id, object data, Metadata metadata)
        {
            _id = id;
            _data = JObject.FromObject(data);
            _metadata = metadata;
        }

        dynamic IEntity.Data
        {
            get { return _data; }
            set { _data = JObject.FromObject(value); }
        }

        Guid IEntity.Id
        {
            get { return _id; }
        }

        Reflection.Model IEntity.Model
        {
            get { throw new NotImplementedException(); }
        }

        IRepository IEntity.Repository
        {
            get { throw new NotImplementedException(); }
        }

        IResult IEntity.Delete()
        {
            throw new NotImplementedException();
        }

        T IEntity.Get<T>()
        {
            var jsonSerializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                ContractResolver = new DefaultContractResolver()
            };

            return (T)jsonSerializer.Deserialize(new JTokenReader(_data), typeof(T));
        }

        IResult IEntity.Refresh()
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Set<T>(T value)
        {
            _data = JObject.FromObject(value);

            return null;
        }

        IResult IEntity.Patch(Linq.IDictionary data)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.Update(Linq.IDictionary data)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.WriteJson(System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }

        IResult IEntity.WriteJson(System.IO.TextWriter writer)
        {
            throw new NotImplementedException();
        }

        System.IO.Stream IDocument.Content
        {
            get { throw new NotImplementedException(); }
        }

        IDocumentContext IDocument.Context
        {
            get { throw new NotImplementedException(); }
        }

        string IDocument.Key
        {
            get { throw new NotImplementedException(); }
        }

        string IDocument.MediaType
        {
            get { return "application/json"; }
        }

        Metadata IDocument.Metadata
        {
            get { return _metadata; }
        }
    }
}
