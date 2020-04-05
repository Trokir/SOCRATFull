using System;
using System.Text.RegularExpressions;

namespace Socrat.Core.Entities
{
    public class CustomerContact : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? ContactTypeId { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }

        private ContactType _contactType;
        public virtual ContactType ContactType
        {
            get { return _contactType; }
            set { SetField(ref _contactType, value, () => ContactType); }
        }

        [ParentItem]
        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }
        protected override string GetTitle()
        {
            string _tmp = $"Контакт: {ContactType?.Name} {Value}";
            return Regex.Replace(_tmp, @"\s+", " ").Trim();
        }
    }
}
