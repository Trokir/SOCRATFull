using System;

namespace Socrat.Core.Entities
{
    public class PriceSelectType : Entity
    {
        public Guid? PriceId { get; set; }
        public Guid? PriceTypeId { get; set; }

        private PriceType _priceType;
        public virtual PriceType PriceType
        {
            get { return _priceType; }
            set { SetField(ref _priceType, value, () => PriceType); }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        public override string ToString()
        {
            return "Раздел прайса";
        }
    }
}