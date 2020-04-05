using System;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class PricePeriod : Entity
    {
        public PricePeriod()
        {
            _priceLogs = new ObservableCollection<PriceLog>();
            _priceProcessings = new ObservableCollection<PriceProcessing>();
            _priceValues = new ObservableCollection<PriceValue>();
        }
        public Guid? PriceId { get; set; }

        private DateTime? _dateBegin;
        public DateTime? DateBegin
        {
            get { return _dateBegin; }
            set { SetField(ref _dateBegin, value, () => DateBegin); }
        }

        private double? _baseSpo;
        public double? BaseSpo
        {
            get { return _baseSpo; }
            set { SetField(ref _baseSpo, value, () => BaseSpo); }
        }

        private double? _baseSpd;
        public double? BaseSpd
        {
            get { return _baseSpd; }
            set { SetField(ref _baseSpd, value, () => BaseSpd); }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }
        private void CollectionChange(object sender, EventArgs e)
        {
            Changed = true;
        }

        private ObservableCollection<PriceLog> _priceLogs;
        public virtual ObservableCollection<PriceLog> PriceLogs
        {
            get => _priceLogs;
            set
            {
                _priceLogs = value;
                _priceLogs.CollectionChanged -= CollectionChange;
                _priceLogs.CollectionChanged += CollectionChange;
            }
        }
        private ObservableCollection<PriceProcessing> _priceProcessings;
        public virtual ObservableCollection<PriceProcessing> PriceProcessings
        {
            get => _priceProcessings;
            set
            {
                _priceProcessings = value;
                _priceProcessings.CollectionChanged -= CollectionChange;
                _priceProcessings.CollectionChanged += CollectionChange;
            }
        }

        private ObservableCollection<PriceValue> _priceValues;
        public virtual ObservableCollection<PriceValue> PriceValues
        {
            get => _priceValues;
            set
            {
                _priceValues = value;
                _priceValues.CollectionChanged -= CollectionChange;
                _priceValues.CollectionChanged += CollectionChange;
            }
        }

        public override string ToString()
        {
            return $"Период прайса: {DateBegin}";
        }
    }
}
