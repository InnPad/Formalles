using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Json
{
    internal class Collection : Entry, ICollection
    {
        public static implicit operator JArray(Collection value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Collection(JArray json)
        {
            return json != null ? new Collection(json) : null;
        }

        private readonly JArray _json;

        public Collection(JArray json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
