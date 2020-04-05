using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class Material : Entity
    {
        public Material()
        {
            MaterialSpecProperties = new ObservableCollection<MaterialSpecProperty>();
            MaterialFields = new ObservableCollection<MaterialField>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        public Guid? MaterialTypeId { get; set; }

        private string _enumCode;
        public string EnumCode
        {
            get { return _enumCode; }
            set { SetField(ref _enumCode, value, () => EnumCode); }
        }

        private MaterialType _materialType;
        public virtual MaterialType MaterialType
        {
            get { return _materialType; }
            set { SetField(ref _materialType, value, () => MaterialType); }
        }

        public virtual ObservableCollection<Brand> Brands { get; set; } = new ObservableCollection<Brand>();
        public virtual ICollection<FormulaItem> FormulaItems { get; set; } = new HashSet<FormulaItem>();
        public virtual ICollection<ProcessingType> ProcessingTypes { get; set; } = new HashSet<ProcessingType>();

        private ObservableCollection<MaterialField> _materialFields;
        public virtual ObservableCollection<MaterialField> MaterialFields
        {
            get => _materialFields;
            set => SetMaterialFields(value);
        }

        private void SetMaterialFields(ObservableCollection<MaterialField> value)
        {
            _materialFields = value;
            _materialFields.CollectionChanged -= _CollectionChanged;
            _materialFields.CollectionChanged += _CollectionChanged;
        }
        public virtual ICollection<MaterialMarkType> MaterialMarkTypes { get; set; } = new HashSet<MaterialMarkType>();

        private ObservableCollection<MaterialSpecProperty> _materialSpecProperties;
        public virtual ObservableCollection<MaterialSpecProperty> MaterialSpecProperties
        {
            get => _materialSpecProperties;
            set => SetMaterialSpecProperties(value);
        }

        private void SetMaterialSpecProperties(ObservableCollection<MaterialSpecProperty> value)
        {
            _materialSpecProperties = value;
            _materialSpecProperties.CollectionChanged -= _CollectionChanged;
            _materialSpecProperties.CollectionChanged += _CollectionChanged;
        }
        public virtual ICollection<PriceType> PriceTypes { get; set; } = new HashSet<PriceType>();
        public virtual ObservableCollection<TradeMark> TradeMarks { get; set; } = new ObservableCollection<TradeMark>();
        public virtual ICollection<VendorMaterial> VendorMaterials { get; set; } = new HashSet<VendorMaterial>();
        public virtual ICollection<VendorMaterialNom> VendorMaterialNoms { get; set; } = new HashSet<VendorMaterialNom>();

        public MaterialEnum MaterialEnum
        {
            get { return EnumHelper<MaterialEnum>.Parse(EnumCode); }
        }

        private void _CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Changed = true;
        }

        public override string ToString()
        {
            return Name;
        }

        protected override string GetTitle()
        {
            return "Материал: " + Name;
        }

        public bool ContainsVendor(Vendor vendor)
        {
            if (vendor != null)
                return VendorMaterials.Select(x => x.Vendor).Count(x => x.Id == vendor.Id) > 0;
            return false;
        }
    }
}
