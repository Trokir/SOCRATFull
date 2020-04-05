using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.UI.Core;
using Socrat.UI.Core.Properties;

namespace Socrat.UI.Core
{
    public partial class FxBaseEditForm : FxBaseForm, IEntityEditor
    {
        public event EventHandler SaveButtonClick;
        public event EventHandler PrintButtonClick;

        public IEntity Entity
        {
            get { return GetEntity();}
            set { SetEntity(value); }
        }

        public FxBaseEditForm()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            Load += FxBaseEditForm_Load;
        }

        private void FxBaseEditForm_Load(object sender, EventArgs e)
        {
        }

        protected virtual void OnSaveButtonClick()
        {
            if (Entity != null && Entity.Changed && !ReadOnly)
                SaveButtonClick?.Invoke(this, new EventArgs());
        }

        protected virtual void OnPrintButtonClick()
        {
            PrintButtonClick?.Invoke(this, new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveButtonClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrintButtonClick();
        }

        private void FxBaseEditForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
                OnSaveButtonClick();
        }

        protected virtual void SetEntity(IEntity value)
        {
        }

        protected virtual IEntity GetEntity()
        {
            return null;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
             btnSave.Hide();
        }
    }
}