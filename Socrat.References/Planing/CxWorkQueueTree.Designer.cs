namespace Socrat.References.Planing
{
    partial class CxWorkQueueTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxWorkQueueTree));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnSetPrevDate = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetNextDate = new DevExpress.XtraEditors.SimpleButton();
            this.tlWorkPlan = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.hlTitle = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.svgImageCollection = new DevExpress.Utils.SvgImageCollection(this.components);
            this.deQueueDate = new DevExpress.XtraEditors.DateEdit();
            this.btnAction = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPlanQueue = new DevExpress.XtraBars.BarButtonItem();
            this.biReplan = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSetMachine = new DevExpress.XtraBars.BarSubItem();
            this.bsiSetWorkShift = new DevExpress.XtraBars.BarSubItem();
            this.biResetProdLine = new DevExpress.XtraBars.BarButtonItem();
            this.biResetWorkShift = new DevExpress.XtraBars.BarButtonItem();
            this.biSetNum = new DevExpress.XtraBars.BarButtonItem();
            this.biChangeQueueDate = new DevExpress.XtraBars.BarButtonItem();
            this.biDelQueue = new DevExpress.XtraBars.BarButtonItem();
            this.biDelEmptyQueue = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.bsiAddOrderAtNewQueue = new DevExpress.XtraBars.BarSubItem();
            this.bsiAddOrderAtExistsQueue = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.biRemoveFromQueue = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.pmQueue = new DevExpress.XtraBars.PopupMenu(this.components);
            this.pmOrder = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlWorkPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deQueueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deQueueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmQueue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnSetPrevDate);
            this.layoutControl.Controls.Add(this.btnSetNextDate);
            this.layoutControl.Controls.Add(this.tlWorkPlan);
            this.layoutControl.Controls.Add(this.deQueueDate);
            this.layoutControl.Controls.Add(this.btnAction);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(859, 347, 650, 400);
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(456, 701);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnSetPrevDate
            // 
            this.btnSetPrevDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPrevDate.ImageOptions.Image")));
            this.btnSetPrevDate.Location = new System.Drawing.Point(285, 10);
            this.btnSetPrevDate.MaximumSize = new System.Drawing.Size(27, 22);
            this.btnSetPrevDate.MinimumSize = new System.Drawing.Size(27, 22);
            this.btnSetPrevDate.Name = "btnSetPrevDate";
            this.btnSetPrevDate.Size = new System.Drawing.Size(27, 22);
            this.btnSetPrevDate.StyleController = this.layoutControl;
            this.btnSetPrevDate.TabIndex = 9;
            this.btnSetPrevDate.Click += new System.EventHandler(this.btnSetPrevDate_Click);
            // 
            // btnSetNextDate
            // 
            this.btnSetNextDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetNextDate.ImageOptions.Image")));
            this.btnSetNextDate.Location = new System.Drawing.Point(422, 10);
            this.btnSetNextDate.Name = "btnSetNextDate";
            this.btnSetNextDate.Size = new System.Drawing.Size(24, 22);
            this.btnSetNextDate.StyleController = this.layoutControl;
            this.btnSetNextDate.TabIndex = 8;
            this.btnSetNextDate.Click += new System.EventHandler(this.btnSetNextDate_Click);
            // 
            // tlWorkPlan
            // 
            this.tlWorkPlan.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlWorkPlan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tlWorkPlan.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tlWorkPlan.HtmlImages = this.svgImageCollection;
            this.tlWorkPlan.Location = new System.Drawing.Point(2, 44);
            this.tlWorkPlan.Name = "tlWorkPlan";
            this.tlWorkPlan.OptionsBehavior.Editable = false;
            this.tlWorkPlan.OptionsSelection.MultiSelect = true;
            this.tlWorkPlan.OptionsSelection.UseIndicatorForSelection = true;
            this.tlWorkPlan.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlWorkPlan.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus;
            this.tlWorkPlan.OptionsView.RootCheckBoxStyle = DevExpress.XtraTreeList.NodeCheckBoxStyle.None;
            this.tlWorkPlan.OptionsView.ShowHorzLines = false;
            this.tlWorkPlan.OptionsView.ShowIndicator = false;
            this.tlWorkPlan.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.tlWorkPlan.OptionsView.ShowVertLines = false;
            this.tlWorkPlan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.hlTitle});
            this.tlWorkPlan.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.tlWorkPlan.Size = new System.Drawing.Size(452, 655);
            this.tlWorkPlan.TabIndex = 7;
            this.tlWorkPlan.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.tlWorkPlan_NodeCellStyle);
            this.tlWorkPlan.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlWorkPlan_AfterCheckNode);
            this.tlWorkPlan.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlWorkPlan_FocusedNodeChanged);
            this.tlWorkPlan.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.tlWorkPlan_PopupMenuShowing);
            this.tlWorkPlan.DoubleClick += new System.EventHandler(this.tlWorkPlan_DoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Очередь";
            this.treeListColumn1.ColumnEdit = this.hlTitle;
            this.treeListColumn1.FieldName = "QueueTitle";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.ReadOnly = true;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // hlTitle
            // 
            this.hlTitle.HtmlImages = this.svgImageCollection;
            this.hlTitle.Name = "hlTitle";
            this.hlTitle.ReadOnly = true;
            // 
            // svgImageCollection
            // 
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
            // 
            // deQueueDate
            // 
            this.deQueueDate.EditValue = null;
            this.deQueueDate.Location = new System.Drawing.Point(316, 10);
            this.deQueueDate.MaximumSize = new System.Drawing.Size(100, 0);
            this.deQueueDate.Name = "deQueueDate";
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.deQueueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.deQueueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deQueueDate.Size = new System.Drawing.Size(100, 22);
            this.deQueueDate.StyleController = this.layoutControl;
            this.deQueueDate.TabIndex = 6;
            this.deQueueDate.EditValueChanged += new System.EventHandler(this.deQueueDate_EditValueChanged);
            // 
            // btnAction
            // 
            this.btnAction.DropDownControl = this.popupMenu;
            this.btnAction.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAction.ImageOptions.Image")));
            this.btnAction.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnAction.Location = new System.Drawing.Point(10, 10);
            this.btnAction.Name = "btnAction";
            this.barManager.SetPopupContextMenu(this.btnAction, this.popupMenu);
            this.btnAction.Size = new System.Drawing.Size(119, 22);
            this.btnAction.StyleController = this.layoutControl;
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Действие";
            this.btnAction.ArrowButtonClick += new System.EventHandler(this.btnAction_ArrowButtonClick);
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.popupMenu.Manager = this.barManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Очередь";
            this.barSubItem2.Id = 4;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPlanQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.biReplan),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetMachine, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetWorkShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.biResetProdLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.biResetWorkShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSetNum, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biChangeQueueDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelQueue, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelEmptyQueue)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // biEdit
            // 
            this.biEdit.Caption = "Редактировать";
            this.biEdit.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.biEdit.Id = 0;
            this.biEdit.Name = "biEdit";
            this.biEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEdit_ItemClick);
            // 
            // bbiPlanQueue
            // 
            this.bbiPlanQueue.Caption = "Отменить нарезку";
            this.bbiPlanQueue.Id = 26;
            this.bbiPlanQueue.Name = "bbiPlanQueue";
            this.bbiPlanQueue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPlanQueue_ItemClick);
            // 
            // biReplan
            // 
            this.biReplan.Caption = "Отменить планирование";
            this.biReplan.Id = 29;
            this.biReplan.Name = "biReplan";
            this.biReplan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biReplan_ItemClick);
            // 
            // bsiSetMachine
            // 
            this.bsiSetMachine.Caption = "Установить линию";
            this.bsiSetMachine.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.bsiSetMachine.Id = 3;
            this.bsiSetMachine.Name = "bsiSetMachine";
            // 
            // bsiSetWorkShift
            // 
            this.bsiSetWorkShift.Caption = "Установить смену";
            this.bsiSetWorkShift.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.bsiSetWorkShift.Id = 20;
            this.bsiSetWorkShift.Name = "bsiSetWorkShift";
            // 
            // biResetProdLine
            // 
            this.biResetProdLine.Caption = "Сбросить линию";
            this.biResetProdLine.Id = 21;
            this.biResetProdLine.Name = "biResetProdLine";
            this.biResetProdLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biResetProdLine_ItemClick);
            // 
            // biResetWorkShift
            // 
            this.biResetWorkShift.Caption = "Сбросить смену";
            this.biResetWorkShift.Id = 22;
            this.biResetWorkShift.Name = "biResetWorkShift";
            this.biResetWorkShift.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biResetWorkShift_ItemClick);
            // 
            // biSetNum
            // 
            this.biSetNum.Caption = "Установить номер";
            this.biSetNum.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.biSetNum.Id = 7;
            this.biSetNum.Name = "biSetNum";
            this.biSetNum.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSetNum_ItemClick);
            // 
            // biChangeQueueDate
            // 
            this.biChangeQueueDate.Caption = "Перенести в дату";
            this.biChangeQueueDate.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.biChangeQueueDate.Id = 8;
            this.biChangeQueueDate.Name = "biChangeQueueDate";
            this.biChangeQueueDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biChangeQueueDate_ItemClick);
            // 
            // biDelQueue
            // 
            this.biDelQueue.Caption = "Расформировать";
            this.biDelQueue.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.biDelQueue.Id = 10;
            this.biDelQueue.Name = "biDelQueue";
            this.biDelQueue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDelQueue_ItemClick);
            // 
            // biDelEmptyQueue
            // 
            this.biDelEmptyQueue.Caption = "Удалить пустые";
            this.biDelEmptyQueue.CategoryGuid = new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13");
            this.biDelEmptyQueue.Id = 9;
            this.biDelEmptyQueue.Name = "biDelEmptyQueue";
            this.biDelEmptyQueue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDelEmptyQueue_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Заказ";
            this.barSubItem3.Id = 5;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiAddOrderAtNewQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiAddOrderAtExistsQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRemoveFromQueue, true)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // bsiAddOrderAtNewQueue
            // 
            this.bsiAddOrderAtNewQueue.Caption = "Добавить в новую";
            this.bsiAddOrderAtNewQueue.CategoryGuid = new System.Guid("6e527209-43c0-4e95-aa65-bc54771ab88a");
            this.bsiAddOrderAtNewQueue.Id = 11;
            this.bsiAddOrderAtNewQueue.Name = "bsiAddOrderAtNewQueue";
            // 
            // bsiAddOrderAtExistsQueue
            // 
            this.bsiAddOrderAtExistsQueue.Caption = "Добавить в очередь";
            this.bsiAddOrderAtExistsQueue.CategoryGuid = new System.Guid("6e527209-43c0-4e95-aa65-bc54771ab88a");
            this.bsiAddOrderAtExistsQueue.Id = 13;
            this.bsiAddOrderAtExistsQueue.Name = "bsiAddOrderAtExistsQueue";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Переместить вверх";
            this.barButtonItem1.Id = 27;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Переместить вниз";
            this.barButtonItem2.Id = 28;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // biRemoveFromQueue
            // 
            this.biRemoveFromQueue.Caption = "Удалить из очереди";
            this.biRemoveFromQueue.CategoryGuid = new System.Guid("6e527209-43c0-4e95-aa65-bc54771ab88a");
            this.biRemoveFromQueue.Id = 14;
            this.biRemoveFromQueue.Name = "biRemoveFromQueue";
            this.biRemoveFromQueue.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biRemoveFromQueue_ItemClick);
            // 
            // barManager
            // 
            this.barManager.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Order", new System.Guid("6e527209-43c0-4e95-aa65-bc54771ab88a")),
            new DevExpress.XtraBars.BarManagerCategory("Queue", new System.Guid("60e999ba-8151-4bd2-82c2-063902dd2c13"))});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biEdit,
            this.bsiSetMachine,
            this.barSubItem2,
            this.barSubItem3,
            this.biSetNum,
            this.biChangeQueueDate,
            this.biDelEmptyQueue,
            this.biDelQueue,
            this.bsiAddOrderAtNewQueue,
            this.bsiAddOrderAtExistsQueue,
            this.biRemoveFromQueue,
            this.bsiSetWorkShift,
            this.biResetProdLine,
            this.biResetWorkShift,
            this.bbiPlanQueue,
            this.barButtonItem1,
            this.barButtonItem2,
            this.biReplan});
            this.barManager.MaxItemId = 30;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(456, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 701);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(456, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 701);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(456, 0);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 701);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(456, 701);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAction;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(139, 42);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(139, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlItem2.Size = new System.Drawing.Size(139, 42);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deQueueDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(312, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(110, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(110, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 10, 10);
            this.layoutControlItem3.Size = new System.Drawing.Size(110, 42);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tlWorkPlan;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(340, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(456, 659);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSetNextDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(422, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(34, 42);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(34, 42);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem4.Size = new System.Drawing.Size(34, 42);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 10, 10, 10);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnSetPrevDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(275, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(37, 42);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(37, 42);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Size = new System.Drawing.Size(37, 42);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(10, 0, 10, 10);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(139, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(136, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pmQueue
            // 
            this.pmQueue.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPlanQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.biReplan),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetMachine, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSetWorkShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.biResetProdLine),
            new DevExpress.XtraBars.LinkPersistInfo(this.biResetWorkShift),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSetNum, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biChangeQueueDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelQueue, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelEmptyQueue)});
            this.pmQueue.Manager = this.barManager;
            this.pmQueue.Name = "pmQueue";
            // 
            // pmOrder
            // 
            this.pmOrder.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiAddOrderAtNewQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiAddOrderAtExistsQueue),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.biRemoveFromQueue, true)});
            this.pmOrder.Manager = this.barManager;
            this.pmOrder.Name = "pmOrder";
            // 
            // CxWorkQueueTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CxWorkQueueTree";
            this.Size = new System.Drawing.Size(456, 701);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlWorkPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deQueueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deQueueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmQueue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DropDownButton btnAction;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit deQueueDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTreeList.TreeList tlWorkPlan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.SimpleButton btnSetPrevDate;
        private DevExpress.XtraEditors.SimpleButton btnSetNextDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.BarButtonItem biEdit;        
        private DevExpress.XtraBars.BarSubItem bsiSetMachine;
        private DevExpress.XtraBars.BarSubItem barSubItem2;        
        private DevExpress.XtraBars.BarButtonItem biSetNum;
        private DevExpress.XtraBars.BarButtonItem biChangeQueueDate;
        private DevExpress.XtraBars.BarButtonItem biDelQueue;
        private DevExpress.XtraBars.BarButtonItem biDelEmptyQueue;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem bsiAddOrderAtNewQueue;
        private DevExpress.XtraBars.BarSubItem bsiAddOrderAtExistsQueue;
        private DevExpress.XtraBars.BarButtonItem biRemoveFromQueue;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarSubItem bsiSetWorkShift;
        private DevExpress.XtraBars.BarButtonItem biResetProdLine;
        private DevExpress.XtraBars.BarButtonItem biResetWorkShift;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.BarButtonItem bbiPlanQueue;
        private DevExpress.Utils.SvgImageCollection svgImageCollection;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel hlTitle;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu pmQueue;
        private DevExpress.XtraBars.PopupMenu pmOrder;
        private DevExpress.XtraBars.BarButtonItem biReplan;
        //private DevExpress.XtraBars.BarSubItem bsiAddNewQueue;
        //private DevExpress.XtraBars.BarSubItem bsiAddQueueWithNum;
    }
}
