namespace Socrat.References.Materials
{
    partial class FxMaterialSizeTypeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMaterialSizeTypeEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.beDefaultMaterialNom = new DevExpress.XtraEditors.ButtonEdit();
            this.lueMeasure = new DevExpress.XtraEditors.LookUpEdit();
            this.seTickness = new DevExpress.XtraEditors.SpinEdit();
            this.beMaterialMark = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.teMark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beDefaultMaterialNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.teMark);
            this.layoutControl.Controls.Add(this.beDefaultMaterialNom);
            this.layoutControl.Controls.Add(this.lueMeasure);
            this.layoutControl.Controls.Add(this.seTickness);
            this.layoutControl.Controls.Add(this.beMaterialMark);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(678, 186);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // beDefaultMaterialNom
            // 
            this.beDefaultMaterialNom.Location = new System.Drawing.Point(15, 123);
            this.beDefaultMaterialNom.MenuManager = this.barManager;
            this.beDefaultMaterialNom.Name = "beDefaultMaterialNom";
            this.beDefaultMaterialNom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beDefaultMaterialNom.Size = new System.Drawing.Size(648, 20);
            this.beDefaultMaterialNom.StyleController = this.layoutControl;
            this.beDefaultMaterialNom.TabIndex = 7;
            this.beDefaultMaterialNom.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beDefaultMaterialNom_ButtonClick);
            // 
            // lueMeasure
            // 
            this.lueMeasure.Location = new System.Drawing.Point(235, 77);
            this.lueMeasure.MenuManager = this.barManager;
            this.lueMeasure.Name = "lueMeasure";
            this.lueMeasure.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lueMeasure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMeasure.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueMeasure.Properties.DisplayMember = "Name";
            this.lueMeasure.Properties.ShowFooter = false;
            this.lueMeasure.Properties.ShowHeader = false;
            this.lueMeasure.Properties.ValueMember = "Id";
            this.lueMeasure.Size = new System.Drawing.Size(209, 20);
            this.lueMeasure.StyleController = this.layoutControl;
            this.lueMeasure.TabIndex = 6;
            this.lueMeasure.EditValueChanged += new System.EventHandler(this.lueMeasure_EditValueChanged);
            // 
            // seTickness
            // 
            this.seTickness.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seTickness.Location = new System.Drawing.Point(15, 77);
            this.seTickness.MenuManager = this.barManager;
            this.seTickness.Name = "seTickness";
            this.seTickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seTickness.Properties.DisplayFormat.FormatString = "N2";
            this.seTickness.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seTickness.Properties.EditFormat.FormatString = "N2";
            this.seTickness.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seTickness.Size = new System.Drawing.Size(210, 20);
            this.seTickness.StyleController = this.layoutControl;
            this.seTickness.TabIndex = 5;
            // 
            // beMaterialMark
            // 
            this.beMaterialMark.Location = new System.Drawing.Point(15, 31);
            this.beMaterialMark.MenuManager = this.barManager;
            this.beMaterialMark.Name = "beMaterialMark";
            this.beMaterialMark.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMaterialMark.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beMaterialMark.Size = new System.Drawing.Size(648, 20);
            this.beMaterialMark.StyleController = this.layoutControl;
            this.beMaterialMark.TabIndex = 4;
            this.beMaterialMark.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beMaterialMark_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(678, 186);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beMaterialMark;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(658, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Марка материала";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(205, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 138);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(658, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.seTickness;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(220, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Толщина";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(205, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueMeasure;
            this.layoutControlItem3.Location = new System.Drawing.Point(220, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(219, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Единица измерения";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(205, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.beDefaultMaterialNom;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(658, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Номенклатура материала по умолчанию";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(205, 13);
            // 
            // teMark
            // 
            this.teMark.Location = new System.Drawing.Point(454, 77);
            this.teMark.MenuManager = this.barManager;
            this.teMark.Name = "teMark";
            this.teMark.Size = new System.Drawing.Size(209, 20);
            this.teMark.StyleController = this.layoutControl;
            this.teMark.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.teMark;
            this.layoutControlItem5.Location = new System.Drawing.Point(439, 46);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(219, 46);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "Маркировка";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(205, 13);
            // 
            // FxMaterialSizeTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 223);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxMaterialSizeTypeEdit";
            this.Text = "Типоразмер";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beDefaultMaterialNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMeasure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seTickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueMeasure;
        private DevExpress.XtraEditors.SpinEdit seTickness;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ButtonEdit beMaterialMark;
        private DevExpress.XtraEditors.ButtonEdit beDefaultMaterialNom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit teMark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}