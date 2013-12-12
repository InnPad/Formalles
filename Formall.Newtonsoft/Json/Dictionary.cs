using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Json
{
    using Newtonsoft.Json.Linq;

    internal class Dictionary : Entry, IDictionary
    {
        public static implicit operator JObject(Dictionary value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Dictionary(JObject json)
        {
            return json != null ? new Dictionary(json) : null;
        }

        private readonly JObject _json;

        public Dictionary(JObject json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
