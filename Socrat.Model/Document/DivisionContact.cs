using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class DivisionContact: Entity
    {
        [ParentItem]
        private Division _Division;
        public Division Division
        {
            get { return _Division; }
            set { SetField(ref _Division, value, () => Division); }
        }

        public Nullable<Guid> Division_Id
        {
            get { return Division?.Id; }
        }

        private ContactType _ContactType;
        public ContactType ContactType
        {
            get { return _ContactType; }
            set { SetField(ref _ContactType, value, () => ContactType); }
        }

        public Nullable<Guid> ContactType_Id
        {
            get { return _ContactType?.Id; }
        }


        private DepartmentType _DepartmentType;
        public DepartmentType DepartmentType
        {
            get { return _DepartmentType; }
            set { SetField(ref _DepartmentType, value, () => DepartmentType); }
        }

        public Nullable<Guid> DepartmentType_Id
        {
            get { return DepartmentType?.Id; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        }

        protected override string GetTitle()
        {
            return $"Контакт подразделения {Division?.NameAlias}";
        }

        public string ContactTypeTitle
        {
            get { return GetTypeTitle(); }
        }

        private string GetTypeTitle()
        {
            return string.Join(", ", new[] {DepartmentType?.Name, ContactType?.Name});
        }
    }
}