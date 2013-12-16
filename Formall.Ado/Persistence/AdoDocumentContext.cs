using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Persistence
{
    public class AdoDocumentContext
    {
        private readonly DataSet _dataSet;

        public AdoDocumentContext()
        {
            _dataSet = new DataSet();
        }

        protected DataSet DataSet
        {
            get { return _dataSet; }
        }
    }
}
