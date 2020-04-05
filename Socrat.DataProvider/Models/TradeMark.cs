using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class TradeMark : Entity
    {
        public TradeMark()
        {
            VendorMaterialNoms = new HashSet<VendorMaterialNom>();
        }

        public Guid? MaterialId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? VendorId { get; set; }


        public string Name { get; set; }


        public virtual Brand Brand { get; set; }

        public virtual Material Material { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; }
    }
}