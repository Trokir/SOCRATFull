using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class TradeMark : Entity, INamedEntity
    {
        public Guid? MaterialId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? VendorId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private Brand _brand;
        public virtual Brand Brand
        {
            get { return _brand; }
            set { SetField(ref _brand, value, () => Brand); }
        }
        [ParentItem]
        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set
            {
                SetField(ref _material, value, () => Material);
                if (Material == null)
                {
                    Brand = null;
                }
            }
        }
        [ParentItem]
        private Vendor _vendor;
        public virtual Vendor Vendor
        {
            get { return _vendor; }
            set
            {
                SetField(ref _vendor, value, () => Vendor);
                if (Vendor == null)
                {
                    Material = null;
                    Brand = null;
                }
            }
        }
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; } = new HashSet<VendorMaterialNom>();
        protected override string GetTitle()
        {
            return $"Торговая марка: {Name}";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
