using System;

namespace Socrat.Core.Entities
{
    public class ProcessingTypeMaterial : Entity
    {
        public Guid ProcessingTypeId { get; set; }

        private ProcessingType _ProcessingType;
        public virtual ProcessingType ProcessingType
        {
            get { return _ProcessingType; }
            set { SetField(ref _ProcessingType, value, () => ProcessingType); }
        }

        public Guid MaterialId { get; set; }

        private Material _Material;
        public virtual Material Material
        {
            get { return _Material; }
            set { SetField(ref _Material, value, () => Material); }
        }

        protected override string GetTitle()
        {
            return $"{Material?.Name}";
        }

        public override string ToString()
        {
            return $"{Material?.Name}";
        }
    }
}