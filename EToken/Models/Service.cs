using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class Service : ATEStampState
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [Required,StringLength(100)]
        public string ServiceName { get; set; }

        [Required, StringLength(100)]
        public string ServiceType { get; set; }

        [StringLength(500)]
        public string ServiceDescription { get; set; }
    }
}
