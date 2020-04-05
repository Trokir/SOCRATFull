namespace Socrat.References.Contract
{
    partial class FxAddressContactEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxAddressContactEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.teFio = new DevExpress.XtraEditors.TextEdit();
            this.beWorkPosition = new DevExpress.XtraEditors.ButtonEdit();
            this.teContactValue = new DevExpress.XtraEditors.TextEdit();
            this.lueContactType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teFio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beWorkPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teContactValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueContactType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.teFio);
            this.layoutControl.Controls.Add(this.beWorkPosition);
            this.layoutControl.Controls.Add(this.teContactValue);
            this.layoutControl.Controls.Add(this.lueContactType);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(451, 228);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl";
            // 
            // teFio
            // 
            this.teFio.Location = new System.Drawing.Point(15, 123);
            this.teFio.Name = "teFio";
            this.teFio.Size = new System.Drawing.Size(421, 20);
            this.teFio.StyleController = this.layoutControl;
            this.teFio.TabIndex = 7;
            // 
            // beWorkPosition
            // 
            this.beWorkPosition.Location = new System.Drawing.Point(15, 169);
            this.beWorkPosition.Name = "beWorkPosition";
            this.beWorkPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beWorkPosition.Size = new System.Drawing.Size(421, 20);
            this.beWorkPosition.StyleController = this.layoutControl;
            this.beWorkPosition.TabIndex = 6;
            this.beWorkPosition.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.beWorkPosition_ButtonClick);
            // 
            // teContactValue
            // 
            this.teContactValue.Location = new System.Drawing.Point(15, 77);
            this.teContactValue.Name = "teContactValue";
            this.teContactValue.Size = new System.Drawing.Size(421, 20);
            this.teContactValue.StyleController = this.layoutControl;
            this.teContactValue.TabIndex = 5;
            // 
            // lueContactType
            // 
            this.lueContactType.Location = new System.Drawing.Point(15, 31);
            this.lueContactType.Name = "lueContactType";
            this.lueContactType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueContactType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueContactType.Properties.DisplayMember = "Name";
            this.lueContactType.Properties.ShowFooter = false;
            this.lueContactType.Properties.ShowHeader = false;
            this.lueContactType.Properties.ValueMember = "Id";
            this.lueContactType.Size = new System.Drawing.Size(421, 20);
            this.lueContactType.StyleController = this.layoutControl;
            this.lueContactType.TabIndex = 4;
            this.lueContactType.EditValueChanged += new System.EventHandler(this.lueContactType_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(451, 228);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lueContactType;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(431, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Тип";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(118, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 184);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(431, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teContactValue;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(431, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Значение";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.beWorkPosition;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(431, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Должность";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(118, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teFio;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(431, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Фамилия Имя Отчество";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(118, 13);
            // 
            // FxAddressContactEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 265);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxAddressContactEdit";
            this.Text = "Контакт адреса";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teFio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beWorkPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teContactValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueContactType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.ButtonEdit beWorkPosition;
        private DevExpress.XtraEditors.TextEdit teContactValue;
        private DevExpress.XtraEditors.LookUpEdit lueContactType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit teFio;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}