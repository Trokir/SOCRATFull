using System;

namespace Socrat.Data.Model
{
    public class CustomerCoworker : Entity
    {
        public Guid CustomerId { get; set; }
        public Guid CoworkerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Coworker Coworker { get; set; }
    }
}