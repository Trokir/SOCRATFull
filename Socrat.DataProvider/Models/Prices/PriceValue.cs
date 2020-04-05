using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class PriceValue : Entity
    {
        public PriceValue()
        {
            History = new HashSet<EntityChange>();
        }

        public Guid PricePeriodId { get; set; }

        public Guid PriceSelectTypeId { get; set; }

        public Guid MaterialNomId { get; set; }

        public double PriceVal { get; set; }
        public virtual MaterialNom MaterialNom { get; set; }
        public virtual PricePeriod PricePeriod { get; set; }
        public virtual PriceSelectType PriceSelectType { get; set; }
        public ICollection<EntityChange> History { get; set; }
    }
}