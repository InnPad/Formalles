using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Navigation;
using Formall.Reflection;
using Formall.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
    
    public static class IDocumentContextExtensions
    {
        const string idProp = "id";
        const string keyProp = "key";
        const string dataProp = "data";
        const string metadataProp = "@metadata";

        #region - Create -

        public static void Create(this IDocumentContext store, JToken data, Model descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Create(store, data as JArray, descriptor);
                    break;

                case JTokenType.Object:
                    Create(store, data as JObject, descriptor);
                    break;
            }
        }

        public static void Create(this IDocumentContext store, JArray data, Model descriptor = null)
        {
            Create(store, data.Values().AsEnumerable().OfType<JObject>(), descriptor);
        }

        public static void Create(this IDocumentContext store, IEnumerable<JObject> package, Model descriptor = null)
        {
            foreach (var record in package)
                Create(store, record, descriptor);
        }

        public static void Create(this IDocumentContext store, JObject record, Model descriptor = null)
        {
            throw new NotImplementedException();
        }

        #endregion - Create -

        #region - Destroy -

        public static void Destroy(this IDocumentContext store, JToken data, Model descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Destroy(store, data as JArray, descriptor);
                    break;

                case JTokenType.Object:
                    Destroy(store, data as JObject, descriptor);
                    break;
            }
        }

        public static void Destroy(this IDocumentContext store, JArray data, Model descriptor = null)
        {
            Destroy(store, data.Values().AsEnumerable().OfType<JObject>(), descriptor);
        }

        public static void Destroy(this IDocumentContext store, IEnumerable<JObject> package, Model descriptor = null)
        {
            foreach (var record in package)
                Destroy(store, record, descriptor);
        }

        public static void Destroy(this IDocumentContext store, JObject record, Model descriptor = null)
        {
            throw new NotImplementedException();
        }

        #endregion - Destroy -

        #region - Import -

        public static void Import(this IDocumentContext store, string fileName, Model descriptor = null)
        {
            Import(store, new FileInfo(fileName), descriptor);
        }

        public static void Import(this IDocumentContext store, FileInfo file, Model descriptor = null)
        {
            JObject record;

            using (var reader = file.OpenText())
            {
                record = JObject.Load(new JsonTextReader(reader));
            }

            if (record != null)
            {
                var data = record[dataProp];

                if (data != null && data.Type == JTokenType.Array)
                    Import(store, data as JArray, descriptor);
                else
                    Import(store, record, descriptor);
            }
        }

        public static void Import(this IDocumentContext store, JToken data, Model descriptor = null)
        {
            switch (data.Type)
            {
                case JTokenType.Array:
                    Import(store, data as JArray, descriptor);
                    break;

                case JTokenType.Object:
                    Import(store, data as JObject, descriptor);
                    break;
            }
        }

        public static void Import(this IDocumentContext store, JArray data, Model descriptor = null)
        {
            Import(store, data.Values().AsEnumerable().OfType<JObject>(), descriptor);
        }

        public static void Import(this IDocumentContext store, IEnumerable<JObject> package, Model descriptor = null)
        {
            foreach (var record in package)
                Import(store, record);
        }

        public static bool Import(this IDocumentContext context, JObject data, Model descriptor = null)
        {
            string key = null;
            var metadata = data.Value<Metadata>("@metadata");

            if (metadata != null)
            {
                data.Remove("@metadata");
            }
            else
            {
                key = data.Value<string>(keyProp);
                data.Remove(keyProp);
                metadata = new Metadata { Key = key, Type = key.Exclude(1, '/') };
            }

            Guid id;
            if (string.IsNullOrWhiteSpace(key) || !Guid.TryParse(key.Split('/').Last(), out id))
                return false;

            //record.Add(idProp, new JValue(id));

            var document = context.Import(new JsonEntity(data, metadata));

            return true;
        }

        #endregion - Import -
    }
}
