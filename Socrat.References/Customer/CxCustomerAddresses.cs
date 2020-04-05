using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Customer
{
    public partial class CxCustomerAddresses : CxGenericListTable<CustomerAddress>, ICustomerControl
    {
        private Core.Entities.Customer _customer;
        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public CxCustomerAddresses()
        {
            InitializeComponent();
        }

        public event EventHandler NeedFocus;

        protected override void InitColumns()
        {
            AddColumn("Адрес", "Address", 300, 0);
            AddColumn("ПУ", "IsProduction", 30, 2);
        }

        protected override ObservableCollection<CustomerAddress> GetItems()
        {
            return Customer?.CustomerAddresses;
        }

        protected override CustomerAddress GetNewInstance()
        {
            return new CustomerAddress { Customer = this.Customer, Address = new Core.Entities.Address()};
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCustomerAddressEdit();
        }
    }
}
