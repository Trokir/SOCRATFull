using System;

namespace Socrat.Core.Entities.Tender
{
    public class TenderCustomer: Entity
    {
        private Tender _Tender;
        [ParentItem]
        public virtual Tender Tender
        {
            get { return _Tender; }
            set { SetField(ref _Tender, value, () => Tender); }
        }
        public Guid TenderId { get; set; }


        private Customer _Customer;
        [ParentItem]
        public virtual Customer Customer
        {
            get { return _Customer; }
            set { SetField(ref _Customer, value, () => Customer); }
        }
        public Guid CustomerId { get; set; } 


    }
}