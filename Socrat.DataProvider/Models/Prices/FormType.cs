using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class FormType : Entity
    {
        public FormType()
        {
            Shapes = new HashSet<Shape>();
            PriceForms = new HashSet<PriceForm>();
            CatalogShapes = new HashSet<CatalogShape>();
        }

        public virtual ICollection<PriceForm> PriceForms { get; set; }

        public virtual ICollection<Shape> Shapes { get; set; }
        public virtual ICollection<CatalogShape> CatalogShapes { get; set; }

        public string Name { get; set; }
    }
}