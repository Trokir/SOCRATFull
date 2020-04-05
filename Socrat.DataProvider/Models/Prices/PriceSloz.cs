using System;

namespace Socrat.Data.Model
{
    public class PriceSloz : Entity
    {
        public Guid PriceId { get; set; }
        public Guid SlozTypeId { get; set; }
        public double? AddValueToMeasurementItem { get; set; }

        public double? MultiplyValueToEntireItem { get; set; }

        public double? AddValueToEntireItem { get; set; }
        public virtual Price Price { get; set; }

        public virtual SlozType SlozType { get; set; }
    }
}