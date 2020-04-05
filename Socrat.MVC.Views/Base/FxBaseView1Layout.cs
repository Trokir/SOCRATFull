using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;

namespace Socrat.MVC.Views
{
    public class FxBaseViewLayout : FxBaseView
    {
        public LayoutVisibility PaneTopVisibility { get => lciPaneTop.Visibility; set => lciPaneTop.Visibility = value; }
        public LayoutVisibility PaneRightVisibility { get => lciPaneRight.Visibility; set => lciPaneRight.Visibility = value; }
        public LayoutVisibility PaneBottomVisibility { get => lciPaneBottom.Visibility; set => lciPaneBottom.Visibility = value; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartPosition = FormStartPosition.CenterParent;
        }

        #region Designer code

        public FxBaseViewLayout():base()
        {
            InitializeComponent();
        }

        private DevExpress.XtraLayout.LayoutControl MainLayout;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        protected PanelControl PanelContent;
        protected PanelControl PanelRight;
        protected PanelControl PanelBottom;
        protected PanelControl PanelTop;
        private DevExpress.XtraLayout.LayoutControlItem lciPaneTop;
        private DevExpress.XtraLayout.LayoutControlItem lciPaneBottom;
        private DevExpress.XtraLayout.LayoutControlItem lciPaneRight;
        private DevExpress.XtraLayout.LayoutControlItem lciContent;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            //base.Dispose(disposing);
            try {base.BeginInvoke((MethodInvoker)(delegate { base.Dispose(disposing); }));}
            catch { }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxBaseViewLayout));
            this.MainLayout = new DevExpress.XtraLayout.LayoutControl();
            this.PanelContent = new DevExpress.XtraEditors.PanelControl();
            this.PanelRight = new DevExpress.XtraEditors.PanelControl();
            this.PanelBottom = new DevExpress.XtraEditors.PanelControl();
            this.PanelTop = new DevExpress.XtraEditors.PanelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPaneTop = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPaneBottom = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPaneRight = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciContent = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainLayout)).BeginInit();
            this.MainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContent)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.Controls.Add(this.PanelContent);
            this.MainLayout.Controls.Add(this.PanelRight);
            this.MainLayout.Controls.Add(this.PanelBottom);
            this.MainLayout.Controls.Add(this.PanelTop);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Root = this.Root;
            this.MainLayout.Size = new System.Drawing.Size(653, 431);
            this.MainLayout.TabIndex = 0;
            this.MainLayout.Text = "layoutControl1";
            // 
            // PanelContent
            // 
            this.PanelContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PanelContent.Location = new System.Drawing.Point(2, 44);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(521, 334);
            this.PanelContent.TabIndex = 7;
            // 
            // PanelRight
            // 
            this.PanelRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PanelRight.Location = new System.Drawing.Point(527, 44);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(124, 334);
            this.PanelRight.TabIndex = 6;
            // 
            // PanelBottom
            // 
            this.PanelBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PanelBottom.Location = new System.Drawing.Point(2, 382);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Size = new System.Drawing.Size(649, 47);
            this.PanelBottom.TabIndex = 5;
            // 
            // PanelTop
            // 
            this.PanelTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PanelTop.Location = new System.Drawing.Point(2, 2);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Size = new System.Drawing.Size(649, 38);
            this.PanelTop.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPaneTop,
            this.lciPaneBottom,
            this.lciPaneRight,
            this.lciContent});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(653, 431);
            this.Root.TextVisible = false;
            // 
            // lciPaneTop
            // 
            this.lciPaneTop.Control = this.PanelTop;
            this.lciPaneTop.Location = new System.Drawing.Point(0, 0);
            this.lciPaneTop.Name = "lciPaneTop";
            this.lciPaneTop.Size = new System.Drawing.Size(653, 42);
            this.lciPaneTop.TextSize = new System.Drawing.Size(0, 0);
            this.lciPaneTop.TextVisible = false;
            // 
            // lciPaneBottom
            // 
            this.lciPaneBottom.Control = this.PanelBottom;
            this.lciPaneBottom.Location = new System.Drawing.Point(0, 380);
            this.lciPaneBottom.Name = "lciPaneBottom";
            this.lciPaneBottom.Size = new System.Drawing.Size(653, 51);
            this.lciPaneBottom.TextSize = new System.Drawing.Size(0, 0);
            this.lciPaneBottom.TextVisible = false;
            // 
            // lciPaneRight
            // 
            this.lciPaneRight.Control = this.PanelRight;
            this.lciPaneRight.Location = new System.Drawing.Point(525, 42);
            this.lciPaneRight.Name = "lciPaneRight";
            this.lciPaneRight.Size = new System.Drawing.Size(128, 338);
            this.lciPaneRight.TextSize = new System.Drawing.Size(0, 0);
            this.lciPaneRight.TextVisible = false;
            // 
            // lciContent
            // 
            this.lciContent.Control = this.PanelContent;
            this.lciContent.Location = new System.Drawing.Point(0, 42);
            this.lciContent.Name = "lciContent";
            this.lciContent.Size = new System.Drawing.Size(525, 338);
            this.lciContent.TextSize = new System.Drawing.Size(0, 0);
            this.lciContent.TextVisible = false;
            // 
            // BaseViewLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 431);
            this.Controls.Add(this.MainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseViewLayout";
            this.Text = "Базовое окно диалога";
            ((System.ComponentModel.ISupportInitialize)(this.MainLayout)).EndInit();
            this.MainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPaneRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContent)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
