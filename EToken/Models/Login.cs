using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Login
    {

         [Key]
         public int PrimaryKeyID { get; set; }
         public string CustomerPhoneNumber { get; set; }
         public DateTime? DateDataCreated { get; set; }

    }
}
