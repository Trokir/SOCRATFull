using System;

namespace Socrat.Data.Model
{
    public class VendorMaterial : Entity
    {
        public Guid VendorId { get; set; }
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}