using Socrat.References.Properties;

namespace Socrat.Module.Price.v1
{
    partial class CxPriceTitleEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CxPriceTitleEditor));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lcCustomer = new DevExpress.XtraEditors.LabelControl();
            this.lcDivision = new DevExpress.XtraEditors.LabelControl();
            this.lcName = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lcCustomer);
            this.layoutControl1.Controls.Add(this.lcDivision);
            this.layoutControl1.Controls.Add(this.lcName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(10, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(520, 63);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lcCustomer
            // 
            this.lcCustomer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lcCustomer.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcCustomer.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lcCustomer.ImageOptions.Image")));
            this.lcCustomer.Location = new System.Drawing.Point(218, 29);
            this.lcCustomer.Name = "lcCustomer";
            this.lcCustomer.Size = new System.Drawing.Size(137, 28);
            this.lcCustomer.StyleController = this.layoutControl1;
            this.lcCustomer.TabIndex = 6;
            this.lcCustomer.Text = "Контрагент не выбран";
            // 
            // lcDivision
            // 
            this.lcDivision.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lcDivision.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lcDivision.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcDivision.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lcDivision.ImageOptions.Image")));
            this.lcDivision.Location = new System.Drawing.Point(2, 29);
            this.lcDivision.Name = "lcDivision";
            this.lcDivision.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lcDivision.Size = new System.Drawing.Size(212, 28);
            this.lcDivision.StyleController = this.layoutControl1;
            this.lcDivision.TabIndex = 5;
            this.lcDivision.Text = "Подразделение не установлено";
            // 
            // lcName
            // 
            this.lcName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lcName.Appearance.Options.UseFont = true;
            this.lcName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lcName.Location = new System.Drawing.Point(2, 2);
            this.lcName.Name = "lcName";
            this.lcName.Size = new System.Drawing.Size(516, 23);
            this.lcName.StyleController = this.layoutControl1;
            this.lcName.TabIndex = 4;
            this.lcName.Text = "Без названия";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(520, 63);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lcName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(520, 27);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lcDivision;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(216, 36);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lcCustomer;
            this.layoutControlItem3.Location = new System.Drawing.Point(216, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(304, 36);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // CxPriceTitleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CxPriceTitleEditor";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 5, 3);
            this.Size = new System.Drawing.Size(535, 71);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LabelControl lcName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        public DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LabelControl lcCustomer;
        private DevExpress.XtraEditors.LabelControl lcDivision;
    }
}
