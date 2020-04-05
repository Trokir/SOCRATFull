using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.References.Address;
using Socrat.References.Annotations;
using Socrat.UI.Core;

namespace Socrat.References
{
    public class AddressButtonEditAssistent : INotifyPropertyChanged
    {
        private string _title;

        /// <summary>
        /// Значение поля
        /// </summary>
        private Core.Entities.Address _value;

        /// <summary>
        /// Делегат вывода
        /// </summary>
        private Action<WindowOutputEventArgs> _OnDialogOutput;

        /// <summary>
        /// ссылка на связанный объект
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// связаное поле
        /// </summary>
        public string ObjProperty { get; set; }

        private BarManager barManager;

        public ButtonEdit ButtonEdit { get; set; }

        private EditorButton[] _editorButtons;
        private Expression<Func<Core.Entities.Address, bool>> _externalFilterExp;

        private List<Core.Entities.Address> _Addresses = new List<Core.Entities.Address>();

        public Func<List<Core.Entities.Address>> GetAddtressesMethod { get; set; }

        public Action<object> GetOrderAddresesList { get; set; }

        /// <summary>
        /// Условие внешней фильтрации
        /// </summary>
        public Expression<Func<Core.Entities.Address, bool>> ExternalFilterExp
        {
            get => _externalFilterExp;
            set => SetExternalFilterExp(value);
        }

        private void SetExternalFilterExp(Expression<Func<Core.Entities.Address, bool>> value)
        {
            _externalFilterExp = value;
        }

        public AddressButtonEditAssistent(ButtonEdit editor, Core.Entities.Address entity,
            Func<List<Core.Entities.Address>> getAddtressesMethod, Action<WindowOutputEventArgs> onDialogOutput)
        {
            ButtonEdit = editor;
            _value = entity;
            GetAddtressesMethod = getAddtressesMethod;
            UpdateLookUpItemsData();
            ButtonEdit.EditValue = entity;
            InitButtons();
            if (ButtonEdit != null)
            {
                ButtonEdit.EditValueChanged += CxButtonLookupEdit_EditValueChanged;
                ButtonEdit.DoubleClick += LookupEdit_DoubleClick;
            }
            SetClearButtonVisible();
            _OnDialogOutput = onDialogOutput;
        }

        private void UpdateLookUpItemsData()
        {
            _Addresses = GetAddtressesMethod?.Invoke();
        }

        private void LookupEdit_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }

