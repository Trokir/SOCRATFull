using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Order
{
    public partial class FxSlozTypes : FxGenericListTable<SlozType>
    {
        public FxSlozTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Краткое наименование", "ShortName", 200, 0);
            AddColumn("Наименование", "Name", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxSlozTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Типы сложности";
        }
    }
}