using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    internal class Entry
    {
        private readonly DataColumn _dataColumn;

        public Entry(DataColumn dataColumn)
        {
            _dataColumn = dataColumn;
        }
    }
}
