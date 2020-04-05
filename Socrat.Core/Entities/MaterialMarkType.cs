using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class MaterialMarkType : Entity
    {
        public Guid? MaterialId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private string _mark;
        public string Mark
        {
            get { return _mark; }
            set { SetField(ref _mark, value, () => Mark); }
        }

        private string _gostMark;
        public string GostMark
        {
            get { return _gostMark; }
            set { SetField(ref _gostMark, value, () => GostMark); }
        }

        public int? Def { get; set; }

        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
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

        public virtual ObservableCollection<MaterialSizeType> MaterialSizeTypes { get; set; } = new ObservableCollection<MaterialSizeType>();
        public virtual ObservableCollection<PriceType> PriceTypes { get; set; } = new ObservableCollection<PriceType>();
        public virtual ICollection<PriceTypeMarkType> PriceTypeMarkTypes { get; set; } = new HashSet<PriceTypeMarkType>();
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; } = new HashSet<VendorMaterialNom>();
        public string Code
        {
            get { return !string.IsNullOrEmpty(GostMark) ? GostMark : Mark; }
        }

        protected override string GetTitle()
        {
            return Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
