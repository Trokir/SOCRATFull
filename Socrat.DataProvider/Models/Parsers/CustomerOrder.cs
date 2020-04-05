using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class CustomerOrder : Entity
    {
        public CustomerOrder()
        {
            Rows = new HashSet<CustomerOrderRow>();
        }

        public Guid CustomerOrderFileId { get; set; }
        public virtual CustomerOrderFile CustomerOrderFile { get; set; }
        public string CustomerName { get; set; }
        public string OrderCustomerNumber { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CustomerDate { get; set; }
        public string CustomerOrderId { get; set; }
        public string OrderFormula { get; set; }
        public string OrderKoment { get; set; }
        public DateTime? ReceiveTime { get; set; }
        public string CustomerOrderNumber { get; set; }
        public string CustomerOrderName { get; set; }
        public bool IsPoolList { get; set; }
        public virtual ICollection<CustomerOrderRow> Rows { get; set; }
    }
}