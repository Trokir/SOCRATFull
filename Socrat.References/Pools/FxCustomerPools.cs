using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using Socrat.Core;
using Socrat.Core.Entities.Pools;
using Socrat.DataProvider;

namespace Socrat.References.Pools
{
    public partial class FxCustomerPools : FxGenericListTable<Pool>
    {
        public Core.Entities.Order Order { get; set; }

        public FxCustomerPools()
        {
            InitializeComponent();
            ReadOnly = true;
        }

        protected override void InitColumns()
        {
            AddColumn("Номер", "Num", 80, 0);
            AddColumn("Наименование", "Name", 120, 1);
            AddColumn("Дата и время", "PoolDate", FormatType.DateTime, "dd.MM.yyyy HH:mm:ss", 120, 2);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxCustomerPoolEdit();
        }

        protected override Pool GetNewInstance()
        {
            return new Pool {Customer = Order?.Customer };
        } 

        protected override List<Pool> GetItems()
        {
            if (Order != null && Order.Customer != null)
            {
                return DataHelper.GetAll<Pool>(x => x.CustomerId == Order.Customer.Id 
                        && x.PoolDate != null && Order.DateWork != null).ToList();
            }
            return new AttachedList<Pool>();
        }
    }
}