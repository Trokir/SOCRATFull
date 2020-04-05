using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class PriceSelectType : Entity
    {
        public PriceSelectType()
        {
            PriceValues = new HashSet<PriceValue>();
        }

        public Guid PriceId { get; set; }
        public Guid PriceTypeId { get; set; }
        public virtual ICollection<PriceValue> PriceValues { get; set; }
        public virtual PriceType PriceType { get; set; }
        public virtual Price Price { get; set; }
    }
}