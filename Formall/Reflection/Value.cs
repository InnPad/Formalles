using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;

    public class Value : DataType, IDictionary, IDocument, IEntry, IFileSystem, ISegment
    {
        public const string GUID = "";

        private static readonly object _lock = new object();
        private static Model _model;
        
        protected override Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = new Model());
                }
            }

            return model;
        }
    }
}
