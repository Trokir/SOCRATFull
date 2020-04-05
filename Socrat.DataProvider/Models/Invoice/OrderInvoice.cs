using System;

namespace Socrat.Data.Model
{
    public class OrderInvoice : Entity
    {
        public Guid OrderId { get; set; }
        public Guid InvoiceId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}