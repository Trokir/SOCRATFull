using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Order
{
    public partial class FxOrderStatuses : FxGenericListTable<OrderStatus>
    {
        public FxOrderStatuses()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Номер", "OrderNum", 60, 0);
            AddColumn("Наименование", "Name", 200, 1);
            AddColumn("Пояснение", "Description", 200, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new  FxOrderStatusEditor();
        }

        protected override string GetTitle()
        {
            return "Статусы заявки";
        }
    }
}