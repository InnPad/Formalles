using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Raven.Json.Linq;

    public static class MetadataExtensions
    {
        public static RavenJObject FromMetadata(this Metadata metadata)
        {
            return new RavenJObject
            {
                { "@id", metadata.Key },
                { "Raven-Entity-Name", metadata.Model }
            };
        }

        public static Metadata ToMetadata(this RavenJObject obj)
        {
            var metadata = new Metadata
            {
                Key = obj.Value<string>("@id"),
                Model = obj.Value<string>("Raven-Entity-Name")
            };

            return metadata;
        }
    }
}
