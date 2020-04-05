using System;

namespace Socrat.Core.Entities
{
    public class DivisionCustomer : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? CustomerId { get; set; }

        private bool? _default;
        public bool? Default
        {
            get { return _default; }
            set { SetField(ref _default, value, () => Default); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }

        [ParentItem]
        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division); }
        }
        public string CustomerName
        {
            get => Customer?.AliasName;
        }

        public string CustomerInn
        {
            get => Customer?.Inn;
        }

        public string CustomerKpp
        {
            get => Customer?.Kpp;
        }

        public string CustomerCode_1C
        {
            get => Customer?.Code1C;
        }

        public bool CustomerClosed
        {
            get => false;
        }

        public override string ToString()
        {
            return CustomerName;
        }
    }
}
