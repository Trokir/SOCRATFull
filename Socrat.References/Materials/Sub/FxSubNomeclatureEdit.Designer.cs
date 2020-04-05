namespace Socrat.References.Materials
{
    partial class FxSubNomeclatureEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxSubNomeclatureEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.beBaseMaterialNom = new DevExpress.XtraEditors.ButtonEdit();
            this.bePerMaterialNom = new DevExpress.XtraEditors.ButtonEdit();
            this.pcProcessings = new DevExpress.XtraEditors.PanelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beBaseMaterialNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePerMaterialNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcProcessings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.beBaseMaterialNom);
            this.layoutControl.Controls.Add(this.bePerMaterialNom);
            this.layoutControl.Controls.Add(this.pcProcessings);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(886, 612);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // beBaseMaterialNom
            // 
            this.beBaseMaterialNom.Location = new System.Drawing.Point(15, 77);
            this.beBaseMaterialNom.MenuManager = this.barManager;
            this.beBaseMaterialNom.Name = "beBaseMaterialNom";
            this.beBaseMaterialNom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBaseMaterialNom.Size = new System.Drawing.Size(856, 20);
            this.beBaseMaterialNom.StyleController = this.layoutControl;
            this.beBaseMaterialNom.TabIndex = 7;
            // 
            // bePerMaterialNom
            // 
            this.bePerMaterialNom.Location = new System.Drawing.Point(15, 31);
            this.bePerMaterialNom.MenuManager = this.barManager;
            this.bePerMaterialNom.Name = "bePerMaterialNom";
            this.bePerMaterialNom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bePerMaterialNom.Size = new System.Drawing.Size(856, 20);
            this.bePerMaterialNom.StyleController = this.layoutControl;
            this.bePerMaterialNom.TabIndex = 6;
            // 
            // pcProcessings
            // 
            this.pcProcessings.Location = new System.Drawing.Point(12, 104);
            this.pcProcessings.Name = "pcProcessings";
            this.pcProcessings.Size = new System.Drawing.Size(862, 496);
            this.pcProcessings.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(886, 612);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcProcessings;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(866, 500);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bePerMaterialNom;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(866, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Номенклатура (номинальная)";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(179, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beBaseMaterialNom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(866, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Номенклатура базового материала";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(179, 13);
            // 
            // FxSubNomeclatureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(886, 649);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxSubNomeclatureEdit";
            this.Text = "Полуфабрикат";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beBaseMaterialNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bePerMaterialNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcProcessings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PanelControl pcProcessings;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ButtonEdit bePerMaterialNom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ButtonEdit beBaseMaterialNom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}