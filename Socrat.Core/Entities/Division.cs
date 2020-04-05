using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class Division : Entity
    {
        public Division()
        {
            _divisionCustomers = new ObservableCollection<DivisionCustomer>();
            _divisionContacts = new ObservableCollection<DivisionContact>();
            _divisionSignatures = new ObservableCollection<DivisionSignature>();
            _coworkerPositions = new ObservableCollection<CoworkerPosition>();
            _contracts = new ObservableCollection<Contract>();
        }
        private void _CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }
        private string _aliasName;
        public string AliasName
        {
            get { return _aliasName; }
            set { SetField(ref _aliasName, value, () => AliasName, () => Title); }
        }
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName); }
        }
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { SetField(ref _fullName, value, () => FullName); }
        }
        public string Region { get; set; }
        public Guid? AddressId { get; set; }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { SetField(ref _number, value, () => Number); }
        }

        private Address _address;
        public virtual Address Address
        {
            get { return _address; }
            set
            {
                SetField(ref _address, value, () => Address);
                if (_address != null)
                {
                    _address.PropertyChanged -= _address_PropertyChanged;
                    _address.PropertyChanged += _address_PropertyChanged;
                }
            }
        }

        private void _address_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Changed = true;
        }

        private ObservableCollection<Contract> _contracts;
        public virtual ObservableCollection<Contract> Contracts { get => _contracts; set => SetContracts(value); }
        private void SetContracts(ObservableCollection<Contract> value)
        {
            _contracts = value;
            _contracts.CollectionChanged -= _CollectionChanged;
            _contracts.CollectionChanged += _CollectionChanged;
        }


        private ObservableCollection<CoworkerPosition> _coworkerPositions;
        public virtual ObservableCollection<CoworkerPosition> CoworkerPositions { get => _coworkerPositions; set => SetCoworkerPositions(value); }
        private void SetCoworkerPositions(ObservableCollection<CoworkerPosition> value)
        {
            _coworkerPositions = value;
            _coworkerPositions.CollectionChanged -= _CollectionChanged;
            _coworkerPositions.CollectionChanged += _CollectionChanged;
        }

        private ObservableCollection<DivisionContact> _divisionContacts;
        public virtual ObservableCollection<DivisionContact> DivisionContacts { get => _divisionContacts; set => SetDivisionContacts(value); }
        private void SetDivisionContacts(ObservableCollection<DivisionContact> value)
        {
            _divisionContacts = value;
            _divisionContacts.CollectionChanged -= _CollectionChanged;
            _divisionContacts.CollectionChanged += _CollectionChanged;
        }

        private ObservableCollection<DivisionCustomer> _divisionCustomers;
        public virtual ObservableCollection<DivisionCustomer> DivisionCustomers { get => _divisionCustomers; set => SetDivisionCustomers(value); }
        private void SetDivisionCustomers(ObservableCollection<DivisionCustomer> value)
        {
            _divisionCustomers = value;
            _divisionCustomers.CollectionChanged -= _CollectionChanged;
            _divisionCustomers.CollectionChanged += _CollectionChanged;
        }

        private ObservableCollection<DivisionSignature> _divisionSignatures;
        public virtual ObservableCollection<DivisionSignature> DivisionSignatures { get => _divisionSignatures; set => SetDivisionSignatures(value); }
        private void SetDivisionSignatures(ObservableCollection<DivisionSignature> value)
        {
            _divisionSignatures = value;
            _divisionSignatures.CollectionChanged -= _CollectionChanged;
            _divisionSignatures.CollectionChanged += _CollectionChanged;
        }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>();
        public override string ToString()
        {
            return _aliasName;
        }

        protected override string GetTitle()
        {
            return $"Подразделение: {AliasName}";
        }

        public string City
        {
            get { return GetCity(); }
        }

        private string GetCity()
        {
            if (Address == null)
                return null;
            var _cityItem = Address.AddressItems.FirstOrDefault(x =>
                x.AddressElement.AddressElementType.Enum == AddressElementTypeEnum.City);
            if (_cityItem != null)
                return _cityItem.Value;
            return null;
        }

        public bool IsDivisionCustomer(Customer customer)
        {
            return customer != null 
                && Contracts != null 
                && Contracts.Count(x => x != null && x.Customer != null && x.Customer.Id == customer.Id) > 0;
        }

        public bool IsDivisionContract(Contract contract)
        {
            return contract != null 
                && Contracts != null 
                && Contracts.Count(x => x != null && x.Id == contract.Id) > 0;
        }

        public IEnumerable<Contract> GetActualContracts(DateTime actualDate)
        {
            if (Contracts != null && Contracts.Count > 0)
                return Contracts.Where(x => x.DateBegin <= actualDate && (x.DateEnd == null || actualDate <= x.DateEnd));
            return new Contract[]{};
        }
    }
}
