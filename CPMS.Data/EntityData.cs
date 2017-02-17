using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Methods;
using Common.Methods.Enumumerators;
using Common.Methods.Extensions;
using CPMS.BL;
using CPMS.BL.Interface;
using CPMS.Data.common;

namespace CPMS.Data
{
    public class EntityData : ABase<Entity>, IEntity
    {
        protected override Entity SetData(DataRow row)
        {
            var result = new Entity()
            {
                IDNo = row["IDNo"].ToInt(),
                GUID = row["Guid"].ToString(),
                Name = row["Entity"].ToString(),
                Address = row["Address"].ToString(),
                Remarks = row["Remarks"].ToString(),
                VAT = row["VAT"].ToDouble(),
            };
            return result;
        }

        protected override List<SqlParameter> SetParameter(Entity data)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@IDNo", data.IDNo),
                new SqlParameter("@Guid", data.GUID),
                new SqlParameter("@Entity", data.Name),
                new SqlParameter("@Address", data.Address),
                new SqlParameter("@Remarks", data.Remarks),
                new SqlParameter("@VAT", data.VAT),
            };
            return parameter;
        }


        public OperationResult Save(Entity data)
        {
            var result = new OperationResult();
            try
            {
                int newId = data.IDNo;
                if (data.IDNo == -1) data.GUID = GenerateGuid.Get();
                var parameter = SetParameter(data);
                var mssql = new DBCon();
                result = mssql.Save(parameter, "prc_EntitySave", ref newId);
                if (result.Success) if (data.IDNo == -1) data.IDNo = newId;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }

        public OperationResult GetInfo_ByID(int Id, out Entity data)
        {
            var result = new OperationResult();
            data = null;
            try
            {
                var parameters = new List<SqlParameter> { new SqlParameter("@IDNo", Id) };
                DataTable dtResult;
                var mssql = new DBCon();
                result = mssql.GetData(parameters, "prc_EntitySelect", out dtResult);
                if (result.Success) data = extractSingle(dtResult);
                else
                {
                    result.Success = false;
                    result.Add(ErrorMessage.NoRecordFound);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }

        public OperationResult GetAll(out List<Entity> datalist)
        {
            var result = new OperationResult();
            datalist = null;
            try
            {
                DataTable dtResult;
                var mssql = new DBCon();
                result = mssql.GetData(parameters: null, sProc: "prc_EntitySelect", dtResult: out dtResult);
                if (result.Success) datalist = extractMany(dtResult);
                else
                {
                    result.Success = false;
                    result.Add(ErrorMessage.NoRecordFound);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }

        public OperationResult DeleteInfoByIDNo(int Id)
        {
            var result = new OperationResult();
            try
            {
                var mssql = new DBCon();
                var parameters = new List<SqlParameter> { new SqlParameter("@IDNo", Id) };
                result = mssql.Execute(parameters, "prc_EntityDelete");
            }
            catch (SqlException ex)
            {
                result.Success = false;
                result.Add(ex.Message);
            }
            return result;
        }
    }
}
