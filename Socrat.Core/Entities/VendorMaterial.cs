using System;

namespace Socrat.Core.Entities
{
    public class VendorMaterial : Entity
    {
        public Guid VendorId { get; set; }
        public Guid MaterialId { get; set; }

        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        [ParentItem]
        private Vendor _vendor;
        public virtual Vendor Vendor
        {
            get { return _vendor; }
            set { SetField(ref _vendor, value, () => Vendor); }
        }
        public string MaterialName
        {
            get { return Material?.Name; }
        }

        public MaterialType MaterialType
        {
            get { return Material?.MaterialType; }
        }

        protected override string GetTitle()
        {
            return $"Материал производителя {Vendor?.Name}";
        }

        public override string ToString()
        {
            string _res = Material != null && !string.IsNullOrEmpty(Material.Name) ? Material.Name : String.Empty;
            _res += " " + Vendor?.Name;
            return _res;
        }
    }
}
