using System;

namespace Socrat.Data.Model
{
    public class ProcessingTypeMaterial : Entity
    {
        public Guid ProcessingTypeId { get; set; }
        public virtual ProcessingType ProcessingType { get; set; }
        public Guid MaterialId { get; set; }
        public virtual Material Material { get; set; }
    }
}