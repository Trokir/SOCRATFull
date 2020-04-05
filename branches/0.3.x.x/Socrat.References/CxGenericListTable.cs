using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Commands;
using Socrat.Lib.Interfaces;
using Socrat.Log;
using Socrat.Spreadsheet;
using Socrat.UI.Core;
using BarItem = DevExpress.XtraBars.BarItem;
using DialogOutputType = Socrat.Core.DialogOutputType;
using IEntity = Socrat.Core.IEntity;
using IEntityEditor = Socrat.Core.IEntityEditor;
using ITabable = Socrat.Core.ITabable;
using WindowOutputEventArgs = Socrat.Core.WindowOutputEventArgs;

namespace Socrat.References
{
    /// <summary>
    /// Обобщенный класс табличного списка (справочника)
    /// </summary>
    public partial class CxGenericListTable<T> : XtraUserControl, ITabable, IEntitySelector
        where T : class, IEntity, new()
    {
        public event EventHandler ItemSelected;

        private FormRegime _regime = FormRegime.Edit;
        protected List<SimpleButton> WriteCommandsButtons = new List<SimpleButton>();
        protected List<BarButtonItem> WriteCommandsBarButtons = new List<BarButtonItem>();

        /// <summary>
        /// Условие внешней фильтрации
        /// </summary>
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
            _gvGrid.RowCellStyle += _gvGrid_RowCellStyle;
        }

