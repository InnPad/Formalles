using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Json
{
    using Newtonsoft.Json.Linq;

    internal class Value : Entry, IValue
    {
        public static implicit operator JValue(Value value)
        {
            return value != null ? value._json : null;
        }

        public static implicit operator Value(JValue json)
        {
            return json != null ? new Value(json) : null;
        }

        private readonly JValue _json;

        public Value(JValue json)
        {
            _json = json;
        }

        protected override JToken Json
        {
            get { return _json; }
        }
    }
}
