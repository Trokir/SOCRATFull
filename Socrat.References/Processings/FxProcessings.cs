using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Processings
{
    public partial class FxProcessings : FxGenericListTable<Processing>
    {
        public FxProcessings()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 160, 0);
            AddObjectColumn("Тип", "ProcessingType", 160, 1);
            AddColumn("Наименование", "Name", 200, 2);
            AddColumn("Краткое", "ShortName", 100, 3);
            AddColumn("Оч.", "Step", 50, 4);
            GroupByColumn("Material");
            GroupByColumn("ProcessingType");
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingEdit();
        }

        protected override string GetTitle()
        {
            return "Операции";
        }
    }
}