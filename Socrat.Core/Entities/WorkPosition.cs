using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class WorkPosition : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }

        public override string ToString()
        {
            return Name;
        }

        protected override string GetTitle()
        {
            return $"Должность: {Name}";
        }
        public virtual ICollection<AddressContact> AddressContacts { get; set; } = new HashSet<AddressContact>();
        public virtual ICollection<CoworkerPosition> CoworkerPositions { get; set; } = new HashSet<CoworkerPosition>();
    }
}
