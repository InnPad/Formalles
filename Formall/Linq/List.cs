using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    public class List
    {
    }

    public class List<T> : List
        where T : struct
    {
    }
}
