using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public class Metadata
    {
        public ContentType Type
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public string Model
        {
            get;
            set;
        }

        public bool Private
        {
            get;
            set;
        }
    }
}
