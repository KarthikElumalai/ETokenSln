using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{
    public class TokenStatus : ATEStampState
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TokenStatusID { get; set; }

        [Required,StringLength(100)]
        public string StatusCode { get; set; }

        [StringLength(500)]
        public string StatusDescription { get; set; }
    }
}
