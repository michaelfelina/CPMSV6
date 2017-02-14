using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.Data
{
    public abstract class ABase<T> where T : class
    {
        protected abstract T SetData(DataRow row);
        protected abstract List<SqlParameter> SetParameter(T data);

        internal List<T> extractMany(DataTable dataTable)
        {
            var result = new List<T>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    var cardType = SetData(row);
                    result.Add(cardType);
                }
            }
            return result;
        }

        internal T extractSingle(DataTable dataTable)
        {
            T result = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    result = SetData(row);
                    break;
                }
            }
            return result;
        }
    }
}
