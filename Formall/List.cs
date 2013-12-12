using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class List : DataType
    {
        private static Model _model;

        public List<Item> Items
        {
            get;
            set;
        }
    }
}
