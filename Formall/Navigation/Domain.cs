using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Formall.Navigation
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;
    using Formall.Reflection;

    /// <summary>
    /// Root Segment
    /// </summary>
    public class Domain : Document
    {
        private static readonly object _lock = new object();
        private static Model _model;
        
        internal Domain(IDocument document)
            : base(document, null)
        {
        }

        protected override Model GetModel()
        {
            var model = _model;

            if (model == null)
            {
                lock (_lock)
                {
                    model = _model ?? (_model = Schema.Current["Reflection/Model"] as Model);
                    throw new NotImplementedException();
                }
            }

            return model;
        }
    }
}
