using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{


    //Putting this Abstract classes, so that it will be just derived by entity classes 
     //and it will avoid the  repeation  of  same columns in all entity classes
    public class ATEStampState : ITEStampState
    {
        public string CreatedBy { get ; set ; }
        public DateTime? CreatedDate { get ; set ; }
        public string UpdatedBy { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public bool? IsDeletedFlag { get ; set ; }
        public string DeletedBy { get ; set ; }
        public DateTime? DeletedDate { get ; set ; }
    }
}
