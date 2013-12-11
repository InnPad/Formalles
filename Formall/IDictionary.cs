using System;
using System.Collections.Generic;

namespace Formall
{
    public interface IDictionary : IDictionary<string, IEntry>, IEntry, IValidatable
    {
        Model Model { get; }
    }
}
