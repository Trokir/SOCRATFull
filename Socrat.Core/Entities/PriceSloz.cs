using System;

namespace Socrat.Core.Entities
{
    public class PriceSloz : Entity
    {
        public Guid? PriceId { get; set; }
        public Guid? SlozTypeId { get; set; }


        private double? _priceSlozName;

        public double? PriceSlozName
        {
            get { return _priceSlozName; }
            set
            { SetField(ref _priceSlozName, value, () => PriceSlozName); }
        }

        private double? _discount;
        public double? Discount
        {
            get { return _discount; }
            set { SetField(ref _discount, value, () => Discount); }
        }

        private double? _delta;
        public double? Delta
        {
            get { return _delta; }
            set { SetField(ref _delta, value, () => Delta); }
        }

        private DateTime? _edit;
        public DateTime? Edit
        {
            get { return _edit; }
            set { SetField(ref _edit, value, () => Edit); }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        private SlozType _slozType;
        public virtual SlozType SlozType
        {
            get { return _slozType; }
            set { SetField(ref _slozType, value, () => SlozType); }
        }

        public override string ToString()
        {
            return "Наценка на сложность";
        }
    }
}
