using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Raven
{
    using global::Raven.Json.Linq;

    internal class Object : IDictionary
    {
        private readonly RavenJObject _jsonObject;

        public Object(RavenJObject jsonObject)
        {
            _jsonObject = jsonObject;
        }
    }
}
