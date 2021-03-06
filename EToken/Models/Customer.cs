﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Customer : ATEPerson
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }


        public int?  FkAddressID { get; set; }
        [ForeignKey("FkAddressID")]
        // navigation property for Address
        public virtual Address FkAddressNav { get; set; }

    }


}
