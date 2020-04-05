using System;

namespace Socrat.Data.Model
{
    public class CustomerProp : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? CustomerPropTypeId { get; set; }
        public byte[] Value { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerPropType CustomerPropType { get; set; }
    }
}