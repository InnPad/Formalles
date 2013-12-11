using System;
using System.Collections.Generic;

namespace Formall
{
    public interface ICollection : ICollection<IEntry>, IEntry, IValidatable
    {
    }
}
