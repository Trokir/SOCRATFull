namespace Socrat.References.Price
{
    partial class FxPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxPriceList));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pcCommon = new DevExpress.XtraEditors.PanelControl();
            this.pcIndividual = new DevExpress.XtraEditors.PanelControl();
            this.pcAll = new DevExpress.XtraEditors.PanelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.groupAll = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupCommon = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupIndividual = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pcCommon);
            this.layoutControl1.Controls.Add(this.pcIndividual);
            this.layoutControl1.Controls.Add(this.pcAll);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(815, 346);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pcCommon
            // 
            this.pcCommon.Location = new System.Drawing.Point(24, 46);
            this.pcCommon.Name = "pcCommon";
            this.pcCommon.Size = new System.Drawing.Size(767, 276);
            this.pcCommon.TabIndex = 5;
            // 
            // pcIndividual
            // 
            this.pcIndividual.Location = new System.Drawing.Point(24, 46);
            this.pcIndividual.Name = "pcIndividual";
            this.pcIndividual.Size = new System.Drawing.Size(767, 276);
            this.pcIndividual.TabIndex = 6;
            // 
            // pcAll
            // 
            this.pcAll.Location = new System.Drawing.Point(24, 46);
            this.pcAll.Name = "pcAll";
            this.pcAll.Size = new System.Drawing.Size(767, 276);
            this.pcAll.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(815, 346);
            this.Root.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.groupAll;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(795, 326);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.groupAll,
            this.groupCommon,
            this.groupIndividual});
            this.tabbedControlGroup1.SelectedPageChanging += new DevExpress.XtraLayout.LayoutTabPageChangingEventHandler(this.tabbedControlGroup1_SelectedPageChanging);
            // 
            // groupAll
            // 
            this.groupAll.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.groupAll.Location = new System.Drawing.Point(0, 0);
            this.groupAll.Name = "groupAll";
            this.groupAll.Size = new System.Drawing.Size(771, 280);
            this.groupAll.Text = "Все";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pcAll;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(771, 280);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // groupCommon
            // 
            this.groupCommon.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.groupCommon.Location = new System.Drawing.Point(0, 0);
            this.groupCommon.Name = "groupCommon";
            this.groupCommon.Size = new System.Drawing.Size(771, 280);
            this.groupCommon.Text = "Общие";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcCommon;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(771, 280);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // groupIndividual
            // 
            this.groupIndividual.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.groupIndividual.Location = new System.Drawing.Point(0, 0);
            this.groupIndividual.Name = "groupIndividual";
            this.groupIndividual.Size = new System.Drawing.Size(771, 280);
            this.groupIndividual.Text = "Индивидуальные";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pcIndividual;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(771, 280);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FxPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 383);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxPriceList";
            this.Text = "FxPriceList";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup groupAll;
        private DevExpress.XtraLayout.LayoutControlGroup groupCommon;
        private DevExpress.XtraLayout.LayoutControlGroup groupIndividual;
        private DevExpress.XtraEditors.PanelControl pcAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl pcIndividual;
        private DevExpress.XtraEditors.PanelControl pcCommon;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}