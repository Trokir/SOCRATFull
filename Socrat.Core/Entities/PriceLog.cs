using System;

namespace Socrat.Core.Entities
{
    public class PriceLog : Entity
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get { return _date; }
            set { SetField(ref _date, value, () => Date); }
        }

        public string Editor { get; set; }
        public Guid? PricePeriodId { get; set; }
        public Guid? PriceTypeId { get; set; }
        public Guid? MaterialNomId { get; set; }
        public Guid? PriceValueId { get; set; }

        private double? _oldValue;
        public double? OldValue
        {
            get { return _oldValue; }
            set { SetField(ref _oldValue, value, () => OldValue); }
        }

        private MaterialNom _materialNom;
        public virtual MaterialNom MaterialNom
        {
            get { return _materialNom; }
            set { SetField(ref _materialNom, value, () => MaterialNom); }
        }

        private PricePeriod _pricePeriod;
        public virtual PricePeriod PricePeriod
        {
            get { return _pricePeriod; }
            set { SetField(ref _pricePeriod, value, () => PricePeriod); }
        }

        private PriceType _priceType;
        public virtual PriceType PriceType
        {
            get { return _priceType; }
            set { SetField(ref _priceType, value, () => PriceType); }
        }

        private PriceValue _priceValue;
        public virtual PriceValue PriceValue
        {
            get { return _priceValue; }
            set { SetField(ref _priceValue, value, () => PriceValue); }
        }
    }
}
