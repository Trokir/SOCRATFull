using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.References.Contact;
using Socrat.Core.Entities;

namespace Socrat.References.Customer
{
    public partial class CxCustomerFeedbackContacts : CxGenericListTable<CustomerContact>, ICustomerControl
    {
        public Core.Entities.Customer Customer { get; set; }
        public event EventHandler NeedFocus;

        public CxCustomerFeedbackContacts()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип контакта", "ContactType", 160, 0);
            AddColumn("Значение", "Value", 200, 1);
        }

        protected override ObservableCollection<CustomerContact> GetItems()
        {
            return Customer?.CustomerContacts;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCustomerContactEdit();
        }

        protected override CustomerContact GetNewInstance()
        {
            return new CustomerContact { Customer = Customer};
        }
    }
}
