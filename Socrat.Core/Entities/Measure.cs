using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Measure : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        private int? _okeiCode;
        public int? OkeiCode
        {
            get { return _okeiCode; }
            set { SetField(ref _okeiCode, value, () => OkeiCode); }
        }
        public virtual ICollection<MaterialSizeType> MaterialSizeTypes { get; set; } = new HashSet<MaterialSizeType>();
        public virtual ICollection<ProcessingType> ProcessingTypes { get; set; } = new HashSet<ProcessingType>();
        protected override string GetTitle()
        {
            return "Единица измерения: " + Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
