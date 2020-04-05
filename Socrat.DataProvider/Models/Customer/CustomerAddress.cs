using System;

namespace Socrat.Data.Model
{
    public class CustomerAddress : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public bool? IsProduction { get; set; }
        public string Comment { get; set; }
        public virtual Customer Customer { get; set; }
    }
}