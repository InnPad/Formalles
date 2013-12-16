using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Reflection;
    

    internal class ObjectEntry : Dictionary, IEntry
    {
        private readonly string _name;
        private readonly string _path;

        public ObjectEntry(string name, object value, Model model)
            : base(model)
        {
            _name = name.Split('/').Last();
            _path = string.Join("/", name.Split('/').Reverse().Skip(1).Reverse());
        }

        string IEntry.Name
        {
            get { return _name; }
        }

        string IEntry.Path
        {
            get { return _path; }
        }

        EntryType IEntry.Type
        {
            get { return EntryType.Object; }
        }
        /*
        DataType IObject.DataType
        {
            get { return base.Model; }
        }

        TObject IObject.ToObject<TObject>()
        {
            return base.ToObject<TObject>();
        }

        void IObject.WriteJson(Stream stream)
        {
            base.WriteJson(stream);
        }

        void IObject.WriteJson(TextWriter writer)
        {
            base.WriteJson(writer);
        }*/
    }
}