        private void EditItem()
        {
            FxAddressEdit _fx = new FxAddressEdit();
            if (_value == null)
                _value = new Core.Entities.Address();
            _fx.Address = _value;
            _fx.DialogOutput += _fx_DialogOutput;
            _fx.SaveButtonClick += (o, args) =>
            {
                if (DataHelper.Save(_value))
                {
                    ButtonEdit.EditValue = _value;
                    if (Obj != null)
                        Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, _value);
                }
            };
            var _parent =  ButtonEdit.CollectParents(true).OfType<FxBaseForm>().FirstOrDefault();
            OnDialogOutput(new WindowOutputEventArgs(_fx, DialogOutputType.Modal, _parent));
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(new WindowOutputEventArgs(e.NewTab, e.OutputType, (IWin32Window)sender));
        }

        private void CxButtonLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            SetClearButtonVisible();
            Guid _id;
            if (_Addresses != null && ButtonEdit.EditValue != null
                                   && Guid.TryParse(ButtonEdit.EditValue.ToString(), out _id))
            {
                _value = _Addresses.FirstOrDefault(x => x.Id == _id);
                Obj.GetType().GetProperty(ObjProperty)?.SetValue(Obj, _value);
            }
        }

        private void SetClearButtonVisible()
        {
            if (_editorButtons != null)
            {
                _editorButtons.FirstOrDefault(x => x.Kind == ButtonPredefines.Clear).Visible =
                    ButtonEdit.EditValue != null;
                _editorButtons.FirstOrDefault(x => x.Kind == ButtonPredefines.Search).Visible =
                    ButtonEdit.EditValue != null;
                _Addresses = GetAddtressesMethod?.Invoke();
                _editorButtons.FirstOrDefault(x => x.Kind == ButtonPredefines.Ellipsis).Visible =
                    GetAddtressesMethod != null || ButtonEdit.EditValue == null;
            }
        }

        private void InitButtons()
        {
            if (ButtonEdit == null)
                return;

            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 =
                new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 =
                new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 =
                new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 =
                new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 =
                new DevExpress.Utils.SerializableAppearanceObject();


            _editorButtons = new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis,
                    "", -1, true, true, false, editorButtonImageOptions2,
                    new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5,
                    serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "",
                    "0",
                    null, DevExpress.Utils.ToolTipAnchor.Default),
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Search,
                    "", -1, true, true, false, editorButtonImageOptions3,
                    new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9,
                    serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "",
                    1,
                    null, DevExpress.Utils.ToolTipAnchor.Default),
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Clear,
                    "", -1, true, true, false, editorButtonImageOptions1,
                    new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1,
                    serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "",
                    "2",
                    null, DevExpress.Utils.ToolTipAnchor.Default),
            };

            ButtonEdit.Properties.Buttons.Clear();
            ButtonEdit.Properties.Buttons.AddRange(_editorButtons);
            ButtonEdit.ButtonClick += CxButtonLookupEdit_ButtonClick;
        }

        private void CxButtonLookupEdit_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    SelectItem();
                    break;
                case ButtonPredefines.Search:
                    OpenItem();
                    break;
                case ButtonPredefines.Clear:
                    Clear();
                    break;
            }
        }

        private void Clear()
        {
            _value = null;
            Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, null);
            ButtonEdit.EditValue = null;
        }

        private void SelectItem()
        {
            if (GetAddtressesMethod != null)
            {
                _Addresses = GetAddtressesMethod?.Invoke();
                if (GetAddtressesMethod == null || _Addresses == null || _Addresses.Count < 1)
                {
                    EditItem();
                    return;
                }

                FxAddresses _fx = new FxAddresses();
                _fx.GetAddressesMethod = GetAddtressesMethod;
                _fx.SetSingleSelectMode(_value);
                _fx.ItemSelected += (sender, args) =>
                {
                    _value = _fx.SelectedItem as Core.Entities.Address;
                    if (ButtonEdit != null)
                        ButtonEdit.EditValue = _value;
                    Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, _value);
                };
                _fx.DialogOutput += (sender, ta) => { OnDialogOutput(ta); };
                _fx.ExternalFilterExp = _externalFilterExp;
                var _parent = ButtonEdit.CollectParents(true).OfType<FxBaseForm>().FirstOrDefault();
                OnDialogOutput(new WindowOutputEventArgs(_fx, DialogOutputType.Modal, _parent));
            }
            else
            {
                GetOrderAddresesList?.Invoke(null);
            }
        }

        private void OnDialogOutput(WindowOutputEventArgs ta)
        {
            if (_OnDialogOutput != null)
                _OnDialogOutput(ta);
        }

        public string Title
        {
            get => "AddressLookupEdit";
        }

        private IEntityEditor GetEditor()
        {
            return new FxAddressEdit();
        }

        private void OpenItem()
        {
            if (_value != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _value;
                _fx.SaveButtonClick += (o, args) =>
                {
                    if (ButtonEdit != null)
                    {
                        ButtonEdit.EditValue = _fx.Entity;
                        ButtonEdit.Refresh();
                    }
                    SaveEntity(_value);
                };
                var _parent = ButtonEdit.CollectParents(true).OfType<FxBaseForm>().FirstOrDefault();
                OnDialogOutput(new WindowOutputEventArgs(_fx, DialogOutputType.Modal, _parent));
            }
        }

        private void SaveEntity(Core.Entities.Address address)
        {
            DataHelper.Save(address);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BindProperty<T1, P>(T1 obj, Expression<Func<T1, P>> selectorExpression) where T1 : class
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
            Obj = obj;
            ObjProperty = me.Member.Name;

            INotifyPropertyChanged _notifyObj = Obj as INotifyPropertyChanged;
            if (_notifyObj == null)
                throw new Exception($"В объекте {Obj} не реализоан INotifyPropertyChanged");
            _notifyObj.PropertyChanged += _notifyObj_PropertyChanged;
        }

        private void _notifyObj_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ObjProperty)
            {
                _value = Obj.GetType().GetProperty(ObjProperty).GetValue(Obj) as Core.Entities.Address;
                if (_value != null)
                {
                    UpdateLookUpItemsData();
                    ButtonEdit.EditValue = _value;
                }
            }
        }
    }
}