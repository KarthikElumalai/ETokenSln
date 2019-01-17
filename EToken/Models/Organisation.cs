using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Organisation : ATEStampState
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganisationID { get; set; }

        [Required,StringLength(100)]
        public string OrganisationName { get; set; }

        [Required, StringLength(100)]
        public string OrganisationType { get; set; }

        [Required, StringLength(100)]
        public string Industry { get; set; }



        public int? FkAddressID { get; set; }
        [ForeignKey("FkAddressID")]
        // navigation property for Address
        public virtual Address FkAddressNav { get; set; }
    }
}
