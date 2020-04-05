using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using Socrat.Core;
using Socrat.Log;
using Socrat.Spreadsheet;

namespace Socrat.UI.Core
{
    /// <summary>
    /// Шаблон табличного списка (справочника)
    /// </summary>
    public partial class CxTableList : DevExpress.XtraEditors.XtraUserControl, ITabable
    {
        private FormRegime _regime = FormRegime.Edit;

        public event ListItemEventHandler OpenItemEvent;
        public event ListItemEventHandler AddItemEvent;
        public event ListItemEventHandler DeleteItemEvent;
        public event ListItemEventHandler SelectItemEvent;
        public event EventHandler MultiSelectEvent;
        public event EventHandler RefreshButtonClick;
        public event EventHandler ColumnsInitEvent; 

        public CxTableList()
        {
            InitializeComponent();
            InitColumns();
            if (Site != null && Site.DesignMode == true)
                return;

            Load += CxTableList_Load;
        }

        private void SetControlsReadOnly()
        {
            btnAddItem.Hide();
            btnRemove.Hide();
            btnExcelExport.Hide();
            biAddItem.Visibility = BarItemVisibility.Never;
            biDelete.Visibility = BarItemVisibility.Never;
            biExportToExcel.Visibility = BarItemVisibility.Never;
        }

        public bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { SetReadOnly(value); }
        }

        private Guid _ModuleId;
        public Guid ModuleId
        {
            get => _ModuleId;
            set => _ModuleId = value;
        }

        public GridControl gcGrid
        {
            get { return _gcGrid; }
        }

        public GridView gvGrid
        {
            get { return _gvGrid; }
        }

        private void SetReadOnly(bool value)
        {
            _ReadOnly = value;
            if (value)
                SetControlsReadOnly();
        }

        private bool _filterVisible = true;
        public bool FilterVisible
        {
            get { return _filterVisible; }
            set { SetFilterVisible(value); }
        }

        private bool _multiSelect = false;
        public bool MultiSelect
        {
            get { return _multiSelect; }
            set { SetMultiSelect(value); }
        }

        private GridMultiSelectMode _multiSelectMode;


