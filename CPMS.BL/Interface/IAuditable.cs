using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMS.BL.Interface
{
    public interface IAuditable
    {
        string AddedByUserGuid { get; set; }
        DateTime? DateAdded { get; set; }
        string UpdatedByUserGuid { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
