using System;

namespace Socrat.Data.Model
{
    public class CustomerFormulaEquivalent : Entity
    {
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string CustomerFormula { get; set; }
        public Guid FormulaId { get; set; }
        public virtual Formula Formula { get; set; }
    }
}