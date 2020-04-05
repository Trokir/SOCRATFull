using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxBrendTradeMarks : FxGenericListTable<TradeMark>
    {
        public Brand Brand { get; set; }

        public FxBrendTradeMarks()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Материал", "Material", 200, 0);
            AddColumn("Наименование", "Name", 200, 1);
        }

    }
}