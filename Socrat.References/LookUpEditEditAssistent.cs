using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;
using Socrat.References.Annotations;

namespace Socrat.References
{
    /// <summary>
    /// Асистент выпадающего списка
    /// Обеспечивает заполнение списка
    /// подключение кнопок просмотра выбраноого элемента T1 в редакторе Т2
    /// выбор элемента из списка Т3
    /// </summary>
    /// <typeparam name="T1">тип элемента</typeparam>
    /// <typeparam name="T2">редактор элемента</typeparam>
    /// <typeparam name="T3">список элементов</typeparam>
    public class LookUpEditEditAssistent<T1, T2, T3> : INotifyPropertyChanged
        where T1 : class, IEntity, new()
        where T2 : class, ISelectionDialog, new()
        where T3 : class, IEntityEditor, new()

    {
        private string _title;
        private T1 _bindedEntity;
        private object _editValue;
        private Action<WindowOutputEventArgs> _OnDialogOutput;
        private BarManager barManager;
        public List<T1> _valueList;

        public LookUpEdit _LookUpEdit { get; set; }

        public T1 BindedEntity
        {
            get => _bindedEntity;
            set => SetBindedEntity(value);
        }

        private void SetBindedEntity(T1 value)
        {
            _bindedEntity = value;
            if (_LookUpEdit != null)
                _LookUpEdit.EditValue = _bindedEntity;
            OnPropertyChanged("BindedEntity");
        }

        public LookUpEditEditAssistent(LookUpEdit editor, T1 entity, Action<WindowOutputEventArgs> onDialogOutput)
        {
            _LookUpEdit = editor;
            BindedEntity = entity;
            InitButtons();
            if (_LookUpEdit != null)
                _LookUpEdit.EditValueChanged += CxButtonLookupEdit_EditValueChanged;
            _OnDialogOutput = onDialogOutput;

            _valueList = DataHelper.GetAll<T1>();
            editor.Properties.DataSource = null;
            editor.Properties.DataSource = _valueList;
        }

        private void CxButtonLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_LookUpEdit != null)
                _LookUpEdit.EditValue = _bindedEntity;
        }

        private void InitButtons()
        {
            if (_LookUpEdit == null)
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
            _LookUpEdit.Properties.Buttons.Clear();
            _LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
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
                    null, DevExpress.Utils.ToolTipAnchor.Default)
            });
            _LookUpEdit.ButtonClick += CxButtonLookupEdit_ButtonClick;
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
                _valueList = DataHelper.GetAll<T1>();

                if (!_valueList.Exists(x => x.Id == BindedEntity.Id))
                    BindedEntity = null;

                _LookUpEdit.Properties.DataSource = null;
                _LookUpEdit.Properties.DataSource = _valueList;
                if (_LookUpEdit != null)
                    _LookUpEdit.EditValue = BindedEntity;
            };
            _fx.DialogOutput += (sender, ta) => { OnDialogOutput(ta); };
            OnDialogOutput(new WindowOutputEventArgs(_fx, DialogOutputType.Dialog, null));
        }

        private void OnDialogOutput(WindowOutputEventArgs e)
        {
            if (_OnDialogOutput != null)
                _OnDialogOutput(e);
        }

        private ISelectionDialog GetSelectionForm()
        {
            return Activator.CreateInstance<T2>();
        }

        public string Title
        {
            get => "SwissKnifeEdit";
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
                OnDialogOutput(new WindowOutputEventArgs( _fx, DialogOutputType.Dialog, null));
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
    }
}