using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class Validatable : IValidatable
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            // add an error ALWAYS for testing - it doesn't show up
            // and the debugger never hits this code
            //results.Add(new ValidationResult(/*"Validate Added message", new[] { "Company" }*/));

            return results;
        }
    }
}
