using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Reflection;

    public interface IDataContext
    {
        IRepository CreateRepository(string name);
    }
}
