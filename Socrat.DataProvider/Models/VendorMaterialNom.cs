using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class VendorMaterialNom : Entity
    {
        public VendorMaterialNom()
        {
            MaterialNoms = new HashSet<MaterialNom>();
        }

        public Guid VendorId { get; set; }
        public Guid MaterialId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? TradeMarkId { get; set; }
        public string Name { get; set; }
        public Guid MaterialMarkTypeId { get; set; }
        public string ColorRal { get; set; }
        public double? ColorTransparency { get; set; }
        public string Mark { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Material Material { get; set; }
        public virtual MaterialMarkType MaterialMarkType { get; set; }
        public virtual TradeMark TradeMark { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<MaterialNom> MaterialNoms { get; set; }
    }
}