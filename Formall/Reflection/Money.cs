using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    using Formall.Linq;
    using Formall.Navigation;
    using Formall.Persistence;

    public class Money : Unit
    {
        internal Money(IEntity entity, ISegment parent)
            : base(entity, parent)
        {
        }
    }
}
