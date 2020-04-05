using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Socrat.Core.Entities
{
    public class Bank : Entity
    {
        private string _bik;
        public string Bik
        {
            get { return _bik; }
            set { SetField(ref _bik, value, () => Bik); }
        }

        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { SetField(ref _alias, value, () => Alias, () => Title); }
        }

        private string _filial;
        public string Filial
        {
            get { return _filial; }
            set { SetField(ref _filial, value, () => Filial); }
        }

        private string _ks;
        public string Ks
        {
            get { return _ks; }
            set { SetField(ref _ks, value, () => Ks); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetField(ref _phone, value, () => Phone); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName); }
        }
        public Guid? AddressId { get; set; }

        private ObservableCollection<Account> _accounts;
        public virtual ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set => SetAccounts(value);
        }

        private void SetAccounts(ObservableCollection<Account> value)
        {
            _accounts = value;
            _accounts.CollectionChanged -= _CollectionChanged;
            _accounts.CollectionChanged += _CollectionChanged;
        }

        private void _CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }
        private Address _address;
        public Address Address
        {
            get { return _address; }
            set
            {
                SetField(ref _address, value, () => Address);
                if (_address == null)
                    return;
                _address.PropertyChanged -= AddressOnPropertyChanged;
                _address.PropertyChanged += AddressOnPropertyChanged;
            }
        }
        private void AddressOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Changed = true;
        }

        public override string ToString()
        {
            return Alias;
        }

        public void SetChanged(bool state)
        {
            _Changed = state;
            foreach (Account account in Accounts)
                account.Changed = false;
        }

        protected override string GetTitle()
        {
            return $"Карточка банка: {Alias}";
        }
    }
}
