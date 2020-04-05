using Socrat.Core;

namespace Socrat.References.Formula
{
    public partial class FxFormulas : FxGenericListTable<Socrat.Core.Entities.Formula>
    {
        public FxFormulas()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Формула", "FormulaStr", 160, 0);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxFormulaEdit();
        }
    }
}