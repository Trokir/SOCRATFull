using Socrat.Data.Model.Machines;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Vendor : Entity
    {
        public Vendor()
        {
            Brands = new HashSet<Brand>();
            VendorMaterialNoms = new HashSet<VendorMaterialNom>();
            VendorMaterials = new HashSet<VendorMaterial>();
            TradeMarks = new HashSet<TradeMark>();
            VendorMachineTypes = new HashSet<VendorMachineType>();
            VendorMachineNoms = new HashSet<VendorMachineNom>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<TradeMark> TradeMarks { get; set; }
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; }
        public virtual ICollection<VendorMachineType> VendorMachineTypes { get; set; }
        public virtual ICollection<VendorMachineNom> VendorMachineNoms { get; set; }

        public virtual ICollection<VendorMaterial> VendorMaterials { get; set; }
    }
}