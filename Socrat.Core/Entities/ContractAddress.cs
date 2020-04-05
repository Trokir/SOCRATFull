using System;
using System.ComponentModel;

namespace Socrat.Core.Entities
{
    public class ContractAddress : Entity
    {
        public Guid? ContractId { get; set; }
        public Guid? AddressId { get; set; }

        private string _district;
        public string District
        {
            get { return _district; }
            set { SetField(ref _district, value, () => District); }
        }

        private string _distanceMark;
        public string DistanceMark
        {
            get { return _distanceMark; }
            set { SetField(ref _distanceMark, value, () => DistanceMark); }
        }

        private int? _distanceLength;
        public int? DistanceLength
        {
            get { return _distanceLength; }
            set { SetField(ref _distanceLength, value, () => DistanceLength); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
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
                    _address.PropertyChanged -= AddressOnPropertyChanged;
                    _address.PropertyChanged += AddressOnPropertyChanged;
                }
            }
        }
        private void AddressOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Changed = true;
        }

        [ParentItem]
        private Contract _contract;
        public virtual Contract Contract
        {
            get { return _contract; }
            set { SetField(ref _contract, value, () => Contract); }
        }

        protected override string GetTitle()
        {
            return "Адрес";
        }
    }
}
