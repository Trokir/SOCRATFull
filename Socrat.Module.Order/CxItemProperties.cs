using System;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.Module.Order
{
    public partial class CxItemProperties : DevExpress.XtraEditors.XtraUserControl, ITabable
    {
        private string _title;
        private bool _readOnly;
        public OrderRow OrderRow { get; set; }

        private Guid _ModuleId = Guid.NewGuid();
        public Guid ModuleId
        {
            set => _ModuleId = value;
            get => _ModuleId;
        }

        public CxItemProperties()
        {
            InitializeComponent();
            Load += CxItemProperties_Load;
        }

        private void CxItemProperties_Load(object sender, System.EventArgs e)
        {
            if (OrderRow.Formula != null)
                tsShowSurfaceNumbers.IsOn = OrderRow.Formula.ShowPositionsNumbers;
            BindData();
        }

        private void tsShowSurfaceNumbers_EditValueChanged(object sender, System.EventArgs e)
        {
            if (OrderRow.Formula != null)
                OrderRow.Formula.ShowPositionsNumbers = tsShowSurfaceNumbers.IsOn;
        }

        private void BindData()
        {
            //teH.DataBindings.Clear();
            //teH.DataBindings.Add("EditValue", OrderRow, "OverallH", true, DataSourceUpdateMode.OnPropertyChanged);
            //teW.DataBindings.Clear();
            //teW.DataBindings.Add("EditValue", OrderRow, "OverallW", true, DataSourceUpdateMode.OnPropertyChanged);
            teH.EditValue = OrderRow.OverallH;
            teW.EditValue = OrderRow.OverallW;
        }

        private void btnBaseSide_Click(object sender, System.EventArgs e)
        {
            FxBaseSideEdit _baseSideEdit = new FxBaseSideEdit();
            _baseSideEdit.OrderRow = OrderRow;
            OnDialogOutput(_baseSideEdit, DialogOutputType.Dialog);
        }

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }

        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            DialogOutput?.Invoke(this, ta);
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public bool ReadOnly
        {
            get => _readOnly;
            set => _readOnly = value;
        }

        private void teH_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (teH.EditValue != null && int.TryParse(teH.EditValue.ToString(), out _tmp))
                OrderRow.OverallH = _tmp;
        }

        private void teW_EditValueChanged(object sender, EventArgs e)
        {
            int _tmp = 0;
            if (teW.EditValue != null && int.TryParse(teW.EditValue.ToString(), out _tmp))
                OrderRow.OverallW = _tmp;
        }
    }
}