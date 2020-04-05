using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class Customer : Entity
    {
        public Guid? CustomerTypeId { get; set; }
        public Guid? OpfId { get; set; }
        private string _aliasName;
        [Display(Description = "Условное наименование компании")]
        public string AliasName
        {
            get { return _aliasName; }
            set { SetField(ref _aliasName, value, () => AliasName); }
        }
        private string _fullName;
        [Display(Description = "Полное наименование компании"), Required]
        public string FullName
        {
            get { return _fullName; }
            set { SetField(ref _fullName, value, () => FullName); }
        }
        private string _shortName;
        [Display(Description = "Короткое наименование компании")]
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName, () => Title); }
        }
        private string _foreignName;
        [Display(Description = "Международное наименование компании")]
        public string ForeignName
        {
            get { return _foreignName; }
            set { SetField(ref _foreignName, value, () => ForeignName); }
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Guid? CurrencyId { get; set; }
        public Guid? CountryId { get; set; }

        private string _inn;
        public string Inn
        {
            get { return _inn; }
            set { SetField(ref _inn, value, () => Inn); }
        }

        private string _kpp;
        public string Kpp
        {
            get { return _kpp; }
            set { SetField(ref _kpp, value, () => Kpp); }
        }

        private string _ogrn;
        public string Ogrn
        {
            get { return _ogrn; }
            set { SetField(ref _ogrn, value, () => Ogrn); }
        }
        public string Okpo { get; set; }
        public string TaxNumberForeign { get; set; }

        private DateTime? _dateReg;
        public DateTime? DateReg
        {
            get { return _dateReg; }
            set { SetField(ref _dateReg, value, () => DateReg); }
        }

        public Guid? ManagerId { get; set; }
        public Guid? TypeBarcodeId { get; set; }

        private string _code1C;
        public string Code1C
        {
            get { return _code1C; }
            set { SetField(ref _code1C, value, () => Code1C); }
        }
        public bool? OrderLock { get; set; }
        public bool? ProdLoсk { get; set; }
        public bool? TaxUsn { get; set; }
        public bool? TaxEnvd { get; set; }
        public bool? IsOwner { get; set; }
        public Guid? LegalAddressId { get; set; }
        public Guid? ActualAddressId { get; set; }
        public virtual ObservableCollection<Account> Accounts { get; set; } = new ObservableCollection<Account>();

        private Address _legalAddress;
        public virtual Address LegalAddress
        {
            get { return _legalAddress; }
            set
            {
                SetField(ref _legalAddress, value, () => LegalAddress);
                if (_legalAddress != null)
                {
                    _legalAddress.PropertyChanged -= _PropertyChanged;
                    _legalAddress.PropertyChanged += _PropertyChanged;
                }
            }
        }

        private void _PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Changed = true;
        }
        private Address _actualAddress;
        public virtual Address ActualAddress
        {
            get { return _actualAddress; }
            set
            {
                SetField(ref _actualAddress, value, () => ActualAddress);
                if (_actualAddress != null)
                {
                    _actualAddress.PropertyChanged -= _PropertyChanged;
                    _actualAddress.PropertyChanged += _PropertyChanged;
                }
            }
        }

        private ObservableCollection<Contract> _contracts = new ObservableCollection<Contract>();
        public virtual ObservableCollection<Contract> Contracts
        {
            get => _contracts;
            set
            {
                _contracts = value;
                if (_contracts != null)
                {
                    foreach (var _customerContract in _contracts)
                    {
                        _customerContract.Customer = this;
                        _customerContract.Changed = false;
                    }
                    _contracts.CollectionChanged -= CollectionChange;
                    _contracts.CollectionChanged += CollectionChange;
                }
            }
        }
        private Country _сountry;
        public virtual Country Country
        {
            get { return _сountry; }
            set { SetField(ref _сountry, value, () => Country); }
        }
        public virtual Currency Currency { get; set; }
        public virtual ICollection<CustomerProp> CustomerProps { get; set; } = new HashSet<CustomerProp>();
        public virtual ObservableCollection<CustomerAddress> CustomerAddresses { get; set; } = new ObservableCollection<CustomerAddress>();
        public virtual ObservableCollection<CustomerContact> CustomerContacts { get; set; } = new ObservableCollection<CustomerContact>();
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<DivisionCustomer> DivisionCustomers { get; set; } = new HashSet<DivisionCustomer>();
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; } = new HashSet<DivisionSignature>();


        private Opf _opf;
        [Display(Description = "Введите организационно праввовую форму компании"), Required]
        public Opf Opf
        {
            get { return _opf; }
            set { SetField(ref _opf, value, () => Opf, () => OpfId, () => Title); }
        }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Price> Prices { get; set; } = new HashSet<Price>();

        private Contract _actualContract;
        public Contract ActualContract
        {
            get { return GetActualContract(); }
        }
        private Contract GetActualContract()
        {
            if (null == _actualContract && Contracts.Count > 0)
            {
                _actualContract = Contracts
                    .Where(x => x.DateEnd > DateTime.Now)
                    .OrderByDescending(x => x.DateBegin)
                    .FirstOrDefault();
            }
            return _actualContract;
        }
        private ObservableCollection<Person> _personal;
        public ObservableCollection<Person> Personal
        {
            get => _personal;
            set
            {
                _personal = value;
                if (_personal != null)
                {
                    _personal.CollectionChanged -= CollectionChange;
                    _personal.CollectionChanged += CollectionChange;
                }
            }
        }
        private void CollectionChange(object sender, EventArgs e)
        {
            Changed = true;
        }
        public override string ToString()
        {
            return FullName;
        }

        public Contract GetDefaultContract(Division division)
        {
            if (division != null && Contracts != null && Contracts.Count > 0)
                return Contracts.FirstOrDefault(x => x.Division != null && x.Division.Id == division.Id && (x.Default ?? false));
            return null;
        }

        public bool HasActualContractsByDate(DateTime getActualDate)
        {
            return Contracts.Count(x => x.IsActualByDate(getActualDate)) > 0;
        }
    }
}
