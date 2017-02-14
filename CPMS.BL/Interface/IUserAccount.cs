using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Methods;

namespace CPMS.BL.Interface
{
    public interface IUserAccount : IBase<UserAccount>
    {
        OperationResult Save(UserAccount data);
        OperationResult GetInfo_ByID(int Id, UserAccountType userAccountType, out UserAccount data);
        OperationResult GetInfo_ByUserName(string UserName, UserAccountType userAccountType, out UserAccount data);
        OperationResult GetAll(UserAccountType userAccountType, out List<UserAccount> datalist);
    }
}
