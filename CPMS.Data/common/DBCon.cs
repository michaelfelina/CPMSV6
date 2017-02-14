using Common.Methods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Methods.Enumumerators;

namespace CPMS.Data
{
    public class DBCon
    {
        public string ConnectionString { get; set; }
        public SqlConnection cn { get; set; }

        public DBCon()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
        }

        public OperationResult Connect()
        {
            OperationResult result = new OperationResult();
            try
            {
                cn = new SqlConnection(ConnectionString);
                cn.Open();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }

        public void CloseConnection()
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
            }
            cn = null;
        }

        public OperationResult GetData(List<SqlParameter> parameters, string sProc, out DataTable dtResult)
        {
            var result = new OperationResult();
            dtResult = null;
            result = Connect();
            if (result.Success)
            {
                dtResult = new DataTable();
                try
                {
                    var oCmd = new SqlCommand(sProc, cn){ CommandType = CommandType.StoredProcedure };
                    dtResult = loadDataTable(parameters, oCmd);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Add(ex.Message);
                }
            }

            return result;
        }

        private DataTable loadDataTable(List<SqlParameter> parameters, SqlCommand oCmd)
        {
            var dtResult = new DataTable();
            if (parameters != null)
            {
                foreach (var param in parameters)
                    oCmd.Parameters.Add(param);
            }
            var oParam = oCmd.Parameters.Add(new SqlParameter("@DBStatus", SqlDbType.Int));
            oParam.Direction = ParameterDirection.Output;
            oCmd.CommandTimeout = 120;
            var drResults = oCmd.ExecuteReader();
            dtResult.Load(drResults);
            if ((Status)oCmd.Parameters["@DBStatus"].Value != Status.Success) dtResult = null;

            return dtResult;
        }
    }

    
}
