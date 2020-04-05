using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Currency : Entity
    {
        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { SetField(ref _alias, value, () => Alias, () => Title); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        protected override string GetTitle()
        {
            return "Валюта: " + Alias;
        }
        public virtual ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
