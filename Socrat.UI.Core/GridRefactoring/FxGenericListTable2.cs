using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Common.UI;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;
using Socrat.Log;
using IEntity = Socrat.Core.IEntity;
using IEntityEditor = Socrat.Core.IEntityEditor;


namespace Socrat.UI.Core
{
    public partial class FxGenericListTable2<T> : FxBaseForm, ISelectionDialog, ISelectionDialogFilterable<T>
        where T : Entity, IEntity, new()
    {
        public event EventHandler ItemSelected;
        public event EventHandler ItemMultiSelected;

        protected CxGenericListTable<T> CxTableList { get; private set; }

        /// <summary>
        /// Условие внешней фильтрации
        /// </summary>
        public Func<T, bool> ExternalFilter { get; set; }
        public Expression<Func<T, bool>> ExternalFilterExp { get => CxTableList.ExternalFilterExp; set => CxTableList.ExternalFilterExp = value; }
        //public Expression<Func<T, bool>> ExternalFilterExp2 { get; set; }
        /// <summary>
        /// Внешнее выражение постфильтрации (после загрузки данных из базы)
        /// </summary>
        public Expression<Func<T, bool>> ExternalPostFilterExp { get; set; }

        private List<Tuple<Expression<Func<T, IEntity>>, IEntity>> _newItemInstancePresets = new List<Tuple<Expression<Func<T, IEntity>>, IEntity>>();

        /// <summary>
        /// Добавление предопределенных ссылок на сущности предков (для создания новых сущностей с предустановленными предками)
        /// </summary>
        /// <param name="property">Поле</param>
        /// <param name="reference">Значение</param>
        public void AddNewItemInstancePreset(Expression<Func<T, IEntity>> property, IEntity reference)
        {
            _newItemInstancePresets.Add(new Tuple<Expression<Func<T, IEntity>>, IEntity> (property, reference));
        }

        public PropertyChangedBase DynamicParentEntity { get; set; }

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
            CxTableList.gvGrid.RowCellStyle += _gvGrid_RowCellStyle;
        }

        private void _gvGrid_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var tmp = CxTableList.gvGrid.GetRowCellValue(e.RowHandle, "Id");
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
                {
                    var query = ExternalFilterExp.Compile();
                    return GetItems().Where(query).ToList(); 
                }
                    
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

        public IEntity SelectedItem { get; set; }        

        private List<T> GetSelectedItems()
        {
            Guid[] _ids = CxTableList.GetSelectedRows();
            return Items?.Where(x => _ids.Contains(x.Id)).ToList();
        }

        public FxGenericListTable2()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            CxTableList.ReadOnly = this.ReadOnly;
            CxTableList.SelectItemEvent += CxTableListOnSelectItemEvent;
            CxTableList.MultiSelectEvent += CxTableList_MultiSelectEvent;
            CxTableList.RefreshButtonClick += CxTableListOnRefreshButtonClick;
            CxTableList.DialogOutput += CxTableListOnDialogOutput;
            CxTableList.CommandsInitializing += (o, e) => { OnCommandsInitializing(e); };

            Load += (o,e) => RefreshData();

