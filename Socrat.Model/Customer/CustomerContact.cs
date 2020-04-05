using System;
using System.Text.RegularExpressions;
using Socrat.Lib;

namespace Socrat.Model
{
    public class CustomerContact: Entity
    {
        [ParentItem]
        private Customer _Customer;
        public Customer Customer
        {
            get { return _Customer; }
            set { SetField(ref _Customer, value, () => Customer); }
        }

        public Nullable<Guid> Customer_Id
        {
            get { return Customer?.Id; }
        }

        private ContactType _ContactType;
        public ContactType ContactType
        {
            get { return _ContactType; }
            set { SetField(ref _ContactType, value, () => ContactType); }
        }

        public Nullable<Guid> ContactType_Id
        {
            get { return ContactType?.Id; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        }

        protected override string GetTitle()
        {
            string _tmp = $"Контакт: {ContactType?.Name} {Value}";
            return Regex.Replace(_tmp, @"\s+", " ").Trim();
        }
    }
}