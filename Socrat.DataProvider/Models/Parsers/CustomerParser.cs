using System;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class CustomerParser : Entity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid ParserId { get; set; }
        public virtual Parser Parser { get; set; }
        public bool Default { get; set; }
    }
}