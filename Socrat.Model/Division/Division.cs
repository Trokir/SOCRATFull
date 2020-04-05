using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Socrat.Model
{
    public class Division : Entity
    {
        public Division()
        {
            DivisionCustomers = new ObservableCollection<DivisionCustomer>();
            DivisionContacts = new ObservableCollection<DivisionContact>();
            DivisionSignatures = new ObservableCollection<DivisionSignature>();
            CoworkerPositions = new ObservableCollection<CoworkerPosition>();
        }

        private void _CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }

        private string _NameAlias;
        public string NameAlias
        {
            get { return _NameAlias; }
            set { SetField(ref _NameAlias, value, () => NameAlias, () => Title); }
        }


        private string _NameShort;
        public string NameShort
        {
            get { return _NameShort; }
            set { SetField(ref _NameShort, value, () => NameShort); }
        }


        private string _NameFull;
        public string NameFull
        {
            get { return _NameFull; }
            set { SetField(ref _NameFull, value, () => NameFull); }
        }


        private string _Region;
        public string Region
        {
            get { return _Region; }
            set { SetField(ref _Region, value, () => Region); }
        }


        private string _Number;
        public string Number
        {
            get { return _Number; }
            set { SetField(ref _Number, value, () => Number); }
        } 


        private Address _address;
        private ObservableCollection<DivisionCustomer> _divisionCustomers;
        private ObservableCollection<CoworkerPosition> _coworkerPositions;
        private ObservableCollection<DivisionSignature> _divisionSignatures;
        private ObservableCollection<DivisionContact> _divisionContacts;

        public Address Address
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

        public Nullable<Guid> Address_Id
        {
            get { return Address?.Id; }
        }

        public ObservableCollection<DivisionCustomer> DivisionCustomers { get => _divisionCustomers; set => SetDivisionCustomers(value); }
        private void SetDivisionCustomers(ObservableCollection<DivisionCustomer> value)
        {
            _divisionCustomers = value;
            _divisionCustomers.CollectionChanged -= _CollectionChanged;
            _divisionCustomers.CollectionChanged += _CollectionChanged;
        }

        public ObservableCollection<CoworkerPosition> CoworkerPositions { get => _coworkerPositions; set => SetCoworkerPositions(value); }
        private void SetCoworkerPositions(ObservableCollection<CoworkerPosition> value)
        {
            _coworkerPositions = value;
            _coworkerPositions.CollectionChanged -= _CollectionChanged;
            _coworkerPositions.CollectionChanged += _CollectionChanged;
        }

        public ObservableCollection<DivisionSignature> DivisionSignatures { get => _divisionSignatures; set => SetDivisionSignatures(value); }
        private void SetDivisionSignatures(ObservableCollection<DivisionSignature> value)
        {
            _divisionSignatures = value;
            _divisionSignatures.CollectionChanged -= _CollectionChanged;
            _divisionSignatures.CollectionChanged += _CollectionChanged;
        }

        public ObservableCollection<DivisionContact> DivisionContacts { get => _divisionContacts; set => SetDivisionContacts(value); }
        private void SetDivisionContacts(ObservableCollection<DivisionContact> value)
        {
            _divisionContacts = value;
            _divisionContacts.CollectionChanged -= _CollectionChanged;
            _divisionContacts.CollectionChanged += _CollectionChanged;
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

        public override string ToString()
        {
            return _NameAlias;
        }

        protected override string GetTitle()
        {
            return $"Подразделение: {NameAlias}";
        }

        //protected override void SetChanged(bool value)
        //{
        //    if (!value)
        //    {
        //        foreach (DivisionCustomer divisionCustomer in DivisionCustomers)
        //            divisionCustomer.Changed = value;
        //        foreach (CoworkerPosition coworkerPosition in CoworkerPositions)
        //            coworkerPosition.Changed = value;
        //        foreach (DivisionSignature divisionSignature in DivisionSignatures)
        //            divisionSignature.Changed = value;
        //        foreach (DivisionContact divisionContact in DivisionContacts)
        //            divisionContact.Changed = value;
        //    }

        //    base.SetChanged(value);
        //}
    }
}