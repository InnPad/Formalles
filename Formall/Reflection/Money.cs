using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    using Formall.Linq;

    public class Money : Unit
    {
        internal Money(IDocument document)
            : base(document)
        {
        }
    }
}
