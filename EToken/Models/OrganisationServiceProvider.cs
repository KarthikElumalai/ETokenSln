using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class OrganisationServiceProvider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganisationServiceProviderID { get; set; }


        public int? FkOrganisationID { get; set; }
        // navigation property for Organisation
        [ForeignKey("FkOrganisationID")]
        public virtual Organisation FkOrganisationNav { get; set; }


        public int? FkServiceID { get; set; }
        // navigation property for Service
        [ForeignKey("FkServiceID")]
        public virtual Service FkServiceNav { get; set; }


        public int? FkProviderID { get; set; }
        // navigation property for Provider
        [ForeignKey("FkProviderID")]
        public virtual Provider FkProviderNav { get; set; }
    }
}
