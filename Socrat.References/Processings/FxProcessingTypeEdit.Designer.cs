namespace Socrat.References.Processings
{
    partial class FxProcessingTypeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxProcessingTypeEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lueDialogType = new DevExpress.XtraEditors.LookUpEdit();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.seStep = new DevExpress.XtraEditors.SpinEdit();
            this.teShortName = new DevExpress.XtraEditors.TextEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lueMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.beMeasure = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueDialogType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMeasure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lueDialogType);
            this.layoutControl.Controls.Add(this.ceColor);
            this.layoutControl.Controls.Add(this.seStep);
            this.layoutControl.Controls.Add(this.teShortName);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.lueMaterial);
            this.layoutControl.Controls.Add(this.beMeasure);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(543, 239);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lueDialogType
            // 
            this.lueDialogType.Location = new System.Drawing.Point(15, 189);
            this.lueDialogType.MenuManager = this.barManager;
            this.lueDialogType.Name = "lueDialogType";
            this.lueDialogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDialogType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Имя")});
            this.lueDialogType.Properties.DisplayMember = "Value";
            this.lueDialogType.Properties.ShowFooter = false;
            this.lueDialogType.Properties.ShowHeader = false;
            this.lueDialogType.Properties.ValueMember = "Key";
            this.lueDialogType.Size = new System.Drawing.Size(513, 20);
            this.lueDialogType.StyleController = this.layoutControl;
            this.lueDialogType.TabIndex = 10;
            this.lueDialogType.EditValueChanged += new System.EventHandler(this.lueDialogType_EditValueChanged);
            // 
            // ceColor
            // 
            this.ceColor.EditValue = System.Drawing.Color.Empty;
            this.ceColor.Location = new System.Drawing.Point(387, 143);
            this.ceColor.MenuManager = this.barManager;
            this.ceColor.Name = "ceColor";
            this.ceColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceColor.Size = new System.Drawing.Size(141, 20);
            this.ceColor.StyleController = this.layoutControl;
            this.ceColor.TabIndex = 9;
            this.ceColor.EditValueChanged += new System.EventHandler(this.ceColor_EditValueChanged);
            // 
            // seStep
            // 
            this.seStep.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seStep.Location = new System.Drawing.Point(15, 143);
            this.seStep.MenuManager = this.barManager;
            this.seStep.Name = "seStep";
            this.seStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seStep.Size = new System.Drawing.Size(178, 20);
            this.seStep.StyleController = this.layoutControl;
            this.seStep.TabIndex = 7;
            // 
            // teShortName
            // 
            this.teShortName.Location = new System.Drawing.Point(276, 96);
            this.teShortName.MenuManager = this.barManager;
            this.teShortName.Name = "teShortName";
            this.teShortName.Size = new System.Drawing.Size(251, 20);
            this.teShortName.StyleController = this.layoutControl;
            this.teShortName.TabIndex = 6;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(16, 96);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(250, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 5;
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
            this.lueMaterial.Properties.ShowFooter = false;
            this.lueMaterial.Properties.ShowHeader = false;
            this.lueMaterial.Properties.ValueMember = "Id";
            this.lueMaterial.Size = new System.Drawing.Size(513, 20);
            this.lueMaterial.StyleController = this.layoutControl;
            this.lueMaterial.TabIndex = 4;
            this.lueMaterial.EditValueChanged += new System.EventHandler(this.lueMaterial_EditValueChanged);
            // 
            // beMeasure
            // 
            this.beMeasure.Location = new System.Drawing.Point(203, 143);
            this.beMeasure.MenuManager = this.barManager;
            this.beMeasure.Name = "beMeasure";
            this.beMeasure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMeasure.Properties.NullText = "[нет данных]";
            this.beMeasure.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beMeasure.Size = new System.Drawing.Size(174, 20);
            this.beMeasure.StyleController = this.layoutControl;
            this.beMeasure.TabIndex = 8;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlGroup1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(543, 239);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueMaterial;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(523, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Материал";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 204);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(523, 15);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(523, 66);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Наименование";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(260, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Полное";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teShortName;
            this.layoutControlItem3.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(261, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Короткое";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.seStep;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 112);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(188, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Очередность";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.beMeasure;
            this.layoutControlItem5.Location = new System.Drawing.Point(188, 112);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(184, 46);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "Размерность";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ceColor;
            this.layoutControlItem6.Location = new System.Drawing.Point(372, 112);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(151, 46);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "Цвет";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lueDialogType;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 158);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(523, 46);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.Text = "Тип диалога";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(68, 13);
            // 
            // FxProcessingTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 276);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxProcessingTypeEdit";
            this.Text = "Тип операции";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueDialogType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beMeasure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LookUpEdit lueMaterial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit teShortName;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.SpinEdit seStep;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.ButtonEdit beMeasure;
        private DevExpress.XtraEditors.LookUpEdit lueDialogType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
