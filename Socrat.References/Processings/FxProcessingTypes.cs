using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Processings
{
    public partial class FxProcessingTypes : FxGenericListTable<ProcessingType>
    {
        public FxProcessingTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddObjectColumn("Материал", "Material", 160, 1);
            AddColumn("Очередность", "Step", 80, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Типы операций";
        }
    }
}