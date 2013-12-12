using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall
{
    public interface IDocument
    {
        IEntry this[string name] { get; }
    
        Guid Id { get; }

        string Key { get; }

        Metadata Metadata { get; }

        Model Model { get; }

        IDictionary ToObject();

        TObject ToObject<TObject>();

        XDocument ToXml();

        void WriteJson(Stream stream);

        void WriteJson(TextWriter writer);
    }
}
