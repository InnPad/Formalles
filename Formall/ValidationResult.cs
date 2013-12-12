using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall
{
    public class ValidationResult : IResult
    {
        public bool IsAsynchronous
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSuccess
        {
            get { throw new NotImplementedException(); }
        }

        public void Write(Stream stream)
        {
            throw new NotImplementedException();
        }

        public void Write(TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
