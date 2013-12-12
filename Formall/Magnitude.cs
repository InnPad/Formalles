using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    /// <summary>
    /// Length, Mass, Etc
    /// </summary>
    public class Magnitude : DataType
    {
        private static Model _model;

        protected override Model Model
        {
            get { return _model; }
        }
    }
}
