using System;
using Socrat.Core;

namespace Socrat.References.Bank
{
    public partial class FxCurrency : FxGenericListTable<Socrat.Core.Entities.Currency>
    {
        public FxCurrency()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Alias", 200, 0);
            AddColumn("Коментарий", "Comment", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCurrencyEdit();
        }
    }
}