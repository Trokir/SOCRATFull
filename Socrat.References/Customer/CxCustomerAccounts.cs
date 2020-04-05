using System;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Bank;

namespace Socrat.References.Customer
{
    /// <summary>
    /// Шаблон табличного списка (справочника)
    /// </summary>
    public partial class CxCustomerAccounts : CxGenericListTable<Account>, ICustomerControl
    {
        public event EventHandler NeedFocus;

        private Core.Entities.Customer _customer;
        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Банк", "Bank", 140, 0);
            AddColumn("Рас.счет", "Rs", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxAccountEdit(true);
        }

        protected override Account GetNewInstance()
        {
            return new Account { Customer = _customer };
        }

        protected override ObservableCollection<Account> GetItems()
        {
            return _customer.Accounts;
        }
    }
}
