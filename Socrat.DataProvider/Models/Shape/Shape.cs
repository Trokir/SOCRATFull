using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Shape : Entity
    {
        public Shape()
        {
            ShapePoints = new HashSet<ShapePoint>();
            ShprossMainElements = new HashSet<ShprossMainElement>();
            ShprossElements = new HashSet<ShprossElement>();
        }

        public int SidesCount { get; set; }
        public int CatalogNumber { get; set; }
        public bool IsCatalogShape { get; set; }
        public byte[] ShapeImage { get; set; }
        public Guid? FormTypeId { get; set; }
        public virtual FormType FormType { get; set; }
        public virtual ICollection<ShapePoint> ShapePoints { get; set; }
        public virtual ICollection<ShprossMainElement> ShprossMainElements { get; set; }
        public virtual ICollection<ShprossElement> ShprossElements { get; set; }
        public virtual OrderRow OrderRow { get; set; }
        public virtual ShapeParam ShapeParam { get; set; }
        public virtual ShapeModifedParam ShapeModifedParam { get; set; }
        public int? CrossRetainer { get; set; }
        public int? TRetainer { get; set; }
        public int? YRetainer { get; set; }
        public int? EndsRetainer { get; set; }
        public double? GrossElementsLength { get; set; }
        public double? FinalElementsLength { get; set; }
    }
}