        private void _gvGrid_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var tmp = _gvGrid.GetRowCellValue(e.RowHandle, "Id");
            Guid _id;
            if (tmp != null && Guid.TryParse(tmp.ToString(), out _id))
            {
                if (_HighlightedRows != null && _HighlightedRows.Contains(_id))
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic | FontStyle.Bold);
            }
        }

        public ObservableCollection<T> SourceItems { get; set; }
        private IRepository<T> _repository = null;
        protected IRepository<T> Repository
        {
            get
            {
                if (_repository == null)
                    using (DataFactory _factory = new DataFactory())
                        _repository = _factory.CreateRepository<IRepository<T>>();
                return _repository;
            }
        }

        private IEntity _selectedItem;
        public IEntity SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }

        /// <summary>
        /// Зависимое сохранение.
        /// Например когда элементы дочерней колекции не погут быть сохранены раньше класса родителя
        /// из-за ограничения внешнего ключа, необходимо при создании компонента устанвить св-во в true
        /// </summary>
        public bool DependedSaving { get; set; }

        public ObservableCollection<T> Items
        {
            get
            {
                if (ExternalFilterExp != null)
                    new ObservableCollection<T>(GetItems().Where(ExternalFilterExp.Compile()));
                return GetItems();
            }
        }

        protected virtual ObservableCollection<T> GetItems()
        {
            return new ObservableCollection<T>();
        }

        public event ListItemEventHandler OpenItemEvent;
        public event ListItemEventHandler AddItemEvent;
        public event ListItemEventHandler DeleteItemEvent;
        public event ListItemEventHandler SelectItemEvent;
        public event EventHandler MultiSelectEvent;
        public event EventHandler RefreshButtonClick;
        public event EventHandler ColumnsInitEvent;

        protected List<ReferenceCommand> _commands { get; set; }

        public CxGenericListTable()
        {
            InitializeComponent();
            if (Site != null && Site.DesignMode)
                return;

            InitCommamds();
            BuildCommandsControls();

            Load += CxTableList_Load;
        }

        protected virtual void InitCommamds()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Добавить", AddItemExecute, null) { Image = Properties.Resources.addfile_16x16, IsWriteCommand = true},
                new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true },
                new ReferenceCommand(MenuCommandType.Item, "Экспорт в Excel", ExpotrtToExcelExecute, null)
                    { Image = Properties.Resources.exporttoxlsx_16x16, BeginGroup = true, IsWriteCommand = true},
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отбор по значению текущей ячейки", FilterByCellValueExecute, null)
                    { Image = Properties.Resources.reapplyfilter_16x16, BeginGroup = true},
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отменить отбор", ResetFilterByCellValueExecute, null) { Image = Properties.Resources.clearfilter_16x16 },
            };
        }

        public bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { SetReadOnly(value); }
        }

        public GridControl gcGrid
        {
            get { return _gcGrid; }
        }

        public GridView gvGrid
        {
            get { return _gvGrid; }
        }

        protected virtual void SetReadOnly(bool value)
        {
            _ReadOnly = value;
            if (value)
            {
                WriteCommandsButtons.ForEach(x => x.Hide());
                WriteCommandsBarButtons.ForEach(x => x.Visibility = BarItemVisibility.Never);
            }
        }

        private bool _FilterVisible = true;
        public bool FilterVisible
        {
            get { return _FilterVisible; }
            set { SetFilterVisible(value); }
        }

        private bool _MultiSelect = false;
        public bool MultiSelect
        {
            get { return _MultiSelect; }
            set { SetMultiSelect(value); }
        }

        private GridMultiSelectMode _MultiSelectMode;
        public GridMultiSelectMode MultiSelectMode
        {
            get { return _MultiSelectMode; }
            set { SetMultiSelectMode(value); }
        }

        private void CxTableList_Load(object sender, EventArgs e)
        {
            if (Site != null && Site.DesignMode)
                return;

            Init();
            InitColumns();
            UpdateFooter();
            RestoreGridsSettings();

            MultiSelect = true;
            MultiSelectMode = GridMultiSelectMode.RowSelect;
            _gvGrid.OptionsDetail.EnableMasterViewMode = false;

            RefreshData();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.btnActions = new DropDownButton();
            this.popupMenu = new PopupMenu();
            this.barManager = new BarManager();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcActionLabel = new PanelControl();
            this.lcActionLabel = new LabelControl();
            this.lcFooter = new LabelControl();
            this.flpButtons = new FlowLayoutPanel();
            this._gcGrid = new GridControl();
            this._gvGrid = new GridView();
            this.pcSelectButton = new PanelControl();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTable = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciButtons = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFooter = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAction = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciActionLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiAction = new DevExpress.XtraLayout.EmptySpaceItem();
            this.esiSelect = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcActionLabel)).BeginInit();
            this.pcActionLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActions
            // 
            this.btnActions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActions.DropDownControl = this.popupMenu;
            this.btnActions.ImageOptions.Image = global::Socrat.References.Properties.Resources.play_16x16;
            this.btnActions.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnActions.Location = new System.Drawing.Point(8, 8);
            this.btnActions.Margin = new Padding(8);
            this.btnActions.MaximumSize = new System.Drawing.Size(120, 23);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(120, 23);
            this.btnActions.StyleController = this.layoutControl;
            this.btnActions.TabIndex = 5;
            this.btnActions.Text = "Действие";
            // 
            // popupMenu
            // 
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.MaxItemId = 8;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1025, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 732);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1025, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 732);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1025, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 732);
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcActionLabel);
            this.layoutControl.Controls.Add(this.lcFooter);
            this.layoutControl.Controls.Add(this.flpButtons);
            this.layoutControl.Controls.Add(this._gcGrid);
            this.layoutControl.Controls.Add(this.btnActions);
            this.layoutControl.Controls.Add(this.pcSelectButton);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.lcgMain;
            this.layoutControl.Size = new System.Drawing.Size(1025, 732);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcActionLabel
            // 
            this.pcActionLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcActionLabel.Controls.Add(this.lcActionLabel);
            this.pcActionLabel.Location = new System.Drawing.Point(161, 0);
            this.pcActionLabel.Name = "pcActionLabel";
            this.pcActionLabel.Size = new System.Drawing.Size(724, 40);
            this.pcActionLabel.TabIndex = 11;
            // 
            // lcActionLabel
            // 
            this.lcActionLabel.Location = new System.Drawing.Point(12, 12);
            this.lcActionLabel.Name = "lcActionLabel";
            this.lcActionLabel.Size = new System.Drawing.Size(0, 13);
            this.lcActionLabel.TabIndex = 1;
            // 
            // lcFooter
            // 
            this.lcFooter.Location = new System.Drawing.Point(8, 713);
            this.lcFooter.Name = "lcFooter";
            this.lcFooter.Size = new System.Drawing.Size(869, 11);
            this.lcFooter.StyleController = this.layoutControl;
            this.lcFooter.TabIndex = 9;
            this.lcFooter.Text = "Всего строк:";
            // 
            // flpButtons
            // 
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(887, 42);
            this.flpButtons.MaximumSize = new System.Drawing.Size(136, 0);
            this.flpButtons.MinimumSize = new System.Drawing.Size(136, 0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(136, 661);
            this.flpButtons.TabIndex = 8;
            // 
            // _gcGrid
            // 
            this._gcGrid.Location = new System.Drawing.Point(2, 42);
            this._gcGrid.MainView = this._gvGrid;
            this._gcGrid.Name = "_gcGrid";
            this._gcGrid.Size = new System.Drawing.Size(881, 661);
            this._gcGrid.TabIndex = 7;
            this._gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gvGrid});
            this._gcGrid.DoubleClick += new EventHandler(this.gcGrid_DoubleClick);
            this._gcGrid.KeyDown += new KeyEventHandler(this.CxTableList_KeyDown);
            // 
            // _gvGrid
            // 
            this._gvGrid.GridControl = this._gcGrid;
            this._gvGrid.Name = "_gvGrid";
            this._gvGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this._gvGrid.OptionsBehavior.AutoPopulateColumns = false;
            this._gvGrid.OptionsBehavior.Editable = false;
            this._gvGrid.OptionsBehavior.ReadOnly = true;
            this._gvGrid.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this._gvGrid.OptionsFind.AlwaysVisible = true;
            this._gvGrid.OptionsFind.ClearFindOnClose = false;
            this._gvGrid.OptionsSelection.MultiSelect = true;
            this._gvGrid.PopupMenuShowing += new PopupMenuShowingEventHandler(this._gvGrid_PopupMenuShowing);
            this._gvGrid.SelectionChanged += new SelectionChangedEventHandler(this._gvGrid_SelectionChanged);
            this._gvGrid.ColumnFilterChanged += new EventHandler(this._gvGrid_ColumnFilterChanged);
            // 
            // pcSelectButton
            // 
            this.pcSelectButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSelectButton.Location = new System.Drawing.Point(887, 707);
            this.pcSelectButton.MaximumSize = new System.Drawing.Size(136, 25);
            this.pcSelectButton.MinimumSize = new System.Drawing.Size(136, 25);
            this.pcSelectButton.Name = "pcSelectButton";
            this.pcSelectButton.Size = new System.Drawing.Size(136, 25);
            this.pcSelectButton.TabIndex = 10;
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTable,
            this.lciButtons,
            this.lciFooter,
            this.lciSelectButton,
            this.lciAction,
            this.lciActionLabel,
            this.esiAction});
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(1025, 732);
            this.lcgMain.TextVisible = false;
            // 
            // lciTable
            // 
            this.lciTable.Control = this._gcGrid;
            this.lciTable.Location = new System.Drawing.Point(0, 40);
            this.lciTable.Name = "lciTable";
            this.lciTable.Size = new System.Drawing.Size(885, 665);
            this.lciTable.TextSize = new System.Drawing.Size(0, 0);
            this.lciTable.TextVisible = false;
            // 
            // lciButtons
            // 
            this.lciButtons.Control = this.flpButtons;
            this.lciButtons.Location = new System.Drawing.Point(885, 40);
            this.lciButtons.Name = "lciButtons";
            this.lciButtons.Size = new System.Drawing.Size(140, 665);
            this.lciButtons.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtons.TextVisible = false;
            // 
            // lciFooter
            // 
            this.lciFooter.Control = this.lcFooter;
            this.lciFooter.Location = new System.Drawing.Point(0, 705);
            this.lciFooter.MaxSize = new System.Drawing.Size(0, 29);
            this.lciFooter.MinSize = new System.Drawing.Size(50, 25);
            this.lciFooter.Name = "lciFooter";
            this.lciFooter.Size = new System.Drawing.Size(885, 27);
            this.lciFooter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciFooter.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.lciFooter.TextSize = new System.Drawing.Size(0, 0);
            this.lciFooter.TextVisible = false;
            // 
            // lciSelectButton
            // 
            this.lciSelectButton.Control = this.pcSelectButton;
            this.lciSelectButton.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.lciSelectButton.Location = new System.Drawing.Point(885, 705);
            this.lciSelectButton.MaxSize = new System.Drawing.Size(140, 29);
            this.lciSelectButton.MinSize = new System.Drawing.Size(50, 25);
            this.lciSelectButton.Name = "lciSelectButton";
            this.lciSelectButton.Size = new System.Drawing.Size(140, 27);
            this.lciSelectButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSelectButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciSelectButton.TextVisible = false;
            // 
            // lciAction
            // 
            this.lciAction.Control = this.btnActions;
            this.lciAction.Location = new System.Drawing.Point(0, 0);
            this.lciAction.MaxSize = new System.Drawing.Size(161, 40);
            this.lciAction.MinSize = new System.Drawing.Size(161, 40);
            this.lciAction.Name = "lciAction";
            this.lciAction.Size = new System.Drawing.Size(161, 40);
            this.lciAction.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciAction.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.lciAction.TextSize = new System.Drawing.Size(0, 0);
            this.lciAction.TextVisible = false;
            // 
            // lciActionLabel
            // 
            this.lciActionLabel.Control = this.pcActionLabel;
            this.lciActionLabel.Location = new System.Drawing.Point(161, 0);
            this.lciActionLabel.Name = "lciActionLabel";
            this.lciActionLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciActionLabel.Size = new System.Drawing.Size(724, 40);
            this.lciActionLabel.TextSize = new System.Drawing.Size(0, 0);
            this.lciActionLabel.TextVisible = false;
            // 
            // esiAction
            // 
            this.esiAction.AllowHotTrack = false;
            this.esiAction.Location = new System.Drawing.Point(885, 0);
            this.esiAction.Name = "esiAction";
            this.esiAction.Size = new System.Drawing.Size(140, 40);
            this.esiAction.TextSize = new System.Drawing.Size(0, 0);
            // 
            // esiSelect
            // 
            this.esiSelect.AllowHotTrack = false;
            this.esiSelect.Location = new System.Drawing.Point(862, 683);
            this.esiSelect.Name = "esiSelect";
            this.esiSelect.Size = new System.Drawing.Size(143, 29);
            this.esiSelect.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CxGenericListTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CxGenericListTable";
            this.Size = new System.Drawing.Size(1025, 732);
            this.VisibleChanged += new EventHandler(this.CxGenericListTable_VisibleChanged);
            this.KeyDown += new KeyEventHandler(this.CxTableList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcActionLabel)).EndInit();
            this.pcActionLabel.ResumeLayout(false);
            this.pcActionLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnActions_Click(object sender, EventArgs e)
        {
            btnActions.ShowDropDown();
        }

        private void _gvGrid_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                popupMenu.ShowPopup(barManager, view.GridControl.PointToScreen(e.Point));
            }
        }

        private void _gvGrid_ColumnFilterChanged(object sender, EventArgs e)
        {
            UpdateFooter();
        }

        private void _gvGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFooter();
        }

        #endregion

        #region Подключение событий


        private void gcGrid_DoubleClick(object sender, EventArgs e)
        {
            switch (_regime)
            {
                case FormRegime.SingleSelect:
                    OnSelectItem();
                    break;
                default:
                    OpenItem();
                    break;
            }
        }

        #endregion

        #region Реализация

        public virtual void RefreshData()
        {
            if (Repository == null)
                return;
            gcGrid.DataSource = null;
            gcGrid.DataSource = Items;
            if (RowHighlightingExp != null)
                _HighlightedRows = GetItems()?.ToList().Where(RowHighlightingExp.Compile()).Select(x => x.Id).ToList();
            if (SelectedItem != null)
                SetFocusedRow(SelectedItem.Id);
            OnRefreshButtonClick();
        }

        protected void RefreshDataExecute(object obj)
        {
            RefreshData();
        }

        protected void AddItemExecute(object obj)
        {
            Tag = "Add";
            AddItem();
            Tag = null;
            
        }

        /// <summary>
        /// Перегрузить в потомке, если требуется особенная логика при создании элемента.
        /// По умолчанию создает элемент заданого типа.
        /// </summary>
        /// <returns>элемент списка</returns>
        protected virtual T GetNewInstance()
        {
            return Activator.CreateInstance<T>();
        }

        protected virtual void AddItem()
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
                if (_dialogResult == DialogResult.Yes && !this.ReadOnly)
                {
                    bool res = DependedSaving;
         
                    if (!Items.Contains(_entity))
                    {
                        Items.Add(_entity);
                        if (DependedSaving)
                        {
                            _entity.Changed = false;
                            if (SourceItems != null && !SourceItems.Contains(_entity))
                                SourceItems.Add(_entity);
                        }                          
                    }
                    if (!DependedSaving)
                        Repository.Save(_entity);
                }
                RefreshData();
                gvGrid.RefreshData();
                UpdateFooter();
                if (_entity != null)
                    SetFocusedRow(_entity.Id);
            };
            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            OnAddItem();
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        protected void DeleteItemExecute(object obj)
        {
            DeleteItem();
        }

        protected virtual void DeleteItem()
        {
            T _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить {0}?", _entity), "Удаление", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (_entity != null && dlgRes == DialogResult.Yes)
            {
                Items.Remove(Items.FirstOrDefault(x => x.Id == _entity.Id));
                gvGrid.RefreshData();
                UpdateFooter();
                PreparingDelete(_entity);

                Guid _id = _entity.Id;
                _entity = null;

                Repository.Delete(_id);      
            }
            OnDeleteItem();
        }

        protected virtual void PreparingDelete(T entity)
        {

        }

        protected void OpenItemExecute(object parameter)
        {
            OpenItem();
        }

        protected virtual void OpenItem()
        {
            if (Items == null)
                return;
            T _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            if (_entity != null)
            {
                //T editedEntity = ObjectCopier.Clone(_entity);
                //IEntity _parentEntity = _entity.ParentEntity;
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;//editedEntity;
                _fx.ReadOnly = this.ReadOnly;
                _fx.SaveButtonClick += (_sender, args) =>
                {
                    if (!_fx.Entity?.Changed ?? false)
                        return;
                    DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (_dialogResult != DialogResult.Yes || this.ReadOnly)
                    {
                        //_entity = Repository.Revert(_entity);
                        return;
                    }

                    bool res = DependedSaving;
                    if (!DependedSaving && _dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        //ObjectCopier.Clone(editedEntity, _entity);
                        //editedEntity.Changed = !
                            Repository.Save(_entity);
                    }

                    if (DependedSaving && _dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        //ObjectCopier.CloneEscapeParent(editedEntity, _entity);
                        _entity.Changed = false;
                        _entity.SetParentsChanged(true);
                        //editedEntity.Changed = false;
                        //if (_parentEntity != null)
                        //{
                        //    _entity.ParentEntity = _parentEntity;
                        //    _entity.ParentEntity.Changed = true;
                        //}
                    }

                    gvGrid.RefreshData();
                };
                _fx.DialogOutput += FxOnDialogOutput;
                _fx.StartPosition = FormStartPosition.CenterParent;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }

            OnOpenItem();
        }

        protected virtual void Init()
        {
        }

        protected virtual void InitColumns()
        {
            OnColumnInit();
        }

        protected virtual void ItemsSelect()
        {
            OnSelectItem();
            if (gvGrid.SelectedRowsCount > 1)
                OnMultiSelectItem();
        }

        private void OnMultiSelectItem()
        {
            MultiSelectEvent?.Invoke(this, EventArgs.Empty);
        }

        protected void ExpotrtToExcelExecute(object obj)
        {
            ExpotrtToExcel();
        }

        protected virtual void ExpotrtToExcel()
        {
            try
            {
                MemoryStream _memory = new MemoryStream();
                gvGrid.ExportToXlsx(_memory);

                FxSpreadSheetTest _fxSpreadSheet = new FxSpreadSheetTest(_memory);
                _fxSpreadSheet.StartPosition = FormStartPosition.CenterParent;
                _fxSpreadSheet.SetInfo("Не сохранен", "Экспорт");

                OnDialogOutput(_fxSpreadSheet, DialogOutputType.Tab);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.ExpotrtToExcel", e);
            }
        }

        #endregion

        public Guid GetCurrentRowId()
        {
            Guid _id = Guid.Empty;
            if (gvGrid.GetFocusedRowCellValue("Id") != null)
                Guid.TryParse(gvGrid.GetFocusedRowCellValue("Id").ToString(), out _id);
            return _id;
        }

        public Guid[] GetSelectedRows()
        {
            List<Guid> _ids = new List<Guid>();
            if (gvGrid.SelectedRowsCount > 1)
            {
                Guid _id;
                object _tmp;
                int[] _rows = gvGrid.GetSelectedRows();
                foreach (int row in _rows)
                {
                    _tmp = gvGrid.GetRowCellValue(row, "Id");
                    if (_tmp != null && Guid.TryParse(_tmp.ToString(), out _id))
                        _ids.Add(_id);
                }
            }
            else
                _ids.Add(GetCurrentRowId());
            return _ids.ToArray();
        }

        public bool IsMultiSelected
        {
            get { return GetIsMultiSelected(); }
        }
        private bool GetIsMultiSelected()
        {
            return gvGrid.SelectedRowsCount > 1;
        }

        /// <summary>
        /// Сохранить настройки грида
        /// </summary>
        public void SaveGridsSettings()
        {
            try
            {
                string _fileName = string.Empty;
                string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                _fileName = _folder + "\\" + this.Name + "_" + "gcGrid.xml";
                _gcGrid.MainView.SaveLayoutToXml(_fileName);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.SaveGridsSettings", e);
            }
        }

        /// <summary>
        /// Востановить настройки грида
        /// </summary>
        public void RestoreGridsSettings()
        {
            try
            {
                string _fileName = string.Empty;
                string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
     
                _fileName = _folder + "\\" + this.Name + "gcGrid.xml";
                if (File.Exists(_fileName))
                    _gcGrid.MainView.RestoreLayoutFromXml(_fileName);

            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.RestoreGridsSettings", e);
            }

        }

        public void AddColumn(string name, string caption, string fieldName, FormatType formatType,
            string formatString, int width, int visibleIndex)
        {
            GridColumn _column = new GridColumn();
            _column.Caption = caption;
            _column.DisplayFormat.FormatString = formatString;
            _column.DisplayFormat.FormatType = formatType;
            _column.FieldName = fieldName;
            _column.Name = name;
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _gvGrid.Columns.Add(_column);
        }

        public void AddObjectColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            GridColumn _column = new GridColumn();
            _column.Caption = caption;
            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName + visibleIndex.ToString();
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _column.FieldNameSortGroup = fieldName + "_Id";
            _column.FilterMode = ColumnFilterMode.DisplayText;
            _gvGrid.Columns.Add(_column);
        }

        public void AddColumn(string name, string caption, string fieldName, int width, int visibleIndex)
        {
            var prop = typeof(T).GetProperty(fieldName + "_Id");
            if (prop != null)
                Logger.AddWarning($"Необходимо AddColumn заменить на AddObjectColumn в {this.Name} для поля {fieldName}");

            AddColumn(name, caption, fieldName, FormatType.None, null, width, visibleIndex);
        }

        public void AddColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new Exception("Поле fieldName должно быть заполнено.");
            AddColumn("col" + fieldName, caption, fieldName, FormatType.None, null, width, visibleIndex);
        }

        /// <summary>
        /// Создание колонки с использованием лямбда-синтаксиса
        /// </summary>
        /// <typeparam name="P">тип свойства элемента списка</typeparam>
        /// <param name="caption">заголовок колонки</param>
        /// <param name="selectorExpression">лямбда-селектор свойства</param>
        /// <param name="width">ширина колоки</param>
        /// <param name="visibleIndex">порядок следования</param>
        public void AddColumn<P>( string caption, Expression<Func<T, P>> selectorExpression, int width, int visibleIndex)
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

            AddColumn("col" + me.Member.Name, caption, me.Member.Name, FormatType.None, null, width, visibleIndex);
        }

        public void AddObjectColumn<P>(string caption, Expression<Func<T, P>> selectorExpression, int width, int visibleIndex)
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

            AddObjectColumn(caption, me.Member.Name, width, visibleIndex);
        }

        public void AddColumnSummary(string fieldName, string displayFormat)
        {
            if (!_gvGrid.OptionsView.ShowFooter)
                _gvGrid.OptionsView.ShowFooter = true;

            GridColumnSummaryItem siTotal = new GridColumnSummaryItem();
            siTotal.FieldName = fieldName;
            siTotal.SummaryType = SummaryItemType.Sum;
            siTotal.DisplayFormat = "{0:" + displayFormat + "}";
            gvGrid.Columns[fieldName].Summary.Add(siTotal);
        }

        public void GroupByColumn(string fieldName)
        {
            var _column = gvGrid.Columns[fieldName];
            if (_column == null)
                _column = gvGrid.Columns[fieldName + "_Id"];
            if (_column != null)
                _column.Group();
        }

        protected void UpdateFooter()
        {
            lcFooter.Text = string.Format("Всего строк: {0:N0}", gvGrid.RowCount);

            bool _isCellValueFiltering = _gvGrid.ActiveFilterString.Length > 0;
            bool _isFindFiltering = false;
            if (_gvGrid.IsFindPanelVisible && _gvGrid.GridControl.Controls.Find("FindControl", true).Length > 0)
            {
                FindControl find = _gvGrid.GridControl.Controls.Find("FindControl", true)[0] as FindControl;
                if (find != null)
                {
                    _isFindFiltering =
                        (find.FindEdit.EditValue != null && find.FindEdit.EditValue?.ToString().Length > 0);
                }
            }

            int[] _sel = _gvGrid.GetSelectedRows();

            if (_isCellValueFiltering || _isFindFiltering)
            {
                lcFooter.Text = string.Format("Отобранных строк: {0}", _gvGrid.RowCount);
                if (_sel.Length > 0)
                    lcFooter.Text = string.Format("Отобранных строк/Выделенных строк: {0}/{1}", _gvGrid.RowCount,
                        _sel.Length);
            }
            else
            {
                if (_sel.Length > 0)
                    lcFooter.Text = string.Format("Всего строк/Выделенных строк: {0}/{1}", _gvGrid.RowCount, _sel.Length);
            }
        }

        public void SetFilterVisible(bool state)
        {
            _FilterVisible = state;
            gvGrid.OptionsFind.AlwaysVisible = state;
            gvGrid.OptionsFind.ClearFindOnClose = !state;
        }

        public void SetMultiSelect(bool state)
        {
            _MultiSelect = state;
            gvGrid.OptionsSelection.MultiSelect = state;
        }

        public void SetMultiSelectMode(GridMultiSelectMode mode)
        {
            _MultiSelectMode = mode;
            gvGrid.OptionsSelection.MultiSelectMode = mode;
        }

        private void CxTableList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    RefreshData();
                    return;
                case Keys.Insert:
                    AddItem();
                    return;
                case Keys.Enter:
                    OpenItem();
                    return;
                case Keys.Delete:
                    DeleteItem();
                    return;
            }

            if (_gvGrid.IsFindPanelVisible && IsKeyLetterOrDogit(e.KeyData))
            {
                FindControl find = _gvGrid.GridControl.Controls.Find("FindControl", true)[0] as FindControl;
                find.FindEdit.Focus();

            }
        }

        private bool IsKeyLetterOrDogit(Keys keyData)
        {
            if (!(keyData >= Keys.F1 && keyData <= Keys.F12))
            {
                char key = (char)keyData;
                if (char.IsLetterOrDigit(key))
                {
                    return true;
                }
            }
            return false;
        }

        protected void ResetFilterByCellValueExecute(object obj)
        {
            ResetFilterByCellValue();
        }

        protected void ResetFilterByCellValue()
        {
            _gvGrid.ActiveFilterString = string.Empty;
        }

        protected void FilterByCellValueExecute(object obj)
        {
            FilterByCellValue();
        }

        private void FilterByCellValue()
        {
            if (_gvGrid.FocusedColumn != null && _gvGrid.FocusedValue != null && _gvGrid.FocusedValue != DBNull.Value)
            {
                _gvGrid.ActiveFilterString = string.Format("[{0}] = '{1}'", _gvGrid.FocusedColumn.FieldName, _gvGrid.FocusedValue);
            }
        }

        public void SetSingleSelectMode(T selectedItem)
        {
            AddButtonSelect();
            gvGrid.OptionsSelection.MultiSelect = false;
            gvGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            _regime = FormRegime.SingleSelect;
            SelectedItem = selectedItem;
        }

        public void SetFocusedRow(Guid id)
        {
            int _row = -1;
            _row = _gvGrid.LocateByValue("Id", id);
            _row = _gvGrid.GetRowHandle(_row);
            if (_row != -1)
            {
                _gvGrid.ClearSelection();
                _gvGrid.FocusedRowHandle = _row;
                _gvGrid.SelectRow(_row);
            }
        }

        private BarItem[] GetBarItemsFromCommand(BarManager _barManager, ReferenceCommand command)
        {
            if (command.Commands.Count < 1)
                return null;

            List<BarItem> _items = new List<BarItem>();
            BarItem _button;
            foreach (ReferenceCommand _command in command.Commands)
            {
                switch (_command.CommandType)
                {
                    case MenuCommandType.Group:
                    case MenuCommandType.ContextMenuGroup:
                        _button = new BarSubItem();
                        ((BarSubItem)_button).AddItems(GetBarItemsFromCommand(_barManager, _command));
                        break;
                    default:
                        _button = new BarButtonItem();
                        ((BarButtonItem)_button).BindCommand(_command);
                        break;
                }
                _button.Caption = _command.Title;
                _button.ImageOptions.Image = _command.Image;
                _barManager.Items.Add(_button);
                _items.Add(_button);
            }

            return _items.ToArray();
        }

        private PopupMenu GetPopupMenuFromCommand(BarManager _barManager, ReferenceCommand command)
        {
            if (command.Commands.Count < 1)
                return null;

            PopupMenu _popupMenu = new PopupMenu(this.components);
            _popupMenu.Manager = _barManager;
            BarItem[] _items = GetBarItemsFromCommand(_barManager, command);
            foreach (BarItem item in _items)
                _popupMenu.LinksPersistInfo.Add(new LinkPersistInfo(item));
            return _popupMenu;
        }

        private void BuildCommandsControls()
        {
            //боковые кнопки
            var _buttonsCommands = _commands.Where(x => x.CommandType != MenuCommandType.ComtextMenuItem &&
                                                        x.CommandType != MenuCommandType.ContextMenuGroup);
            SimpleButton _button;
            foreach (ReferenceCommand buttonCommand in _buttonsCommands)
            {
                switch (buttonCommand.CommandType)
                {
                    case MenuCommandType.Group:
                        _button = new DropDownButton();
                        ((DropDownButton) _button).DropDownControl =
                            GetPopupMenuFromCommand(this.barManager, buttonCommand);
                        ((DropDownButton)_button).Click += (sender, args) => { ((DropDownButton)sender).ShowDropDown();};
                        break;
                    default:
                        _button = new SimpleButton();
                        break;
                }
                _button.Text = buttonCommand.Title;
                _button.ImageOptions.Image = buttonCommand.Image;
                _button.BindCommand(buttonCommand);
                _button.Enabled = !buttonCommand.ReadOnly;
                AddButton(_button);
                if (buttonCommand.IsWriteCommand)
                    WriteCommandsButtons.Add(_button);
            }

            //меню действие и контекстное меню
            var _actionCommands = _commands;
            BarItem _barItem;
            foreach (var actionCommand in _actionCommands)
            {
                switch (actionCommand.CommandType)
                {
                    case MenuCommandType.Group:
                    case MenuCommandType.ContextMenuGroup:
                        _barItem = new BarSubItem();
                        _barItem.Caption = actionCommand.Title;
                        _barItem.ImageOptions.Image = actionCommand.Image;
                        ((BarSubItem)_barItem).AddItems(GetBarItemsFromCommand(barManager, actionCommand));
                        break;
                    default:
                        _barItem = new BarButtonItem();
                        _barItem.Caption = actionCommand.Title;
                        _barItem.ImageOptions.Image = actionCommand.Image;
                        ((BarButtonItem) _barItem).BindCommand(actionCommand);
                        if (actionCommand.IsWriteCommand)
                            WriteCommandsBarButtons.Add((BarButtonItem)_barItem);
                        break;
                }
                this.popupMenu.LinksPersistInfo.Add(new LinkPersistInfo(_barItem, actionCommand.BeginGroup));
                this.barManager.Items.Add(_barItem);
            }
        }

        public void AddButton(SimpleButton button)
        {
            button.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            button.Location = new System.Drawing.Point(3, 61);
            button.Size = new System.Drawing.Size(128, 23);
            flpButtons.Controls.Add(button);
        }

        private void AddButtonSelect()
        {
            this.btnSelect = new SimpleButton();
            pcSelectButton.Controls.Add(this.btnSelect);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelect.ImageOptions.Image = Properties.Resources.apply_16x16;
            this.btnSelect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSelect.Location = new System.Drawing.Point(399, 542);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(134, 23);
            this.btnSelect.MaximumSize = new System.Drawing.Size(134, 23);
            this.btnSelect.MinimumSize = new System.Drawing.Size(134, 23);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "Выбрать";
            btnSelect.Dock = DockStyle.Fill;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            btnSelect.Visible = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ItemsSelect();
        }

        private void OnOpenItem()
        {
            OpenItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        protected void OnAddItem()
        {
            AddItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        private void OnDeleteItem()
        {
            DeleteItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        private void OnSelectItem()
        {
            Guid _id = GetCurrentRowId();
            SelectedItem = Items.FirstOrDefault(x => x.Id == _id);
            SelectItemEvent?.Invoke(this, new ListItemEventArgs(_id));
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }

        private void OnColumnInit()
        {
            ColumnsInitEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnRefreshButtonClick()
        {
            RefreshButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType});
        }

        protected virtual IEntityEditor GetEditor()
        {
            return null;
        }

        public string Title
        {
            get { return GetTitle(); }
        }

        protected virtual string GetTitle()
        {
            return "Базовый обобщеный компонент табличного списка";
        }

        protected void SetActionLabel(string text)
        {
            lcActionLabel.Text = text;
        }

        private void _gvGrid_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                popupMenu.ShowPopup(_gcGrid.PointToScreen(e.Point));
            }
        }

        protected void AddToActionPanel(Control control)
        {
            pcActionLabel.Controls.Add(control);
        }

        private void CxGenericListTable_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                SaveGridsSettings();
        }
    }
}
