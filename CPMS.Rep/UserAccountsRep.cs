using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMS.BL;
using CPMS.BL.Interface;
using Common.Methods;
using CPMS.Data;

namespace CPMS.Rep
{
    public class UserAccountsRep : IUserAccount
    {
        private readonly UserAccountData userAccountsData;
        public UserAccountsRep()
        {
            userAccountsData = new UserAccountData();
        }

        public OperationResult DeleteInfoByIDNo(int Id)
        {
            throw new NotImplementedException();
        }

        public OperationResult GetAll(out List<UserAccount> datalist)
        {
            throw new NotImplementedException();
        }

        public OperationResult GetAll(UserAccountType userAccountType, out List<UserAccount> datalist)
        {
            var result = userAccountsData.GetAll(userAccountType, out datalist);
            return result;
        }

        public OperationResult GetInfo_ByID(int Id, out UserAccount data)
        {
            var result = userAccountsData.GetInfo_ByID(Id, out data);
            return result;
        }

        public OperationResult GetInfo_ByID(int Id, UserAccountType userAccountType, out UserAccount data)
        {
            var result = userAccountsData.GetInfo_ByID(Id, userAccountType, out data);
            return result;
        }

        public OperationResult GetInfo_ByUserName(string UserName, UserAccountType userAccountType, out UserAccount data)
        {
            throw new NotImplementedException();
        }

        public OperationResult Save(UserAccount data)
        {
            throw new NotImplementedException();
        }
    }
}
