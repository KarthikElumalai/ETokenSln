using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Models
{

    //putting this interfaces so that it enforces certain properties as a group
    interface ITEStampState
    { 

     

        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }

        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }

        //Flag will be set as y/n
        bool? IsDeletedFlag { get; set; }
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
       
        




    } // end of interface  ITEStampStateTransitionStatus

}
