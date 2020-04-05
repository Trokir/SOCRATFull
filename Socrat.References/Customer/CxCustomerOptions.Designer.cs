namespace Socrat.References.Customer
{
    partial class CxCustomerOptions
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
            this.lueCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.lueCountry = new DevExpress.XtraEditors.LookUpEdit();
            this.tePassword = new DevExpress.XtraEditors.TextEdit();
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            this.ceStopProcess = new DevExpress.XtraEditors.CheckEdit();
            this.ceBanOrders = new DevExpress.XtraEditors.CheckEdit();
            this.ceBan = new DevExpress.XtraEditors.CheckEdit();
            this.ceAccess = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStopProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBanOrders.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAccess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lueCurrency);
            this.layoutControl.Controls.Add(this.lueCountry);
            this.layoutControl.Controls.Add(this.tePassword);
            this.layoutControl.Controls.Add(this.teLogin);
            this.layoutControl.Controls.Add(this.ceStopProcess);
            this.layoutControl.Controls.Add(this.ceBanOrders);
            this.layoutControl.Controls.Add(this.ceBan);
            this.layoutControl.Controls.Add(this.ceAccess);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(812, 225, 650, 632);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(596, 644);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lueCurrency
            // 
            this.lueCurrency.Location = new System.Drawing.Point(376, 116);
            this.lueCurrency.Name = "lueCurrency";
            this.lueCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCurrency.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alias", "Имя")});
            this.lueCurrency.Properties.DisplayMember = "Alias";
            this.lueCurrency.Properties.ShowHeader = false;
            this.lueCurrency.Properties.ValueMember = "Id";
            this.lueCurrency.Size = new System.Drawing.Size(190, 20);
            this.lueCurrency.StyleController = this.layoutControl;
            this.lueCurrency.TabIndex = 12;
            this.lueCurrency.EditValueChanged += new System.EventHandler(this.lueCurrency_EditValueChanged);
            // 
            // lueCountry
            // 
            this.lueCountry.Location = new System.Drawing.Point(376, 64);
            this.lueCountry.Name = "lueCountry";
            this.lueCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCountry.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AliasName", "Имя")});
            this.lueCountry.Properties.DisplayMember = "AliasName";
            this.lueCountry.Properties.ShowHeader = false;
            this.lueCountry.Properties.ValueMember = "Id";
            this.lueCountry.Size = new System.Drawing.Size(190, 20);
            this.lueCountry.StyleController = this.layoutControl;
            this.lueCountry.TabIndex = 11;
            this.lueCountry.EditValueChanged += new System.EventHandler(this.lueCountry_EditValueChanged);
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(30, 141);
            this.tePassword.Name = "tePassword";
            this.tePassword.Size = new System.Drawing.Size(306, 20);
            this.tePassword.StyleController = this.layoutControl;
            this.tePassword.TabIndex = 10;
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(30, 93);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(306, 20);
            this.teLogin.StyleController = this.layoutControl;
            this.teLogin.TabIndex = 9;
            // 
            // ceStopProcess
            // 
            this.ceStopProcess.Location = new System.Drawing.Point(28, 277);
            this.ceStopProcess.Name = "ceStopProcess";
            this.ceStopProcess.Properties.Caption = "Запрет изготавливать изделия";
            this.ceStopProcess.Size = new System.Drawing.Size(207, 19);
            this.ceStopProcess.StyleController = this.layoutControl;
            this.ceStopProcess.TabIndex = 8;
            this.ceStopProcess.CheckedChanged += new System.EventHandler(this.ceStopProcess_CheckedChanged);
            // 
            // ceBanOrders
            // 
            this.ceBanOrders.Location = new System.Drawing.Point(28, 246);
            this.ceBanOrders.Name = "ceBanOrders";
            this.ceBanOrders.Properties.Caption = "Запрет принимать заказы";
            this.ceBanOrders.Size = new System.Drawing.Size(207, 19);
            this.ceBanOrders.StyleController = this.layoutControl;
            this.ceBanOrders.TabIndex = 7;
            this.ceBanOrders.CheckedChanged += new System.EventHandler(this.ceBanOrders_CheckedChanged);
            // 
            // ceBan
            // 
            this.ceBan.Location = new System.Drawing.Point(28, 215);
            this.ceBan.Name = "ceBan";
            this.ceBan.Properties.Caption = "Заблокировать любые действия";
            this.ceBan.Size = new System.Drawing.Size(207, 19);
            this.ceBan.StyleController = this.layoutControl;
            this.ceBan.TabIndex = 6;
            this.ceBan.CheckedChanged += new System.EventHandler(this.ceBan_CheckedChanged);
            // 
            // ceAccess
            // 
            this.ceAccess.Location = new System.Drawing.Point(28, 46);
            this.ceAccess.Name = "ceAccess";
            this.ceAccess.Properties.Caption = "Доступ открыт";
            this.ceAccess.Size = new System.Drawing.Size(310, 19);
            this.ceAccess.StyleController = this.layoutControl;
            this.ceAccess.TabIndex = 4;
            this.ceAccess.CheckedChanged += new System.EventHandler(this.ceVip_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem2,
            this.layoutControlGroup4,
            this.layoutControlGroup3,
            this.emptySpaceItem4});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(596, 644);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(346, 169);
            this.layoutControlGroup2.Text = "VIP";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ceAccess;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem1.Size = new System.Drawing.Size(322, 31);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.teLogin;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 6, 6);
            this.layoutControlItem5.Size = new System.Drawing.Size(322, 48);
            this.layoutControlItem5.Text = "Логин";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(39, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.tePassword;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 79);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 6, 6);
            this.layoutControlItem6.Size = new System.Drawing.Size(322, 48);
            this.layoutControlItem6.Text = "Пароль";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(39, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 314);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(576, 310);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup4.Location = new System.Drawing.Point(346, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(230, 169);
            this.layoutControlGroup4.Text = "Региональные настройки";
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 104);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(206, 23);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lueCountry;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(206, 52);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem7.Text = "Страна";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(39, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lueCurrency;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(206, 52);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem8.Text = "Валюта";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(39, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 169);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(243, 145);
            this.layoutControlGroup3.Text = "Блокировки";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 93);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(219, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceBan;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem3.Size = new System.Drawing.Size(219, 31);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ceBanOrders;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem2.Size = new System.Drawing.Size(219, 31);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ceStopProcess;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 62);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem4.Size = new System.Drawing.Size(219, 31);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(243, 169);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(333, 145);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // CxCustomerOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.Name = "CxCustomerOptions";
            this.Size = new System.Drawing.Size(596, 644);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStopProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBanOrders.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAccess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit tePassword;
        private DevExpress.XtraEditors.TextEdit teLogin;
        private DevExpress.XtraEditors.CheckEdit ceStopProcess;
        private DevExpress.XtraEditors.CheckEdit ceBanOrders;
        private DevExpress.XtraEditors.CheckEdit ceBan;
        private DevExpress.XtraEditors.CheckEdit ceAccess;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.LookUpEdit lueCurrency;
        private DevExpress.XtraEditors.LookUpEdit lueCountry;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
