using System;
using System.Windows.Forms;
using Socrat.Parser;
using Socrat.UI.Core;

namespace Socrat.References.Parsers
{
    public partial class FxDetailEdit : FxBaseForm
    {
        private Detail _detail;
        public Detail Detail
        {
            get => _detail;
            set => SetDetail(value);
        }

        private void SetDetail(Detail value)
        {
            _detail = value;
            UpdateView();
        }

        private void UpdateView()
        {
            if (Detail == null)
                return;
            Text = $"Ячейка №{Detail.Name}";
            teLabel.EditValue = Detail.LabelString;
            seColumn.EditValue = Detail.CellColumn;
            seRow.EditValue = Detail.DeltaRow;
        }

        public FxDetailEdit()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void teLabel_EditValueChanged(object sender, EventArgs e)
        {
            Detail.LabelString = teLabel.EditValue?.ToString();
        }

        private void seColumn_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (seColumn.EditValue != null && int.TryParse(seColumn.EditValue.ToString(), out _tmp))
                Detail.CellColumn = _tmp;
        }

        private void seRow_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (seRow.EditValue != null && int.TryParse(seRow.EditValue.ToString(), out _tmp))
                Detail.DeltaRow = _tmp;
        }
    }
}