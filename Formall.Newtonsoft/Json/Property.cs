using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Json
{
    internal class Property : Entry
    {
        public static implicit operator JProperty(Property value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Property(JProperty json)
        {
            return json != null ? new Property(json) : null;
        }

        private readonly JProperty _json;

        public Property(JProperty json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
