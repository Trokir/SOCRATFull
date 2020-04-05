namespace Socrat.References.Materials
{
    partial class FxMaterialSizeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMaterialSizeEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.beDefaultVendorMaterial = new DevExpress.XtraEditors.ButtonEdit();
            this.lueMeasure = new DevExpress.XtraEditors.LookUpEdit();
            this.seThickness = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.teMark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDefaultVendorMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.teMark);
            this.layoutControl.Controls.Add(this.beDefaultVendorMaterial);
            this.layoutControl.Controls.Add(this.lueMeasure);
            this.layoutControl.Controls.Add(this.seThickness);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(665, 143);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // beDefaultVendorMaterial
            // 
            this.beDefaultVendorMaterial.Location = new System.Drawing.Point(15, 77);
            this.beDefaultVendorMaterial.MenuManager = this.barManager;
            this.beDefaultVendorMaterial.Name = "beDefaultVendorMaterial";
            this.beDefaultVendorMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beDefaultVendorMaterial.Size = new System.Drawing.Size(635, 20);
            this.beDefaultVendorMaterial.StyleController = this.layoutControl;
            this.beDefaultVendorMaterial.TabIndex = 6;
            // 
            // lueMeasure
            // 
            this.lueMeasure.Location = new System.Drawing.Point(230, 31);
            this.lueMeasure.MenuManager = this.barManager;
            this.lueMeasure.Name = "lueMeasure";
            this.lueMeasure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMeasure.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueMeasure.Properties.DisplayMember = "Name";
            this.lueMeasure.Properties.ShowFooter = false;
            this.lueMeasure.Properties.ShowHeader = false;
            this.lueMeasure.Properties.ValueMember = "Id";
            this.lueMeasure.Size = new System.Drawing.Size(205, 20);
            this.lueMeasure.StyleController = this.layoutControl;
            this.lueMeasure.TabIndex = 5;
            this.lueMeasure.EditValueChanged += new System.EventHandler(this.lueMeasure_EditValueChanged);
            // 
            // seThickness
            // 
            this.seThickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seThickness.Location = new System.Drawing.Point(15, 31);
            this.seThickness.MenuManager = this.barManager;
            this.seThickness.Name = "seThickness";
            this.seThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seThickness.Properties.Mask.EditMask = "n2";
            this.seThickness.Size = new System.Drawing.Size(205, 20);
            this.seThickness.StyleController = this.layoutControl;
            this.seThickness.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(665, 143);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.seThickness;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(215, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Толщина";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(205, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 92);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(645, 31);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueMeasure;
            this.layoutControlItem2.Location = new System.Drawing.Point(215, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(215, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Единица измерения";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(205, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.beDefaultVendorMaterial;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(645, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Номенклатура материала по умолчанию";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(205, 13);
            // 
            // teMark
            // 
            this.teMark.Location = new System.Drawing.Point(445, 31);
            this.teMark.MenuManager = this.barManager;
            this.teMark.Name = "teMark";
            this.teMark.Properties.MaxLength = 25;
            this.teMark.Size = new System.Drawing.Size(205, 20);
            this.teMark.StyleController = this.layoutControl;
            this.teMark.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teMark;
            this.layoutControlItem4.Location = new System.Drawing.Point(430, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(215, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Маркировка";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(205, 13);
            // 
            // FxMaterialSizeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 180);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxMaterialSizeEdit";
            this.Text = "Типоразмер материала";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beDefaultVendorMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ButtonEdit beDefaultVendorMaterial;
        private DevExpress.XtraEditors.LookUpEdit lueMeasure;
        private DevExpress.XtraEditors.SpinEdit seThickness;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit teMark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}