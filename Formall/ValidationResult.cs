using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class ValidationResult
    {
        public static readonly ValidationResult Success;

        static ValidationResult()
        {
        }

        private readonly Error _error;

        public ValidationResult(Error error)
        {
            _error = error;
        }
    }
}
