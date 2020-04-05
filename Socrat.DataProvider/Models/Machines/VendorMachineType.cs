using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Common;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Data.Model.Machines
{
    
    public class VendorMachineType : Entity
    {
      
        public Guid VendorId { get; set; }
    
        public Guid MachineTypeId { get; set; }
 
        
        public virtual Vendor Vendor
        {
            get; set;
            
        }

        
        public virtual MachineType MachineType
        {
            get; set;
            
        }


    
    }
}
