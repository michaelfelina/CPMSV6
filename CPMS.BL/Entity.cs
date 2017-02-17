using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPMS.BL.Interface;

namespace CPMS.BL
{
    public class Entity : IAuditable
    {
        public int IDNo { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double VAT { get; set; }
        public string Remarks { get; set; }
        public string AddedByUserGuid { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UpdatedByUserGuid { get; set; }
        public DateTime? DateUpdated { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
