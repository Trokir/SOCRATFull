using Socrat.Lib;

namespace Socrat.References.Materials
{
    public partial class FxMaterialColor : FxGenericListTable<Model.MaterialColor>
    {
        public FxMaterialColor()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("RGB", "RGB", 160, 1);
            AddColumn("RAL", "RAL", 160, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialColorEdit();
        }

        protected override string GetTitle()
        {
            return "Цвета материалов";
        }
    }
}