using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Address : ATEStampState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        [Required, StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [Required, StringLength(50)]
        public string City { get; set; }

        [Required, StringLength(50)]
        public string StateProvince { get; set; }

        [Required, StringLength(50)]
        public string CountryRegion { get; set; }

        [Required, StringLength(50)]
        public string PostalCode { get; set; }

    }
}
