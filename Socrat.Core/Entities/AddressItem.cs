using System;

namespace Socrat.Core.Entities
{
    public class AddressItem : Entity
    {
        //public Guid Id { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? AddressElementId { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }

        [ParentItem]
        private Address _address;
        public virtual Address Address
        {
            get { return _address; }
            set { SetField(ref _address, value, () => Address); }
        }
        private AddressElement _addressElement;
        public virtual AddressElement AddressElement
        {
            get { return _addressElement; }
            set { SetField(ref _addressElement, value, () => AddressElement); }
        }
        public override string ToString()
        {
            return (AddressElement?.ShortName + " " + _value).Trim();
        }
    }
}
