using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Reflection
{
    public interface IValidatable
    {
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
