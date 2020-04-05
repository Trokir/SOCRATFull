namespace Socrat.References.Customer
{
    partial class CxIpCommon
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
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lueCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.deReg = new DevExpress.XtraEditors.DateEdit();
            this.teCode1C = new DevExpress.XtraEditors.TextEdit();
            this.teInn = new DevExpress.XtraEditors.TextEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.lcFullName = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReg.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode1C.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lueCountry);
            this.layoutControl.Controls.Add(this.deReg);
            this.layoutControl.Controls.Add(this.teCode1C);
            this.layoutControl.Controls.Add(this.teInn);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.lcFullName);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(587, 648);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lueCountry
            // 
            this.lueCountry.Location = new System.Drawing.Point(15, 226);
            this.lueCountry.Name = "lueCountry";
            this.lueCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCountry.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AliasName", "Имя")});
            this.lueCountry.Properties.DisplayMember = "AliasName";
            this.lueCountry.Properties.ValueMember = "Id";
            this.lueCountry.Size = new System.Drawing.Size(273, 20);
            this.lueCountry.StyleController = this.layoutControl;
            this.lueCountry.TabIndex = 9;
            this.lueCountry.EditValueChanged += new System.EventHandler(this.lueCitezenship_EditValueChanged);
            // 
            // deReg
            // 
            this.deReg.EditValue = null;
            this.deReg.Location = new System.Drawing.Point(391, 179);
            this.deReg.Name = "deReg";
            this.deReg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReg.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.deReg.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReg.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.deReg.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.deReg.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deReg.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.deReg.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.deReg.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.deReg.Size = new System.Drawing.Size(180, 20);
            this.deReg.StyleController = this.layoutControl;
            this.deReg.TabIndex = 8;
            this.deReg.EditValueChanged += new System.EventHandler(this.deReg_EditValueChanged);
            // 
            // teCode1C
            // 
            this.teCode1C.Location = new System.Drawing.Point(192, 179);
            this.teCode1C.Name = "teCode1C";
            this.teCode1C.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teCode1C.Properties.Mask.EditMask = "[A-Z0-9]{20}";
            this.teCode1C.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teCode1C.Size = new System.Drawing.Size(187, 20);
            this.teCode1C.StyleController = this.layoutControl;
            this.teCode1C.TabIndex = 7;
            // 
            // teInn
            // 
            this.teInn.Location = new System.Drawing.Point(16, 179);
            this.teInn.Name = "teInn";
            this.teInn.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teInn.Properties.Mask.EditMask = "\\d{12}";
            this.teInn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teInn.Size = new System.Drawing.Size(164, 20);
            this.teInn.StyleController = this.layoutControl;
            this.teInn.TabIndex = 6;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(28, 109);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(531, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 5;
            // 
            // lcFullName
            // 
            this.lcFullName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lcFullName.Appearance.Options.UseFont = true;
            this.lcFullName.Location = new System.Drawing.Point(28, 62);
            this.lcFullName.Name = "lcFullName";
            this.lcFullName.Size = new System.Drawing.Size(164, 19);
            this.lcFullName.StyleController = this.layoutControl;
            this.lcFullName.TabIndex = 4;
            this.lcFullName.Text = "Полное наименование";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(587, 648);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 241);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(567, 387);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(567, 147);
            this.layoutControlGroup2.Text = "Наименование";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 95);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(543, 10);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lcFullName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem1.Size = new System.Drawing.Size(543, 47);
            this.layoutControlItem1.Tag = "";
            this.layoutControlItem1.Text = "Полное наименование";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 47);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem2.Size = new System.Drawing.Size(543, 48);
            this.layoutControlItem2.Text = "Наименование без ОПФ";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teInn;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 147);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem3.Size = new System.Drawing.Size(176, 48);
            this.layoutControlItem3.Text = "ИНН";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teCode1C;
            this.layoutControlItem4.Location = new System.Drawing.Point(176, 147);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem4.Size = new System.Drawing.Size(199, 48);
            this.layoutControlItem4.Text = "Код 1С";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.deReg;
            this.layoutControlItem5.Location = new System.Drawing.Point(375, 147);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem5.Size = new System.Drawing.Size(192, 48);
            this.layoutControlItem5.Text = "Дата регистрации";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(119, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lueCountry;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 195);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(283, 46);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "Гражданство";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(119, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(283, 195);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(284, 46);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CxIpCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "CxIpCommon";
            this.Size = new System.Drawing.Size(587, 648);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReg.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teCode1C.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit deReg;
        private DevExpress.XtraEditors.TextEdit teCode1C;
        private DevExpress.XtraEditors.TextEdit teInn;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.LabelControl lcFullName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lueCountry;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}