        public GridMultiSelectMode MultiSelectMode
        {
            get { return _multiSelectMode; }
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

            AddColumn("Ид", "Id", 100, 0, false);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxTableList));
            this.btnActions = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.biRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.biOpen = new DevExpress.XtraBars.BarButtonItem();
            this.biAddItem = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.biFilterByCellValue = new DevExpress.XtraBars.BarButtonItem();
            this.biResetFilterByCell = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcActionLabel = new DevExpress.XtraEditors.PanelControl();
            this.lcActionLabel = new DevExpress.XtraEditors.LabelControl();
            this.pcSelectButton = new DevExpress.XtraEditors.PanelControl();
            this.lcFooter = new DevExpress.XtraEditors.LabelControl();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcelExport = new DevExpress.XtraEditors.SimpleButton();
            this._gcGrid = new DevExpress.XtraGrid.GridControl();
            this._gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAction = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTable = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiAction = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciButtons = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFooter = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciActionLabel = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcActionLabel)).BeginInit();
            this.pcActionLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).BeginInit();
            this.flpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActions
            // 
            this.btnActions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActions.DropDownControl = this.popupMenu;
            this.btnActions.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActions.ImageOptions.Image")));
            this.btnActions.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnActions.Location = new System.Drawing.Point(8, 8);
            this.btnActions.Margin = new System.Windows.Forms.Padding(8);
            this.btnActions.MaximumSize = new System.Drawing.Size(120, 23);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(120, 23);
            this.btnActions.StyleController = this.layoutControl;
            this.btnActions.TabIndex = 5;
            this.btnActions.Text = "Действие";
            this.btnActions.Click += new System.EventHandler(this.btnActions_Click);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.biOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.biAddItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.biExportToExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biFilterByCellValue, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biResetFilterByCell)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // biRefresh
            // 
            this.biRefresh.Caption = "Обновить";
            this.biRefresh.Id = 0;
            this.biRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biRefresh.ImageOptions.Image")));
            this.biRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biRefresh.ImageOptions.LargeImage")));
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biRefresh_ItemClick);
            // 
            // biOpen
            // 
            this.biOpen.Caption = "Просмотр";
            this.biOpen.Id = 1;
            this.biOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biOpen.ImageOptions.Image")));
            this.biOpen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biOpen.ImageOptions.LargeImage")));
            this.biOpen.Name = "biOpen";
            this.biOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biOpen_ItemClick);
            // 
            // biAddItem
            // 
            this.biAddItem.Caption = "Добавить";
            this.biAddItem.Id = 3;
            this.biAddItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biAddItem.ImageOptions.Image")));
            this.biAddItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biAddItem.ImageOptions.LargeImage")));
            this.biAddItem.Name = "biAddItem";
            this.biAddItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biAddItem_ItemClick);
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Удалить";
            this.biDelete.Id = 4;
            this.biDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biDelete.ImageOptions.Image")));
            this.biDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biDelete.ImageOptions.LargeImage")));
            this.biDelete.Name = "biDelete";
            this.biDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDelete_ItemClick);
            // 
            // biExportToExcel
            // 
            this.biExportToExcel.Caption = "Экспорт в Excel";
            this.biExportToExcel.Id = 5;
            this.biExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biExportToExcel.ImageOptions.Image")));
            this.biExportToExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biExportToExcel.ImageOptions.LargeImage")));
            this.biExportToExcel.Name = "biExportToExcel";
            this.biExportToExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biExportToExcel_ItemClick);
            // 
            // biFilterByCellValue
            // 
            this.biFilterByCellValue.Caption = "Отбор по значению текущей ячейки";
            this.biFilterByCellValue.Id = 6;
            this.biFilterByCellValue.ImageOptions.Image = global::Socrat.UI.Core.Properties.Resources.reapplyfilter_16x16;
            this.biFilterByCellValue.ImageOptions.LargeImage = global::Socrat.UI.Core.Properties.Resources.reapplyfilter_32x32;
            this.biFilterByCellValue.Name = "biFilterByCellValue";
            this.biFilterByCellValue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biFilterByCellValue_ItemClick);
            // 
            // biResetFilterByCell
            // 
            this.biResetFilterByCell.Caption = "Отменить отбор";
            this.biResetFilterByCell.Id = 7;
            this.biResetFilterByCell.ImageOptions.Image = global::Socrat.UI.Core.Properties.Resources.clearfilter_16x16;
            this.biResetFilterByCell.ImageOptions.LargeImage = global::Socrat.UI.Core.Properties.Resources.clearfilter_32x32;
            this.biResetFilterByCell.Name = "biResetFilterByCell";
            this.biResetFilterByCell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biResetFilterByCell_ItemClick);
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biRefresh,
            this.biOpen,
            this.biEdit,
            this.biAddItem,
            this.biDelete,
            this.biExportToExcel,
            this.biFilterByCellValue,
            this.biResetFilterByCell});
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
            // biEdit
            // 
            this.biEdit.Caption = "Редактировать";
            this.biEdit.Id = 2;
            this.biEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biEdit.ImageOptions.Image")));
            this.biEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biEdit.ImageOptions.LargeImage")));
            this.biEdit.Name = "biEdit";
            this.biEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEdit_ItemClick);
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcActionLabel);
            this.layoutControl.Controls.Add(this.pcSelectButton);
            this.layoutControl.Controls.Add(this.lcFooter);
            this.layoutControl.Controls.Add(this.flpButtons);
            this.layoutControl.Controls.Add(this._gcGrid);
            this.layoutControl.Controls.Add(this.btnActions);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(718, 233, 857, 676);
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
            // pcSelectButton
            // 
            this.pcSelectButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSelectButton.Location = new System.Drawing.Point(887, 705);
            this.pcSelectButton.MaximumSize = new System.Drawing.Size(136, 25);
            this.pcSelectButton.MinimumSize = new System.Drawing.Size(136, 25);
            this.pcSelectButton.Name = "pcSelectButton";
            this.pcSelectButton.Size = new System.Drawing.Size(136, 25);
            this.pcSelectButton.TabIndex = 10;
            // 
            // lcFooter
            // 
            this.lcFooter.Location = new System.Drawing.Point(8, 711);
            this.lcFooter.Name = "lcFooter";
            this.lcFooter.Size = new System.Drawing.Size(869, 13);
            this.lcFooter.StyleController = this.layoutControl;
            this.lcFooter.TabIndex = 9;
            this.lcFooter.Text = "Всего строк:";
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnRefresh);
            this.flpButtons.Controls.Add(this.btnOpen);
            this.flpButtons.Controls.Add(this.btnAddItem);
            this.flpButtons.Controls.Add(this.btnRemove);
            this.flpButtons.Controls.Add(this.btnExcelExport);
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(887, 42);
            this.flpButtons.MaximumSize = new System.Drawing.Size(136, 0);
            this.flpButtons.MinimumSize = new System.Drawing.Size(136, 0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(136, 659);
            this.flpButtons.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(128, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.ImageOptions.Image")));
            this.btnOpen.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnOpen.Location = new System.Drawing.Point(3, 32);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(128, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Просмотр";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.ImageOptions.Image")));
            this.btnAddItem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAddItem.Location = new System.Drawing.Point(3, 61);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(128, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Добавить";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRemove.Location = new System.Drawing.Point(3, 90);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(128, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.ImageOptions.Image = global::Socrat.UI.Core.Properties.Resources.exporttoxlsx_16x16;
            this.btnExcelExport.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExcelExport.Location = new System.Drawing.Point(3, 119);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(128, 23);
            this.btnExcelExport.TabIndex = 4;
            this.btnExcelExport.Text = "Экспорт в Excel";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // _gcGrid
            // 
            this._gcGrid.Location = new System.Drawing.Point(2, 42);
            this._gcGrid.MainView = this._gvGrid;
            this._gcGrid.Name = "_gcGrid";
            this._gcGrid.Size = new System.Drawing.Size(881, 659);
            this._gcGrid.TabIndex = 7;
            this._gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gvGrid});
            this._gcGrid.DoubleClick += new System.EventHandler(this.gcGrid_DoubleClick);
            this._gcGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CxTableList_KeyDown);
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
            this._gvGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this._gvGrid_PopupMenuShowing);
            this._gvGrid.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this._gvGrid_SelectionChanged);
            this._gvGrid.ColumnFilterChanged += new System.EventHandler(this._gvGrid_ColumnFilterChanged);
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAction,
            this.lciTable,
            this.esiAction,
            this.lciButtons,
            this.lciFooter,
            this.lciSelectButton,
            this.lciActionLabel});
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(1025, 732);
            this.lcgMain.TextVisible = false;
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
            // lciTable
            // 
            this.lciTable.Control = this._gcGrid;
            this.lciTable.Location = new System.Drawing.Point(0, 40);
            this.lciTable.MinSize = new System.Drawing.Size(104, 24);
            this.lciTable.Name = "lciTable";
            this.lciTable.Size = new System.Drawing.Size(885, 663);
            this.lciTable.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTable.TextSize = new System.Drawing.Size(0, 0);
            this.lciTable.TextVisible = false;
            // 
            // esiAction
            // 
            this.esiAction.AllowHotTrack = false;
            this.esiAction.Location = new System.Drawing.Point(885, 0);
            this.esiAction.Name = "esiAction";
            this.esiAction.Size = new System.Drawing.Size(140, 40);
            this.esiAction.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciButtons
            // 
            this.lciButtons.Control = this.flpButtons;
            this.lciButtons.Location = new System.Drawing.Point(885, 40);
            this.lciButtons.MaxSize = new System.Drawing.Size(140, 0);
            this.lciButtons.MinSize = new System.Drawing.Size(140, 160);
            this.lciButtons.Name = "lciButtons";
            this.lciButtons.Size = new System.Drawing.Size(140, 663);
            this.lciButtons.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciButtons.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtons.TextVisible = false;
            // 
            // lciFooter
            // 
            this.lciFooter.Control = this.lcFooter;
            this.lciFooter.Location = new System.Drawing.Point(0, 703);
            this.lciFooter.MaxSize = new System.Drawing.Size(0, 29);
            this.lciFooter.MinSize = new System.Drawing.Size(80, 29);
            this.lciFooter.Name = "lciFooter";
            this.lciFooter.Size = new System.Drawing.Size(885, 29);
            this.lciFooter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciFooter.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.lciFooter.TextSize = new System.Drawing.Size(0, 0);
            this.lciFooter.TextVisible = false;
            // 
            // lciSelectButton
            // 
            this.lciSelectButton.Control = this.pcSelectButton;
            this.lciSelectButton.Location = new System.Drawing.Point(885, 703);
            this.lciSelectButton.MaxSize = new System.Drawing.Size(140, 29);
            this.lciSelectButton.MinSize = new System.Drawing.Size(140, 29);
            this.lciSelectButton.Name = "lciSelectButton";
            this.lciSelectButton.Size = new System.Drawing.Size(140, 29);
            this.lciSelectButton.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciSelectButton.TextSize = new System.Drawing.Size(0, 0);
            this.lciSelectButton.TextVisible = false;
            // 
            // lciActionLabel
            // 
            this.lciActionLabel.Control = this.pcActionLabel;
            this.lciActionLabel.Location = new System.Drawing.Point(161, 0);
            this.lciActionLabel.MinSize = new System.Drawing.Size(5, 5);
            this.lciActionLabel.Name = "lciActionLabel";
            this.lciActionLabel.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciActionLabel.Size = new System.Drawing.Size(724, 40);
            this.lciActionLabel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciActionLabel.TextSize = new System.Drawing.Size(0, 0);
            this.lciActionLabel.TextVisible = false;
            // 
            // CxTableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CxTableList";
            this.Size = new System.Drawing.Size(1025, 732);
            this.VisibleChanged += new System.EventHandler(this.CxTableList_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CxTableList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcActionLabel)).EndInit();
            this.pcActionLabel.ResumeLayout(false);
            this.pcActionLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).EndInit();
            this.flpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Вывод окон

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType, Owner = this.ParentForm });
        }

        public void OnDialogOutput(WindowOutputEventArgs woa)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = woa.NewTab, OutputType = woa.OutputType, Owner = woa.Owner });
        }

        #endregion

        #region Подключение событий

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenItem();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tsmiDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void biAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddItem();
        }

        private void biDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteItem();
        }

        private void biEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void biRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void biOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenItem();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (!ReadOnly)
                OpenItem();
        }

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

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            ExpotrtToExcel();
        }

        private void biExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExpotrtToExcel();
        }

        private void tsmiExportToExcel_Click(object sender, EventArgs e)
        {
            ExpotrtToExcel();
        }

        #endregion

        #region Реализация

        protected virtual void RefreshData()
        {
            OnRefreshButtonClick();
        }

        protected virtual void AddItem()
        {
            OnAddItem();
        }

        protected virtual void DeleteItem()
        {
            OnDeleteItem();
        }

        protected virtual void OpenItem()
        {
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
            if (gvGrid.SelectedRowsCount > 1)
                OnMultiSelectItem();
            else
                OnSelectItem();
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
                Logger.AddErrorMsgEx("CxTableList.ExpotrtToExcel", e);
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
                Logger.AddErrorMsgEx("CxTableList.SaveGridsSettings", e);
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
                Logger.AddErrorMsgEx("CxTableList.RestoreGridsSettings", e);
            }

        }

        public void AddColumn(string caption, string fieldName, DevExpress.Utils.FormatType formatType,
            string formatString, int width, int visibleIndex)
        {
            GridColumn _column = new DevExpress.XtraGrid.Columns.GridColumn();
            _column.Caption = caption;
            _column.DisplayFormat.FormatString = formatString;
            _column.DisplayFormat.FormatType = formatType;
            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName + visibleIndex.ToString();
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _gvGrid.Columns.Add(_column);
        }

        public void AddColumn(string caption, string fieldName,
             int width, int visibleIndex, bool defaultVisible)
        {
            GridColumn _column = new DevExpress.XtraGrid.Columns.GridColumn();
            _column.Caption = caption;

            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName + visibleIndex.ToString();
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _column.Visible = defaultVisible;
            _gvGrid.Columns.Add(_column);
        }

        public void AddObjectColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            GridColumn _column = new DevExpress.XtraGrid.Columns.GridColumn();
            _column.Caption = caption;
            _column.FieldName = fieldName;
            _column.Name = "col" + fieldName + visibleIndex.ToString();
            _column.Visible = true;
            _column.VisibleIndex = visibleIndex;
            _column.Width = width;
            _column.FieldNameSortGroup = fieldName + "Id";
            _column.FilterMode = ColumnFilterMode.DisplayText;
            _gvGrid.Columns.Add(_column);
        }

        public void AddColumn(string name, string caption, string fieldName, DevExpress.Utils.FormatType formatType,
            string formatString, int width, int visibleIndex)
        {
            GridColumn _column = new DevExpress.XtraGrid.Columns.GridColumn();
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

        public void ClarColumns()
        {
            _gvGrid.Columns.Clear();
        }

        public void AddColumn(string name, string caption, string fieldName, int width, int visibleIndex)
        {
            AddColumn(name, caption, fieldName, FormatType.None, null, width, visibleIndex);
        }

        public void AddColumn(string caption, string fieldName, int width, int visibleIndex)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new Exception("Поле fieldName должно быть заполнено.");
            AddColumn("col" + fieldName, caption, fieldName, FormatType.None, null, width, visibleIndex);
        }

        public string Footer { get => lcFooter.Text; protected set => lcFooter.Text = value; }

        public virtual void UpdateFooter()
        {
            Footer = string.Format("Всего строк: {0:N0}", gvGrid.RowCount);

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
                Footer = string.Format("Отобранных строк: {0}", _gvGrid.RowCount);
                if (_sel.Length > 0)
                    Footer = string.Format("Отобранных строк/Выделенных строк: {0}/{1}", _gvGrid.RowCount,
                        _sel.Length);
            }
            else
            {
                if (_sel.Length > 0)
                    Footer = string.Format("Всего строк/Выделенных строк: {0}/{1}", _gvGrid.RowCount, _sel.Length);
            }
        }

        public void SetFilterVisible(bool state)
        {
            _filterVisible = state;
            gvGrid.OptionsFind.AlwaysVisible = state;
            gvGrid.OptionsFind.ClearFindOnClose = !state;
        }

        public void SetMultiSelect(bool state)
        {
            _multiSelect = state;
            gvGrid.OptionsSelection.MultiSelect = state;
        }

        public void SetMultiSelectMode(GridMultiSelectMode mode)
        {
            _multiSelectMode = mode;
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

        private void biFilterByCellValue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FilterByCellValue();
        }

        private void biResetFilterByCell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetFilterByCellValue();
        }

        private void tsmiFilterByCellValue_Click(object sender, EventArgs e)
        {
            FilterByCellValue();
        }

        private void tsmiResetCellValueFilter_Click(object sender, EventArgs e)
        {
            ResetFilterByCellValue();
        }

        private void ResetFilterByCellValue()
        {
            _gvGrid.ActiveFilterString = string.Empty;
        }

        private void FilterByCellValue()
        {
            if (_gvGrid.FocusedColumn != null && _gvGrid.FocusedValue != null && _gvGrid.FocusedValue != DBNull.Value)
            {
                _gvGrid.ActiveFilterString = string.Format("[{0}] = '{1}'", _gvGrid.FocusedColumn.FieldName, _gvGrid.FocusedValue);
            }
        }

        public void SetSingleSelectMode()
        {
            AddButtonSelect();
            gvGrid.OptionsSelection.MultiSelect = false;
            gvGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            _regime = FormRegime.SingleSelect;
        }

        public void SetFocusedRow(Guid id)
        {
            int _row = -1;
            _row = _gvGrid.LocateByValue("Id", id);
            if (_row != -1)
            {
                _gvGrid.ClearSelection();
                _gvGrid.FocusedRowHandle = _row;
                _gvGrid.SelectRow(_row);
            }
        }

        private void AddButtonSelect()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxTableList));
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
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
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
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

        private void OnAddItem()
        {
            AddItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        private void OnDeleteItem()
        {
            DeleteItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        private void OnSelectItem()
        {
            SelectItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        private void OnMultiSelectItem()
        {
            MultiSelectEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnColumnInit()
        {
            ColumnsInitEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnRefreshButtonClick()
        {
            RefreshButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public string Title
        {
            get => GetTitle();
        }

        protected virtual string GetTitle()
        {
            return "Табличный компонент";
        }

        public void SetEditable(bool state)
        {
            _gvGrid.OptionsBehavior.Editable = state;
            _gvGrid.OptionsBehavior.ReadOnly = !state;
        }

        public void HideOpenButton()
        {
            btnOpen.Hide();
            biOpen.Visibility = BarItemVisibility.Never;
        }

        public void HideExportExcelButton()
        {
            btnExcelExport.Hide();
            biExportToExcel.Visibility = BarItemVisibility.Never;
            foreach (BarItemLink popupMenuItemLink in popupMenu.ItemLinks)
            {
                popupMenuItemLink.BeginGroup = false;
            }
        }

        private void _gvGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFooter();
        }

        private void _gvGrid_ColumnFilterChanged(object sender, EventArgs e)
        {
            UpdateFooter();
        }

        private void btnActions_Click(object sender, EventArgs e)
        {
            btnActions.ShowDropDown();
        }

        public void GroupByColumn(string fieldName)
        {
            var _column = gvGrid.Columns[fieldName];
            if (_column == null)
                _column = gvGrid.Columns[fieldName + "_Id"];
            if (_column != null)
                _column.Group();
        }

        public void SortByColumn(string fieldName)
        {
            var _column = gvGrid.Columns[fieldName];
            if (_column != null)
                _column.SortOrder = ColumnSortOrder.Ascending;
        }

        private void _gvGrid_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
            {
                e.Allow = false;
                popupMenu.ShowPopup(_gcGrid.PointToScreen(e.Point));
            }
        }

        private void CxTableList_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                SaveGridsSettings();
        }

        #region Управление видимостью полей команд. Надо бы как-то слить вместе генерализованый контрол и старый

        public void SetActionsButtonVisibility(bool show)
        {
            if (show)
                esiAction.Visibility = lciAction.Visibility = LayoutVisibility.Always;
            else
                esiAction.Visibility = lciAction.Visibility = LayoutVisibility.Never;
        }

        public void SetRightPaneButtonsVisibility(bool show)
        {
            if (show)
                esiAction.Visibility = lciButtons.Visibility = lciSelectButton.Visibility = LayoutVisibility.Always;
            else
                esiAction.Visibility = lciButtons.Visibility = lciSelectButton.Visibility = LayoutVisibility.Never;
        }

        public void ShowFilterPanel(bool show)
        {
            gvGrid.OptionsFind.AlwaysVisible = show;
        }

        public void ShowGroupPanel(bool show)
        {
            gvGrid.OptionsView.ShowGroupPanel = false;
        }

        #endregion
    }
}
