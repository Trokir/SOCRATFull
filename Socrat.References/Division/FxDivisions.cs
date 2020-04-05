
using Socrat.Core;

namespace Socrat.References.Division
{
    public partial class FxDivisions : FxGenericListTable<Core.Entities.Division>
    {

        public FxDivisions()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Подразделение", "AliasName", 160, 0);
            AddColumn("Регион", "Region", 140, 1);
            AddColumn("Город", "City", 140, 3);
            AddColumn("Фактический адрес", "Address", 250, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxDivisionEdit();
        }
    }
}