namespace Socrat.Module.Invoice
{
    partial class FxInvoiceEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxInvoiceEdit));
            this.lcInvoice = new DevExpress.XtraLayout.LayoutControl();
            this.pcInvoice = new DevExpress.XtraEditors.PanelControl();
            this.cxInvoiceEdit = new Socrat.Module.Invoice.CxInvoiceEdit();
            this.pcInvoiceItems = new DevExpress.XtraEditors.PanelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcInvoice)).BeginInit();
            this.lcInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcInvoice)).BeginInit();
            this.pcInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcInvoiceItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcInvoice
            // 
            this.lcInvoice.Controls.Add(this.pcInvoice);
            this.lcInvoice.Controls.Add(this.pcInvoiceItems);
            this.lcInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcInvoice.Location = new System.Drawing.Point(0, 0);
            this.lcInvoice.Name = "lcInvoice";
            this.lcInvoice.Root = this.Root;
            this.lcInvoice.Size = new System.Drawing.Size(619, 639);
            this.lcInvoice.TabIndex = 5;
            this.lcInvoice.Text = "layoutControl1";
            // 
            // pcInvoice
            // 
            this.pcInvoice.Controls.Add(this.cxInvoiceEdit);
            this.pcInvoice.Location = new System.Drawing.Point(6, 6);
            this.pcInvoice.Name = "pcInvoice";
            this.pcInvoice.Size = new System.Drawing.Size(607, 324);
            this.pcInvoice.TabIndex = 5;
            // 
            // cxInvoiceEdit
            // 
            this.cxInvoiceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxInvoiceEdit.Invoice = null;
            this.cxInvoiceEdit.Location = new System.Drawing.Point(2, 2);
            this.cxInvoiceEdit.Name = "cxInvoiceEdit";
            this.cxInvoiceEdit.Size = new System.Drawing.Size(603, 320);
            this.cxInvoiceEdit.TabIndex = 0;
            // 
            // pcInvoiceItems
            // 
            this.pcInvoiceItems.Location = new System.Drawing.Point(18, 368);
            this.pcInvoiceItems.Name = "pcInvoiceItems";
            this.pcInvoiceItems.Size = new System.Drawing.Size(583, 253);
            this.pcInvoiceItems.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Root.Size = new System.Drawing.Size(619, 639);
            this.Root.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 328);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup1;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(611, 303);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(587, 257);
            this.layoutControlGroup1.Text = "Состав счета";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pcInvoiceItems;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(587, 257);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcInvoice;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 328);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(5, 328);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(611, 328);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FxInvoiceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(619, 676);
            this.Controls.Add(this.lcInvoice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(629, 580);
            this.Name = "FxInvoiceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FxInvoiceEdit";
            this.Controls.SetChildIndex(this.lcInvoice, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcInvoice)).EndInit();
            this.lcInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcInvoice)).EndInit();
            this.pcInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcInvoiceItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcInvoice;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PanelControl pcInvoice;
        private DevExpress.XtraEditors.PanelControl pcInvoiceItems;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private CxInvoiceEdit cxInvoiceEdit;
    }
}