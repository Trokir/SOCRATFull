using System;
using DevExpress.XtraEditors;

namespace Socrat.References.Price
{
    public partial class CxPriceEditorTitle : XtraUserControl
    {
        /// <summary>
        /// Fires when user as to rename item by double-click on Title label
        /// </summary>
        public event EventHandler RenamingRequested;
        public event EventHandler DivisionChangingRequested;
        public event EventHandler CustomerChangingRequested;

        public CxPriceEditorTitle()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Название
        /// </summary>
        public override string Text
        {
            get => lcName.Text;
            set => lcName.Text = value;
        }

        /// <summary>
        /// Название подразделения
        /// </summary>
        public string DivisionName
        {
            get => lcDivision.Text;
            set => lcDivision.Text = value;
        }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string CustomerName
        {
            get => lcCustomer.Text;
            set => lcCustomer.Text = value;
        }

        /// <summary>
        /// Общий прайс
        /// </summary>
        public bool IsCommon
        {
            get => !lcCustomer.Visible;
            set => lcCustomer.Visible = !value;
        }

        #endregion

        #region Event wrappers

        protected void OnRenamingRequested()
        {
            RenamingRequested?.Invoke(this, EventArgs.Empty);
        }

        protected void OnDivisionChangingRequested()
        {
            DivisionChangingRequested?.Invoke(this, EventArgs.Empty);
        }

        protected void OnCustomerChangingRequested()
        {
            CustomerChangingRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Event handlers

        private void labelDivision_DoubleClick(object sender, EventArgs e)
        {
            OnDivisionChangingRequested();
        }

        private void labelCustomer_DoubleClick(object sender, EventArgs e)
        {
            OnCustomerChangingRequested();
        }
        private void labelTitle_DoubleClick(object sender, EventArgs e)
        {
            OnRenamingRequested();
        }

        #endregion
    }
}
