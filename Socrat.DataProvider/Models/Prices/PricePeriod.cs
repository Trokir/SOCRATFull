using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class PricePeriod : Entity
    {
        public PricePeriod()
        {
            BaseSpo = 0;
            BaseSpd = 0;
            PricePeriodProcessingNoms = new HashSet<PricePeriodProcessingNom>();
            PriceValues = new HashSet<PriceValue>();
        }

        public Guid? PriceId { get; set; }

        public virtual ICollection<PricePeriodProcessingNom> PricePeriodProcessingNoms { get; set; }

        public virtual ICollection<PriceValue> PriceValues { get; set; }

        public DateTime? DateBegin { get; set; }

        public double? BaseSpo { get; set; }

        public double? BaseSpd { get; set; }

        public virtual Price Price { get; set; }
    }
}