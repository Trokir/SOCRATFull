using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Division
{
    public partial class FxWorkPositions : FxGenericListTable<WorkPosition>
    {
        public FxWorkPositions()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Должность", "Name", 250, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxWorkPositionEdit();
        }

        protected override string GetTitle()
        {
            return "Справочник должностей";
        }
    }
}