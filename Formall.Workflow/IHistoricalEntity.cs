using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public interface IHistoricalEntity : IEntity
    {
        DateTimeOffset Version { get; set; }
    }
}
