using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall.Linq
{
    using Formall.Reflection;

    public interface IEntry
    {
        string Name { get; }

        string Path { get; }

        EntryType Type { get; }
    }
}
