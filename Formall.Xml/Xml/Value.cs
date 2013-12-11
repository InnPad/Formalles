using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formall
{
    internal class Value : Entry, IValue
    {
        private readonly XNode _node;
        private readonly DataType _type;
        
        public Value(XNode node, DataType type)
        {
            _node = node;
            _type = type;
        }

        public override DataType Type
        {
            get { return _type; }
        }

        #region - IEntry -

        DataType IEntry.Type
        {
            get { return _type; }
        }

        #endregion - IEntry -

        #region - IValidatable -

        IEnumerable<ValidationResult> IValidatable.Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        #endregion - IValidatable -
    }
}
