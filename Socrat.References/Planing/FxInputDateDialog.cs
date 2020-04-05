
using System;
using System.Windows.Forms;
using Socrat.UI.Core;

namespace Socrat.References.Planing
{
    public partial class FxInputDateDialog : FxBaseForm
    {
        private DateTime _date;

        public DateTime? MaxDate { get; set; }   
        public DateTime? MinDate { get; set; }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                deDate.EditValue = _date;
            }
        }

        public FxInputDateDialog()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            deDate.Properties.MinValue = MinDate ?? DateTime.Today;
            deDate.Properties.MaxValue = MaxDate ?? DateTime.Today.AddMonths(3);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Date = deDate.DateTime;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}