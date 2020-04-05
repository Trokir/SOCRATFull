using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class CustomerOrderRow : Entity
    {
        public CustomerOrderRow()
        {
            Frames = new HashSet<CustomerOrderRowFrame>();
            CustomerOrderRowItems = new HashSet<CustomerOrderRowItem>();
        }

        public Guid CustomerOrderId { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public short? Width { get; set; }
        public short? Height { get; set; }
        public string Formula { get; set; }
        public short? Count { get; set; }
        public string Mark { get; set; }
        public string Barcode { get; set; }
        public string Comment { get; set; }
        public string CellNumber { get; set; }
        public string ProductionParty { get; set; }
        public string CartNumber { get; set; }
        public string CustNumCustomer { get; set; }
        public bool IsTender { get; set; }
        public string TenderNumber { get; set; }
        public virtual ICollection<CustomerOrderRowFrame> Frames { get; set; }
        public virtual ICollection<CustomerOrderRowItem> CustomerOrderRowItems { get; set; }
    }
}