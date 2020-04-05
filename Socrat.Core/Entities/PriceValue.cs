using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class PriceValue : Entity
    {
        public PriceValue()
        {
            _priceLogs = new ObservableCollection<PriceLog>();
            _priceLogs.CollectionChanged -= CollectionChange;
            _priceLogs.CollectionChanged += CollectionChange;

        }
        public Guid? PricePeriodId { get; set; }
        public Guid? PriceTypeId { get; set; }
        public Guid? MaterialNomId { get; set; }

        private double _priceVal;
        public double PriceVal
        {
            get { return _priceVal; }
            set { SetField(ref _priceVal, value, () => PriceVal); }
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

        private ObservableCollection<PriceLog> _priceLogs;
        public virtual ObservableCollection<PriceLog> PriceLogs
        {
            get => _priceLogs;
            set
            {
                _priceLogs = value;
                //_priceLogs.CollectionChanged -= CollectionChange;
                //_priceLogs.CollectionChanged += CollectionChange;
            }
        }
        private void CollectionChange(object sender, EventArgs e)
        {
            Changed = true;
        }
        public override string ToString()
        {
            return "Цена на номенклатуру раздела прайса";
        }
    }
}
