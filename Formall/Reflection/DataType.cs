using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;
    using Formall.Reflection;

    public abstract class DataType
    {
        public Guid Identity
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Text Summary
        {
            get;
            set;
        }

        public Text Title
        {
            get;
            set;
        }
    }
}
