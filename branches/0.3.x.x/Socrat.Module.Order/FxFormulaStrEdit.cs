using System;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxFormulaStrEdit : FxBaseForm
    {
        public event EventHandler NeedUpdateOwner;
        public OrderRow Row { get; set; }

        public FxFormulaStrEdit()
        {
            InitializeComponent();
            Load += FxFormulaEdit_Load;
        }

        private void FxFormulaEdit_Load(object sender, EventArgs e)
        {
            teFormula.EditValue = Row.FormulaStr;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Row.FormulaStr = teFormula.EditValue?.ToString();
            OnNeedUpdateOwner();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnNeedUpdateOwner()
        {
            NeedUpdateOwner?.Invoke(this, EventArgs.Empty);
        }

        private void teFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxRowFormulaEdit _fxRow = new FxRowFormulaEdit();
            if (teFormula.Text.Length > 0)
                _fxRow.Row.Formula = FormulaParser.Parse(teFormula.Text);
            OnDialogOutput(_fxRow, DialogOutputType.Dialog);
        }
    }
}