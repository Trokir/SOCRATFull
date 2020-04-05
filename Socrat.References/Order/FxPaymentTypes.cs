using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Order
{
    public partial class FxPaymentTypes : FxGenericListTable<PaymentType>
    {
        public FxPaymentTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxNamedEntityEdit("Тип оплаты");
        }
    }
}