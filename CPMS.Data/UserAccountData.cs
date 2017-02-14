using Common.Methods;
using Common.Methods.Enumumerators;
using CPMS.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Common.Methods.Extensions;
using CPMS.BL.Interface;
using System.Web;

namespace CPMS.Data
{
    public class UserAccountData : ABase<UserAccount>, IUserAccount
    {
        protected override UserAccount SetData(DataRow row)
        {
            var result = new UserAccount
            {
                IDNo = row["IDNo"].ToInt(),
                Guid = row["Guid"].ToString(),
                Name = row["Name"].ToString(),
                UserName = row["UserName"].ToString(),
                Password = row["Password"].Decrypt(),
                ValidFrom = row["ValidFrom"].ObjectToNullableDate(),
                ValidTo = row["ValidTo"].ObjectToNullableDate(),
                Remarks = row["Remarks"].ToString(),
                Photo = row["Photo"].ToImage(),
                AccountType = (UserAccountType) row["AccountType"].ToInt(),
                AddedByUserGuid = row["AddedByUserGuid"].ToString(),
                DateAdded = row["DateAdded"].ObjectToDate(),
                UpdatedByUserGuid = row["UpdatedByUserGuid"].ToString(),
                DateUpdated = row["DateUpdated"].ObjectToNullableDate()
            };
            return result;
        }

        protected override List<SqlParameter> SetParameter(UserAccount data)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@IDNo", data.IDNo),
                new SqlParameter("@Guid", data.Guid),
                new SqlParameter("@EntityGuid", data.EntityGuid),
                new SqlParameter("@Name", data.Name),
                new SqlParameter("@UserName", data.UserName),
                new SqlParameter("@Password", data.Password.Encrypt()),
                new SqlParameter("@ValidFrom", data.ValidFrom),
                new SqlParameter("@ValidTo", data.ValidTo),
                new SqlParameter("@Remarks", data.Remarks),
                new SqlParameter("@Photo", data.Photo.ToBytes()),
                new SqlParameter("@AccountType", data.AccountType),
                new SqlParameter("@AddedByUserGuid", data.AddedByUserGuid),
                new SqlParameter("@DateAdded", data.DateAdded),
                new SqlParameter("@UpdatedByUserGuid", data.UpdatedByUserGuid),
                new SqlParameter("@DateUpdated", data.DateUpdated),
                new SqlParameter("@Deleted", false),
            };
            return parameter;
        }

        public OperationResult GetInfo_ByUserName(string UserName, UserAccountType userAccountType, out UserAccount data)
        {
            throw new NotImplementedException();
        }

        public OperationResult GetAll(UserAccountType userAccountType, out List<UserAccount> datalist)
        {
            var result = new OperationResult();
            datalist = null;
            try
            {
                var parameters = new List<SqlParameter> { new SqlParameter("@AccountType", userAccountType) };
                DataTable dtResult;
                var mssql = new DBCon();
                result = mssql.GetData(parameters, "prc_UserSelect", out dtResult);
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

        public OperationResult GetInfo_ByID(int Id, UserAccountType userAccountType, out UserAccount data)
        {
            var result = new OperationResult();
            data = null;
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IDNo", Id),
                    new SqlParameter("AccountType", userAccountType)
                };
                DataTable dtResult;
                var mssql = new DBCon();
                result = mssql.GetData(parameters, "prc_UserSelect", out dtResult);
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

        public OperationResult Save(UserAccount data)
        {
            throw new NotImplementedException();
        }

        public OperationResult GetInfo_ByID(int Id, out UserAccount data)
        {
            var result = new OperationResult();
            data = null;
            try
            {
                var parameters = new List<SqlParameter> { new SqlParameter("@IDNo", Id) };
                DataTable dtResult;
                var mssql = new DBCon();
                result = mssql.GetData(parameters, "prc_UserSelect", out dtResult);
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

        public OperationResult GetAll(out List<UserAccount> datalist)
        {
            throw new NotImplementedException();
        }

        public OperationResult DeleteInfoByIDNo(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
