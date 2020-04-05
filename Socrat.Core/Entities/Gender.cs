using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Gender : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        public virtual ICollection<Coworker> Coworkers { get; set; } = new HashSet<Coworker>();
    }
}
