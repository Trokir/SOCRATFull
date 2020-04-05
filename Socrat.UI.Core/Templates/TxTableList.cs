using System;

namespace Socrat.UI.Core.Templates
{
    /// <summary>
    /// Шаблон табличного списка (справочника)
    /// </summary>
    public partial class TxTableList : DevExpress.XtraEditors.XtraUserControl
    {
        public bool ReadOnly { get; set; }

        public TxTableList()
        {
            InitializeComponent();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TxTableList));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnActions = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.biRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.biOpen = new DevExpress.XtraBars.BarButtonItem();
            this.biAddItem = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.gcGrid = new DevExpress.XtraGrid.GridControl();
            this.cmsGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel.SuspendLayout();
            this.flpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).BeginInit();
            this.cmsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel.Controls.Add(this.flpButtons, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnActions, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gcGrid, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(536, 568);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnRefresh);
            this.flpButtons.Controls.Add(this.btnOpen);
            this.flpButtons.Controls.Add(this.btnAddItem);
            this.flpButtons.Controls.Add(this.btnRemove);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpButtons.Location = new System.Drawing.Point(399, 43);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(134, 522);
            this.flpButtons.TabIndex = 4;
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
            // btnActions
            // 
            this.btnActions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnActions.DropDownControl = this.popupMenu;
            this.btnActions.Location = new System.Drawing.Point(8, 10);
            this.btnActions.Margin = new System.Windows.Forms.Padding(8);
            this.btnActions.Name = "btnActions";
            this.btnActions.Size = new System.Drawing.Size(135, 20);
            this.btnActions.TabIndex = 5;
            this.btnActions.Text = "Действие";
            // 
            // popupMenu
            // 
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.biOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.biAddItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelete)});
            this.popupMenu.Manager = this.barManager1;
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
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.biRefresh,
            this.biOpen,
            this.biEdit,
            this.biAddItem,
            this.biDelete});
            this.barManager1.MaxItemId = 5;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(536, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 568);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(536, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 568);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(536, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 568);
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
            // gcGrid
            // 
            this.gcGrid.ContextMenuStrip = this.cmsGrid;
            this.gcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGrid.Location = new System.Drawing.Point(3, 43);
            this.gcGrid.MainView = this.gvGrid;
            this.gcGrid.Name = "gcGrid";
            this.gcGrid.Size = new System.Drawing.Size(390, 522);
            this.gcGrid.TabIndex = 6;
            this.gcGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGrid});
            // 
            // cmsGrid
            // 
            this.cmsGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.tsmiOpen,
            this.toolStripSeparator2,
            this.tsmiAddItem,
            this.tsmiDeleteItem});
            this.cmsGrid.Name = "cmsGrid";
            this.cmsGrid.Size = new System.Drawing.Size(132, 98);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(131, 22);
            this.tsmiRefresh.Text = "Обновить";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(131, 22);
            this.tsmiOpen.Text = "Просмотр";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(128, 6);
            // 
            // tsmiAddItem
            // 
            this.tsmiAddItem.Name = "tsmiAddItem";
            this.tsmiAddItem.Size = new System.Drawing.Size(131, 22);
            this.tsmiAddItem.Text = "Добавить";
            // 
            // tsmiDeleteItem
            // 
            this.tsmiDeleteItem.Name = "tsmiDeleteItem";
            this.tsmiDeleteItem.Size = new System.Drawing.Size(131, 22);
            this.tsmiDeleteItem.Text = "Удалить";
            this.tsmiDeleteItem.Click += new System.EventHandler(this.tsmiDeleteItem_Click);
            // 
            // gvGrid
            // 
            this.gvGrid.GridControl = this.gcGrid;
            this.gvGrid.Name = "gvGrid";
            this.gvGrid.OptionsFind.AlwaysVisible = true;
            this.gvGrid.OptionsView.ShowGroupPanel = false;
            // 
            // TxTableList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TxTableList";
            this.Size = new System.Drawing.Size(536, 568);
            this.tableLayoutPanel.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGrid)).EndInit();
            this.cmsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
            OpenItem();
        }

        #endregion

        #region Реализация

        private void RefreshData()
        {
            throw new NotImplementedException();
        }


        private void AddItem()
        {
            throw new NotImplementedException();
        }

        private void DeleteItem()
        {
            throw new NotImplementedException();
        }

        private void OpenItem()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
