using Socrat.Lib;
using Socrat.Model;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class CxProcessings : CxGenericListTable<Model.Processing>
    {
        public FormulaItem FormulaItem { get; set; }

        public CxProcessings()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Операции", "Title", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            FxSurfaceCoverProtectionEdit _fx = new FxSurfaceCoverProtectionEdit();
            _fx.FormulaItem = FormulaItem;
            return _fx;
        }

        protected override Processing GetNewInstance()
        {
            return new SurfaseCoverProtection();
        }
    }
}