            DataBindings.Clear();
            DataBindings.Add("Text", this, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CxTableListOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void CxTableListOnRefreshButtonClick(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void CxTableListOnSelectItemEvent(object sender, ListItemEventArgs e)
        {
            SelectedItem = CxTableList.GetFocusedItem();
            if (SelectedItem == null)
            {
                XtraMessageBox.Show(
                    "Не допускается выбирать узловой элемент списка. Раскройте дерево списка и выберите запись подчиненного уровня.",
                    GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        protected virtual T GetNewInstance()
        {
            return null;
        }

        protected void RefreshData()
        {
            CxTableList.RefreshData();
        }

        protected virtual IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            var assy = Assembly.GetCallingAssembly();

            Type type = Assembly.GetCallingAssembly()
                      .GetTypes()
                      .FirstOrDefault(x =>
                          x.Name == $"Fx{typeof(T).Name}Edit") as Type;

            if (type == null)
            {
                Assembly assembly = Assembly.LoadFrom(@"Socrat.Module.Settings.dll");
                type = assembly?.GetTypes()
                      .FirstOrDefault(x =>
                          x.Name == ($"Fx{typeof(T).Name}Edit"));
                if (type == null)
                    return null;
            }

            if (Activator.CreateInstance(type) is IEntityEditor editor)
            {
                editor.OpenMode = openMode;
                return editor;
            }

            return null;
        }

        protected virtual IEntityEditor GetEditor(T entity, OpenMode openMode = OpenMode.Default)
        {            
            return GetEditor(openMode);
        }

        protected GridColumn AddColumn(string caption, string fieldName, int width, int visibleIndex, string tooltip = null)
        {
            Type type = typeof(T);
            var prop = type.GetProperty(fieldName + "Id");
            if (prop != null)
                Logger.AddWarning(
                    $"Необходимо AddColumn заменить на AddObjectColumn в {this.Name} для поля {fieldName}");
            return CxTableList.AddColumn(caption, fieldName, width, visibleIndex, tooltip);
        }

        protected GridColumn AddColumn(string caption, string fieldName, FormatType formatType, string formatString, int width, int visibleIndex)
        {
            Type type = typeof(T);
            var prop = type.GetProperty(fieldName + "Id");
            if (prop != null)
                Logger.AddWarning(
                    $"Необходимо AddColumn заменить на AddObjectColumn в {this.Name} для поля {fieldName}");
            return CxTableList.AddColumn(caption, fieldName, formatType, formatString, width, visibleIndex, null);
        }

        public void SortByColumn(string fieldName)
        {
            CxTableList.SortByColumn(fieldName);
        }

        protected GridColumn AddObjectColumn(string caption, string fieldName, int width, int visibleIndex, string tooltip = null)
        {
            return CxTableList.AddObjectColumn(caption, fieldName, width, visibleIndex, tooltip);
        }

        protected void GroupByColumn(string fieldName)
        {
            CxTableList.GroupByColumn(fieldName);
        }

        protected void AddColumnSummary(string fieldName)
        {
            CxTableList.AddColumnSummary(fieldName, "{n3:0}");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FxGenericListTable2));
            this.CxTableList = new CxGenericListTable<T>();
            this.SuspendLayout();
            // 
            // cxTableList
            // 
            this.CxTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CxTableList.FilterVisible = true;
            this.CxTableList.Location = new System.Drawing.Point(0, 0);
            this.CxTableList.MultiSelect = false;
            this.CxTableList.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.CxTableList.Name = "cxTableList";
            this.CxTableList.ReadOnly = false;
            this.CxTableList.Size = new System.Drawing.Size(892, 596);
            this.CxTableList.TabIndex = 0;
            // 
            // FxGenericListTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(892, 596);
            this.Controls.Add(this.CxTableList);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FxGenericListTable";
            this.Text = "FxGenericListTable";
            this.ResumeLayout(false);

        }

        public void SetSingleSelectMode(IEntity SelectedEntity)
        {
            CxTableList.SetSingleSelectMode();
            this.Refresh();
            SelectedItem = SelectedEntity;
            if (SelectedEntity != null)
                CxTableList.SetFocusedRow(SelectedEntity.Id);
        }

        private void OnItemSelected()
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
                CxTableList.ReadOnly = value;
        }

        private IRepository<T> GetRepository()
        {
            if (_repository == null)
            {               
                _repository = DataFactory.CreateUniDefaultRepository<T>();
            };
            return _repository;
        }

        protected override string GetTitle()
        {
            if (typeof(T)
                   .GetCustomAttributes(true)
                       .Where(s => s.GetType() == typeof(EntityFormConfigurationAttribute))
                       .FirstOrDefault()
                       is EntityFormConfigurationAttribute entityFormConfiguration)
            {
                Text = entityFormConfiguration.DefaultTableListFormTitle;
                return entityFormConfiguration.DefaultTableListFormTitle;
            }

            return base.GetTitle();
        }

        protected virtual void OnCommandsInitializing(List<ReferenceCommand> commands)
        {

        }
    }
}