using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class Address : Entity
    {
        public Address()
        {
            AddressItems = new ObservableCollection<AddressItem>();
            AddressItems.CollectionChanged += AddressItems_CollectionChanged;
            AddressContacts = new ObservableCollection<AddressContact>();
            AddressContacts.CollectionChanged += AddressItems_CollectionChanged;
        }
        private void AddressItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
            OnPropertyChanged(() => Title);
        }
        public Guid? CountryId { get; set; }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetField(ref _zipCode, value, () => ZipCode); }
        }
        private string _valueStr;
        public string ValueStr
        {
            get { return GetValueStr(); }
            set { SetField(ref _valueStr, value, () => ValueStr); }
        }
        private string GetValueStr()
        {
            if (string.IsNullOrEmpty(_valueStr))
                _valueStr = GetStrAddress();
            return _valueStr;
        }

        public bool? IsProduction { get; set; }

        private Country _country;
        public virtual Country Country
        {
            get { return _country; }
            set { SetField(ref _country, value, () => Country); }
        }
        public virtual ObservableCollection<AddressContact> AddressContacts { get; set; }
        public virtual ObservableCollection<AddressItem> AddressItems { get; set; }
        public virtual ICollection<Bank> Banks { get; set; } = new HashSet<Bank>();
        public virtual ICollection<ContractAddress> ContractAddresses { get; set; } = new HashSet<ContractAddress>();
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Customer> Customers1 { get; set; } = new HashSet<Customer>();
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();
        public virtual ICollection<Division> Divisions { get; set; } = new HashSet<Division>();
        public virtual ICollection<Order> Orders { get; set; }
        
        private string GetStrAddress()
        {
            string address = String.Empty;
            IEnumerable<AddressItem> _items = AddressItems.OrderBy(x => x.AddressElement.AddressElementType.Sort);
            address = (Country == null || string.IsNullOrEmpty(Country.FullName)
                           ? string.Empty
                           : Country.FullName + ", ") + string.Join(", ", _items);
            return address;
        }

        protected override string GetTitle()
        {
            return "Адрес: " + GetStrAddress();
        }

        public override string ToString()
        {
            return GetStrAddress();
        }
    }
}
