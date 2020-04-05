using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Params
{
    public partial class FxParams : FxBaseForm
    {
        private List<Core.Entities.Division> _divisions;

        public FxParams()
        {
            InitializeComponent();

            Load += FxParams_Load;
        }

        private void FxParams_Load(object sender, EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<Core.Entities.Division> _repo = _factory.CreateRepository<IRepository<Core.Entities.Division>>();
                _divisions = _repo.GetAll().ToList();

                lueDivision.Properties.DataSource = null;
                lueDivision.Properties.DataSource = _divisions;
            }

            UpdateGrid();

            seOrderNumber.Value = string.IsNullOrEmpty(AppParams.Params[ParamAlias.OrderNumber])
                ? 0
                : decimal.Parse(AppParams.Params[ParamAlias.OrderNumber]);

            if (!string.IsNullOrEmpty(AppParams.Params[ParamAlias.CurrentDivision]))
                lueDivision.EditValue = Guid.Parse(AppParams.Params[ParamAlias.CurrentDivision]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppParams.Params.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult _dlgRes = XtraMessageBox.Show("Сохранить сделанные изменения?", "Сохранение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dlgRes == DialogResult.OK)
                AppParams.Params.Save();
            else
                AppParams.Params.Revert();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AppParams.Params.AddNew();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            gcParams.DataSource = null;
            gcParams.DataSource = AppParams.Params.GetItems();
        }

        private void seOrderNumber_EditValueChanged(object sender, EventArgs e)
        {
            AppParams.Params[ParamAlias.OrderNumber] = seOrderNumber.EditValue != null  
                ? seOrderNumber.EditValue.ToString()
                : "0";
        }

        private void lueDivision_EditValueChanged(object sender, EventArgs e)
        {
            AppParams.Params[ParamAlias.CurrentDivision] = lueDivision.EditValue != null
                ? lueDivision.EditValue.ToString()
                : "0";
        }
    }
}