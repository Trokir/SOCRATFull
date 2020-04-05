using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class MaterialNom : Entity
    {
        public Guid? VendorMaterialNomId { get; set; }
        public Guid? MaterialSizeTypeId { get; set; }

        private string _code1C;
        public string Code1C
        {
            get { return _code1C; }
            set { SetField(ref _code1C, value, () => Code1C); }
        }

        private MaterialSizeType _materialSizeType;
        public virtual MaterialSizeType MaterialSizeType
        {
            get { return _materialSizeType; }
            set { SetField(ref _materialSizeType, value, () => MaterialSizeType); }
        }

        private VendorMaterialNom _vendorMaterialNom;
        public virtual VendorMaterialNom VendorMaterialNom
        {
            get { return _vendorMaterialNom; }
            set { SetField(ref _vendorMaterialNom, value, () => VendorMaterialNom); }
        }
        [NotMapped]
        public Vendor Vendor
        {
            get { return VendorMaterialNom?.Vendor; }
        }
        [NotMapped]
        public Guid? VendorId
        {
            get { return Vendor?.Id; }
        }

        public virtual ICollection<FormulaItem> FormulaItems { get; set; } = new HashSet<FormulaItem>();
        public virtual ICollection<MaterialSizeType> MaterialSizeTypes { get; set; } = new HashSet<MaterialSizeType>();
        public virtual ICollection<PriceLog> PriceLogs { get; set; } = new HashSet<PriceLog>();
        public virtual ICollection<PriceValue> PriceValues { get; set; } = new HashSet<PriceValue>();
        public string Code
        {
            get { return MaterialSizeType?.Code; }
        }
        public double Thickness
        {
            get { return MaterialSizeType?.Thickness ?? 0; }
        }
        public Material Material
        {
            get { return VendorMaterialNom?.Material; }
        }
        public Guid? MaterialId
        {
            get { return Material?.Id; }
        }
        public string FullName
        {
            get { return VendorMaterialNom?.ToString(); }
        }
        public MaterialType MaterialType
        {
            get { return VendorMaterialNom?.Material?.MaterialType; }
        }
        public Guid? MaterialTypeId
        {
            get { return MaterialType?.Id; }
        }
        protected override string GetTitle()
        {
            return $"Номенклатура материала";
        }

        public override string ToString()
        {
            return VendorMaterialNom?.ToString();
        }
    }
}
