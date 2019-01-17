using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Token : ATEStampState
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenID { get; set; }

        public int TokenNumber { get; set; }
        
        public string TokenDescription { get; set; }


        public int? FkCustomerID { get; set; }
        // navigation property for Customer
        [ForeignKey("FkCustomerID")]
        public virtual Customer FkCustomerNav { get; set; }


        public int? FkTokenStatusID { get; set; }
        // navigation property for TokenStatus
        [ForeignKey("FkTokenStatusID")]
        public virtual TokenStatus FkTokenStatusNav { get; set; }


        public int? FkOrganisationServiceProviderID { get; set; }
        // navigation property for OrganisationServiceProvider
        [ForeignKey("FkOrganisationServiceProviderID")]
        public virtual OrganisationServiceProvider FkOrganisationServiceProviderNav { get; set; }
    }
}
