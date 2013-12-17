using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Formall.Navigation
{
    using Formall.Linq;
    using Formall.Reflection;

    public class Area : Document
    {
        private static readonly object _lock = new object();
        private static Model _model;

        internal Area(IDocument document, ISegment segment)
            : base(document, segment)
        {
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

        protected override Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = new Model(null, null));
                    throw new NotImplementedException();
                }
            }

            return model;
        }
    }
}
