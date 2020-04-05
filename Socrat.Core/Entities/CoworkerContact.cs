using System;

namespace Socrat.Core.Entities
{
    public class CoworkerContact : Entity
    {
        public Guid? CoworkerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public Guid? TimeRangeId { get; set; }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        }

        private ContactType _ContactType;
        public virtual ContactType ContactType
        {
            get { return _ContactType; }
            set { SetField(ref _ContactType, value, () => ContactType); }
        }

        private Coworker _Coworker;
        public virtual Coworker Coworker
        {
            get { return _Coworker; }
            set { SetField(ref _Coworker, value, () => Coworker); }
        }

        private TimeRange _TimeRange;
        public virtual TimeRange TimeRange
        {
            get { return _TimeRange; }
            set { SetField(ref _TimeRange, value, () => TimeRange); }
        }

        protected override string GetTitle()
        {
            return $"Контакт сотрудника:{Coworker}";
        }
    }
}
