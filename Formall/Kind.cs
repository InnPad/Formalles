using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class Kind
    {
        public static Kind Array = new Kind("Array");
        public static Kind Complex = new Kind("Complex");
        public static Kind Magnitude = new Kind("Magnitude");
        public static Kind Money = new Kind("Money");
        public static Kind Value = new Kind("Value");

        private readonly string _name;

        private Kind(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
