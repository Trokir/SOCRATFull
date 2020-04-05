using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class DivisionCustomer: Entity
    {
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

        [ParentItem]
        private Division _Division;
        public Division Division
        {
            get { return _Division; }
            set { SetField(ref _Division, value, () => Division); }
        }

        public Nullable<Guid> Division_Id
        {
            get { return Division?.Id; }
        }

        private bool _Defoult;
        public bool Defoult
        {
            get { return _Defoult; }
            set { SetField(ref _Defoult, value, () => Defoult); }
        }

        public string CustomerName
        {
            get => Customer?.NameAlias;
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
            get => Customer?.Code_1C;
        }

        public bool CustomerClosed
        {
            get => false;
        }

        public override string ToString()
        {
            return CustomerName;
        }

        //protected override void SetChanged(bool value)
        //{
        //    if (!value)
        //    {
        //        _Customer.SetChange(value);
        //        _Division.Changed = value;
        //    }

        //    base.SetChanged(value);
        //}
    }
}