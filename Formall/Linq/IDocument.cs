using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Persistence;
    using Formall.Reflection;
    
    public interface IDocument
    {
        dynamic Content { get; }

        IDocumentContext Context { get; }

        string Key { get; }

        Metadata Metadata { get; }
    }
}
