using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Socrat.Core;

namespace Socrat.References.Customer
{
    public class CxCustomerControl : DevExpress.XtraEditors.XtraUserControl, ICustomerControl
    {
        protected bool _readOnly;
        protected Core.Entities.Customer _customer;
        protected DXErrorProvider dxErrorProvider;
        /// <summary>
        /// Признак, tru - если данные в контрол были загружены
        /// </summary>
        private bool IsLoaded { get; set; }

        public event EventHandler NeedFocus;

        public CxCustomerControl()
        {
            InitializeComponent();
            dxErrorProvider = new DXErrorProvider(this);
        }
        public bool ReadOnly
        {
            get => _readOnly;
            set => SetReadOnly(value);
        }

        private Guid _ModuleId;
        public Guid ModuleId
        {
            get => _ModuleId;
            set => _ModuleId = value;
        }

        protected virtual void SetReadOnly(bool value)
        {
            _readOnly = value;
        }

        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CxCustomerControl
            // 
            this.Name = "CxCustomerControl";
            this.Size = new System.Drawing.Size(466, 413);
            this.ResumeLayout(false);

        }

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public virtual void OnDialogOutput(ITabable outWindow, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outWindow, OutputType = outputType});
        }

        public virtual void OnDialogOutput(ITabable outWindow, DialogOutputType outputType, IWin32Window owner)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outWindow, OutputType = outputType, Owner = owner});
        }

        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            DialogOutput?.Invoke(this, ta);
        }

        #region Валидация

        private List<BaseEdit> _validateControls = null;

        protected virtual List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>(); 
        }

        protected void InitValidateControls()
        {
            if (_validateControls == null)
                _validateControls = GetControlsForValidation();

            for (int i = 0; i < _validateControls.Count; i++)
            {
                _validateControls[i].Validating += Control_Validating;
                _validateControls[i].Leave += Control_Leave;
            }
        }

        public new bool Validate()
        {
            bool res = false;
            if (_validateControls == null)
                InitValidateControls();
            if (!IsLoaded)
                LoadBeforeValidate();
            List<BaseEdit> _noValid = new List<BaseEdit>();
            for (int i = 0; i < _validateControls.Count; i++)
            {
                res = !checkEmpty(_validateControls[i]);
                //if (!res)
                //{
                //    _validateControls[i].Focus();
                //    XtraMessageBox.Show("Не заполнено обязательное поле!", "Ошибка заполнения", MessageBoxButtons.OK,
                //        MessageBoxIcon.Warning);
                //    NeedFocus?.Invoke(this, EventArgs.Empty);
                //    break;
                //}
                if (!res)
                    _noValid.Add(_validateControls[i]);
            }

            if (!res)
            {
                XtraMessageBox.Show("Не заполнено обязательное поле!", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _noValid.FirstOrDefault().Focus();
                NeedFocus?.Invoke(this, EventArgs.Empty);
            }
            return res;
        }

        private void LoadBeforeValidate()
        {
            if (!IsLoaded)
            {
                OnLoad(this, EventArgs.Empty);
            }
        }

        protected virtual void OnLoad(object sender, EventArgs e)
        {
            IsLoaded = true;
        }

        private void Control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            checkEmpty((BaseEdit)sender);
        }

        private bool checkEmpty(BaseEdit control)
        {
            if (string.IsNullOrEmpty(control.Text) || control.EditValue == null)
            {
                dxErrorProvider.SetError(control, "Необходимо заполнить");
                return true;
            }

            dxErrorProvider.SetError(control, string.Empty);
            return false;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            ((BaseEdit)sender).DoValidate();
        }

        #endregion

        public string Title
        {
            get { return GetTitle(); }
        }

        protected virtual string GetTitle()
        {
            return string.Empty;
        }
    }
}