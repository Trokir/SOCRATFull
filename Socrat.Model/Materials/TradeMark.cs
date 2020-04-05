using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class TradeMark: Entity
    {
        private Material _material;
        public Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        public Nullable<Guid> Material_Id
        {
            get { return Material?.Id; }
        }

        private Brand _brand;
        public Brand Brand
        {
            get { return _brand; }
            set { SetField(ref _brand, value, () => Brand); }
        }

        public Nullable<Guid> Brand_Id
        {
            get { return Brand?.Id; }
        }

        [ParentItem]
        private Vendor _Vendor;
        public Vendor Vendor
        {
            get { return _Vendor; }
            set { SetField(ref _Vendor, value, () => Vendor); }
        }

        public Nullable<Guid>Vendor_Id
        {
            get { return Vendor?.Id; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name, () => Title); }
        }

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