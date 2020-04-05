using Socrat.MVC.PrintModels.Planning;

namespace Socrat.Reports.Planning
{
    public partial class RxAssemblyPlanItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RxAssemblyPlanItem()
        {
            InitializeComponent();
        }

        private void RxAssemblyPlanItem_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentRow() is AssemblyPlanItem item)
            {
                xrFrame1HasGas.Visible = item.Frame1HasArgon;
                xrFrame2HasGas.Visible = item.Frame2HasArgon;
                if (!item.IsNewFormula)
                    formulaCell.BackColor = sizeCell.BackColor = System.Drawing.Color.Transparent;
                else
                    formulaCell.BackColor = sizeCell.BackColor = System.Drawing.Color.LightGray; ;
            }
        }
    }
}
