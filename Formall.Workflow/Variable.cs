using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    using Formall.Reflection;

    public class Variable : IEntity, IHistoricalEntity, INamedEntity
    {
        //public Area Area { get; set; }

        /// <summary>
        /// If null global to area
        /// </summary>
        public Program Program { get; set; }

        public string Value { get; set; }

        public Prototype Type { get; set; }

        public bool Readonly { get; set; }

        #region - IEntity -

        public int Id { get; set; }

        #endregion - INamedEntity -

        #region - IHistoricalEntity -

        public DateTimeOffset Version { get; set; }

        #endregion - IHistoricalEntity -

        #region - INamedEntity -

        /// <summary>
        /// Unique to area
        /// </summary>
        public string Name { get; set; }

        #endregion - INamedEntity -
    }
}
