using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    internal class Entry : IEntry
    {
        public static implicit operator Entry(RavenJToken token)
        {
            return null;
        }

        RavenJToken _token;

        public Entry(RavenJToken token)
        {   
            _token = token;
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string Path
        {
            get { throw new NotImplementedException(); }
        }

        public EntryType Type
        {
            get { throw new NotImplementedException(); }
        }

        public object Value
        {
            get
            {
                switch (_token.Type)
                {
                    case JTokenType.Array:
                        break;

                    case JTokenType.Object:
                        break;

                    default:
                        return (_token as RavenJValue).Value;
                }

                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
