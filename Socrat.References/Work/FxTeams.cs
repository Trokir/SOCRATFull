using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities.Machines;
using Socrat.Core.Entities.Work;

namespace Socrat.References.Work
{
    public partial class FxTeams : FxGenericListTable<Team>
    {
        public FxTeams()
        {
            InitializeComponent();
            ExternalFilterExp = t => t.Division.Id == Constants.CurrentDivision.Id;
        }

        protected override void InitColumns()
        {
            AddColumn("Название", "Name", 200, 0);
            AddColumn("Номер", "Num", 200, 0);
            AddObjectColumn("Тип бригады", "TeamType", 200, 0);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxTeamEdit() { OpenMode = openMode };
        }

        protected override string GetTitle()
        {
            return "Бригады";
        }

        protected override Team GetNewInstance()
        {
            return new Team { Division = Constants.CurrentDivision, Loaded = true };

        }
        
    }
}
