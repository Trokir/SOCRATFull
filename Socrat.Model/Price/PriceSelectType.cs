using System;

namespace Socrat.Model
{
    public class PriceSelectType : Entity
    {
        private Price _price;
        public Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        public Guid? Price_Id
        {
            get { return Price?.Id; }
        }

        private PriceType _priceType;
        public PriceType PriceType
        {
            get { return _priceType; }
            set { SetField(ref _priceType, value, () => PriceType); }
        }

        public Guid? PriceType_Id
        {
            get { return PriceType?.Id; }
        }
    }
}