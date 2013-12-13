using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Raven
{
    using global::Raven.Abstractions.Data;
    using global::Raven.Imports.Newtonsoft.Json;
    using global::Raven.Imports.Newtonsoft.Json.Serialization;
    using global::Raven.Json.Linq;

    internal class Document : IDocument
    {
        private readonly JsonDocument _jsonDocument;

        public Document(JsonDocument jsonDocument)
        {
            _jsonDocument = jsonDocument;
        }

        public Document(RavenJObject jsonObject)
        {
            var jsonMetadata = jsonObject.Value<RavenJObject>("@metadata");
        }

        public string Key
        {
            get { return _jsonDocument.Key; }
        }

        public Metadata Metadata
        {
            get { throw new NotImplementedException(); }
        }

        public IDictionary ToObject()
        {
            return new Dictionary(_jsonDocument.ToJson());
        }

        public TObject ToObject<TObject>()
        {
            return ToObject<TObject>(new JsonConverter[0]);
        }

        internal protected TObject ToObject<TObject>(JsonConverter[] converters)
        {
            var jsonSerializer = new JsonSerializer
            {
                DateParseHandling = DateParseHandling.None,
                ContractResolver = /*new CamelCasePropertyNamesContractResolver()*/ new DefaultContractResolver()
            };

            if (converters != null)
            {
                foreach (var converter in converters)
                {
                    jsonSerializer.Converters.Add(converter);
                }
            }

            return (TObject)jsonSerializer.Deserialize(new RavenJTokenReader(_jsonDocument.ToJson()), typeof(TObject));
        }

        public void WriteJson(TextWriter writer)
        {
            var jsonObject = _jsonDocument.ToJson();
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonObject.WriteTo(jsonWriter);
            }
        }

        public void WriteJson(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                WriteJson(writer);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(TextWriter writer)
        {
            using (var xmlWriter = new XmlTextWriter(writer))
            {
                WriteXml(xmlWriter);
            }
        }

        public void WriteXml(Stream stream)
        {
            using (var writer = new StreamWriter(stream))
            {
                WriteXml(writer);
            }
        }
    }
}
