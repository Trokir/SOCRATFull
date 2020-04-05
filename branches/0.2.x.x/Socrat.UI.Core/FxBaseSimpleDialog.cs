using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Socrat.Lib;

namespace Socrat.UI.Core
{
    public partial class FxBaseSimpleDialog : FxBaseForm, IEntityEditor
    {
        private bool _readOnly;
        protected DXErrorProvider dxErrorProvider;

        public FxBaseSimpleDialog()
        {
            InitializeComponent();
            dxErrorProvider = new DXErrorProvider(this);
            Load += FxBaseSimpleDialog_Load;
        }

        private void FxBaseSimpleDialog_Load(object sender, EventArgs e)
        {
            BindData();
            btnSave.Visible = !this.ReadOnly;
        }

        protected virtual void BindData()
        {
            if (Entity != null)
            {
                btnSave.DataBindings.Clear();
                btnSave.DataBindings.Add("Enabled", Entity, "Changed", false, DataSourceUpdateMode.OnPropertyChanged);
                
                this.DataBindings.Clear();
                this.DataBindings.Add("Text", Entity, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public event EventHandler SaveButtonClick;
        public event EventHandler PrintButtonClick;

        public IEntity Entity
        {
            get => GetEntity();
            set => SetEntity(value);
        }

        protected virtual void SetEntity(IEntity value)
        {
        }

        protected virtual IEntity GetEntity()
        {
            return null;
        }

        protected virtual void OnSaveButtonClick()
        {
            if (!Entity.Changed || ReadOnly)
                return;

            SaveButtonClick?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPrintButtonClick()
        {
            PrintButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveButtonClicked();
        }

        private bool _closeAfterSave = false;
        protected virtual void SaveButtonClicked()
        {
            if (Validate())
            {
                OnSaveButtonClick();
                _closeAfterSave = true;
                Close();
            }
        }

        private void FxBaseSimpleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closeAfterSave)
                OnSaveButtonClick();
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

        public new virtual bool Validate()
        {
            bool res = false;
            if (_validateControls == null)
                InitValidateControls();
            for (int i = 0; i < _validateControls.Count; i++)
            {
                res = !checkEmpty(_validateControls[i]);
                if (!res)
                {
                    XtraMessageBox.Show("Не заполнено обязательное поле!", "Ошибка заполнения", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    break;
                }
            }
            return res;
        }

        private void Control_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            checkEmpty((BaseEdit)sender);
        }

        private bool checkEmpty(BaseEdit control)
        {
            if (string.IsNullOrEmpty(control.Text) || control.EditValue == null)
            {
                LookUpEdit _upEdit = new LookUpEdit();
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

        public void BindEditor(BaseEdit editor, object obj, string propName)
        {
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, propName, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Привязка данных через люмбда-синтаксис
        /// </summary>
        /// <typeparam name="T">тиб обякта данных</typeparam>
        /// <typeparam name="P">тип свойства объекта данных</typeparam>
        /// <param name="editor">редактор</param>
        /// <param name="obj">объект данных</param>
        /// <param name="selectorExpression">лямбда-селестор свойства объекта данных</param>
        public void BindEditor<T, P>(BaseEdit editor, T obj, Expression<Func<T, P>> selectorExpression) where T : class
        {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            var me = selectorExpression.Body as MemberExpression;

            //внутри функции могут быть вложены свойства равные null
            if (me == null)
            {
                var ue = selectorExpression.Body as UnaryExpression;
                if (ue != null)
                    me = ue.Operand as MemberExpression;
            }

            if (me == null)
                throw new ArgumentException("Тело должно содержать Выражение(Expression)");
            editor.DataBindings.Clear();
            editor.DataBindings.Add("EditValue", obj, me.Member.Name, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void AddPrintButton(SimpleButton button)
        {
            tableLayoutPanel1.Controls.Add(button, 0, 0);
            button.Dock = DockStyle.Fill;
        }

        protected override string GetTitle()
        {
            return Entity?.Title;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
                btnSave.Hide();
        }
    }
}