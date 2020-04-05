using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Lib.Interfaces;
using Socrat.Log;
using Socrat.UI.Core;
using DialogOutputType = Socrat.Core.DialogOutputType;
using IEntity = Socrat.Core.IEntity;
using IEntityEditor = Socrat.Core.IEntityEditor;
using WindowOutputEventArgs = Socrat.Core.WindowOutputEventArgs;

namespace Socrat.References
{
    public partial class FxGenericListTable<T> : FxBaseForm, ISelectionDialog, ISelectionDialogFilterable<T> where T : class, IEntity, new()
    {
        public event EventHandler ItemSelected;
        public event EventHandler ItemMultiSelected;

        private CxTableList cxTableList;
        protected CxTableList CxTableList
        {
            get { return cxTableList; }
        }
        /// <summary>
        /// Условие внешней фильтрации
        /// </summary>
        public Func<T, bool> ExternalFilter { get; set; }
        public Expression<Func<T, bool>> ExternalFilterExp { get; set; }

        public List<Guid> _HighlightedRows = new List<Guid>();
        private Expression<Func<T, bool>> _rowHighlightingExp;
        /// <summary>
        /// Условие выделения курсивом
        /// </summary>
        public Expression<Func<T, bool>> RowHighlightingExp
        {
            get => _rowHighlightingExp;
            set => SetRowHighlightingExp(value);
        }

        private void SetRowHighlightingExp(Expression<Func<T, bool>> value)
        {
            _rowHighlightingExp = value;
            cxTableList.gvGrid.RowCellStyle += _gvGrid_RowCellStyle;
        }

        private void _gvGrid_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var tmp = cxTableList.gvGrid.GetRowCellValue(e.RowHandle, "Id");
            Guid _id;
            if (tmp != null && Guid.TryParse(tmp.ToString(), out _id))
            {
                if (_HighlightedRows != null && _HighlightedRows.Contains(_id))
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
            }
        }

        private IRepository<T> _repository = null;
        public IRepository<T> Repository
        {
            get { return GetRepository(); }
            set { _repository = value; }
        }

        protected List<T> _items = null;
        public List<T> Items
        {
            get
            {
                if (ExternalFilterExp != null)
                    return GetItems().Where(ExternalFilterExp.Compile()).ToList();
                return GetItems();
            }
            set { _items = value; }
        }

        protected virtual List<T> GetItems()
        {
            if (_items == null)
                _items = new List<T>();
            return _items;
        }

