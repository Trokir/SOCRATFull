using System;

namespace Socrat.Core.Entities
{
    public class CustomerAddress : Entity
    {
        public Guid? CustomerId { get; set; }
        public Guid? AddressId { get; set; }

        private Address _address;
        public virtual Address Address
        {
            get { return _address; }
            set
            {
                SetField(ref _address, value, () => Address);
                _address.PropertyChanged -= _Address_PropertyChanged;
                _address.PropertyChanged += _Address_PropertyChanged;
            }
        }
        private void _Address_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.Changed = true;
            Customer.Changed = true;
        }

        private bool? _IsProduction;
        public bool? IsProduction
        {
            get { return _IsProduction; }
            set { SetField(ref _IsProduction, value, () => IsProduction); }
        }
        
        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { SetField(ref _Comment, value, () => Comment); }
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
            return "Адрес";
        }
    }
}
