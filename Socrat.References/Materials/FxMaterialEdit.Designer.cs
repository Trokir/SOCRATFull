namespace Socrat.References.Materials
{
    partial class FxMaterialEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMaterialEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pcTradeMarks = new DevExpress.XtraEditors.PanelControl();
            this.pcFields = new DevExpress.XtraEditors.PanelControl();
            this.pcSpecProps = new DevExpress.XtraEditors.PanelControl();
            this.teEnumCode = new DevExpress.XtraEditors.TextEdit();
            this.lueSubtype = new DevExpress.XtraEditors.LookUpEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tcgTradeMarks = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcTradeMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSpecProps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEnumCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubtype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgTradeMarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pcTradeMarks);
            this.layoutControl.Controls.Add(this.pcSpecProps);
            this.layoutControl.Controls.Add(this.pcFields);
            this.layoutControl.Controls.Add(this.teEnumCode);
            this.layoutControl.Controls.Add(this.lueSubtype);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(680, 678);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pcTradeMarks
            // 
            this.pcTradeMarks.Location = new System.Drawing.Point(24, 184);
            this.pcTradeMarks.Name = "pcTradeMarks";
            this.pcTradeMarks.Size = new System.Drawing.Size(632, 470);
            this.pcTradeMarks.TabIndex = 10;
            // 
            // pcFields
            // 
            this.pcFields.Location = new System.Drawing.Point(24, 184);
            this.pcFields.Name = "pcFields";
            this.pcFields.Size = new System.Drawing.Size(632, 470);
            this.pcFields.TabIndex = 9;
            // 
            // pcSpecProps
            // 
            this.pcSpecProps.Location = new System.Drawing.Point(24, 184);
            this.pcSpecProps.Name = "pcSpecProps";
            this.pcSpecProps.Size = new System.Drawing.Size(632, 470);
            this.pcSpecProps.TabIndex = 8;
            // 
            // teEnumCode
            // 
            this.teEnumCode.Location = new System.Drawing.Point(15, 123);
            this.teEnumCode.MenuManager = this.barManager;
            this.teEnumCode.Name = "teEnumCode";
            this.teEnumCode.Size = new System.Drawing.Size(650, 20);
            this.teEnumCode.StyleController = this.layoutControl;
            this.teEnumCode.TabIndex = 7;
            // 
            // lueSubtype
            // 
            this.lueSubtype.Location = new System.Drawing.Point(15, 31);
            this.lueSubtype.MenuManager = this.barManager;
            this.lueSubtype.Name = "lueSubtype";
            this.lueSubtype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSubtype.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueSubtype.Properties.DisplayMember = "Name";
            this.lueSubtype.Properties.ShowFooter = false;
            this.lueSubtype.Properties.ShowHeader = false;
            this.lueSubtype.Properties.ValueMember = "Id";
            this.lueSubtype.Size = new System.Drawing.Size(650, 20);
            this.lueSubtype.StyleController = this.layoutControl;
            this.lueSubtype.TabIndex = 6;
            this.lueSubtype.EditValueChanged += new System.EventHandler(this.lueSubtype_EditValueChanged);
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 77);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(650, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.tcgTradeMarks});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(680, 678);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(660, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Наименование";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lueSubtype;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(660, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Тип";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teEnumCode;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(660, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Код энумератора";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 13);
            // 
            // tcgTradeMarks
            // 
            this.tcgTradeMarks.Location = new System.Drawing.Point(0, 138);
            this.tcgTradeMarks.Name = "tcgTradeMarks";
            this.tcgTradeMarks.SelectedTabPage = this.layoutControlGroup2;
            this.tcgTradeMarks.Size = new System.Drawing.Size(660, 520);
            this.tcgTradeMarks.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.tcgTradeMarks.Text = "Торговые марки";
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(636, 474);
            this.layoutControlGroup4.Text = "Торговые марки";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.pcTradeMarks;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(636, 474);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(636, 474);
            this.layoutControlGroup2.Text = "Специальные св-ва";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pcSpecProps;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(636, 474);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(636, 474);
            this.layoutControlGroup3.Text = "Дополнительные параметры";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.pcFields;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(636, 474);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FxMaterialEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 715);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxMaterialEdit";
            this.Text = "Материал";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcTradeMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcSpecProps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teEnumCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSubtype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgTradeMarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueSubtype;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit teEnumCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl pcSpecProps;
        private DevExpress.XtraLayout.TabbedControlGroup tcgTradeMarks;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraEditors.PanelControl pcFields;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.PanelControl pcTradeMarks;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}