using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public Int32 CustomerTokenNumber { get; set; }
        public string CustomerName { get; set; }
        public Int64 CustomerPhoneNumber { get; set; }

    }


}
