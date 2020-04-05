using Socrat.Common;

namespace Socrat.Reports.Invoices
{
    [Printable(
    "Счет",
    "Socrat.MVC.PrintModels",
    "Socrat.MVC.PrintModels.Invoices.Invoice",
    "Socrat.Reports",
    "Socrat.Reports.Invoices.RxInvoice")]
    public partial class RxInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public RxInvoice()
        {
            InitializeComponent();
        }

        private void xrInvoiceItems_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentRow() is MVC.PrintModels.Invoices.Invoice invoice)
            {
                if (xrInvoiceItems.ReportSource == null)
                        xrInvoiceItems.ReportSource.DataSource = invoice.Items;
            }
        }
    }
}
