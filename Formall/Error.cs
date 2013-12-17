using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;
    using Formall.Reflection;

    public class Error : Document
    {
        private static readonly object _lock = new object();
        private static Model _model;

        
        public Error(IDocument document, ISegment parent)
            : base(document, parent)
        {
        }

        public Text Message
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
