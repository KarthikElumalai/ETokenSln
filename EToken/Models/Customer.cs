using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Customer : ATEStampState
    {
        private Guid CustomerID { get; set; }
        private Int32 CustomerTokenNumber { get; set; }
        private string CustomerName { get; set; }
        private Int64 CustomerPhoneNumber { get; set; }

    }


}
