namespace Socrat.Module.Settings
{
    partial class CxMenuTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxMenuTree));
            this.tlMenuTree = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.icState = new DevExpress.Utils.ImageCollection();
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.biAdd = new DevExpress.XtraBars.BarButtonItem();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.tlMenuTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tlMenuTree
            // 
            this.tlMenuTree.AllowDrop = true;
            this.tlMenuTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5});
            this.tlMenuTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlMenuTree.CustomizationFormBounds = new System.Drawing.Rectangle(1206, 575, 260, 232);
            this.tlMenuTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMenuTree.KeyFieldName = "";
            this.tlMenuTree.Location = new System.Drawing.Point(0, 31);
            this.tlMenuTree.Name = "tlMenuTree";
            this.tlMenuTree.OptionsBehavior.Editable = false;
            this.tlMenuTree.OptionsBehavior.EditorShowMode = DevExpress.XtraTreeList.TreeListEditorShowMode.Click;
            this.tlMenuTree.OptionsBehavior.ReadOnly = true;
            this.tlMenuTree.OptionsView.ShowIndentAsRowStyle = true;
            this.tlMenuTree.ParentFieldName = "";
            this.tlMenuTree.SelectImageList = this.icState;
            this.tlMenuTree.Size = new System.Drawing.Size(1075, 655);
            this.tlMenuTree.StateImageList = this.icState;
            this.tlMenuTree.TabIndex = 0;
            this.tlMenuTree.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.tlMenuTree_BeforeExpand);
            this.tlMenuTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlMenuTree_DragDrop);
            this.tlMenuTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlMenuTree_DragEnter);
            this.tlMenuTree.DoubleClick += new System.EventHandler(this.tlMenuTree_DoubleClick);
            this.tlMenuTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlMenuTree_MouseDown);
            this.tlMenuTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tlMenuTree_MouseMove);
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Тип";
            this.treeListColumn2.FieldName = "TreeItemType";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 4;
            this.treeListColumn2.Width = 283;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Наименование";
            this.treeListColumn3.FieldName = "Name";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 301;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Модуль";
            this.treeListColumn4.FieldName = "Module";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 301;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "Порядок";
            this.treeListColumn5.FieldName = "SortNum";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 1;
            this.treeListColumn5.Width = 95;
            // 
            // icState
            // 
            this.icState.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icState.ImageStream")));
            this.icState.Images.SetKeyName(0, "bofolder_16x16.png");
            this.icState.Images.SetKeyName(1, "window_16x16.png");
            this.icState.Images.SetKeyName(2, "cube_16x16.png");
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biAdd,
            this.biDelete,
            this.biEdit,
            this.biSave});
            this.barManager.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Сервис";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.biSave)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Сервис";
            // 
            // biAdd
            // 
            this.biAdd.Caption = "Добавить";
            this.biAdd.Id = 0;
            this.biAdd.ImageOptions.Image = global::Socrat.Module.Settings.Properties.Resources.add_16x16;
            this.biAdd.Name = "biAdd";
            this.biAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biAdd_ItemClick);
            // 
            // biEdit
            // 
            this.biEdit.Caption = "Редактировать";
            this.biEdit.Id = 2;
            this.biEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("biEdit.ImageOptions.Image")));
            this.biEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("biEdit.ImageOptions.LargeImage")));
            this.biEdit.Name = "biEdit";
            this.biEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEdit_ItemClick);
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Удалить";
            this.biDelete.Id = 1;
            this.biDelete.ImageOptions.Image = global::Socrat.Module.Settings.Properties.Resources.delete_16x16;
            this.biDelete.Name = "biDelete";
            this.biDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDelete_ItemClick);
            // 
            // biSave
            // 
            this.biSave.Caption = "Сохранить";
            this.biSave.Id = 3;
            this.biSave.ImageOptions.Image = global::Socrat.Module.Settings.Properties.Resources.save_16x16;
            this.biSave.Name = "biSave";
            this.biSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1075, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 686);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1075, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 655);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1075, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 655);
            // 
            // CxMenuTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlMenuTree);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CxMenuTree";
            this.Size = new System.Drawing.Size(1075, 686);
            ((System.ComponentModel.ISupportInitialize)(this.tlMenuTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlMenuTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.Utils.ImageCollection icState;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem biAdd;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biSave;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
    }
}
