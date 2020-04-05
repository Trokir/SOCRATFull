namespace Socrat.References.Customer
{
    partial class FxCustomerAddressEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxCustomerAddressEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcContacts = new DevExpress.XtraEditors.PanelControl();
            this.teComment = new DevExpress.XtraEditors.TextEdit();
            this.lcDefault = new DevExpress.XtraEditors.LabelControl();
            this.ceProduction = new DevExpress.XtraEditors.CheckEdit();
            this.beAddress = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceProduction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcContacts);
            this.layoutControl.Controls.Add(this.teComment);
            this.layoutControl.Controls.Add(this.lcDefault);
            this.layoutControl.Controls.Add(this.ceProduction);
            this.layoutControl.Controls.Add(this.beAddress);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1015, 294, 650, 400);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(573, 542);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcContacts
            // 
            this.pcContacts.Location = new System.Drawing.Point(10, 131);
            this.pcContacts.Name = "pcContacts";
            this.pcContacts.Size = new System.Drawing.Size(553, 401);
            this.pcContacts.TabIndex = 8;
            // 
            // teComment
            // 
            this.teComment.Location = new System.Drawing.Point(15, 106);
            this.teComment.MenuManager = this.barManager;
            this.teComment.Name = "teComment";
            this.teComment.Size = new System.Drawing.Size(543, 20);
            this.teComment.StyleController = this.layoutControl;
            this.teComment.TabIndex = 7;
            // 
            // lcDefault
            // 
            this.lcDefault.Location = new System.Drawing.Point(516, 15);
            this.lcDefault.Name = "lcDefault";
            this.lcDefault.Size = new System.Drawing.Size(42, 13);
            this.lcDefault.StyleController = this.layoutControl;
            this.lcDefault.TabIndex = 6;
            // 
            // ceProduction
            // 
            this.ceProduction.Location = new System.Drawing.Point(15, 15);
            this.ceProduction.MenuManager = this.barManager;
            this.ceProduction.Name = "ceProduction";
            this.ceProduction.Properties.Caption = "Производственная площадка";
            this.ceProduction.Size = new System.Drawing.Size(491, 19);
            this.ceProduction.StyleController = this.layoutControl;
            this.ceProduction.TabIndex = 5;
            this.ceProduction.CheckedChanged += new System.EventHandler(this.ceProduction_CheckedChanged);
            // 
            // beAddress
            // 
            this.beAddress.Location = new System.Drawing.Point(15, 60);
            this.beAddress.MenuManager = this.barManager;
            this.beAddress.Name = "beAddress";
            this.beAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beAddress.Size = new System.Drawing.Size(543, 20);
            this.beAddress.StyleController = this.layoutControl;
            this.beAddress.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(573, 542);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beAddress;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(553, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Адрес";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ceProduction;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(501, 29);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lcDefault;
            this.layoutControlItem3.Location = new System.Drawing.Point(501, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(52, 29);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teComment;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(553, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Примечание";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.pcContacts;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem5.Size = new System.Drawing.Size(553, 401);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FxCustomerAddressEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 579);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxCustomerAddressEdit";
            this.Text = "Адрес";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceProduction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.PanelControl pcContacts;
        private DevExpress.XtraEditors.TextEdit teComment;
        private DevExpress.XtraEditors.LabelControl lcDefault;
        private DevExpress.XtraEditors.CheckEdit ceProduction;
        private DevExpress.XtraEditors.ButtonEdit beAddress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}