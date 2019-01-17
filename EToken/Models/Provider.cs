using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Provider : ATEPerson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProviderID { get; set; }

        [Required,StringLength(100)]
        public string ProviderType { get; set; }



        public int? FkAddressID { get; set; }
        [ForeignKey("FkAddressID")]
        // navigation property for Address
        public virtual Address FkAddressNav { get; set; }
    }
}
