using Socrat.Core;
using Socrat.Core.Entities.Machines;
using Socrat.Core.Entities.Work;

namespace Socrat.References.Work
{
    public partial class FxTeamTypes : FxGenericListTable<TeamType>
    {
        public FxTeamTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxTeamTypeEdit() { OpenMode = openMode };
        }

        protected override string GetTitle()
        {
            return "Типы бригад";
        }
    }
}
