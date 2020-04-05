using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Socrat.Core.Entities
{
    public class VendorMaterialNom : Entity
    {
        public Guid? VendorId { get; set; }
        public Guid? MaterialId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? TradeMarkId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        public Guid? MaterialMarkTypeId { get; set; }

        private string _colorRal;
        public string ColorRal
        {
            get { return _colorRal; }
            set { SetField(ref _colorRal, value, () => ColorRal); }
        }
        private double? _colorTransparency;
        public double? ColorTransparency
        {
            get { return _colorTransparency; }
            set { SetField(ref _colorTransparency, value, () => ColorTransparency); }
        }

        private string _mark;
        public string Mark
        {
            get { return _mark; }
            set { SetField(ref _mark, value, () => Mark); }
        }

        private Brand _brand;
        public virtual Brand Brand
        {
            get { return _brand; }
            set { SetField(ref _brand, value, () => Brand); }
        }
        [NotMapped]
        public Guid? MaterialTypeId
        {
            get { return MaterialType?.Id; }
        }
        [NotMapped]
        public MaterialType MaterialType
        {
            get { return Material?.MaterialType; }
        }
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
                    TradeMark = null;
                }
            }
        }

        private MaterialMarkType _materialMarkType;
        public virtual MaterialMarkType MaterialMarkType
        {
            get { return _materialMarkType; }
            set { SetField(ref _materialMarkType, value, () => MaterialMarkType); }
        }


        private TradeMark _tradeMark;
        public virtual TradeMark TradeMark
        {
            get { return _tradeMark; }
            set => SetField(ref _tradeMark, value, () => TradeMark);
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
                }
            }
        }
        public virtual ICollection<MaterialNom> MaterialNoms { get; set; } = new HashSet<MaterialNom>();
        protected override string GetTitle()
        {
            return $"Ќаменклатура материала производител€ {Vendor?.Name}";
        }

        public override string ToString()
        {
            string _tmp = $"{Vendor?.Name.Trim()} {Brand?.Name.Trim()} {TradeMark?.Name.Trim()} {Name?.Trim()}".Trim();
            _tmp = Regex.Replace(_tmp, @"\s+", " ");
            return _tmp;
        }
    }
}
