using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Data.Model
{
    public class CatalogShape : Entity
    {
        public CatalogShape()
        {
            CatalogShapePoints = new HashSet<CatalogShapePoint>();
        }

        public int SidesCount { get; set; }
        public int CatalogNumber { get; set; }
        public bool IsCatalogShape { get; set; }
        public byte[] ShapeImage { get; set; }
        public Guid? FormTypeId { get; set; }
        public virtual FormType FormType { get; set; }
        public virtual ICollection<CatalogShapePoint> CatalogShapePoints { get; }

     //   public bool Selected { get; set; }
        public virtual CatalogShapeParam CatalogShapeParam { get; set; }
    }
}