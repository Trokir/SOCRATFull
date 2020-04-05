namespace Socrat.Module.Order
{
    partial class FxOrders
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxOrders));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.beiDivisions = new DevExpress.XtraBars.BarEditItem();
            this.lueDivision = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bbiImportFromXml = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcOrders = new DevExpress.XtraEditors.PanelControl();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
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
            this.beiDivisions,
            this.barStaticItem1,
            this.barButtonItem1,
            this.bbiImportFromXml});
            this.barManager.MaxItemId = 13;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueDivision});
            // 
            // bar1
            // 
            this.bar1.BarName = "Сервис";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiDivisions, "", false, true, true, 140),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiImportFromXml)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.Text = "Сервис";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Площадка";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // beiDivisions
            // 
            this.beiDivisions.Caption = "Площадка";
            this.beiDivisions.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.beiDivisions.Edit = this.lueDivision;
            this.beiDivisions.Hint = "Площадка";
            this.beiDivisions.Id = 0;
            this.beiDivisions.Name = "beiDivisions";
            this.beiDivisions.EditValueChanged += new System.EventHandler(this.beiDivisions_EditValueChanged);
            // 
            // lueDivision
            // 
            this.lueDivision.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lueDivision.AutoHeight = false;
            this.lueDivision.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDivision.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AliasName", "Имя")});
            this.lueDivision.DisplayMember = "AliasName";
            this.lueDivision.Name = "lueDivision";
            this.lueDivision.NullText = "Все полщадки";
            this.lueDivision.ShowFooter = false;
            this.lueDivision.ShowHeader = false;
            this.lueDivision.ShowNullValuePromptWhenFocused = true;
            this.lueDivision.EditValueChanged += new System.EventHandler(this.lueDivision_EditValueChanged);
            // 
            // bbiImportFromXml
            // 
            this.bbiImportFromXml.Caption = "Иморт из XML";
            this.bbiImportFromXml.Id = 12;
            this.bbiImportFromXml.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiImportFromXml.ImageOptions.Image")));
            this.bbiImportFromXml.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiImportFromXml.ImageOptions.LargeImage")));
            this.bbiImportFromXml.Name = "bbiImportFromXml";
            this.bbiImportFromXml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiImportFromXml_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1037, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 651);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1037, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 620);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1037, 31);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 620);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcOrders);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 31);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1033, 337, 650, 400);
            this.layoutControl.Root = this.lcgRoot;
            this.layoutControl.Size = new System.Drawing.Size(1037, 620);
            this.layoutControl.TabIndex = 4;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcOrders
            // 
            this.pcOrders.Location = new System.Drawing.Point(3, 3);
            this.pcOrders.Name = "pcOrders";
            this.pcOrders.Size = new System.Drawing.Size(1031, 614);
            this.pcOrders.TabIndex = 4;
            // 
            // lcgRoot
            // 
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgRoot.Name = "lcgRoot";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.lcgRoot.Size = new System.Drawing.Size(1037, 620);
            this.lcgRoot.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pcOrders;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1035, 618);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem1";
            this.barEditItem2.Edit = this.lueDivision;
            this.barEditItem2.Id = 0;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // FxOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 651);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxOrders";
            this.Text = "Заказы";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup lcgRoot;
        private DevExpress.XtraEditors.PanelControl pcOrders;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarEditItem beiDivisions;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueDivision;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem bbiImportFromXml;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}