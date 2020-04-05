namespace Socrat.References.Materials
{
    partial class FxMaterialNomFormulaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMaterialNomFormulaEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.beFormula = new DevExpress.XtraEditors.ButtonEdit();
            this.beMaterialNom = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.meDesc = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beFormula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.meDesc);
            this.layoutControl.Controls.Add(this.beFormula);
            this.layoutControl.Controls.Add(this.beMaterialNom);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(434, 318);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // beFormula
            // 
            this.beFormula.Location = new System.Drawing.Point(12, 68);
            this.beFormula.MenuManager = this.barManager;
            this.beFormula.Name = "beFormula";
            this.beFormula.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.beFormula.Properties.ReadOnly = true;
            this.beFormula.Properties.UseReadOnlyAppearance = false;
            this.beFormula.Size = new System.Drawing.Size(410, 20);
            this.beFormula.StyleController = this.layoutControl;
            this.beFormula.TabIndex = 5;
            this.beFormula.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beFormula_ButtonClick);
            // 
            // beMaterialNom
            // 
            this.beMaterialNom.Location = new System.Drawing.Point(12, 28);
            this.beMaterialNom.MenuManager = this.barManager;
            this.beMaterialNom.Name = "beMaterialNom";
            this.beMaterialNom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMaterialNom.Size = new System.Drawing.Size(410, 20);
            this.beMaterialNom.StyleController = this.layoutControl;
            this.beMaterialNom.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(434, 318);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beMaterialNom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(414, 40);
            this.layoutControlItem1.Text = "Номенклатура";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 80);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(414, 218);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.beFormula;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(414, 40);
            this.layoutControlItem2.Text = "Формула";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
            // 
            // meDesc
            // 
            this.meDesc.Location = new System.Drawing.Point(12, 108);
            this.meDesc.MenuManager = this.barManager;
            this.meDesc.Name = "meDesc";
            this.meDesc.Size = new System.Drawing.Size(410, 158);
            this.meDesc.StyleController = this.layoutControl;
            this.meDesc.TabIndex = 6;
            this.meDesc.EditValueChanged += new System.EventHandler(this.meDesc_EditValueChanged);
            // 
            // FxMaterialNomFormulaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(434, 355);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxMaterialNomFormulaEdit";
            this.Text = "Формула номенклатуры материала";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beFormula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.ButtonEdit beFormula;
        private DevExpress.XtraEditors.ButtonEdit beMaterialNom;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit meDesc;
    }
}