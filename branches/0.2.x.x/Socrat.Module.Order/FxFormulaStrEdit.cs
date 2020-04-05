using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.Model;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxFormulaStrEdit : FxBaseForm
    {
        public event EventHandler NeedUpdateOwner;
        public Model.OrderRow Row { get; set; }

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
            FxFormulaEdit _fx = new FxFormulaEdit();
            if (teFormula.Text.Length > 0)
                _fx.Formula = FormulaParser.Parse(teFormula.Text);
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }
    }
}