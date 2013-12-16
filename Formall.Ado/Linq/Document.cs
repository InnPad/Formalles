using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    internal class Document
    {
        private readonly DataRow _dataRow;

        public Document(DataRow dataRow)
        {
            _dataRow = dataRow;
        }

        protected DataRow DataRow
        {
            get { return _dataRow; }
        }
    }
}
