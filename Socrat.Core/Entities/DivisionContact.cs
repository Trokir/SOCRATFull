using System;

namespace Socrat.Core.Entities
{
    public class DivisionContact : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? DepartmentTypeId { get; set; }
        public Guid? ContactTypeId { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }

        private ContactType _contactType;
        public virtual ContactType ContactType
        {
            get { return _contactType; }
            set { SetField(ref _contactType, value, () => ContactType); }
        }

        private DepartmentType _departmentType;
        public virtual DepartmentType DepartmentType
        {
            get { return _departmentType; }
            set { SetField(ref _departmentType, value, () => DepartmentType); }
        }

        [ParentItem]
        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division); }
        }

        protected override string GetTitle()
        {
            return $"Контакт подразделения {Division?.AliasName}";
        }

        public string ContactTypeTitle
        {
            get { return GetTypeTitle(); }
        }

        private string GetTypeTitle()
        {
            return string.Join(", ", new[] { DepartmentType?.Name, ContactType?.Name });
        }
    }
}
