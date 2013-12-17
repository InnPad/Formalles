using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    internal class Raw : Entry
    {
        public static implicit operator JRaw(Raw value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Raw(JRaw json)
        {
            return json != null ? new Raw(json) : null;
        }

        private readonly JRaw _json;

        public Raw(JRaw json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
