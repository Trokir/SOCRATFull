using System;

namespace Socrat.Data.Model
{
    public class PriceLog : Entity
    {
        public DateTime? Date { get; set; }
        public string Editor { get; set; }
        public Guid? PricePeriodId { get; set; }
        public Guid? PriceTypeId { get; set; }
        public Guid? MaterialNomId { get; set; }
        public Guid? PriceValueId { get; set; }
        public double? OldValue { get; set; }
        public virtual MaterialNom MaterialNom { get; set; }
        public virtual PricePeriod PricePeriod { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual PriceValue PriceValue { get; set; }
    }
}