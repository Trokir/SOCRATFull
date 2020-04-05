using System;

namespace Socrat.Core.Entities
{
    public class AddressContact : Entity
    {
        public Guid? AddressId { get; set; }
        public Guid? ContactTypeId { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value, () => Title); }
        }
        public Guid? WorkPositionId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private Address _address;
        public virtual Address Address
        {
            get { return _address; }
            set { SetField(ref _address, value, () => Address); }
        }
        private ContactType _contactType;
        public virtual ContactType ContactType
        {
            get { return _contactType; }
            set { SetField(ref _contactType, value, () => ContactType, () => Title); }
        }
        private WorkPosition _workPosition;
        public virtual WorkPosition WorkPosition
        {
            get { return _workPosition; }
            set { SetField(ref _workPosition, value, () => WorkPosition); }
        }
        protected override string GetTitle()
        {
            return $"Контакт: {ContactType} {Value}";
        }
    }
}
