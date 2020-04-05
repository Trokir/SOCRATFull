using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Measure : Entity
    {
        public Measure()
        {
            MaterialSizeTypes = new HashSet<MaterialSizeType>();
            ProcessingTypes = new HashSet<ProcessingType>();
            ProcessingComponents = new HashSet<ProcessingComponent>();
        }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? OkeiCode { get; set; }
        public virtual ICollection<MaterialSizeType> MaterialSizeTypes { get; set; }
        public virtual ICollection<ProcessingType> ProcessingTypes { get; set; }
        public virtual ICollection<ProcessingComponent> ProcessingComponents { get; set; }
    }
}