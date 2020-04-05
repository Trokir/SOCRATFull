using System;

namespace Socrat.Data.Model
{
    public class InvoiceItem : Entity
    {
        public Guid InvoiceId { get; set; }
        public Guid OrderRowId { get; set; }
        public Guid InvoiceMeasurementUnitId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual OrderRow OrderRow { get; set; }
        public virtual InvoiceMeasurementUnit InvoiceMeasurementUnit { get; set; }
        public string Text { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Sum { get; set; }
        public int OrderRowHashCode { get; set; }
    }
}