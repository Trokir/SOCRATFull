using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class CustomerOrderFile : Entity
    {
        public CustomerOrderFile()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string FileName { get; set; }
        public DateTime FileChangeDate { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}