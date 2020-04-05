using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Brand : Entity
    {
        public Brand()
        {
            VendorMaterialNoms = new HashSet<VendorMaterialNom>();
            TradeMarks = new HashSet<TradeMark>();
        }

        public Guid? VendorId { get; set; }
        public string Name { get; set; }
        public Guid? MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<TradeMark> TradeMarks { get; set; }
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; }
    }
}