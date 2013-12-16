using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formall.Linq
{
    using Formall.Reflection;

    internal class Value
    {
        private readonly DataRow _dataRow;
        private readonly DataColumn _dataColumn;
        private readonly DataType _dataType;

        public Value(DataRow dataRow, DataColumn dataColumn, DataType dataType)
        {
            _dataRow = dataRow;
            _dataColumn = dataColumn;
            _dataType = dataType;
        }

        public DataColumn DataColumn
        {
            get { return _dataColumn; }
        }

        public DataRow DataRow
        {
            get { return _dataRow; }
        }

        public DataType DataType
        {
            get { return _dataType; }
        }

        public TObject ToObject<TObject>()
        {
            return _dataRow.Field<TObject>(_dataColumn, DataRowVersion.Current);
        }
    }
}
