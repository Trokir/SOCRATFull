
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterials : FxGenericListTable<Material>
    {
        public FxMaterials()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип", "MaterialType", 200, 0);
            AddColumn("Наименование", "Name", 200, 1);
            GroupByColumn("MaterialType");
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialEdit();
        }

        protected override string GetTitle()
        {
            return "Материалы";
        }
    }
}