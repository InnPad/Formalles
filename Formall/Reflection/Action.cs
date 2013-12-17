using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Formall.Reflection
{
    using Formall.Linq;

    public class Action : Dictionary
    {
        private static readonly object _lock = new object();
        private static Model _model;

        private static Model GetModel()
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

        public Action(IDictionary source)
            : base(GetModel(), source)
        {
        }

        public string Name
        {
            get { return base["Name"].ToString(); }
            set { }
        }
    }
}
