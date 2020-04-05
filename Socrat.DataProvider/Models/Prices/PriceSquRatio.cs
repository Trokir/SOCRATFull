using System;

namespace Socrat.Data.Model
{
    public class PriceSquRatio : Entity
    {
        public Guid? PriceId { get; set; }
        public double Squ { get; set; }

        public double Ratio { get; set; }
        public double MinPrice { get; set; }
        public virtual Price Price { get; set; }
    }
}