using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    public class Money : DataType
    {
        private static Model _model;

        protected override Model Template
        {
            get { return _model; }
        }
    }
}
