using Socrat.Common.Interfaces.Planning;
using Socrat.MVC.PrintModels.Planning;

namespace Socrat.Reports.Planning
{
    public partial class RxAssemblyPlan : DevExpress.XtraReports.UI.XtraReport
    {
        public RxAssemblyPlan()
        {
            InitializeComponent();
        }

        public RxAssemblyPlan(object parameters)
        {
            InitializeComponent();
        }

        private void RxAssemblyPlan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentRow() is AssemblyPlan plan)
                xrAssemblyPlanItems.ReportSource.DataSource = plan.Items;
        }

        private void xrHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentRow() is IPlanningActivityHeader plan)
                xrHeader.ReportSource.DataSource = new IPlanningActivityHeader[] { plan };
        }
    }
}
