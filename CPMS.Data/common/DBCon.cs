using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Common.Methods;
using Common.Methods.Enumumerators;
using Common.Methods.Extensions;

namespace CPMS.Data.common
{
    public class DBCon
    {
        private string ConnectionString { get; set; }
        private SqlConnection cn { get; set; }

        public DBCon()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
        }

        private OperationResult Connect()
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

        private void CloseConnection()
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
            dtResult = null;
            var result = Connect();
            if (result.Success)
            {
                dtResult = new DataTable();
                try
                {
                    var oCmd = new SqlCommand(sProc, cn){ CommandType = CommandType.StoredProcedure };
                    dtResult = loadDataTable(parameters, oCmd);
                    CloseConnection();
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Add(ex.Message);
                }
            }

            return result;
        }

        public OperationResult Save(List<SqlParameter> parameters, string sProc)
        {
            var result = new OperationResult();
            try
            {
                result = Connect();
                if (result.Success)
                {
                    var cmd = new SqlCommand(sProc, cn) { CommandType = CommandType.StoredProcedure };

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.Add(param);
                    }
                    var oParam = cmd.Parameters.Add(new SqlParameter("@DBStatus", SqlDbType.Int));
                    oParam.Direction = ParameterDirection.Output;

                    oParam = cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    oParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    if ((Status)cmd.Parameters["@DBStatus"].Value != Status.Success)
                    {
                        result.Success = false;
                        result.Add("Save Failed");
                    }
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }

        public OperationResult Save(List<SqlParameter> parameters, string sProc, ref int newId)
        {
            var result = new OperationResult();
            try
            {
                result = Connect();
                if (result.Success)
                {
                    var cmd = new SqlCommand(sProc, cn) { CommandType = CommandType.StoredProcedure };

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.Add(param);
                    }
                    var oParam = cmd.Parameters.Add(new SqlParameter("@DBStatus", SqlDbType.Int));
                    oParam.Direction = ParameterDirection.Output;

                    oParam = cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int));
                    oParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    if ((Status)cmd.Parameters["@DBStatus"].Value == Status.Success)
                    {
                        if (newId == -1)
                        {
                            newId = cmd.Parameters["@NewID"].Value.ToInt();
                            if (newId <= 0)
                            {
                                result.Success = false;
                                result.Add("No ID returned from database after insert");
                            }
                        }
                    }
                    else
                    {
                        result.Success = false;
                        result.Add("Save Failed");
                    }
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
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

        public OperationResult Execute(List<SqlParameter> parameters, string sProc)
        {
            var result = new OperationResult();
            try
            {
                result = Connect();
                if (result.Success)
                {
                    var cmd = new SqlCommand(sProc, cn) { CommandType = CommandType.StoredProcedure };
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    var oParam = cmd.Parameters.Add(new SqlParameter("@DBStatus", SqlDbType.Int));
                    oParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    if ((Status)cmd.Parameters["@DBStatus"].Value != Status.Success)
                    {
                        result.Success = false;
                        result.Add("Execute Query Failed");
                    }
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }

            return result;
        }
    }

    
}
