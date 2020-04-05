namespace Socrat.References.Pools
{
    partial class FxCustomerPoolEdit
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxCustomerPoolEdit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.teTime = new DevExpress.XtraEditors.TimeEdit();
            this.teNum = new DevExpress.XtraEditors.TextEdit();
            this.deDate = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Номер = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Дата = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Номер)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Дата)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.teTime);
            this.layoutControl.Controls.Add(this.teNum);
            this.layoutControl.Controls.Add(this.deDate);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(277, 197);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 77);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(247, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 8;
            // 
            // teTime
            // 
            this.teTime.EditValue = new System.DateTime(2019, 11, 20, 0, 0, 0, 0);
            this.teTime.Location = new System.Drawing.Point(143, 123);
            this.teTime.MenuManager = this.barManager;
            this.teTime.Name = "teTime";
            this.teTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.teTime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.teTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.teTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.teTime.Size = new System.Drawing.Size(119, 20);
            this.teTime.StyleController = this.layoutControl;
            this.teTime.TabIndex = 7;
            // 
            // teNum
            // 
            this.teNum.Location = new System.Drawing.Point(15, 31);
            this.teNum.MenuManager = this.barManager;
            this.teNum.Name = "teNum";
            this.teNum.Size = new System.Drawing.Size(247, 20);
            this.teNum.StyleController = this.layoutControl;
            this.teNum.TabIndex = 4;
            // 
            // deDate
            // 
            this.deDate.EditValue = null;
            this.deDate.Location = new System.Drawing.Point(15, 123);
            this.deDate.MenuManager = this.barManager;
            this.deDate.Name = "deDate";
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.deDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.deDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDate.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.deDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDate.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.deDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDate.Properties.Mask.EditMask = "";
            this.deDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.deDate.Size = new System.Drawing.Size(118, 22);
            this.deDate.StyleController = this.layoutControl;
            this.deDate.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Номер,
            this.emptySpaceItem1,
            this.Дата,
            this.layoutControlItem4,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(277, 197);
            this.Root.TextVisible = false;
            // 
            // Номер
            // 
            this.Номер.Control = this.teNum;
            this.Номер.Location = new System.Drawing.Point(0, 0);
            this.Номер.Name = "Номер";
            this.Номер.Size = new System.Drawing.Size(257, 46);
            this.Номер.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Номер.TextLocation = DevExpress.Utils.Locations.Top;
            this.Номер.TextSize = new System.Drawing.Size(31, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 140);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(257, 37);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Дата
            // 
            this.Дата.Control = this.deDate;
            this.Дата.Location = new System.Drawing.Point(0, 92);
            this.Дата.Name = "Дата";
            this.Дата.Size = new System.Drawing.Size(128, 48);
            this.Дата.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Дата.TextLocation = DevExpress.Utils.Locations.Top;
            this.Дата.TextSize = new System.Drawing.Size(31, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teTime;
            this.layoutControlItem4.Location = new System.Drawing.Point(128, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 48);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Время";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(31, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(257, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Имя";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(31, 13);
            // 
            // FxCustomerPoolEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(277, 234);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxCustomerPoolEdit";
            this.Text = "Пул";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Номер)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Дата)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TimeEdit teTime;
        private DevExpress.XtraEditors.TextEdit teNum;
        private DevExpress.XtraLayout.LayoutControlItem Номер;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem Дата;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DateEdit deDate;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}