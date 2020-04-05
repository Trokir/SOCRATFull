using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class SlozType : Entity
    {
        public SlozType()
        {
            OrderRowSlozs = new HashSet<OrderRowSloz>();
            PriceSlozs = new HashSet<PriceSloz>();
            Processings = new HashSet<Processing>();
            MaterialMarkTypes = new HashSet<MaterialMarkType>();
            Materials = new HashSet<Material>();
            WorkDifficulties = new HashSet<WorkDifficulty>();
        }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public virtual ICollection<OrderRowSloz> OrderRowSlozs { get; set; }
        public virtual ICollection<PriceSloz> PriceSlozs { get; set; }
        public virtual ICollection<Processing> Processings { get; set; }
        public virtual ICollection<MaterialMarkType> MaterialMarkTypes { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<WorkDifficulty> WorkDifficulties { get; set; }
        public string EnumCode { get; set; }
    }
}