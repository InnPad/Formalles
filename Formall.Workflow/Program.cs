using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class Program : IEntity, IHistoricalEntity, INamedEntity
    {
        //public Area Area { get; set; }

        public ICollection<Argument> Arguments { get; set; }

        //public Domain ResultType { get; set; }

        public ICollection<Variable> Variables { get; set; }

        /// <summary>
        /// Compressed Workflow
        /// </summary>
        public Binary Workflow { get; set; }

        #region - IEntity -

        public int Id { get; set; }

        #endregion - INamedEntity -

        #region - IHistoricalEntity -

        public DateTimeOffset Version { get; set; }

        #endregion - IHistoricalEntity -

        #region - INamedEntity -

        public string Name { get; set; }

        #endregion - INamedEntity -
    }

    public abstract class ProgramWithResult : Program
    {
        /// <summary>
        /// When implemented in a derived class, gets or sets the value of an object
        /// </summary>
        public abstract object Result { get; set; }

        /// <summary>
        /// When implemented in a derived class, gets the type of the result.
        /// </summary>
        public abstract Type ResultType { get; }
    }

    public class Program<TResult> : ProgramWithResult
    {
        public override object Result
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override Type ResultType
        {
            get { return typeof(TResult); }
        }
    }
}
