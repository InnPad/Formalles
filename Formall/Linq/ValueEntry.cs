using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    class ValueEntry : IEntry
    {
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

        public string Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
