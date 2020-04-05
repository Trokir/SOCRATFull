using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterialTypes : FxGenericListTable<MaterialType>
    {
        public FxMaterialTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 250, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxNamedEntityEdit("Группа материалов");
        }

        protected override string GetTitle()
        {
            return "Типы материалов";
        }
    }
}