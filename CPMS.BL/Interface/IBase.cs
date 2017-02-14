using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Methods;

namespace CPMS.BL.Interface
{
    public interface IBase<T> where T : class
    {
        OperationResult Save(T data);
        OperationResult GetInfo_ByID(int Id, out T data);
        OperationResult GetAll(out List<T> datalist);
        OperationResult DeleteInfoByIDNo(int Id);
    }
}
