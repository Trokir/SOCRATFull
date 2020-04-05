using System;

namespace Socrat.Data.Model
{
    public class CustomerContact : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public string Value { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}