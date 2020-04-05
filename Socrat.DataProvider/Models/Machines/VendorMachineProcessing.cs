using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Data.Model.Machines
{
    public class VendorMachineProcessing : Entity
    {
        public Guid VendorMachineNomId { get; set; }
        public Guid ProcessingId { get; set; }
        public Guid? VendorMachineOptionId { get; set; }

        
        public virtual VendorMachineNom VendorMachineNom
        {
            get; set;
            
        }

        
        public virtual Processing Processing
        {
            get; set;
            
        }

        
        public virtual VendorMachineOption VendorMachineOption
        {
            get; set;
            
        }
      
    }
}
