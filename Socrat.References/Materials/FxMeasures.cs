using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMeasures : FxGenericListTable<Measure>
    {
        public FxMeasures()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 250, 0);
            AddColumn("Код ОКЕИ", "OkeiCode", 150, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMeasureEdit();
        }

        protected override string GetTitle()
        {
            return "Единицы измерения";
        }
    }
}