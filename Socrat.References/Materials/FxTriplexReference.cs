using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxTriplexReference : FxGenericListTable<MaterialNomFormula>
    { 
        public FxTriplexReference()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Номенклатура", "MaterialNom", 100, 1);
            AddObjectColumn("Производитель", "Vendor", 100, 2);
            AddObjectColumn("Формула", "Formula", 160, 3);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxMaterialNomFormulaEdit();
        }

        protected override MaterialNomFormula GetNewInstance()
        {
            return new MaterialNomFormula();
        }
    }
}