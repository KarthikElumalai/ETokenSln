using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Login : ATEStampState
    {

         [Key]
         public int ID { get; set; }
         public string CustomerPhoneNumber { get; set; }
    }
}
