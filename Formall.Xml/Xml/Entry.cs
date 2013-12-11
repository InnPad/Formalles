using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall
{
    internal abstract class Entry : IEntry
    {
        public static implicit operator XNode(Entry entry)
        {
            return null;
        }

        protected Entry()
        {
        }

        public abstract DataType Type { get; }

        DataType IEntry.Type
        {
            get { return this.Type; }
        }
    }
}
