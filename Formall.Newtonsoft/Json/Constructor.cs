using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Json
{
    internal class Constructor : Entry
    {
        public static implicit operator JConstructor(Constructor value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Constructor(JConstructor json)
        {
            return json != null ? new Constructor(json) : null;
        }

        private readonly JConstructor _json;

        public Constructor(JConstructor json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
