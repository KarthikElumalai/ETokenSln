using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{


    //Putting this Abstract classes, so that it will be just derived by entity classes 
     //and it will avoid the  repeation  of  same columns in all entity classes
    public class ATEStampState : ITEStampState
    {
        [StringLength(100)]
        public string CreatedBy { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }

        [StringLength(100)]
        public string UpdatedBy { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }


        public bool? IsDeletedFlag { get ; set ; }
        [StringLength(100)]
        public string DeletedBy { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
    }
    public class ATEPerson :ATEStampState
    {


        [StringLength(10)]
        public string Title{ get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required,StringLength(50)]
        public string Phone { get; set; }


    }
    
}
