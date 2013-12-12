using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class Model : DataType
    {
        public List<Action> Actions
        {
            get;
            set;
        }

        public List<Field> Fields
        {
            get;
            set;
        }
    }
}
