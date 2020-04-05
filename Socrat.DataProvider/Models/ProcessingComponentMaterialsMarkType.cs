using System;

namespace Socrat.Data.Model
{
    public class ProcessingComponentMaterialsMarkType : Entity
    {
        public Guid ProcessingId { get; set; }
        public virtual Processing Processing { get; set; }
        public Guid MaterialMarkTypeId { get; set; }
        public virtual MaterialMarkType MaterialMarkType { get; set; }
        public Guid? MaterialId { get; set; }
        public Material Material { get; set; }
    }
}