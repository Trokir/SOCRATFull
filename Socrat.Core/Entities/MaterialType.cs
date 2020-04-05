using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class MaterialType : Entity, INamedEntity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        public string DbTable { get; set; }
        public virtual ICollection<Material> Materials { get; set; } = new HashSet<Material>();
        public override string ToString()
        {
            return Name;
        }
    }
}
