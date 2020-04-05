namespace Socrat.References.Materials
{
    partial class FxTradeMarkEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxTradeMarkEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.beVendor = new DevExpress.XtraEditors.ButtonEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lueMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.beBrand = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBrand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.beVendor);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.lueMaterial);
            this.layoutControl.Controls.Add(this.beBrand);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(403, 212);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // beVendor
            // 
            this.beVendor.Location = new System.Drawing.Point(15, 77);
            this.beVendor.MenuManager = this.barManager;
            this.beVendor.Name = "beVendor";
            this.beVendor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.beVendor.Size = new System.Drawing.Size(373, 20);
            this.beVendor.StyleController = this.layoutControl;
            this.beVendor.TabIndex = 7;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 169);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(373, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 6;
            // 
            // lueMaterial
            // 
            this.lueMaterial.Location = new System.Drawing.Point(15, 31);
            this.lueMaterial.MenuManager = this.barManager;
            this.lueMaterial.Name = "lueMaterial";
            this.lueMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaterial.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueMaterial.Properties.DisplayMember = "Name";
            this.lueMaterial.Properties.NullText = "";
            this.lueMaterial.Properties.ShowFooter = false;
            this.lueMaterial.Properties.ShowHeader = false;
            this.lueMaterial.Properties.ValueMember = "Id";
            this.lueMaterial.Size = new System.Drawing.Size(373, 20);
            this.lueMaterial.StyleController = this.layoutControl;
            this.lueMaterial.TabIndex = 4;
            this.lueMaterial.EditValueChanged += new System.EventHandler(this.lueMaterialType_EditValueChanged);
            // 
            // beBrand
            // 
            this.beBrand.Location = new System.Drawing.Point(15, 123);
            this.beBrand.MenuManager = this.barManager;
            this.beBrand.Name = "beBrand";
            this.beBrand.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.beBrand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beBrand.Size = new System.Drawing.Size(373, 20);
            this.beBrand.StyleController = this.layoutControl;
            this.beBrand.TabIndex = 5;
            this.beBrand.EditValueChanged += new System.EventHandler(this.beBrand_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(403, 212);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueMaterial;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(383, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Материал";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.beBrand;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(383, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Бренд";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(383, 54);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Наименование";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.beVendor;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(383, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Производитель";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(79, 13);
            // 
            // FxTradeMarkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 249);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxTradeMarkEdit";
            this.Text = "Торговая марка";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBrand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.LookUpEdit lueMaterial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ButtonEdit beBrand;
        private DevExpress.XtraEditors.ButtonEdit beVendor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}