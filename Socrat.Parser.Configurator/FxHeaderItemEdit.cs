using System.Windows.Forms;
using Socrat.UI.Core;

namespace Socrat.Parser.Configurator
{
    public partial class FxHeaderItemEdit : FxBaseForm
    {
        public HeaderItem HeaderItem { get; set; }

        public FxHeaderItemEdit()
        {
            InitializeComponent();
            Load += FxHeaderItemEdit_Load;
        }

        private void FxHeaderItemEdit_Load(object sender, System.EventArgs e)
        {
            Text += $" {HeaderItem?.Name}";
            cbValue.EditValue = HeaderItem.ConstValue;
            seColumn.EditValue = HeaderItem.CellColumn;
            seRow.EditValue = HeaderItem.CellRow;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            HeaderItem.ConstValue = cbValue.EditValue?.ToString();
            HeaderItem.CellColumn = seColumn.EditValue?.ToString();
            HeaderItem.CellRow = seRow.EditValue?.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}