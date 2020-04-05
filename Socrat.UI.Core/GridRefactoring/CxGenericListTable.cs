using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using Socrat.Common;
using Socrat.Common.Commands;
using Socrat.Common.Exceptions;
using Socrat.Common.UI;
using Socrat.Core;
using Socrat.Core.Helpers;
using Socrat.DataProvider;
using Socrat.Lib.Commands;
using Socrat.Log;
using Socrat.Spreadsheet;
using BarItem = DevExpress.XtraBars.BarItem;
using IEntity = Socrat.Core.IEntity;
using IEntityEditor = Socrat.Core.IEntityEditor;


namespace Socrat.UI.Core
{
    /// <summary>
    /// Обобщенный класс табличного списка (справочника)
    /// </summary>
    /// 
    public partial class CxGenericListTable<T> : 
        PrintableControl, 
        IEntitySelector, 
        IRefreshable, 
        Socrat.Common.Interfaces.MVC.IView
        where T : Entity, IEntity, new()
    {
        /// <summary>
        /// Не грузить данные по при первой загрузке контрола, когда не переопределен GetItems дженерика
        /// и не надо грузить все данные по умолчанию
        /// </summary>
        public bool PreventRefreshDataOnLoading { get; set; } = false;

        public event EventHandler ItemSelected;
        
        public FormOperationModes Mode { get; private set; } = FormOperationModes.Edit;
        protected List<SimpleButton> WriteCommandsButtons = new List<SimpleButton>();
        protected List<BarButtonItem> WriteCommandsBarButtons = new List<BarButtonItem>();
        protected ReferenceCommand ResetFilterCommand = new ReferenceCommand();

        //public PropertyChangedBase DynamicParentEntity { get; set; }

        public List<T> SelectedItems { get; protected set; } = new List<T>();

        private Expression<Func<T, bool>> _ExternalFilterExp;
        /// <summary>
        /// Условие внешней фильтрации
        /// </summary>
        public Expression<Func<T, bool>> ExternalFilterExp
        {
            get => _ExternalFilterExp;
            set
            {
                _ExternalFilterExp = value;
                sbResetFilter.Visible = (_ExternalFilterExp != null || _ExternalFilterExp2 !=null);
            }
        }

        private Expression<Func<T, bool>> _ExternalFilterExp2;

        public Expression<Func<T, bool>> ExternalFilterExp2
        {
            get => _ExternalFilterExp2;
            set
            {
                _ExternalFilterExp2 = value;
                sbResetFilter.Visible = (_ExternalFilterExp != null || _ExternalFilterExp2 != null);
            }
        }

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
            gvGrid.RowCellStyle += _gvGrid_RowCellStyle;
        }

