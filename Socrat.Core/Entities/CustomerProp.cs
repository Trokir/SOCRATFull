using System;

namespace Socrat.Core.Entities
{
    public class CustomerProp : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? CustomerPropTypeId { get; set; }

        private byte[] _value;
        public byte[] Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get
            {
                return _customer;
            }
            set { SetField(ref _customer, value, () => Customer); }
        }

        private CustomerPropType _customerPropType;
        public virtual CustomerPropType CustomerPropType
        {
            get { return _customerPropType; }
            set { SetField(ref _customerPropType, value, () => CustomerPropType); }
        }

    }
}
