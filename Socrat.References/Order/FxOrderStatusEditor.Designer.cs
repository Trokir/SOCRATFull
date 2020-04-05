namespace Socrat.References.Order
{
    partial class FxOrderStatusEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxOrderStatusEditor));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.ceColor = new DevExpress.XtraEditors.ColorEdit();
            this.meMessage = new DevExpress.XtraEditors.MemoEdit();
            this.meDesc = new DevExpress.XtraEditors.MemoEdit();
            this.seNum = new DevExpress.XtraEditors.SpinEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.ceColor);
            this.layoutControl.Controls.Add(this.meMessage);
            this.layoutControl.Controls.Add(this.meDesc);
            this.layoutControl.Controls.Add(this.seNum);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(729, 360);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // ceColor
            // 
            this.ceColor.EditValue = System.Drawing.Color.Empty;
            this.ceColor.Location = new System.Drawing.Point(611, 31);
            this.ceColor.MenuManager = this.barManager;
            this.ceColor.Name = "ceColor";
            this.ceColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceColor.Size = new System.Drawing.Size(103, 20);
            this.ceColor.StyleController = this.layoutControl;
            this.ceColor.TabIndex = 8;
            this.ceColor.ColorChanged += new System.EventHandler(this.ceColor_ColorChanged);
            // 
            // meMessage
            // 
            this.meMessage.Location = new System.Drawing.Point(15, 180);
            this.meMessage.MenuManager = this.barManager;
            this.meMessage.Name = "meMessage";
            this.meMessage.Size = new System.Drawing.Size(699, 165);
            this.meMessage.StyleController = this.layoutControl;
            this.meMessage.TabIndex = 7;
            // 
            // meDesc
            // 
            this.meDesc.Location = new System.Drawing.Point(15, 77);
            this.meDesc.MenuManager = this.barManager;
            this.meDesc.Name = "meDesc";
            this.meDesc.Properties.MaxLength = 300;
            this.meDesc.Size = new System.Drawing.Size(699, 77);
            this.meDesc.StyleController = this.layoutControl;
            this.meDesc.TabIndex = 6;
            // 
            // seNum
            // 
            this.seNum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seNum.Location = new System.Drawing.Point(498, 31);
            this.seNum.MenuManager = this.barManager;
            this.seNum.Name = "seNum";
            this.seNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seNum.Properties.IsFloatValue = false;
            this.seNum.Properties.Mask.EditMask = "N00";
            this.seNum.Size = new System.Drawing.Size(103, 20);
            this.seNum.StyleController = this.layoutControl;
            this.seNum.TabIndex = 5;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 31);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(473, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(729, 360);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(483, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Наименование";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.meDesc;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(709, 103);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Пояснение";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.meMessage;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 149);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(709, 191);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Сообщение клиенту";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.seNum;
            this.layoutControlItem2.Location = new System.Drawing.Point(483, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(113, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Номер по порядку";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(103, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ceColor;
            this.layoutControlItem5.Location = new System.Drawing.Point(596, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(113, 46);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "Цвет";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(103, 13);
            // 
            // FxOrderStatusEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 397);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxOrderStatusEditor";
            this.Text = "Редактор статуса заявки";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ColorEdit ceColor;
        private DevExpress.XtraEditors.MemoEdit meMessage;
        private DevExpress.XtraEditors.MemoEdit meDesc;
        private DevExpress.XtraEditors.SpinEdit seNum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