        private void _gvGrid_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var tmp = gvGrid.GetRowCellValue(e.RowHandle, "Id");
            if (tmp != null && Guid.TryParse(tmp.ToString(), out var _id))
            {
                if (_HighlightedRows != null && _HighlightedRows.Contains(_id))
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic | FontStyle.Bold);
            }
        }

        public AttachedList<T> SourceItems { get; set; }
        private IRepository<T> _repository = null;
        protected IRepository<T> Repository
        {
            get
            {
                if (Site != null && Site.DesignMode)
                        return null;

                if (_repository == null)
                    _repository = DataFactory.CreateUniDefaultRepository<T>();
                return _repository;
            }
        }

        public IEntity SelectedItem { get; set; }

        /// <summary>
        /// Зависимое сохранение.
        /// Например когда элементы дочерней колекции не погут быть сохранены раньше класса родителя
        /// из-за ограничения внешнего ключа, необходимо при создании компонента устанвить св-во в true
        /// </summary>
        public bool DependedSaving { get; set; }

        protected AttachedList<T> CachedItems { get; private set; }

        #region Items related functionality

        public event EventHandler<AttachedList<T>> GettingItems;

        public AttachedList<T> Items
        {
            get
            {
                if (PreventRefreshDataOnLoading)
                    return new AttachedList<T>();

                if (ExternalFilterExp != null)
                {
                    IEntity owner = GetOwnerWrapper();
                    return new AttachedList<T>(GetItems().Where(ExternalFilterExp.Compile()), owner);
                }
                OnGetttingItems(_items);
                return GetItems();
            }
        }

        protected virtual AttachedList<T> GetItems()
        {
            if (_items == null)
            {
                _items = new AttachedList<T>(GetOwnerWrapper());
                _items.AddRange(DataHelper.GetRepository<T>().GetAll());
            }

            if (_items.Count == 0)
                OnGetItemsReturnEmptyList(_items);
            return _items;
        }

        protected void OnGetttingItems(AttachedList<T> items)
        {
            GettingItems?.Invoke(this, items);
            _items = items;
        }

        #endregion

        public event ListItemEventHandler OpenItemEvent;
        public event ListItemEventHandler AddItemEvent;
        public event ListItemEventHandler DeleteItemEvent;
        public event ListItemEventHandler SelectItemEvent;
        public event EventHandler MultiSelectEvent;
        public event EventHandler RefreshButtonClick;
        public event EventHandler ColumnsInitEvent;
        public event EventHandler DeleteAllItemsEvent;
        public event EventHandler<T> EntitySelected;
        public event EventHandler RefreshingData;
        public event EventHandler<AttachedList<T>> GetItemsReturnEmptyList;

        protected List<ReferenceCommand> _commands { get; set; }

        private bool _Inited = false;
        public bool RestoreUserGridSettings { get; set; } = false;

        private System.IO.Stream defaultGridSettings = new System.IO.MemoryStream();

        public CxGenericListTable()
        {
            InitializeComponent();
            if (DesignMode) return;

            InternalInitCommands();
            _gvGrid.CustomColumnDisplayText += OnCustomColumnDisplayText;
            Load += CxTableList_Load;
        }



        private AttachedList<T> _items;


        #region Owner related logic
        public event EventHandler<IEntity> GettingOwner;

        private IEntity _owner;
        private  IEntity GetOwnerWrapper()
        {
            OnGettingOwner(_owner);
            return GetOwner();
        }

        protected virtual IEntity GetOwner()
        {
            return _owner;
        }

        protected void OnGettingOwner(IEntity owner)
        {
            GettingOwner?.Invoke(this, owner);
        }
        #endregion

        /// <summary>
        /// Метод для применения контрола как грида без создания отдельного класса в пректе.
        /// </summary>
        /// <param name="items">Коллекция, являющаяся источником записей</param>
        /// <param name="owner">Сущность, владеющая коллекцией</param>
        public CxGenericListTable(AttachedList<T> items, IEntity owner, bool canAdd = true, bool canOpen = true, bool canDelete = true, bool canBePrinted = false)
        {
            InitializeComponent();
            if (DesignMode) return;

            _owner = owner;
            _items = items;
            CanAdd = canAdd;
            CanOpen = canOpen;
            CanDelete = canDelete;
            CanBePrinted = canBePrinted;

            InternalInitCommands();
            BuildCommandsControls();
            _gvGrid.CustomColumnDisplayText += OnCustomColumnDisplayText;
            Load += CxTableList_Load;
        }

        public ReferenceCommand CommandOpen { get; protected set; }

        

        private void ResetGridSettingsExecute(object obj)
        {
            RestoreDefaultSettingsGrid();
        }

        public bool _ReadOnly;

        //public GridControl gcGrid { get; private set; }
        //public GridView gvGrid { get; private set; }
        private GridControl _gcGrid;
        public GridControl gcGrid
        {
            get { return _gcGrid; }
        }

        private GridView _gvGrid;
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
            gvGrid.OptionsDetail.EnableMasterViewMode = false;
            sbSelect.ImageOptions.Image = Properties.Resources.apply_16x16;
            btnActions.ImageOptions.Image = Properties.Resources.play_16x16;
            SetActionLabel(string.Empty);

            RefreshData();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcTopActionContainer = new DevExpress.XtraEditors.PanelControl();
            this.btnActions = new DevExpress.XtraEditors.DropDownButton();
            this.pcTitle = new DevExpress.XtraEditors.PanelControl();
            this.pcTopControlsContainer = new DevExpress.XtraEditors.PanelControl();
            this.gcTitle = new DevExpress.XtraEditors.GroupControl();
            this.pcRightPane = new DevExpress.XtraEditors.PanelControl();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.pcSelectButton = new DevExpress.XtraEditors.PanelControl();
            this.sbResetFilter = new DevExpress.XtraEditors.SimpleButton();
            this.sbSelect = new DevExpress.XtraEditors.SimpleButton();
            this.lcFooter = new DevExpress.XtraEditors.LabelControl();
            this._gcGrid = new DevExpress.XtraGrid.GridControl();
            this._gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTable = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBottomPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRightPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTopPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciActionPane = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiSelect = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTopActionContainer)).BeginInit();
            this.pcTopActionContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTitle)).BeginInit();
            this.pcTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTopControlsContainer)).BeginInit();
            this.pcTopControlsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRightPane)).BeginInit();
            this.pcRightPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).BeginInit();
            this.pcSelectButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBottomPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRightPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTopPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSelect)).BeginInit();
            this.SuspendLayout();
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
            this.layoutControl.Controls.Add(this.pcTopActionContainer);
            this.layoutControl.Controls.Add(this.pcTitle);
            this.layoutControl.Controls.Add(this.pcRightPane);
            this.layoutControl.Controls.Add(this.lcFooter);
            this.layoutControl.Controls.Add(this._gcGrid);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(476, 237, 650, 400);
            this.layoutControl.Root = this.lcgMain;
            this.layoutControl.Size = new System.Drawing.Size(1025, 732);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcTopActionContainer
            // 
            this.pcTopActionContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcTopActionContainer.Controls.Add(this.btnActions);
            this.pcTopActionContainer.Location = new System.Drawing.Point(9, 9);
            this.pcTopActionContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pcTopActionContainer.Name = "pcTopActionContainer";
            this.pcTopActionContainer.Size = new System.Drawing.Size(125, 26);
            this.pcTopActionContainer.TabIndex = 7;
            // 
            // btnActions
            // 
            this.btnActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActions.DropDownControl = this.popupMenu;
            this.btnActions.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnActions.Location = new System.Drawing.Point(0, 0);
            this.btnActions.Margin = new System.Windows.Forms.Padding(4);
            this.btnActions.MaximumSize = new System.Drawing.Size(120, 23);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(120, 22);
            this.btnActions.TabIndex = 6;
            this.btnActions.Text = "Действие";
            this.btnActions.Click += new System.EventHandler(this.BtnActions_Click);
            // 
            // pcTitle
            // 
            this.pcTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcTitle.Controls.Add(this.pcTopControlsContainer);
            this.pcTitle.Location = new System.Drawing.Point(145, 2);
            this.pcTitle.Margin = new System.Windows.Forms.Padding(0);
            this.pcTitle.Name = "pcTitle";
            this.pcTitle.Size = new System.Drawing.Size(878, 40);
            this.pcTitle.TabIndex = 14;
            // 
            // pcTopControlsContainer
            // 
            this.pcTopControlsContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcTopControlsContainer.Controls.Add(this.gcTitle);
            this.pcTopControlsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcTopControlsContainer.Location = new System.Drawing.Point(0, 0);
            this.pcTopControlsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pcTopControlsContainer.Name = "pcTopControlsContainer";
            this.pcTopControlsContainer.Size = new System.Drawing.Size(878, 40);
            this.pcTopControlsContainer.TabIndex = 8;
            // 
            // gcTitle
            // 
            this.gcTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTitle.Location = new System.Drawing.Point(0, 0);
            this.gcTitle.Name = "gcTitle";
            this.gcTitle.Size = new System.Drawing.Size(878, 40);
            this.gcTitle.TabIndex = 0;
            this.gcTitle.Text = "Табличная форма";
            // 
            // pcRightPane
            // 
            this.pcRightPane.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcRightPane.Controls.Add(this.flpButtons);
            this.pcRightPane.Controls.Add(this.pcSelectButton);
            this.pcRightPane.Location = new System.Drawing.Point(889, 44);
            this.pcRightPane.Name = "pcRightPane";
            this.pcRightPane.Size = new System.Drawing.Size(136, 659);
            this.pcRightPane.TabIndex = 13;
            // 
            // flpButtons
            // 
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(0, 0);
            this.flpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(136, 590);
            this.flpButtons.TabIndex = 8;
            // 
            // pcSelectButton
            // 
            this.pcSelectButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcSelectButton.Controls.Add(this.sbResetFilter);
            this.pcSelectButton.Controls.Add(this.sbSelect);
            this.pcSelectButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pcSelectButton.Location = new System.Drawing.Point(0, 590);
            this.pcSelectButton.Margin = new System.Windows.Forms.Padding(0);
            this.pcSelectButton.Name = "pcSelectButton";
            this.pcSelectButton.Padding = new System.Windows.Forms.Padding(5);
            this.pcSelectButton.Size = new System.Drawing.Size(136, 69);
            this.pcSelectButton.TabIndex = 12;
            this.pcSelectButton.Visible = false;
            // 
            // sbResetFilter
            // 
            this.sbResetFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.sbResetFilter.ImageOptions.Image = global::Socrat.UI.Core.Properties.Resources.clearfilter_16x161;
            this.sbResetFilter.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.sbResetFilter.Location = new System.Drawing.Point(5, 5);
            this.sbResetFilter.Name = "sbResetFilter";
            this.sbResetFilter.Size = new System.Drawing.Size(126, 23);
            this.sbResetFilter.TabIndex = 1;
            this.sbResetFilter.Text = "Сбросить фильтр";
            this.sbResetFilter.Visible = false;
            this.sbResetFilter.Click += new System.EventHandler(this.sbResetFilter_Click);
            // 
            // sbSelect
            // 
            this.sbSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbSelect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.sbSelect.Location = new System.Drawing.Point(5, 41);
            this.sbSelect.Name = "sbSelect";
            this.sbSelect.Size = new System.Drawing.Size(126, 23);
            this.sbSelect.TabIndex = 0;
            this.sbSelect.Text = "Выбрать";
            this.sbSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lcFooter
            // 
            this.lcFooter.Location = new System.Drawing.Point(8, 711);
            this.lcFooter.Name = "lcFooter";
            this.lcFooter.Size = new System.Drawing.Size(1009, 13);
            this.lcFooter.StyleController = this.layoutControl;
            this.lcFooter.TabIndex = 9;
            this.lcFooter.Text = "Всего строк:";
            // 
            // _gcGrid
            // 
            this._gcGrid.Location = new System.Drawing.Point(4, 48);
            this._gcGrid.MainView = this._gvGrid;
            this._gcGrid.Name = "_gcGrid";
            this._gcGrid.Size = new System.Drawing.Size(881, 651);
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
            this._gvGrid.OptionsView.ColumnAutoWidth = false;
            this._gvGrid.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this._gvGrid_PopupMenuShowing);
            this._gvGrid.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this._gvGrid_SelectionChanged);
            this._gvGrid.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this._gvGrid_FocusedRowChanged);
            this._gvGrid.ColumnFilterChanged += new System.EventHandler(this._gvGrid_ColumnFilterChanged);
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTable,
            this.lciBottomPane,
            this.lciRightPane,
            this.lciTopPane,
            this.lciActionPane});
            this.lcgMain.Name = "Root";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(1025, 732);
            this.lcgMain.TextVisible = false;
            // 
            // lciTable
            // 
            this.lciTable.Control = this._gcGrid;
            this.lciTable.Location = new System.Drawing.Point(0, 44);
            this.lciTable.MinSize = new System.Drawing.Size(104, 24);
            this.lciTable.Name = "lciTable";
            this.lciTable.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.lciTable.Size = new System.Drawing.Size(889, 659);
            this.lciTable.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTable.TextSize = new System.Drawing.Size(0, 0);
            this.lciTable.TextVisible = false;
            // 
            // lciBottomPane
            // 
            this.lciBottomPane.Control = this.lcFooter;
            this.lciBottomPane.Location = new System.Drawing.Point(0, 703);
            this.lciBottomPane.MaxSize = new System.Drawing.Size(0, 29);
            this.lciBottomPane.MinSize = new System.Drawing.Size(50, 25);
            this.lciBottomPane.Name = "lciBottomPane";
            this.lciBottomPane.Size = new System.Drawing.Size(1025, 29);
            this.lciBottomPane.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciBottomPane.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.lciBottomPane.TextSize = new System.Drawing.Size(0, 0);
            this.lciBottomPane.TextVisible = false;
            // 
            // lciRightPane
            // 
            this.lciRightPane.Control = this.pcRightPane;
            this.lciRightPane.Location = new System.Drawing.Point(889, 44);
            this.lciRightPane.MaxSize = new System.Drawing.Size(136, 0);
            this.lciRightPane.MinSize = new System.Drawing.Size(136, 1);
            this.lciRightPane.Name = "lciRightPane";
            this.lciRightPane.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciRightPane.Size = new System.Drawing.Size(136, 659);
            this.lciRightPane.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciRightPane.TextSize = new System.Drawing.Size(0, 0);
            this.lciRightPane.TextVisible = false;
            // 
            // lciTopPane
            // 
            this.lciTopPane.Control = this.pcTitle;
            this.lciTopPane.Location = new System.Drawing.Point(143, 0);
            this.lciTopPane.MinSize = new System.Drawing.Size(5, 5);
            this.lciTopPane.Name = "lciTopPane";
            this.lciTopPane.Size = new System.Drawing.Size(882, 44);
            this.lciTopPane.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciTopPane.TextSize = new System.Drawing.Size(0, 0);
            this.lciTopPane.TextVisible = false;
            // 
            // lciActionPane
            // 
            this.lciActionPane.Control = this.pcTopActionContainer;
            this.lciActionPane.Location = new System.Drawing.Point(0, 0);
            this.lciActionPane.MaxSize = new System.Drawing.Size(143, 44);
            this.lciActionPane.MinSize = new System.Drawing.Size(143, 44);
            this.lciActionPane.Name = "lciActionPane";
            this.lciActionPane.Size = new System.Drawing.Size(143, 44);
            this.lciActionPane.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciActionPane.Spacing = new DevExpress.XtraLayout.Utils.Padding(7, 7, 7, 7);
            this.lciActionPane.TextSize = new System.Drawing.Size(0, 0);
            this.lciActionPane.TextVisible = false;
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
            this.VisibleChanged += new System.EventHandler(this.CxGenericListTable_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CxTableList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcTopActionContainer)).EndInit();
            this.pcTopActionContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcTitle)).EndInit();
            this.pcTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcTopControlsContainer)).EndInit();
            this.pcTopControlsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRightPane)).EndInit();
            this.pcRightPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcSelectButton)).EndInit();
            this.pcSelectButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBottomPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRightPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTopPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciActionPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private DevExpress.XtraLayout.LayoutControlItem lciBottomPane;
        private DevExpress.XtraEditors.PanelControl pcRightPane;
        private DevExpress.XtraLayout.LayoutControlItem lciRightPane;


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
            var pos = e as DevExpress.Utils.DXMouseEventArgs;
            GridControl grid = sender as GridControl;
            if (pos == null || grid == null)
                return;

            GridHitInfo info = grid.FocusedView?.CalcHitInfo(pos.Location) as GridHitInfo;
            if (info == null)
                return;

            if (info.InRow || info.InRowCell)
            {
                switch (Mode)
                {
                    case FormOperationModes.SingleSelect:
                        OnSelectItem();
                        break;
                    default:
                        OpenItem();
                        break;
                }
                pos.Handled = true;
            }
        }

        #endregion

        #region Реализация

        public virtual void RefreshData()
        {
            OnRefreshingData();
            if (Repository == null)
                return;
            //Repository.RefreshSet();
            gcGrid.DataSource = null;
            gcGrid.DataSource = Items;
            if (RowHighlightingExp != null)
                _HighlightedRows = GetItems()?.ToList().Where(RowHighlightingExp.Compile()).Select(x => x.Id).ToList();
            if (SelectedItem != null)
                SetFocusedRow(SelectedItem.Id);
            //Чо за хня? Очепятка?
            //OnRefreshButtonClick();

            try
            {
                gvGrid.BestFitColumns();
            }
            catch (Exception e)
            {
                Logger.AddErrorEx("Внезапно!!!", e);
            }
        }

        public virtual void RefreshData(AttachedList<T> items, IEntity owner)
        {
            _items = items;
            _owner = owner;
            RefreshData();
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

        protected virtual bool CanAddItem(object obj)
        {
            return true;
        }

        protected virtual bool CanOpenItem(object obj)
        {
            return true;
        }

        protected virtual bool CanDeleteItem(object obj)
        {
            return true;
        }

        /// <summary>
        /// Перегрузить в потомке, если требуется особенная логика при создании элемента.
        /// По умолчанию создает элемент заданого типа.
        /// </summary>
        /// <returns>элемент списка</returns>
        protected virtual T GetNewInstance()
        {
            T entity = Activator.CreateInstance<T>();
            ///TODO: Тут какое-то немного масляное масло - Вызов ивента на создание уже был в AddItem. Надо еще подумать....
            EntityCreatingEventArgs e = new EntityCreatingEventArgs(entity, false);
            OnEntityCtreating(e);

            if (!e.Cancel)
                return null;

            entity.Loaded = true;
            return entity;
        }

        protected virtual void AddItem()
        {
            if (!CanAdd) return;

            T _entity = GetNewInstance();
            if (_entity == null)
            {
                _entity = Activator.CreateInstance<T>();
                EntityCreatingEventArgs e = new EntityCreatingEventArgs(_entity, false);
                OnEntityCtreating(e);
            }


            _entity.Loaded = true;

            //_entity.EditMode = true; // общее правило

            IEntityEditor _fx = GetEditor(OpenMode.NewEntity);
            _fx.Entity = _entity;

            //if (DynamicParentEntity != null)
            //{
            //    _entity.AddChangingParent(DynamicParentEntity);
            //    // а родительскому Changed поставим при сохранении _entity (фейковом) - если не будет отмены
            //}

            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_entity?.Changed ?? false)
                    return;

                if (this.ReadOnly)
                {
                    //ZZZZ  откат 2488
                    DataHelper.RevertEx(_entity);
                    //
                    return;
                }

                bool isNewEntity = !Items.Contains(_entity);

                DialogResult dr = DialogResult.Yes;
                if (args.FromClosing)
                    dr = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (ValidationHelper.Validate<T>(
                        isNewEntity
                        ? ValidationStage.OnAdd
                        : ValidationStage.OnEdit,
                        _entity,
                        GetItemsForValidate()))
                    {
                        IEntity owner = _fx.PreviousEditor?.Entity;

                        if (isNewEntity)
                        {
                            Items.Add(_entity);
                            if (SourceItems != null && !SourceItems.Contains(_entity))
                                SourceItems.Add(_entity);

                        }

                        Repository.Save2(_entity, owner);

                        OnEntityCreated(_entity);

                        RefreshData();
                        gvGrid.RefreshData();
                        UpdateFooter();

                        if (_entity != null)
                            SetFocusedRow(_entity.Id);
                    }
                    else
                    {
                        args.Cancel = true;
                    }
                }
                else if (dr == DialogResult.No)
                {
                    Repository.Revert2(_entity);
                }
                else if (dr == DialogResult.Cancel)
                {
                    args.Cancel = true;
                }
            };

            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            OnAddItem();
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected void DeleteItemExecute(object obj)
        {
            if (obj is bool supressWarning)
                DeleteItem(supressWarning);
            else
                DeleteItem();
        }

        protected void DeleteAllExecute(object obj)
        {
            DeleteAllItems();
        }
        protected virtual void DeleteAllItems()
        {
            if (!CanDelete) return;

            DialogResult dlgRes = XtraMessageBox.Show(string.Format("Удалить все элементы?"), "Удаление", MessageBoxButtons.YesNoCancel,
                         MessageBoxIcon.Question);

            IEntity owner = GetOwnerWrapper();
            Repository.Delete2(Items, owner);
            Items.Clear();
            gvGrid.RefreshData();
            UpdateFooter();
            OnDeleteAllItems();
        }

        protected virtual void DeleteItem(bool supressWarning = false)
        {
            if (!CanDelete) return;

            if (!(gvGrid.GetFocusedRow() is T _entity))
                throw new NothingToProcessException();

            DialogResult dlgRes = DialogResult.Yes;

            if (!supressWarning)
                dlgRes = XtraMessageBox.Show($"Удалить {_entity}?", "Удаление", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (_entity != null && dlgRes == DialogResult.Yes)
            {
                IEntity owner = GetOwnerWrapper();

                // если владелец удаляемой сущности не указан или отмечен атрибутом ParentItem - то сущность удаляем полностью, иначе - только из коллекции владельца
                bool needCommonRemoving;
                if (owner != null)
                {
                    needCommonRemoving = false;

                    Type type = ObjectContext.GetObjectType(_entity.GetType());
                    var parentProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => x.GetCustomAttribute(typeof(ParentItemAttribute)) != null);
                    foreach (PropertyInfo propInfo in parentProperties)
                    {
                        var val = propInfo.GetValue(_entity) as IEntity;
                        if (val == owner)
                        {
                            needCommonRemoving = true;
                            break;
                        }
                    }
                }
                else
                {
                    needCommonRemoving = true;
                }

                // валидация удаления только если это полное удаление
                bool allowed = true;
                if (needCommonRemoving)
                {
                    var c = _repository.GetAll();
                    allowed = ValidationHelper.Validate<T>(
                                            ValidationStage.OnDelete,
                                            _entity,
                                            c.ToList());
                }

                if (allowed)
                {
                    if (Repository.Delete2(_entity, owner, !needCommonRemoving))
                    {
                        //AttachedList<T> items = (AttachedList<T>)gvGrid.DataSource;
                        if (gvGrid.DataSource is IList<T> items)
                        {
                            items.Remove(_entity);// (items.FirstOrDefault(x => x.Id == _entity.Id));
                            gvGrid.RefreshData();
                            UpdateFooter();
                            OnDeleteItem(_entity);
                        }
                    }
                }
            }
        }

        protected void OpenItemExecute(object parameter)
        {
            OpenItem();
        }

        protected virtual void OpenItem()
        {
            if (!CanOpen) return;
            if (!(GetFocusedItem() is T entity))
                throw new NothingToProcessException();


            if (!(GetEditor() is IEntityEditor _fx))
                throw new Exception($"Для данного типа сущности '{entity.GetType().Name}' не задан тип формы редактирования");

            _fx.Entity = entity;
            _fx.ReadOnly = ReadOnly;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;

                if (this.ReadOnly)
                {
                    //ZZZZ  откат 2488
                    DataHelper.RevertEx(entity);
                    //
                    return;
                }

                DialogResult dr = DialogResult.Yes;
                if (args.FromClosing)
                    dr = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    if (ValidationHelper.Validate<T>(
                    ValidationStage.OnEdit,
                    entity,
                    GetItemsForValidate()))
                    {
                        IEntity owner = _fx.PreviousEditor?.Entity;
                        Repository.Save2(entity, owner);
                        gvGrid.RefreshData();
                    }
                    else
                        args.Cancel = true;
                }
                else if (dr == DialogResult.No)
                {
                    Repository.Revert2(entity);
                    gvGrid.RefreshData();
                }
                else if (dr == DialogResult.Cancel)
                {
                    args.Cancel = true;
                }
            };

            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            OnOpenItem();
        }

        protected virtual List<T> GetItemsForValidate()
        {
            List<T> _list = Repository.GetAll().ToList();
            AttachedList<T> items = GetItems();
            
            foreach(T item in items)
            {
                if (!_list.Exists(x => x.Id == item.Id))
                    _list.Add(item);

                // [ale 2020.03.11] но надо подумать как учитывать удаленные в этой сессии, чтобы они не участвовали в проверке валидации
            }
            return _list;
        }

        protected virtual void Init()
        {

        }

        public void BuildDefaultColumns()
        {
            typeof(T).GetCustomAttributes<PropertyVisualisationAttribute>().ToList()
                .ForEach(columnProperty =>
                    gvGrid.AddColumn(columnProperty));
        }

        protected virtual void InitColumns()
        {
            BuildDefaultColumns();
            OnColumnInit();
        }

        protected virtual void ItemsSelect()
        {
            if (gvGrid.SelectedRowsCount == 1)
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
                _fxSpreadSheet.Show(this);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.ExpotrtToExcel", e);
            }
        }

        #endregion

        public Guid GetCurrentRowId()
        {
            //Может, так лучше? 
            //if (gvGrid.GetFocusedRow() is Entity entity)
            //    return entity.Id;
            //return Guid.Empty;

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
                _fileName = Path.Combine(_folder, "Socrat", this.Name + "_" + "gcGrid.xml");
                if (!Directory.Exists(Path.Combine(_folder, "Socrat")))
                    Directory.CreateDirectory(Path.Combine(_folder, "Socrat"));
                gcGrid.MainView.SaveLayoutToXml(_fileName);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.SaveGridsSettings", e);
            }
        }

        protected void RestoreDefaultSettingsGrid()
        {
            gvGrid.RestoreLayoutFromStream(defaultGridSettings);
            defaultGridSettings.Seek(0, System.IO.SeekOrigin.Begin);
        }

        /// <summary>
        /// Востановить настройки грида
        /// </summary>
        public void RestoreGridsSettings()
        {
            if (!RestoreUserGridSettings)
                return;
            try
            {
                string _fileName = string.Empty;
                string _folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                _fileName = Path.Combine(_folder, "Socrat", this.Name + "_" + "gcGrid.xml");
                System.Diagnostics.Debug.Print($"Восстановление настроек таблицы {this.Name} из {_fileName}");
                if (File.Exists(_fileName))
                    gcGrid.MainView.RestoreLayoutFromXml(_fileName);
                _Inited = true;

            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx("CxGenericListTable.RestoreGridsSettings", e);
            }

        }



        public GridColumn AddColumn(string name, string caption, string fieldName, FormatType formatType,
            string formatString, int width, int visibleIndex, string toolTip = null, bool allowEdit = false)
        {
            return gvGrid.AddColumn(name, caption, fieldName, formatType, formatString, width, visibleIndex, toolTip, allowEdit);
        }

        /// <summary>
        /// Adds the CheckBox column.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="formatType">Type of the format.</param>
        /// <param name="formatString">The format string.</param>
        /// <param name="width">The width.</param>
        /// <param name="visibleIndex">Index of the visible.</param>
        /// <param name="toolTip">The tool tip.</param>
        /// <param name="unboundType">Type of the unbound.</param>
        public RepositoryItemCheckEdit AddCheckBoxColumnRepositoryItem(string caption,
        string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            return gvGrid.AddCheckBoxColumnRepositoryItem(caption, fieldName, width, visibleIndex, toolTip);
        }

        public GridColumn AddObjectColumn(string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            return gvGrid.AddObjectColumn(caption, fieldName, width, visibleIndex, toolTip);
        }

        public void AddColumn(string name, string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            var prop = typeof(T).GetProperty(fieldName + "Id");
            if (prop != null)
                Logger.AddWarning($"Необходимо AddColumn заменить на AddObjectColumn в {this.Name} для поля {fieldName}");

            AddColumn(name, caption, fieldName, FormatType.None, null, width, visibleIndex, toolTip);
        }

        public GridColumn AddColumn(string caption, string fieldName, int width, int visibleIndex, string toolTip = null)
        {
            if (string.IsNullOrEmpty(fieldName))
                throw new Exception("Поле fieldName должно быть заполнено.");
            return AddColumn("col" + fieldName, caption, fieldName, FormatType.None, null, width, visibleIndex, toolTip);
        }

        public GridColumn AddColumn(string caption, string fieldName, DevExpress.Utils.FormatType formatType,
            string formatString, int width, int visibleIndex, string tooltip = null)
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
            _column.ToolTip = tooltip;
            _gvGrid.Columns.Add(_column);

            return _column;
        }

        /// <summary>
        /// Создание колонки с использованием лямбда-синтаксиса
        /// </summary>
        /// <typeparam name="P">тип свойства элемента списка</typeparam>
        /// <param name="caption">заголовок колонки</param>
        /// <param name="selectorExpression">лямбда-селектор свойства</param>
        /// <param name="width">ширина колоки</param>
        /// <param name="visibleIndex">порядок следования</param>
        public GridColumn AddColumn<P>(string caption, Expression<Func<T, P>> selectorExpression, int width, int visibleIndex, string toolTip = null, bool allowEdit = false)
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

            return AddColumn("col" + me.Member.Name, caption, me.Member.Name, FormatType.None, null, width, visibleIndex, toolTip, allowEdit);
        }

        public GridColumn AddObjectColumn<P>(string caption, Expression<Func<T, P>> selectorExpression, int width, int visibleIndex, string toolTip = null, UnboundColumnType unboundType = UnboundColumnType.String)
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

            return AddObjectColumn(caption, me.Member.Name, width, visibleIndex, toolTip);
        }

        public void AddColumnSummary(string fieldName, string displayFormat)
        {
            if (!gvGrid.OptionsView.ShowFooter)
                gvGrid.OptionsView.ShowFooter = true;

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
                _column = gvGrid.Columns[fieldName + "Id"];
            if (_column != null)
                _column.Group();
        }

        public void UngroupAll()
        {
            gvGrid.Columns.ToList().ForEach(col => col.UnGroup());
        }

        public void SortByColumn(string fieldName, ColumnSortOrder sortOrder = ColumnSortOrder.Ascending)
        {
            var _column = gvGrid.Columns[fieldName];
            if (_column != null)
                _column.SortOrder = sortOrder;
        }

        protected string Footer { get => lcFooter.Text; set => lcFooter.Text = value; }

        public void UpdateFooterEnvelope() { UpdateFooter(); }

        public virtual void UpdateFooter()
        {
            Footer = string.Format("Всего строк: {0:N0}", gvGrid.RowCount);

            bool _isCellValueFiltering = gvGrid.ActiveFilterString.Length > 0;
            bool _isFindFiltering = false;
            if (gvGrid.IsFindPanelVisible && gvGrid.GridControl.Controls.Find("FindControl", true).Length > 0)
            {
                FindControl find = gvGrid.GridControl.Controls.Find("FindControl", true)[0] as FindControl;
                if (find != null)
                {
                    _isFindFiltering =
                        (find.FindEdit.EditValue != null && find.FindEdit.EditValue?.ToString().Length > 0);
                }
            }

            int[] _sel = gvGrid.GetSelectedRows();

            if (_isCellValueFiltering || _isFindFiltering)
            {
                Footer = string.Format("Отобранных строк: {0}", gvGrid.RowCount);
                if (_sel.Length > 0)
                    Footer = string.Format("Отобранных строк/Выделенных строк: {0}/{1}", gvGrid.RowCount,
                        _sel.Length);
            }
            else
            {
                if (_sel.Length > 0)
                    Footer = string.Format("Всего строк/Выделенных строк: {0}/{1}", gvGrid.RowCount, _sel.Length);
            }
        }

        public void SetFilterVisible(bool state)
        {
            _FilterVisible = state;
            gvGrid.OptionsFind.AlwaysVisible = state;
            gvGrid.OptionsFind.ClearFindOnClose = !state;
        }

        public void SetSingleSelectMode()
        {
            //AddButtonSelect();
            if (ResetFilterCommand == null)
                ResetFilterCommand = new ReferenceCommand(MenuCommandType.Item, "Сбросить фильтр", ResetFilter, (x) => true) { Image = Properties.Resources.clearfilter_16x16 };
            if (!_commands.Contains(ResetFilterCommand))
                 _commands.Add(ResetFilterCommand);
            pcSelectButton.Visible = true;
            Mode = FormOperationModes.SingleSelect;
            SetMultiSelectMode(GridMultiSelectMode.RowSelect);
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
            CustomKeyDown(e.KeyData);
        }

        protected virtual void CustomKeyDown(Keys keys)
        {
            switch (keys)
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

            if (gvGrid.IsFindPanelVisible && IsKeyLetterOrDogit(keys))
            {
                FindControl find = gvGrid.GridControl.Controls.Find("FindControl", true)[0] as FindControl;
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
            gvGrid.ActiveFilterString = string.Empty;
        }

        protected void FilterByCellValueExecute(object obj)
        {
            FilterByCellValue();
        }

        protected virtual void FilterByCellValue()
        {
            if (gvGrid.FocusedColumn != null && gvGrid.FocusedValue != null && gvGrid.FocusedValue != DBNull.Value)
            {
                gvGrid.ActiveFilterString = string.Format("[{0}] = '{1}'", gvGrid.FocusedColumn.FieldName, gvGrid.FocusedValue);
            }
        }

        public void SetSingleSelectMode(T selectedItem)
        {
            pcSelectButton.Visible = true;

            gvGrid.OptionsSelection.MultiSelect = false;
            gvGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            Mode = FormOperationModes.SingleSelect;
            SelectedItem = selectedItem;
        }

        public virtual void SetFocusedRow(Guid id)
        {
            int _row = -1;
            _row = gvGrid.LocateByValue("Id", id);
            if (_row != -1)
            {
                gvGrid.ClearSelection();
                gvGrid.FocusedRowHandle = _row;
                gvGrid.SelectRow(_row);
            }
        }

        public virtual void SetFocusedRow(int index)
        {
            gvGrid.ClearSelection();
            gvGrid.FocusedRowHandle = index;
            gvGrid.SelectRow(index);
        }


        private BarItem[] GetBarItemsFromCommand(BarManager _barManager, BaseReferenceCommand command)
        {
            if (command.Commands.Count < 1)
                return null;

            List<BarItem> _items = new List<BarItem>();
            BarItem _button;
            foreach (BaseReferenceCommand _command in command.Commands)
            {
                switch (_command.CommandType)
                {
                    case MenuCommandType.Group:
                    case MenuCommandType.ContextMenuGroup:
                        _button = new BarSubItem();
                        BarItem[] _buttons = GetBarItemsFromCommand(_barManager, _command);
                        if (_buttons != null)
                            ((BarSubItem)_button).AddItems(_buttons);
                        break;
                    default:
                        {
                            _button = new BarButtonItem();
                            ((BarButtonItem)_button).BindCommand(_command);
                            _command.Owner = _button;
                            break;
                        }
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

        public void OnExecutionConditionsChanged()
        {
            var _buttonsCommands = _commands.Where(x => x.CommandType != MenuCommandType.ComtextMenuItem &&
                                                        x.CommandType != MenuCommandType.ContextMenuGroup);

            foreach (ReferenceCommand buttonCommand in _buttonsCommands)
            {
                SimpleButton _button = buttonCommand.Owner as SimpleButton;
                if (_button != null)
                    _button.Enabled = buttonCommand.CanExecute(null);
            }
        }

        private void AddButtonSelect()
        {
            pcSelectButton.Visible = true;
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
            this.btnSelect.Text = "Выбрать3";
            btnSelect.Dock = DockStyle.Fill;
            this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
            btnSelect.Visible = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ItemsSelect();
        }

        protected void OnOpenItem()
        {
            OpenItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        protected void OnAddItem()
        {
            AddItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }

        protected virtual void OnDeleteItem(Entity deletedEntity)
        {
            DeleteItemEvent?.Invoke(this, new ListItemEventArgs(GetCurrentRowId()));
        }
        protected void OnDeleteAllItems()
        {
            DeleteAllItemsEvent?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnEntitySelected(T entity)
        {
            EntitySelected?.Invoke(this, entity);
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


        //protected virtual void OnItemSelectionChanged(int[] selectedRowsHandles)
        //{
        //    SelectedItems.Clear();
        //    foreach (var idx in selectedRowsHandles)
        //    {
        //        if (gvGrid.GetRow(idx) is T rowObject)
        //            SelectedItems.Add(Items.FirstOrDefault(dataObject => dataObject.Id == rowObject.Id));
        //    }

        //    ItemSelectionChanged?.Invoke(this, SelectedItems);

        //    foreach (ReferenceCommand command in _commands)
        //    {
        //        new Func<object, bool>(command.CanExecute).Invoke(null);
        //    }
        //}

        protected virtual IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            if (Common.Reflection.Reflector.Instance.FindType($"Fx{typeof(T).Name}Edit") is Type typeFromReflector)
            {
                if (Activator.CreateInstance(typeFromReflector) is IEntityEditor editorFromReflector)
                {
                    if (editorFromReflector is ITabable iTabable)
                        iTabable.DialogOutput += (o, e) => OnDialogOutput(e);

                    editorFromReflector.OpenMode = openMode;
                    Logger.AddInfo($"Открываем редактор [Fx{typeof(T).Name}Edit] из типа, найденного рефлектором");
                    return editorFromReflector;
                }
            }

            Logger.AddInfo($"Открываем редактор [Fx{typeof(T).Name}Edit] из типа который рефлектор не нашел... :(");

            //Ищем редактор в вызывающей сборке
            Type type = Assembly.GetCallingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x =>
                        x.Name == $"Fx{typeof(T).Name}Edit") as Type;

            if (type == null)
            {
                //Ищем сборку редактора по атрибуту сущности
                if (typeof(T).GetCustomAttribute<Socrat.Common.Attributes.EditorAttribute>() is
                    Socrat.Common.Attributes.EditorAttribute editorAttribute)
                {
                    if (Assembly.Load(editorAttribute.AssemblyName) is Assembly assembly)
                    {
                        type = assembly.GetTypes()
                          .FirstOrDefault(x =>
                              x.Name == $"Fx{typeof(T).Name}Edit") as Type;
                    }
                }
            }

            if (type == null)
            {
                //Ищем сборку редактора по атрибуту текуущего грида
                if (this.GetType().GetCustomAttribute<Socrat.Common.Attributes.EditorAttribute>() is
                    Socrat.Common.Attributes.EditorAttribute editorAttribute)
                {
                    if (Assembly.Load(editorAttribute.AssemblyName) is Assembly assembly)
                    {
                        type = assembly.GetTypes()
                          .FirstOrDefault(x =>
                              x.Name == $"Fx{typeof(T).Name}Edit") as Type;
                    }
                }
            }

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
                if (editor is ITabable iTabable)
                    iTabable.DialogOutput += (o, e) => OnDialogOutput(e);

                editor.OpenMode = openMode;
                return editor;
            }

            return null;
        }

        protected virtual string GetTitle()
        {
            return "Базовый обобщеный компонент табличного списка";
        }

        protected void SetActionLabel(string text)
        {
            gcTitle.Visible = !string.IsNullOrEmpty(text);
            gcTitle.Text = text;
            if (gcTitle.Controls.Count == 0)
                lciTopPane.Height = 30;
        }

        private void _gvGrid_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest == GridHitTest.RowCell)
            {
                e.Allow = false;
                popupMenu.ShowPopup(gcGrid.PointToScreen(e.Point));
            }
        }

        protected void AddToActionPanel(Control control)
        {
            if (string.IsNullOrEmpty(gcTitle.Text))
            {
                gcTitle.Visible = true;
                gcTitle.ShowCaption = false;
            }
            else
            {
                lciTopPane.Height = 45;
            }

            if (!gcTitle.Controls.Contains(control))
            {
                gcTitle.Controls.Add(control);
            }
        }

        private void CxGenericListTable_VisibleChanged(object sender, EventArgs e)
        {
            if (_Inited && !Visible)
                SaveGridsSettings();
        }

        //private void _gvGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    OnItemSelectionChanged(new[] { e.FocusedRowHandle });
        //}

        #region Управление видимостью полей команд. Надо бы как-то слить вместе генерализованый контрол и старый

        public void SetActionsButtonVisibility(bool show)
        {
            if (show)
                esiAction.Visibility = lciAction.Visibility = lciActionLabel.Visibility = LayoutVisibility.Always;
            else
                esiAction.Visibility = lciAction.Visibility = lciActionLabel.Visibility = LayoutVisibility.Never;
        }

        public void SetFooterVisibility(bool show)
        {
            if (show)
            {
                lciFooter.Visibility = lciSelectButton.Visibility = LayoutVisibility.Always;
                lciTable.OptionsTableLayoutItem.RowSpan = 1;
            }
            else
            {
                lciFooter.Visibility = lciSelectButton.Visibility = LayoutVisibility.Never;
                lciTable.OptionsTableLayoutItem.RowSpan = 2;
            }
        }

        public void SetRightPaneButtonsVisibility(bool show)
        {
            if (show)
            {
                if (esiAction.Visibility == LayoutVisibility.Never)
                    lciButtons.Visibility = lciSelectButton.Visibility = LayoutVisibility.Always;
                else
                    esiAction.Visibility = lciButtons.Visibility = lciSelectButton.Visibility = LayoutVisibility.Always;
            }
            else
                esiAction.Visibility = lciButtons.Visibility = lciSelectButton.Visibility = LayoutVisibility.Never;
        }

        public void SetShowGroupPanel(bool visible)
        {
            gvGrid.OptionsView.ShowGroupPanel = visible;
        }

        #endregion


        public void SetVisualStyleMinimized(bool topPaneVisible = false, bool rightPaneVisible = false, bool bottomPaneVisible = false)
        {
            Dock = DockStyle.Fill;

            FilterVisible = false;
            MultiSelect = false;
            MultiSelectMode = GridMultiSelectMode.RowSelect;
            SetShowGroupPanel(false);

            TopPaneVisible = topPaneVisible;
            RightPaneVisible = rightPaneVisible;
            BottomPaneVisible = bottomPaneVisible;
        }

        public T GetFocusedItem()
        {
            Guid id = GetCurrentRowId();
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public void SetCheckBoxMultuSelect()
        {
            gvGrid.OptionsSelection.MultiSelect = true;
            gvGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gvGrid.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
        }

        #region Layout control properties

        [Category("Grid Layout")]
        public bool RightPaneVisible
        {
            get => lciRightPane.Visibility == LayoutVisibility.Always;
            set
            {
                if (value)
                    lciRightPane.Visibility = LayoutVisibility.Always;
                else
                    lciRightPane.Visibility = LayoutVisibility.Never;
            }
        }
        [Category("Grid Layout")]
        public int RightPaneWidth
        {
            get => lciRightPane.Width;
            set => lciRightPane.Width = value;
        }

        [Category("Grid Layout")]
        public bool BottomPaneVisible
        {
            get => lciBottomPane.Visibility == LayoutVisibility.Always;
            set
            {
                if (value)
                    lciBottomPane.Visibility = LayoutVisibility.Always;
                else
                    lciBottomPane.Visibility = LayoutVisibility.Never;
            }
        }

        [Category("Grid Layout")]
        public bool TopPaneVisible
        {
            get => lciTopPane.Visibility == LayoutVisibility.Always;
            set
            {
                if (value)
                    lciTopPane.Visibility = LayoutVisibility.Always;
                else
                    lciTopPane.Visibility = LayoutVisibility.Never;
            }
        }
        [Category("Grid Layout")]
        public bool GroupPaneVisible
        {
            get => gvGrid.OptionsView.ShowGroupPanel;
            set => gvGrid.OptionsView.ShowGroupPanel = value;
        }
        [Category("Grid Layout")]
        public bool SearchPaneVisible
        {
            get => gvGrid.OptionsFind.AlwaysVisible;
            set => gvGrid.OptionsFind.AlwaysVisible = value;
        }
        [Category("Grid Layout")]
        public bool ActionPaneVisible
        {
            get => lciActionPane.Visibility == LayoutVisibility.Always;
            set
            {
                if (value)
                    lciActionPane.Visibility = LayoutVisibility.Always;
                else
                    lciActionPane.Visibility = LayoutVisibility.Never;
            }
        }

        [Category("Grid Layout")]
        public string HeaderText
        {
            get => gcTitle.Text;
            set
            {
                gcTitle.Visible = !string.IsNullOrEmpty(value);
                gcTitle.Text = value;
                if (gcTitle.Controls.Count == 0)
                    lciTopPane.Height = 30;
            }
        }

        #endregion

        #region Обеспечение создания нового инстанса по требованию

        /// <summary>
        /// Событие, вызываемое у подписчиков в момент создания сущности, 
        /// </summary>
        public event EventHandler<EntityCreatingEventArgs> EntityCreating;
        public event EventHandler<T> EntityCreated;

        protected void OnEntityCtreating(EntityCreatingEventArgs e)
        {
            EntityCreating?.Invoke(this, e);
        }

        protected void OnEntityCreated(T entity)
        {
            EntityCreated?.Invoke(this, entity);
        }

        #endregion

        #region Обеспечения выполения комманд, прописанных в Entity

        public event EventHandler<CommandExecutingEventArgs> CommandExecuting;
        public event EventHandler<object> CommandExecuted;

        public void OnCommandExecuting(CommandExecutingEventArgs e)
        {
            CommandExecuting?.Invoke(this, e);
        }

        public void OnCommandExecuted(object data)
        {
            CommandExecuted?.Invoke(this, data);
        }

        #endregion

        #region Управление доступностью стандартных комманд

        public bool CanAdd { get; set; } = true;

        public bool CanOpen { get; set; } = true;

        public bool CanDelete { get; set; } = true;

        public bool CanBePrinted { get; set; } = true;

        public bool CanExportToExcel { get; set; } = true;

        #endregion

        private HashSet<Type> _numericTypes = new HashSet<Type>
                    {
                        typeof(decimal), typeof(byte), typeof(sbyte),
                        typeof(short), typeof(ushort), typeof(float),
                        typeof(double), typeof(int), typeof(uint)
                    };

        protected void OnCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            {
                if (e.ListSourceRowIndex == DevExpress.XtraGrid.GridControl.InvalidRowHandle) return;
                if (!(e.Column.Tag is PropertyVisualisationAttribute columnProperity))
                    return;

                e.Column.AppearanceCell.TextOptions.HAlignment = columnProperity.HAlignment;
                e.Column.AppearanceHeader.TextOptions.HAlignment = columnProperity.HAlignment;

                if (e.Value == null) return;

                string displayValue = $"{e.Value}";
                Type valueType = e.Value.GetType();
                if (valueType.IsValueType)
                {
                    if (_numericTypes.Any(t => t == valueType))
                    {
                        if (e.Value is double value)
                        {
                            if (value == 0 && columnProperity.ReplaceZeroValueBy != null)
                            {
                                e.DisplayText = columnProperity.ReplaceZeroValueBy;
                                return;
                            }
                            else
                            {
                                if (columnProperity.TextFormat == "c2")
                                    displayValue = $"{e.Value:c2}";
                                else if (columnProperity.TextFormat == "p2")
                                    displayValue = $"{(100 * (double)e.Value):f2} %";
                                else if (columnProperity.TextFormat == "f2")
                                    displayValue = $"{e.Value:f2}";
                                else
                                    displayValue = $"{e.Value}";
                            }
                        }
                    }
                    if (e.Value is DateTime date)
                    {
                        if (columnProperity.TextFormat == "d")
                        {
                            displayValue = $"{e.Value:d}";
                            return;
                        }
                    }
                }
                e.DisplayText = $"{columnProperity.ValuePrefix}{displayValue}{columnProperity.ValueSuffix}";
            }
        }

        protected void OnRefreshingData()
        {
            RefreshingData?.Invoke(this, EventArgs.Empty);
        }

        protected void OnGetItemsReturnEmptyList(AttachedList<T> items)
        {
            GetItemsReturnEmptyList?.Invoke(this, items);
        }

        public T FocusedEntity { get; set; }

        public void HideOpenButton()
        {
            _commands.Remove(CommandOpen);
        }

        private void _gvGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            FocusedEntity = gvGrid.GetRow(e.FocusedRowHandle) as T;
            OnEntitySelected(FocusedEntity);
        }

        public override void CreatePrintController(Type requestorType = null, Type controllerType = null, Socrat.Common.Interfaces.MVC.IView parentView = null)
        {
            if (requestorType == null)
                base.CreatePrintController(typeof(T), controllerType, parentView);  
            else
                base.CreatePrintController(requestorType, controllerType, parentView);
        }

        public override List<object> GetPrintableData()
        {
            List<object> data = base.GetPrintableData();

            gvGrid.GetSelectedRows().ToList()
                .ForEach(idx =>
                {
                    if (gvGrid.GetRow(idx) is T entity)
                        data.Add(entity);
                });
            return data;
        }

        public void ResetFilter(object data)
        {
            ExternalFilterExp = null;
            OnRefreshButtonClick();
        }

        #region IView implementation
        public object Data { get; protected set; }
        public object Selection { get; set; }

        private Socrat.Common.Interfaces.MVC.IViewModel _viewModel;
        public Socrat.Common.Interfaces.MVC.IViewModel ViewModel
        {
            get => GetViewModel(_viewModel);
            set => _viewModel = value;
        }
        public virtual Socrat.Common.Interfaces.MVC.IViewModel GetViewModel(Socrat.Common.Interfaces.MVC.IViewModel viewModel = null)
        {
            if (_viewModel == null)
                OnViewModelEmpty(viewModel);
            return _viewModel;
        }
        protected virtual void OnViewModelEmpty(Socrat.Common.Interfaces.MVC.IViewModel viewModel)
        {
            ViewModelEmpty?.Invoke(this, viewModel);
        }

        public event EventHandler<Socrat.Common.Interfaces.MVC.IViewModel> ViewModelEmpty;

        #endregion

        private void sbResetFilter_Click(object sender, EventArgs e)
        {
            ResetFilter(null);
        }

        #region Логика создания комманд

        /// <summary>
        /// Вызывается прямо перед вызовом базового метода InitCommands или его переопределения
        /// </summary>
        public event EventHandler<List<ReferenceCommand>> CommandsInitializing;
        /// <summary>
        /// Вызывается сразу после вызова базового метода InitCommands или его переопределения
        /// </summary>
        public event EventHandler<List<ReferenceCommand>> CommandsInitialized;
        /// <summary>
        /// Вызывается сразу после вызова метода BuildCommandsControls
        /// </summary>
        public event EventHandler CommandsControlsBuilt;

        /// <summary>
        /// Обертка вызовов потока создания команд грида
        /// </summary>
        private void InternalInitCommands()
        {
            _commands = new List<ReferenceCommand>();
            //Сигналим перед началом инициализации
            OnCommandsInitializing(_commands);
            InitCommands();
            //Сигналим после инициализации
            OnCommandsInitialized(_commands);
            BuildCommandsControls();
            //Сигналим после инициализации контролов команд
            OnCommandsControlsBuilt();
        }

        protected virtual void OnCommandsInitializing(List<ReferenceCommand> commands)
        {
            CommandsInitializing?.Invoke(this, commands);
        }

        protected virtual void OnCommandsInitialized(List<ReferenceCommand> commands)
        {
            CommandsInitialized?.Invoke(this, commands);
        }
        protected virtual void OnCommandsControlsBuilt()
        {
            CommandsControlsBuilt?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void InitCommands()
        {
            if (_commands == null)
                _commands = new List<ReferenceCommand>();

            if (CommandOpen == null) CommandOpen = new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, CanOpenItem, ReferenceCommand.ActionTypes.ViewOrEdit) { Image = Properties.Resources.preview_16x16 };

            
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null, ReferenceCommand.ActionTypes.Refresh) { Image = Properties.Resources.refresh2_16x16 });
            if (CanOpen) _commands.Add(CommandOpen);
            if (CanAdd) _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Добавить", AddItemExecute, CanAddItem, ReferenceCommand.ActionTypes.Add) { Image = Properties.Resources.addfile_16x16, IsWriteCommand = true });
            if (CanDelete) _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, CanDeleteItem, ReferenceCommand.ActionTypes.Delete) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true, ActionType = ReferenceCommand.ActionTypes.Delete });
            if (CanBePrinted) _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Печать...", Print, CanPrint, BaseReferenceCommand.ActionTypes.Print) { Image = Properties.Resources.print_16x16, BeginGroup = true, IsWriteCommand = true });

            //List<ReferenceCommand> tmp = new List<ReferenceCommand>();
            //CreatePrintCommands().ForEach(obj => { if (obj is BaseReferenceCommand cmd) tmp.Add(new ReferenceCommand(cmd)); });
            //_commands.AddRange(tmp);

            if (CanExportToExcel) _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Экспорт в Excel", ExpotrtToExcelExecute, null, ReferenceCommand.ActionTypes.Export) { Image = Properties.Resources.exporttoxlsx_16x16, BeginGroup = true, IsWriteCommand = true });
            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отбор по значению текущей ячейки", FilterByCellValueExecute, null) { Image = Properties.Resources.reapplyfilter_16x16, BeginGroup = true });
            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отменить отбор", ResetFilterByCellValueExecute, null) { Image = Properties.Resources.clearfilter_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Сбросить настройки таблицы", ResetGridSettingsExecute, null) { Image = Properties.Resources.reapplyfilter_16x16, BeginGroup = true });


            bool newGroupStarted = false;

            typeof(T).GetMethods().ToList()
                .ForEach(method =>
                {
                    if (method.GetCustomAttribute<CommandMethodAttribute>() is CommandMethodAttribute command)
                    {
                        if (!(method.CreateDelegate(typeof(Func<object, object>)) is Func<object, object> commandDelegate))
                            return;

                        ReferenceCommand cmd = new ReferenceCommand(
                                commandDelegate,
                                MenuCommandType.Item,
                                command.Title)
                                    { ToolTipText = command.TooltipText};

                        if (!newGroupStarted)
                        {
                            cmd.BeginGroup = true;
                            newGroupStarted = true;
                        }
                        cmd.Executing += (o, e) => OnCommandExecuting(e);
                        cmd.Executed += (o, e) => OnCommandExecuted(e);
                        _commands.Add(cmd);
                    };
                });
        }

        private void BuildCommandsControls()
        {
            //боковые кнопки
            if (_commands == null) // если кнопки не заданы (не нужны)            
                return;

            var _buttonsCommands = _commands.Where(x => x.CommandType != MenuCommandType.ComtextMenuItem &&
                                                        x.CommandType != MenuCommandType.ContextMenuGroup);
            SimpleButton _button;
            foreach (ReferenceCommand buttonCommand in _buttonsCommands)
            {
                switch (buttonCommand.CommandType)
                {
                    case MenuCommandType.Group:
                        _button = new DropDownButton();
                        ((DropDownButton)_button).DropDownControl =
                            GetPopupMenuFromCommand(this.barManager, buttonCommand);
                        ((DropDownButton)_button).Click += (sender, args) => { ((DropDownButton)sender).ShowDropDown(); };
                        break;
                    default:
                        _button = new SimpleButton();
                        break;
                }
                buttonCommand.Owner = _button;
                _button.ToolTip = buttonCommand.ToolTipText;
                _button.Text = buttonCommand.Title;
                _button.ImageOptions.Image = buttonCommand.Image;
                _button.BindCommand(buttonCommand);
                _button.Enabled = !buttonCommand.ReadOnly & buttonCommand.CanExecute(null);
                _button.Layout += (o, e) =>
                {
                    _button.Enabled = buttonCommand.CanExecute(null);
                };

                AddButton(_button);
                if (buttonCommand.IsWriteCommand)
                    WriteCommandsButtons.Add(_button);
            }

            //меню действие и контекстное меню
            var _actionCommands = _commands.Where(x => x.CommandType != MenuCommandType.ButtonsOnly);
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
                        ((BarButtonItem)_barItem).BindCommand(actionCommand);
                        if (actionCommand.IsWriteCommand)
                            WriteCommandsBarButtons.Add((BarButtonItem)_barItem);
                        break;
                }
                this.popupMenu.LinksPersistInfo.Add(new LinkPersistInfo(_barItem, actionCommand.BeginGroup));
                this.barManager.Items.Add(_barItem);
            }
        }

        /// <summary>
        /// Добавляем кнопки в правую панель
        /// </summary>
        /// <param name="button"></param>
        public void AddButton(SimpleButton button)
        {
            button.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            button.Location = new System.Drawing.Point(3, 61);
            button.Size = new System.Drawing.Size(128, 23);
            flpButtons.Controls.Add(button);
        }

        #endregion
    }
}
