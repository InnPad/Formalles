using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;

    public class Unit : Prototype
    {
        private static readonly object _lock = new object();
        private static Model _model;
        
        internal Unit(IEntity entity, ISegment parent)
            : base(entity, parent)
        {
        }

        public double Factor
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
