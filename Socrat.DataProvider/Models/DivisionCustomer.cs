using System;

namespace Socrat.Data.Model
{
    public class DivisionCustomer : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? CustomerId { get; set; }
        public bool? Default { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Division Division { get; set; }
    }
}