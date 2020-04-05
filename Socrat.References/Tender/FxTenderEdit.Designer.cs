namespace Socrat.References.Tender
{
    partial class FxTenderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxTenderEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcFormulas = new DevExpress.XtraEditors.PanelControl();
            this.ceClose = new DevExpress.XtraEditors.CheckEdit();
            this.deCreate = new DevExpress.XtraEditors.DateEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Наименование = new DevExpress.XtraLayout.LayoutControlItem();
            this.Создан = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.pcTendecCustomers = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcFormulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceClose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Наименование)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Создан)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTendecCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcTendecCustomers);
            this.layoutControl.Controls.Add(this.pcFormulas);
            this.layoutControl.Controls.Add(this.ceClose);
            this.layoutControl.Controls.Add(this.deCreate);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(627, 445);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcFormulas
            // 
            this.pcFormulas.Location = new System.Drawing.Point(24, 138);
            this.pcFormulas.Name = "pcFormulas";
            this.pcFormulas.Size = new System.Drawing.Size(579, 283);
            this.pcFormulas.TabIndex = 7;
            // 
            // ceClose
            // 
            this.ceClose.Location = new System.Drawing.Point(233, 77);
            this.ceClose.MenuManager = this.barManager;
            this.ceClose.Name = "ceClose";
            this.ceClose.Properties.Caption = "";
            this.ceClose.Size = new System.Drawing.Size(379, 19);
            this.ceClose.StyleController = this.layoutControl;
            this.ceClose.TabIndex = 6;
            // 
            // deCreate
            // 
            this.deCreate.EditValue = null;
            this.deCreate.Location = new System.Drawing.Point(15, 77);
            this.deCreate.MenuManager = this.barManager;
            this.deCreate.Name = "deCreate";
            this.deCreate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deCreate.Size = new System.Drawing.Size(159, 20);
            this.deCreate.StyleController = this.layoutControl;
            this.deCreate.TabIndex = 5;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 31);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(597, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Наименование,
            this.Создан,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.tabbedControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(627, 445);
            this.Root.TextVisible = false;
            // 
            // Наименование
            // 
            this.Наименование.Control = this.teName;
            this.Наименование.Location = new System.Drawing.Point(0, 0);
            this.Наименование.Name = "Наименование";
            this.Наименование.Size = new System.Drawing.Size(607, 46);
            this.Наименование.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Наименование.TextLocation = DevExpress.Utils.Locations.Top;
            this.Наименование.TextSize = new System.Drawing.Size(73, 13);
            // 
            // Создан
            // 
            this.Создан.Control = this.deCreate;
            this.Создан.Location = new System.Drawing.Point(0, 46);
            this.Создан.Name = "Создан";
            this.Создан.Size = new System.Drawing.Size(169, 46);
            this.Создан.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Создан.TextLocation = DevExpress.Utils.Locations.Top;
            this.Создан.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceClose;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(218, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(389, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Закрыт";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(169, 46);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(49, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 92);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(607, 333);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2});
            this.tabbedControlGroup1.Text = "Заказчики";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(583, 287);
            this.layoutControlGroup1.Text = "Тендерные формулы";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pcFormulas;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(583, 287);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(583, 287);
            this.layoutControlGroup2.Text = "Заказчики";
            // 
            // pcTendecCustomers
            // 
            this.pcTendecCustomers.Location = new System.Drawing.Point(24, 138);
            this.pcTendecCustomers.Name = "pcTendecCustomers";
            this.pcTendecCustomers.Size = new System.Drawing.Size(579, 283);
            this.pcTendecCustomers.TabIndex = 8;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcTendecCustomers;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(583, 287);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FxTenderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(627, 482);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxTenderEdit";
            this.Text = "Тендер";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcFormulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceClose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Наименование)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Создан)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcTendecCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.CheckEdit ceClose;
        private DevExpress.XtraEditors.DateEdit deCreate;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem Наименование;
        private DevExpress.XtraLayout.LayoutControlItem Создан;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.PanelControl pcFormulas;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.PanelControl pcTendecCustomers;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}