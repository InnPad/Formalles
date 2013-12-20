using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Navigation
{
    public interface ISegment
    {
        string Name { get; }

        string Path { get; }

        ISegment Parent { get; }

        IDictionary<string, ISegment> Children { get; }
    }
}
