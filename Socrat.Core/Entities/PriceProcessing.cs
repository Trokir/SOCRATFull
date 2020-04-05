using System;

namespace Socrat.Core.Entities
{
    public class PriceProcessing : Entity
    {
        //public Guid Id { get; set; }
        public Guid? PricePeriodId { get; set; }
        public Guid? ProcessingId { get; set; }

        private decimal? _discount;
        public decimal? Discount
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

        private DateTime? _editDate;
        public DateTime? EditDate
        {
            get { return _editDate; }
            set { SetField(ref _editDate, value, () => EditDate); }
        }

        private PricePeriod _pricePeriod;
        public virtual PricePeriod PricePeriod
        {
            get { return _pricePeriod; }
            set { SetField(ref _pricePeriod, value, () => PricePeriod); }
        }

        private Processing _processing;
        public virtual Processing Processing
        {
            get { return _processing; }
            set { SetField(ref _processing, value, () => Processing); }
        }

        public override string ToString()
        {
            return "Цена за операцию";
        }
    }
}
