using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;
using Socrat.References.Annotations;

namespace Socrat.References
{
    public class LookupEditAssistent<T1, T2, T3> : INotifyPropertyChanged
        where T1 : class, IEntity, new()
        where T2 : class, ISelectionDialog, new()
        where T3 : class, IEntityEditor, new()
    {
        private string _title;
        private T1 _bindedEntity;
        private object _editValue;
        private Action<ITabable, DialogOutputType> onDialogOutput;
        private BarManager barManager;
        private List<T1> _valuesList;
        private string _displayMember;

        public LookUpEdit _LookupEdit { get; set; }

        public T1 BindedEntity
        {
            get => _bindedEntity;
            set => SetBindedEntity(value);
        }

        private void SetBindedEntity(T1 value)
        {
            _bindedEntity = value;
            if (_LookupEdit != null)
                _LookupEdit.EditValue = _bindedEntity;
            OnPropertyChanged("BindedEntity");
        }

        public LookupEditAssistent(LookUpEdit editor, string displayMember, Action<ITabable, DialogOutputType> onDialogOutput)
        {
            _LookupEdit = editor;
            _displayMember = displayMember;
            InitButtons();
            InitSettings();
            InitData();
            if (_LookupEdit != null)
                _LookupEdit.EditValueChanged += CxButtonLookupEdit_EditValueChanged;
            this.onDialogOutput = onDialogOutput;
        }

        private void InitSettings()
        {
            _LookupEdit.Properties.DisplayMember = _displayMember;
            _LookupEdit.Properties.KeyMember = "Id";
            _LookupEdit.Properties.Columns.Clear();
            _LookupEdit.Properties.Columns.Add(new LookUpColumnInfo(_displayMember, _displayMember));
            _LookupEdit.Properties.ShowHeader = false;
            _LookupEdit.Properties.ShowFooter = false;
        }

        private void InitData()
        {
            _valuesList = DataHelper.GetAll<T1>();
            _LookupEdit.Properties.DataSource = null;
            _LookupEdit.Properties.DataSource = _valuesList;
        }

        private void CxButtonLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_LookupEdit != null && _LookupEdit.EditValue != null &&
                Guid.TryParse(_LookupEdit.EditValue.ToString(), out _id))
            {
                _bindedEntity = _valuesList.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void InitButtons()
        {
            if (_LookupEdit == null)
                return;

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
            _LookupEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Search,
                    "", -1, true, true, false, editorButtonImageOptions3,
                    new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9,
                    serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "",
                    1,
                    null, DevExpress.Utils.ToolTipAnchor.Default),
                new DevExpress.XtraEditors.Controls.EditorButton(
                    DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis,
                    "", -1, true, true, false, editorButtonImageOptions2,
                    new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5,
                    serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "",
                    "0",
                    null, DevExpress.Utils.ToolTipAnchor.Default)
                
            });
            _LookupEdit.ButtonClick += CxButtonLookupEdit_ButtonClick;
        }

        private void CxButtonLookupEdit_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int _tag;
            if (int.TryParse(e.Button.Tag?.ToString(), out _tag))
            {
                switch (_tag)
                {
                    case 0:
                        SelectItem();
                        break;
                    case 1:
                        OpenItem();
                        break;
                }
            }
        }

        private void SelectItem()
        {
            ISelectionDialog _fx = GetSelectionForm();
            _fx.SetSingleSelectMode(BindedEntity);
            _fx.ItemSelected += (sender, args) =>
            {
                BindedEntity = _fx.SelectedItem as T1;
                if (_LookupEdit != null)
                    _LookupEdit.EditValue = BindedEntity?.Id;
            };
            _fx.DialogOutput += (sender, ta) => { OnDialogOutput(ta.NewTab, ta.OutputType); };
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void OnDialogOutput(ITabable taNewTab, DialogOutputType taOutputType)
        {
            if (onDialogOutput != null)
                onDialogOutput(taNewTab, taOutputType);
        }

        private ISelectionDialog GetSelectionForm()
        {
            return Activator.CreateInstance<T2>();
        }

        public string Title
        {
            get => "SwissKnifeEdit";
        }

        private void LookUpItems()
        {
            List<T1> _items = DataHelper.GetAll<T1>().ToList();

            PopupMenu _popupMenu = new PopupMenu((BarManager)_LookupEdit.MenuManager);
            BarButtonItem _buttonItem;
            foreach (T1 item in _items)
            {
                _buttonItem = new BarButtonItem((BarManager)_LookupEdit.MenuManager, item.ToString());
                _buttonItem.Tag = item;
                _buttonItem.ItemClick += ButtonItemOnItemClick;
                _popupMenu.AddItem(_buttonItem);
            }
            Point _point = _LookupEdit.PointToScreen(_LookupEdit.Location);
            //(BarManager)_LookUpEdit.MenuManager
            _popupMenu.ShowPopup(_point);

        }

        private void ButtonItemOnItemClick(object sender, ItemClickEventArgs e)
        {
            BindedEntity = e.Item.Tag as T1;
        }

        private IEntityEditor GetEditor()
        {
            return Activator.CreateInstance<T3>();
        }

        private void OpenItem()
        {
            if (BindedEntity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = BindedEntity;
                _fx.SaveButtonClick += (o, args) => SaveEntity(BindedEntity);
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
        }

        private void SaveEntity(IEntity bindedEntity)
        {
            DataHelper.Save((T1)bindedEntity);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Привязка данных через лямбда-синтаксис
        /// </summary>
        /// <typeparam name="T">тиб объекта данных</typeparam>
        /// <typeparam name="P">тип свойства объекта данных</typeparam>
        /// <param name="editor">редактор</param>
        /// <param name="obj">объект данных</param>
        /// <param name="selectorExpression">лямбда-селектор свойства объекта данных</param>
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
            editor.DataBindings.Add("BindedEntity", obj, me.Member.Name, true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }

}