using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Payment : Entity
    {
        public Payment()
        {
            InvoicePayments = new HashSet<InvoicePayment>();
        }

        public Guid ContractId { get; set; }

        public Guid PaymentTypeId { get; set; }

        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }


        public virtual Contract Contract { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public DateTime Dated { get; set; }

        public double Sum { get; set; }

        public string IcRef { get; set; }


        public string Comments { get; set; }
    }
}