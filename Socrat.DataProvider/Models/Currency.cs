using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Currency : Entity
    {
        public Currency()
        {
            Accounts = new HashSet<Account>();
            Customers = new HashSet<Customer>();
        }

        public string Alias { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}