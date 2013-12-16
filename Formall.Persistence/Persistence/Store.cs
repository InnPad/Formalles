using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall.Persistence
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Reflection;

    public class Store //: IDocument, IFileSystem, ISegment
    {
        private static Model _model;
        private IDocument _document;

        public string Name
        {
            get;
            set;
        }
    }
}
