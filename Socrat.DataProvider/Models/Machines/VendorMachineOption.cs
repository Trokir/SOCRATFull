using Socrat.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = Socrat.Common.ValidationResult;

namespace Socrat.Data.Model.Machines
{
  
    public class VendorMachineOption : Entity
    {
        public VendorMachineOption()
        {
            VendorMachineProcessings = new HashSet<VendorMachineProcessing>();
            MachineNomOptions = new HashSet<MachineNomOption>();
        }

     
        public Guid VendorMachineNomId { get; set; }

        
      
        public string Name
        {
            get; set;
            
        }

        
       
        public string Description
        {
            get; set;
            
        }
      

     
        
     
        public virtual VendorMachineNom VendorMachineNom
        {
            get; set;
            
        }
      
        
        public virtual ICollection<VendorMachineProcessing> VendorMachineProcessings { get; set; }

        public virtual ICollection<MachineNomOption> MachineNomOptions { get; set; }
     
    }
}
