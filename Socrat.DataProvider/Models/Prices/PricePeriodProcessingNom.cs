using System;

namespace Socrat.Data.Model
{
    public class PricePeriodProcessingNom : Entity
    {
        public Guid PricePeriodId { get; set; }
        public Guid ProcessingNomId { get; set; }
        public double MultiplyPriceFactor { get; set; }

        public double AdditionalPriceValue { get; set; }

        public virtual PricePeriod PricePeriod { get; set; }

        public virtual ProcessingNom ProcessingNom { get; set; }


        public string DisplayName { get; set; }
    }
}