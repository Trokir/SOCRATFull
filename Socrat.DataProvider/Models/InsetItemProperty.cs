using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class InsetItemProperty : Entity
    {
        public InsetItemProperty()
        {
            InsetPositions = new HashSet<InsetPosition>();
        }

        public virtual InsetItem InsetItem { get; set; }
        [AutoMapper.IgnoreMap]
        public virtual ICollection<InsetPosition> InsetPositions { get; set; }
        [AutoMapper.IgnoreMap]
        public string VendorName { get; set; }
        [AutoMapper.IgnoreMap]
        public string MaterialNomName { get; set; }
    }
}