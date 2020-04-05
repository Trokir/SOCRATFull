using DevExpress.XtraPrinting.BarCode;
using Socrat.Common;
using System.Collections;

namespace Socrat.Reports.Planning
{
    public partial class RxPyramideItem : DevExpress.XtraReports.UI.XtraReport
    {
        public RxPyramideItem()
        {
            InitializeComponent();
        }
        private void RxPyramideItem_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DataSource is IList list)
                lGrandTotal.Text = $"Итого на пирамиде {list.Count} шт.";
            else
                lGrandTotal.Text = $"Итого на пирамиде";
        }

        internal void SetbarCodeGenerator(BarCodeGeneratorBase generator)
        {
            barCode.Symbology = generator;
        }

        private void barCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentRow() is MVC.PrintModels.Planning.PyramidItem item)
            {
                if (item.PrintingMode == Common.Enums.QueuePrintingModes.PackingListWithOwnBarCode)
                    barCode.Symbology = RxPyramid.GetBarBarCodeGenerator(Preferences.OWN_BAR_CODE_TYPE_BY_DEFAULT);
                else
                {
                    if (string.IsNullOrEmpty(item.CustomerBarCode))
                        barCode.Visible = false;
                    else
                        barCode.Symbology = RxPyramid.GetBarBarCodeGenerator(item.BarCodeType);
                }
            }
        }
    }
}
