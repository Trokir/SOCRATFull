namespace Socrat.References.Materials.Sub
{
    partial class FxSubMaterialNomProcessingEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxSubMaterialNomProcessingEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.seSeq = new DevExpress.XtraEditors.SpinEdit();
            this.pcComponents = new DevExpress.XtraEditors.PanelControl();
            this.beBaseMaterial = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seSeq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcComponents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBaseMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.seSeq);
            this.layoutControl.Controls.Add(this.pcComponents);
            this.layoutControl.Controls.Add(this.beBaseMaterial);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(810, 418);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // seSeq
            // 
            this.seSeq.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSeq.Location = new System.Drawing.Point(15, 31);
            this.seSeq.MenuManager = this.barManager;
            this.seSeq.Name = "seSeq";
            this.seSeq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSeq.Properties.IsFloatValue = false;
            this.seSeq.Properties.Mask.EditMask = "N00";
            this.seSeq.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seSeq.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSeq.Size = new System.Drawing.Size(190, 20);
            this.seSeq.StyleController = this.layoutControl;
            this.seSeq.TabIndex = 6;
            // 
            // pcComponents
            // 
            this.pcComponents.Location = new System.Drawing.Point(12, 58);
            this.pcComponents.Name = "pcComponents";
            this.pcComponents.Size = new System.Drawing.Size(786, 348);
            this.pcComponents.TabIndex = 5;
            // 
            // beBaseMaterial
            // 
            this.beBaseMaterial.Location = new System.Drawing.Point(215, 31);
            this.beBaseMaterial.MenuManager = this.barManager;
            this.beBaseMaterial.Name = "beBaseMaterial";
            this.beBaseMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beBaseMaterial.Size = new System.Drawing.Size(580, 20);
            this.beBaseMaterial.StyleController = this.layoutControl;
            this.beBaseMaterial.TabIndex = 4;
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
            this.Root.Size = new System.Drawing.Size(810, 418);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beBaseMaterial;
            this.layoutControlItem1.Location = new System.Drawing.Point(200, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(590, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Номенклатура операции";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(124, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcComponents;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(790, 352);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.seSeq;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(134, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(200, 46);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "№ п/п";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(124, 13);
            // 
            // FxSubMaterialNomProcessingEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(810, 455);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxSubMaterialNomProcessingEdit";
            this.Text = "Операция";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seSeq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcComponents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beBaseMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ButtonEdit beBaseMaterial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl pcComponents;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SpinEdit seSeq;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}