        private IEntity _selectedItem;
        public IEntity SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }

        private List<T> _selectedItems;
        public List<T> SelectedItems
        {
            get { return GetSelectedItems(); }
        }

        private List<T> GetSelectedItems()
        {
            Guid[] _ids = cxTableList.GetSelectedRows();
            return Items?.Where(x => _ids.Contains(x.Id)).ToList();
        }

        public FxGenericListTable()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            cxTableList.ReadOnly = this.ReadOnly;
            cxTableList.AddItemEvent += CxTableListOnAddItemEvent;
            cxTableList.OpenItemEvent += CxTableListOnOpenItemEvent;
            cxTableList.DeleteItemEvent += CxTableListOnDeleteItemEvent;
            cxTableList.SelectItemEvent += CxTableListOnSelectItemEvent;
            cxTableList.MultiSelectEvent += CxTableList_MultiSelectEvent;
            cxTableList.RefreshButtonClick += CxTableListOnRefreshButtonClick;
            cxTableList.DialogOutput += CxTableListOnDialogOutput;

            Load += OnLoad;
            cxTableList.ColumnsInitEvent += _listTable_ColumnsInitEvent;

            this.DataBindings.Clear();
            this.DataBindings.Add("Text", this, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
        }



        private void CxTableListOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void CxTableListOnRefreshButtonClick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void CxTableListOnSelectItemEvent(object sender, ListItemEventArgs e)
        {
            _selectedItem = Items.FirstOrDefault(x => x.Id == e.ItemId);
            OnItemSelected();
            DialogResult = DialogResult.OK;
            Close();
        }
        private void CxTableList_MultiSelectEvent(object sender, EventArgs e)
        {
            OnItemMultiSelected();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnItemMultiSelected()
        {
            ItemMultiSelected?.Invoke(this, EventArgs.Empty);
        }

        private void CxTableListOnDeleteItemEvent(object sender, ListItemEventArgs e)
        {
            T _entity = Items.FirstOrDefault(x => x.Id == e.ItemId);
            DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить {0}?", _entity), "Удаление", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Repository.Delete(e.ItemId);
                Items.RemoveAll(x => x.Id == e.ItemId);
                cxTableList.gvGrid.RefreshData();
                cxTableList.UpdateFooter();
            }
        }

        private void CxTableListOnOpenItemEvent(object sender, ListItemEventArgs e)
        {
            T _entity = Items.FirstOrDefault(x => x.Id == e.ItemId);
            if (_entity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;
                _fx.ReadOnly = this.ReadOnly;
                _fx.SaveButtonClick += (_sender, args) =>
                {
                    if (!_fx.Entity?.Changed ?? false)
                        return;
                    DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (_dialogResult != DialogResult.Yes || this.ReadOnly)
                    {
                        _entity = Repository.Revert(_entity);
                        return;
                    }

                    bool res = false;
                    if (_dialogResult == DialogResult.Yes)
                        res = Repository.Save(_entity);

                    RefreshData();
                    cxTableList.gvGrid.RefreshData();
                    cxTableList.UpdateFooter();
                };
                _fx.StartPosition = FormStartPosition.CenterParent;
                _fx.DialogOutput += _fx_DialogOutput;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void CxTableListOnAddItemEvent(object sender, ListItemEventArgs e)
        {
            T _entity = GetNewInstance();
            if (_entity == null)
                _entity = Activator.CreateInstance<T>();
            IEntityEditor _fx = GetEditor();
            _fx.Entity = _entity;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    bool res = Repository.Save(_entity);
                    if (res && !Items.Contains(_entity))
                        Items.Add(_entity);
                }
                RefreshData();
                cxTableList.gvGrid.RefreshData();
                cxTableList.UpdateFooter();
                if (_entity != null)
                    cxTableList.SetFocusedRow(_entity.Id);
            };
            _fx.StartPosition = FormStartPosition.CenterParent;
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        protected virtual T GetNewInstance()
        {
            return null;
        }

        protected void RefreshData()
        {
            LoadData();
            if (RowHighlightingExp != null)
                _HighlightedRows = Items.Where(RowHighlightingExp.Compile()).Select(x => x.Id).ToList();
            cxTableList.gcGrid.DataSource = null;
            cxTableList.gcGrid.DataSource = Items;
            if (SelectedItem != null)
                cxTableList.SetFocusedRow(SelectedItem.Id);
        }

        protected virtual void LoadData()
        {
            Items = Repository.GetAll().ToList();
        }


        private void OnLoad(object sender, EventArgs e)
        {
           RefreshData();
        }

        private void _listTable_ColumnsInitEvent(object sender, System.EventArgs e)
        {
            InitColumns();
        }

        protected virtual void InitColumns()
        {
        }

        protected virtual IEntityEditor GetEditor()
        {
            return null;
        }

        protected void AddColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            Type type = typeof(T);
            var prop = type.GetProperty(fieldName + "Id");
            if (prop != null)
                Logger.AddWarning($"Необходимо AddColumn заменить на AddObjectColumn в {this.Name} для поля {fieldName}");
            cxTableList.AddColumn(caption, fieldName, width, visibleIndex);
        }

        protected void AddObjectColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            cxTableList.AddObjectColumn(caption, fieldName, width, visibleIndex);
        }

        protected void GroupByColumn(string fieldName)
        {
            cxTableList.GroupByColumn(fieldName);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxGenericListTable));
            this.cxTableList = new Socrat.UI.Core.CxTableList();
            this.SuspendLayout();
            // 
            // cxTableList
            // 
            this.cxTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxTableList.FilterVisible = true;
            this.cxTableList.Location = new System.Drawing.Point(0, 0);
            this.cxTableList.MultiSelect = false;
            this.cxTableList.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.cxTableList.Name = "cxTableList";
            this.cxTableList.ReadOnly = false;
            this.cxTableList.Size = new System.Drawing.Size(892, 596);
            this.cxTableList.TabIndex = 0;
            // 
            // FxGenericListTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 596);
            this.Controls.Add(this.cxTableList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxGenericListTable";
            this.Text = "FxGenericListTable";
            this.ResumeLayout(false);

        }

        public void SetSingleSelectMode(IEntity SelectedEntity)
        {
            cxTableList.SetSingleSelectMode();
            this.Refresh();
            SelectedItem = SelectedEntity;
            if (SelectedEntity != null)
                cxTableList.SetFocusedRow(SelectedEntity.Id);
        }

        private void OnItemSelected()
        { 
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
                cxTableList.ReadOnly = value;
        }

        public T GetFocusedItem()
        {
            T res = null;
            Guid _id = cxTableList.GetCurrentRowId();
            res = Items.FirstOrDefault(x => x.Id == _id);
            return res;
        }

        private IRepository<T> GetRepository()
        {
            if (_repository == null)
                using (DataFactory _factory = new DataFactory())
                    _repository = _factory.CreateRepository<IRepository<T>>();
            return _repository;
        }
    }
}