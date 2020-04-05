using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class PriceType : Entity
    {
        public PriceType()
        {
            _priceTypeMarkTypes = new ObservableCollection<PriceTypeMarkType>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        public Guid? MaterialId { get; set; }
        public Guid? PriceTagTypeId { get; set; }
        public Guid? MaterialMarkTypeId { get; set; }

        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        private PriceTagType _priceTagType;
        public virtual PriceTagType PriceTagType
        {
            get { return _priceTagType; }
            set { SetField(ref _priceTagType, value, () => PriceTagType); }
        }

        private MaterialMarkType _materialMarkType;
        public virtual MaterialMarkType MaterialMarkType
        {
            get => _materialMarkType; 
            set { SetField(ref _materialMarkType, value, () => MaterialMarkType); }
        }

        private PriceType.PriceTypes _sysType;

        public virtual PriceType.PriceTypes SysType
        {
            get => _sysType;
            set => SetField(ref _sysType, value, () => SysType); 
        }


        private void CollectionChange(object sender, EventArgs e)
        {
            Changed = true;
        }

        public virtual ICollection<PriceLog> PriceLogs { get; set; } = new HashSet<PriceLog>();
        public virtual ICollection<PriceSelectType> PriceSelectTypes { get; set; } = new HashSet<PriceSelectType>();

        private ObservableCollection<PriceTypeMarkType> _priceTypeMarkTypes;
        public virtual ObservableCollection<PriceTypeMarkType> PriceTypeMarkTypes
        {
            get => _priceTypeMarkTypes;
            set
            {
                _priceTypeMarkTypes = value;
                _priceTypeMarkTypes.CollectionChanged -= CollectionChange;
                _priceTypeMarkTypes.CollectionChanged += CollectionChange;
            }
        }

        public virtual ICollection<PriceValue> PriceValues { get; set; } = new HashSet<PriceValue>();
        public virtual ICollection<ContractPrice> ContractPrices { get; set; } = new HashSet<ContractPrice>();
        public override string ToString()
        {
            return "Раздел прайса";
        }

        public enum PriceTypes
        {
            Unknown = 0,
            Glasses = 1,
            Frame = 2,
            Film = 3
        }
    }
}
