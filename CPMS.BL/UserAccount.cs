using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Common.Methods;
using CPMS.BL.Interface;

namespace CPMS.BL
{
    public enum UserAccountType
    {
        Admin = 1,
        Cashier = 2
    }

    public class UserAccount : IAuditable
    {
        public int IDNo { get; set; }
        public string Guid { get; set; }
        public string EntityGuid { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Remarks { get; set; }
        public Image Photo { get; set; }
        public UserAccountType AccountType { get; set; }
        public string AddedByUserGuid { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UpdatedByUserGuid { get; set; }
        public DateTime? DateUpdated { get; set; }

        //public override string ToString()
        //{
        //    return Name;
        //}

        public OperationResult AccountIsExpired(DateTime currentDate, UserAccount userAccount)
        {
            var result = new OperationResult();
            if (!(currentDate >= userAccount.ValidFrom &&
                  currentDate <= userAccount.ValidTo))
            {
                result.Success = false;
                result.Add("Account is Expired");
            }
            return result;
        }

        public OperationResult IsValidPassword(string Password, UserAccount userAccount)
        {
            var result = new OperationResult();
            if (userAccount.Password != Password)
            {
                result.Success = false;
                result.Add("Invalid Password");
            }
            return result;
        }
    }
}
