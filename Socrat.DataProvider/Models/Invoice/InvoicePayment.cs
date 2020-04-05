using System;

namespace Socrat.Data.Model
{
    public class InvoicePayment : Entity
    {
        public Guid InvoiceId { get; set; }

        public Guid PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Invoice Invoice { get; set; }

        public DateTime Dated { get; set; }

        public double Sum { get; set; }
    }
}