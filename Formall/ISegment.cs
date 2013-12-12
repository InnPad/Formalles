using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public interface ISegment
    {
        string Name { get; }

        string Path { get; }

        ISegment Parent { get; }

        List<ISegment> Children { get; }
    }
}
