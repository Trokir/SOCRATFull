namespace Socrat.References.Statuses
{
    partial class CxWorkQueuesItemsTree
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxWorkQueuesItemsTree));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiClearSelection = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSetLine = new DevExpress.XtraBars.BarSubItem();
            this.bbiExpandAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColapseAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiWorkQueuesExpand = new DevExpress.XtraBars.BarButtonItem();
            this.btnColapseWorkQueues = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpandToOrder = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColapseToOrder = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbiSetStatus = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetDateDone = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetCutters = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetAsseblers = new DevExpress.XtraBars.BarButtonItem();
            this.bsiDateDone = new DevExpress.XtraBars.BarSubItem();
            this.bdeDateDone = new DevExpress.XtraBars.BarEditItem();
            this.rideDone = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bbiSetDefect = new DevExpress.XtraBars.BarButtonItem();
            this.tlTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.htlTitle = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.svgImageCollection = new DevExpress.Utils.SvgImageCollection(this.components);
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rideDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rideDone.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.htlTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dropDownButton1);
            this.layoutControl1.Controls.Add(this.tlTree);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(540, 254, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(571, 757);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.DropDownControl = this.popupMenu;
            this.dropDownButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dropDownButton1.ImageOptions.Image")));
            this.dropDownButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.dropDownButton1.Location = new System.Drawing.Point(12, 12);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(130, 22);
            this.dropDownButton1.StyleController = this.layoutControl1;
            this.dropDownButton1.TabIndex = 6;
            this.dropDownButton1.Text = "Действие";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClearSelection, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetLine, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExpandAll, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiColapseAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiWorkQueuesExpand),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnColapseWorkQueues),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExpandToOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiColapseToOrder)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // bbiClearSelection
            // 
            this.bbiClearSelection.Caption = "Снять отметки";
            this.bbiClearSelection.Id = 6;
            this.bbiClearSelection.Name = "bbiClearSelection";
            this.bbiClearSelection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClearSelection_ItemClick);
            // 
            // bsiSetLine
            // 
            this.bsiSetLine.Caption = "Установить линию";
            this.bsiSetLine.Id = 11;
            this.bsiSetLine.Name = "bsiSetLine";
            // 
            // bbiExpandAll
            // 
            this.bbiExpandAll.Caption = "Развернуть все";
            this.bbiExpandAll.Id = 1;
            this.bbiExpandAll.Name = "bbiExpandAll";
            this.bbiExpandAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpandAll_ItemClick);
            // 
            // bbiColapseAll
            // 
            this.bbiColapseAll.Caption = "Свернуть все";
            this.bbiColapseAll.Id = 0;
            this.bbiColapseAll.Name = "bbiColapseAll";
            this.bbiColapseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiColapseAll_ItemClick);
            // 
            // bbiWorkQueuesExpand
            // 
            this.bbiWorkQueuesExpand.Caption = "Развернуть до очередей";
            this.bbiWorkQueuesExpand.Id = 2;
            this.bbiWorkQueuesExpand.Name = "bbiWorkQueuesExpand";
            this.bbiWorkQueuesExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiWorkQueuesExpand_ItemClick);
            // 
            // btnColapseWorkQueues
            // 
            this.btnColapseWorkQueues.Caption = "Свернуть до очередей";
            this.btnColapseWorkQueues.Id = 3;
            this.btnColapseWorkQueues.Name = "btnColapseWorkQueues";
            this.btnColapseWorkQueues.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnColapseWorkQueues_ItemClick);
            // 
            // bbiExpandToOrder
            // 
            this.bbiExpandToOrder.Caption = "Развернуть до заказов";
            this.bbiExpandToOrder.Id = 4;
            this.bbiExpandToOrder.Name = "bbiExpandToOrder";
            this.bbiExpandToOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpandToOrder_ItemClick);
            // 
            // bbiColapseToOrder
            // 
            this.bbiColapseToOrder.Caption = "Свернуть до заказов";
            this.bbiColapseToOrder.Id = 5;
            this.bbiColapseToOrder.Name = "bbiColapseToOrder";
            this.bbiColapseToOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiColapseToOrder_ItemClick);
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiColapseAll,
            this.bbiExpandAll,
            this.bbiWorkQueuesExpand,
            this.btnColapseWorkQueues,
            this.bbiExpandToOrder,
            this.bbiColapseToOrder,
            this.bbiClearSelection,
            this.bbiSetStatus,
            this.bbiSetDateDone,
            this.bbiSetCutters,
            this.bbiSetAsseblers,
            this.bsiSetLine,
            this.bsiDateDone,
            this.bdeDateDone,
            this.bbiSetDefect});
            this.barManager.MaxItemId = 19;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rideDone});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(571, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 757);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(571, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 757);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(571, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 757);
            // 
            // bbiSetStatus
            // 
            this.bbiSetStatus.Caption = "Установить статус";
            this.bbiSetStatus.Id = 7;
            this.bbiSetStatus.Name = "bbiSetStatus";
            this.bbiSetStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetStatus_ItemClick);
            // 
            // bbiSetDateDone
            // 
            this.bbiSetDateDone.Caption = "Установить дату готовности";
            this.bbiSetDateDone.Id = 8;
            this.bbiSetDateDone.Name = "bbiSetDateDone";
            // 
            // bbiSetCutters
            // 
            this.bbiSetCutters.Caption = "Установить бригаду резщиков";
            this.bbiSetCutters.Id = 9;
            this.bbiSetCutters.Name = "bbiSetCutters";
            this.bbiSetCutters.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetCutters_ItemClick);
            // 
            // bbiSetAsseblers
            // 
            this.bbiSetAsseblers.Caption = "Установить бригаду сборщиков";
            this.bbiSetAsseblers.Id = 10;
            this.bbiSetAsseblers.Name = "bbiSetAsseblers";
            this.bbiSetAsseblers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetAsseblers_ItemClick);
            // 
            // bsiDateDone
            // 
            this.bsiDateDone.Caption = "Установить дату готовности";
            this.bsiDateDone.Id = 12;
            this.bsiDateDone.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bdeDateDone)});
            this.bsiDateDone.Name = "bsiDateDone";
            // 
            // bdeDateDone
            // 
            this.bdeDateDone.Caption = "Установить дату готовности";
            this.bdeDateDone.Edit = this.rideDone;
            this.bdeDateDone.Id = 17;
            this.bdeDateDone.Name = "bdeDateDone";
            this.bdeDateDone.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bdeDateDone_ItemClick);
            // 
            // rideDone
            // 
            this.rideDone.AutoHeight = false;
            this.rideDone.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rideDone.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rideDone.Name = "rideDone";
            this.rideDone.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.rideDone_Closed);
            // 
            // bbiSetDefect
            // 
            this.bbiSetDefect.Caption = "Отметить брак";
            this.bbiSetDefect.Id = 18;
            this.bbiSetDefect.Name = "bbiSetDefect";
            this.bbiSetDefect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiSetDefect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetDefect_ItemClick);
            // 
            // tlTree
            // 
            this.tlTree.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlTree.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.tlTree.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tlTree.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.tlTree.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tlTree.ChildListFieldName = "WorkItems";
            this.tlTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
            this.tlTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlTree.HtmlImages = this.svgImageCollection;
            this.tlTree.Location = new System.Drawing.Point(2, 48);
            this.tlTree.Name = "tlTree";
            this.tlTree.OptionsBehavior.Editable = false;
            this.tlTree.OptionsBehavior.ReadOnly = true;
            this.tlTree.OptionsSelection.MultiSelect = true;
            this.tlTree.OptionsSelection.UseIndicatorForSelection = true;
            this.tlTree.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.tlTree.OptionsView.ShowCaption = true;
            this.tlTree.OptionsView.ShowFirstLines = false;
            this.tlTree.OptionsView.ShowHorzLines = false;
            this.tlTree.OptionsView.ShowIndicator = false;
            this.tlTree.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.False;
            this.tlTree.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.htlTitle,
            this.repositoryItemProgressBar1});
            this.tlTree.Size = new System.Drawing.Size(567, 707);
            this.tlTree.TabIndex = 5;
            this.tlTree.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.tlTree_NodeCellStyle);
            this.tlTree.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.tlTree_AfterExpand);
            this.tlTree.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlTree_AfterCheckNode);
            this.tlTree.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlTree_FocusedNodeChanged);
            this.tlTree.CustomColumnDisplayText += new DevExpress.XtraTreeList.CustomColumnDisplayTextEventHandler(this.tlTree_CustomColumnDisplayText);
            this.tlTree.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.tlTree_PopupMenuShowing);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = " ";
            this.treeListColumn1.ColumnEdit = this.htlTitle;
            this.treeListColumn1.FieldName = "WorkTitle";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 325;
            // 
            // htlTitle
            // 
            this.htlTitle.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.htlTitle.HtmlImages = this.svgImageCollection;
            this.htlTitle.Name = "htlTitle";
            this.htlTitle.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.htlTitle_CustomDisplayText);
            // 
            // svgImageCollection
            // 
            this.svgImageCollection.Add("bo_vendor", "image://svgimages/business objects/bo_vendor.svg");
            this.svgImageCollection.Add("GreenRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.GreenRomb"))));
            this.svgImageCollection.Add("BlueRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.BlueRomb"))));
            this.svgImageCollection.Add("EmptyRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.EmptyRomb"))));
            this.svgImageCollection.Add("GreyRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.GreyRomb"))));
            this.svgImageCollection.Add("RedRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.RedRomb"))));
            this.svgImageCollection.Add("YellowRomb", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.YellowRomb"))));
            this.svgImageCollection.Add("ZeroQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.ZeroQueue"))));
            this.svgImageCollection.Add("4LineQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.4LineQueue"))));
            this.svgImageCollection.Add("1LineQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.1LineQueue"))));
            this.svgImageCollection.Add("3LineQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.3LineQueue"))));
            this.svgImageCollection.Add("2LineQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.2LineQueue"))));
            this.svgImageCollection.Add("EmptyQueue", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.EmptyQueue"))));
            this.svgImageCollection.Add("Defect", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection.Defect"))));
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Изготовлено";
            this.treeListColumn2.FieldName = "DateDone";
            this.treeListColumn2.MaxWidth = 80;
            this.treeListColumn2.MinWidth = 80;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 3;
            this.treeListColumn2.Width = 80;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Готовность";
            this.treeListColumn3.FieldName = "Progress";
            this.treeListColumn3.MaxWidth = 80;
            this.treeListColumn3.MinWidth = 80;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            this.treeListColumn3.Width = 80;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "В процентах";
            this.treeListColumn4.ColumnEdit = this.repositoryItemProgressBar1;
            this.treeListColumn4.FieldName = "ProgressPercent";
            this.treeListColumn4.MaxWidth = 80;
            this.treeListColumn4.MinWidth = 80;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 80;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.EndColor = System.Drawing.Color.ForestGreen;
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.StartColor = System.Drawing.Color.Red;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(571, 757);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(381, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(190, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(154, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(227, 46);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tlTree;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(571, 711);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dropDownButton1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(154, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // CxWorkQueuesItemsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CxWorkQueuesItemsTree";
            this.Size = new System.Drawing.Size(571, 757);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rideDone.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rideDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.htlTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraTreeList.TreeList tlTree;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel htlTitle;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarButtonItem bbiExpandAll;
        private DevExpress.XtraBars.BarButtonItem bbiColapseAll;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiWorkQueuesExpand;
        private DevExpress.XtraBars.BarButtonItem btnColapseWorkQueues;
        private DevExpress.XtraBars.BarButtonItem bbiExpandToOrder;
        private DevExpress.XtraBars.BarButtonItem bbiColapseToOrder;
        private DevExpress.XtraBars.BarButtonItem bbiClearSelection;
        private DevExpress.XtraBars.BarButtonItem bbiSetStatus;
        private DevExpress.XtraBars.BarButtonItem bbiSetDateDone;
        private DevExpress.XtraBars.BarButtonItem bbiSetCutters;
        private DevExpress.XtraBars.BarButtonItem bbiSetAsseblers;
        private DevExpress.XtraBars.BarSubItem bsiSetLine;
        private DevExpress.XtraBars.BarSubItem bsiDateDone;
        private DevExpress.XtraBars.BarEditItem bdeDateDone;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rideDone;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraBars.BarButtonItem bbiSetDefect;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
    }
}
