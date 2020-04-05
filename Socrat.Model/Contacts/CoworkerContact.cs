using System;

namespace Socrat.Model
{
    public class CoworkerContact : Entity
    {
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

        private Coworker _Coworker;
        public Coworker Coworker
        {
            get { return _Coworker; }
            set { SetField(ref _Coworker, value, () => Coworker); }
        }

        public Nullable<Guid> Coworker_Id
        {
            get { return _Coworker?.Id; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        }

        protected override string GetTitle()
        {
            return $"{ContactType?.Name} {Coworker?.NameLast} {Coworker?.Initials}";
        }
    }
}