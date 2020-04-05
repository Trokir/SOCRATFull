using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxProcessings : FxGenericListTable<Processing>
    {
        public FxProcessings()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Тип материала", "Material.MaterialType", 160, 0);
            AddColumn("Код", "Code", 160, 1);
            AddColumn("Наименование", "Name", 160, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingEdit();
        }
    }
}