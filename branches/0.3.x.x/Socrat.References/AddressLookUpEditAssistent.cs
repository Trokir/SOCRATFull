using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;
using Socrat.References.Address;
using Socrat.References.Annotations;

namespace Socrat.References
{
    public class AddressLookUpEditAssistent : INotifyPropertyChanged
    {
        private string _title;

        /// <summary>
        /// Значение поля
        /// </summary>
        private Core.Entities.Address _value;

        /// <summary>
        /// Делегат вывода
        /// </summary>
        private Action<ITabable, DialogOutputType> onDialogOutput;

        /// <summary>
        /// ссылка на связанный объект
        /// </summary>
        public object Obj { get; set; }

        /// <summary>
        /// связаное поле
        /// </summary>
        public string ObjProperty { get; set; }

        private BarManager barManager;

        public LookUpEdit LookupEdit { get; set; }

        private EditorButton[] _editorButtons;
        private Expression<Func<Core.Entities.Address, bool>> _externalFilterExp;

        private List<Core.Entities.Address> _Addresses = new List<Core.Entities.Address>();
        //public List<Core.Entities.Address> Addresses
        //{
        //    get { return _Addresses; }
        //    set { _Addresses = value; }
        //}

        public Func<List<Core.Entities.Address>> GetAddtressesMethod { get; set; }

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

        public AddressLookUpEditAssistent(LookUpEdit editor, Core.Entities.Address entity,
            Func<List<Core.Entities.Address>> getAddtressesMethod,  Action<ITabable, DialogOutputType> onDialogOutput)
        {
            LookupEdit = editor;
            _value = entity;
            GetAddtressesMethod = getAddtressesMethod;
            UpdateLookUpItemsData();
            LookupEdit.EditValue = entity?.Id;
            InitButtons();
            if (LookupEdit != null)
            {
                LookupEdit.EditValueChanged += CxButtonLookupEdit_EditValueChanged;
                LookupEdit.DoubleClick += LookupEdit_DoubleClick;
                LookupEdit.BeforePopup += LookupEdit_BeforePopup;
            }
            SetClearButtonVisible();
            this.onDialogOutput = onDialogOutput;
        }

        private void LookupEdit_BeforePopup(object sender, EventArgs e)
        {
            UpdateLookUpItemsData();
        }

        private void UpdateLookUpItemsData()
        {
            LookupEdit.Properties.DataSource = null;
            LookupEdit.Properties.DataSource = GetAddtressesMethod?.Invoke();
            _Addresses = GetAddtressesMethod?.Invoke();
        }

        private void LookupEdit_DoubleClick(object sender, EventArgs e)
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
                    LookupEdit.EditValue = _value.Id;
                    if (Obj != null)
                        Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, _value);
                }
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e.NewTab, e.OutputType);
        }

        private void CxButtonLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            SetClearButtonVisible();
            Guid _id;
            if (_Addresses != null && LookupEdit.EditValue != null
                                   && Guid.TryParse(LookupEdit.EditValue.ToString(), out _id))
            {
                _value = _Addresses.FirstOrDefault(x => x.Id == _id);
                Obj.GetType().GetProperty(ObjProperty)?.SetValue(Obj, _value);
            } 
        }

        private void SetClearButtonVisible()
        {
            if (_editorButtons != null)
                _editorButtons.FirstOrDefault(x => x.Kind == ButtonPredefines.Clear).Visible =
                    LookupEdit.EditValue != null;
        }

        private void InitButtons()
        {
            if (LookupEdit == null)
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
                    null, DevExpress.Utils.ToolTipAnchor.Default)
            };

            //LookupEdit.Properties.Buttons.Clear();
            LookupEdit.Properties.Buttons.AddRange(_editorButtons);
            LookupEdit.ButtonClick += CxButtonLookupEdit_ButtonClick;
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
                default:
                    UpdateLookUpItemsData();
                    LookupEdit.ShowPopup();
                    break;
            }
        }

        private void Clear()
        {
            _value = null;
            Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, null);
            LookupEdit.EditValue = null;
        }

        private void SelectItem()
        {
            FxAddresses _fx = new FxAddresses();
            _fx.GetAddressesMethod = GetAddtressesMethod;
            _fx.SetSingleSelectMode(_value);
            _fx.ItemSelected += (sender, args) =>
            {
                _value = _fx.SelectedItem as Core.Entities.Address;
                if (LookupEdit != null)
                    LookupEdit.EditValue = _value.Id;
                Obj.GetType().GetProperty(ObjProperty).SetValue(Obj, _value);
            };
            _fx.DialogOutput += (sender, ta) => { OnDialogOutput(ta.NewTab, ta.OutputType); };
            _fx.ExternalFilterExp = _externalFilterExp;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void OnDialogOutput(ITabable taNewTab, DialogOutputType taOutputType)
        {
            if (onDialogOutput != null)
                onDialogOutput(taNewTab, taOutputType);
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
                _fx.SaveButtonClick += (o, args) => SaveEntity(_value);
                OnDialogOutput(_fx, DialogOutputType.Dialog);
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
                    LookupEdit.EditValue = _value.Id;
                }
            }
        }
    }
}