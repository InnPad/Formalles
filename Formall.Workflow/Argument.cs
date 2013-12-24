using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    using Formall.Reflection;

    public class Argument : IEntity, INamedEntity
    {
        public Program Program { get; set; }

        public Prototype Type { get; set; }

        #region - IEntity -

        public int Id { get; set; }

        #endregion - INamedEntity -

        #region - INamedEntity -

        public string Name { get; set; }

        #endregion - INamedEntity -
    }
}
