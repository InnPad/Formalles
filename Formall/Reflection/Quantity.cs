using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    public class Quantity : DataType
    {
        private static readonly object _lock = new object();
        private static Model _model;

        protected override Model Template
        {
            get
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

        public List<Unit> Units
        {
            get;
            set;
        }
    }
}
