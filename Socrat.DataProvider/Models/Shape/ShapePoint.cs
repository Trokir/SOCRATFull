using System;

namespace Socrat.Data.Model
{
    public class ShapePoint : Entity
    {
        public string PointName { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
        public float? PointRadius { get; set; }
        public Guid? ShprossMainElementId { get; set; }
        public Guid? ShapeId { get; set; }
        public virtual Shape Shape { get; set; }
        public virtual ShprossMainElement ShprossMainElement { get; set; }
    }
}