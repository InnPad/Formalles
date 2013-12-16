using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Reflection;
    

    internal class Entry : IEntry
    {
        private readonly string _name;

        public Entry(string name, object value)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { throw new NotImplementedException(); }
        }

        public EntryType Type
        {
            get { throw new NotImplementedException(); }
        }

        public DataType DataType
        {
            get { throw new NotImplementedException(); }
        }

        public TObject ToObject<TObject>()
        {
            throw new NotImplementedException();
        }

        public void WriteJson(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void WriteJson(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
