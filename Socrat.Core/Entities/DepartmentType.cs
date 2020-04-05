using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class DepartmentType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        protected override string GetTitle()
        {
            return $"Отдел: {Name}";
        }
        public virtual ICollection<DivisionContact> DivisionContacts { get; set; } = new HashSet<DivisionContact>();
    }
}
