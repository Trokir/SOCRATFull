using System;
using System.Windows.Forms;

namespace Socrat.References.Price
{
    public partial class CxPricePeriodSelector : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler NextPeriodRequested;
        public event EventHandler PreviousPeriodRequested;
        public event EventHandler CurrentPeriodRequested;
        public event EventHandler<DateTime> SpecificPeriodRequested; 

        public CxPricePeriodSelector()
        {
            InitializeComponent();
        }

        public DateTime FromDate
        {
            get => deSpecificPeriod.DateTime;
            set => deSpecificPeriod.DateTime = value;
        }

        public DateTime ToDate
        {
            get => dePeriodEnd.DateTime;
            set => dePeriodEnd.DateTime = value;
        }

        #region Event handlers wrappers

        protected void OnNextPeriodRequested()
        {
            NextPeriodRequested?.Invoke(this, EventArgs.Empty);
        }

        protected void OnPreviousPeriodRequested()
        {
            PreviousPeriodRequested?.Invoke(this, EventArgs.Empty);
        }

        protected void OnCurrentPeriodRequested()
        {
            CurrentPeriodRequested?.Invoke(this, EventArgs.Empty);
        }

        protected void OnSpecificPeriodRequested(DateTime dateTime)
        {
            SpecificPeriodRequested?.Invoke(this, dateTime);
        }

        #endregion

        #region Event Handlers

        private void sbPrevPeriod_Click(object sender, EventArgs e)
        {
            OnPreviousPeriodRequested();
        }

        private void sbCurrentPeriod_Click(object sender, EventArgs e)
        {
            OnCurrentPeriodRequested();
        }

        private void sbNextPeriod_Click(object sender, EventArgs e)
        {
            OnNextPeriodRequested();
        }

        #endregion

        private void deSpecificPeriod_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var date = (DateTime)deSpecificPeriod.EditValue;
                OnSpecificPeriodRequested(date);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Value you have suppplied {deSpecificPeriod.EditValue} is not DateTime value!");
            }
            
        }
    }
}
