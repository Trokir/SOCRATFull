using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.UI.Core;

namespace Socrat.Parser.Configurator
{
    public partial class FxParseItemEdit : FxBaseForm
    {
        public ParseItem ParseItem { get; set; }

        public FxParseItemEdit()
        {
            InitializeComponent();

            Load += FxParseItem_Load;
        }

        private void FxParseItem_Load(object sender, System.EventArgs e)
        {
            Text += " " + ParseItem.Order.ToString();

            cbType.Properties.Items.AddRange(ParseTypes.ParseTypesList);

            cbType.EditValue = ParseItem.Type;
            teParseStr.EditValue = ParseItem.ParseStr;
            teValueStr.EditValue = ParseItem.ValueStr;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            ParseItem.ParseStr = teParseStr.EditValue?.ToString();
            ParseItem.ValueStr = teValueStr.EditValue?.ToString();
            ParseItem.Type = cbType.EditValue?.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void teValueStr_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string desc = string.Empty;
            if (cbType.EditValue != null)
                desc = ParseTypes.GetDesc(cbType.EditValue.ToString().ToUpper());
            if (desc.Length > 0)
                XtraMessageBox.Show(desc, "Инфо по операции");
        }

        private void btnTest_Click(object sender, System.EventArgs e)
        {
            teTestResult.EditValue = "";
            teTestResult.EditValue = ParseTypes.Parse(cbType.Text.ToUpper(), teParseStr.Text, teValueStr.Text, teTestInput.Text);
        }
    }
}