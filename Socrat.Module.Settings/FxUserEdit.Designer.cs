namespace Socrat.Module.Settings
{
    partial class FxUserEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxUserEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnLoadFromAD = new DevExpress.XtraEditors.SimpleButton();
            this.lueRole = new DevExpress.XtraEditors.LookUpEdit();
            this.teMail = new DevExpress.XtraEditors.TextEdit();
            this.teLogin = new DevExpress.XtraEditors.TextEdit();
            this.teDomain = new DevExpress.XtraEditors.TextEdit();
            this.tePatron = new DevExpress.XtraEditors.TextEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.teSurname = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueRole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDomain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePatron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnLoadFromAD);
            this.layoutControl.Controls.Add(this.lueRole);
            this.layoutControl.Controls.Add(this.teMail);
            this.layoutControl.Controls.Add(this.teLogin);
            this.layoutControl.Controls.Add(this.teDomain);
            this.layoutControl.Controls.Add(this.tePatron);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.teSurname);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(693, 203);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnLoadFromAD
            // 
            this.btnLoadFromAD.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnLoadFromAD.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnLoadFromAD.Location = new System.Drawing.Point(12, 12);
            this.btnLoadFromAD.MaximumSize = new System.Drawing.Size(220, 30);
            this.btnLoadFromAD.MinimumSize = new System.Drawing.Size(220, 30);
            this.btnLoadFromAD.Name = "btnLoadFromAD";
            this.btnLoadFromAD.Size = new System.Drawing.Size(220, 30);
            this.btnLoadFromAD.StyleController = this.layoutControl;
            this.btnLoadFromAD.TabIndex = 11;
            this.btnLoadFromAD.Text = "Загрузить из ActiveDirectory";
            this.btnLoadFromAD.Click += new System.EventHandler(this.btnLoadFromAD_Click);
            // 
            // lueRole
            // 
            this.lueRole.Location = new System.Drawing.Point(15, 157);
            this.lueRole.Name = "lueRole";
            this.lueRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueRole.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Имя")});
            this.lueRole.Properties.DisplayMember = "Name";
            this.lueRole.Properties.ShowFooter = false;
            this.lueRole.Properties.ShowHeader = false;
            this.lueRole.Properties.ValueMember = "Id";
            this.lueRole.Size = new System.Drawing.Size(326, 20);
            this.lueRole.StyleController = this.layoutControl;
            this.lueRole.TabIndex = 10;
            this.lueRole.EditValueChanged += new System.EventHandler(this.lueRole_EditValueChanged);
            // 
            // teMail
            // 
            this.teMail.Location = new System.Drawing.Point(351, 111);
            this.teMail.Name = "teMail";
            this.teMail.Size = new System.Drawing.Size(327, 20);
            this.teMail.StyleController = this.layoutControl;
            this.teMail.TabIndex = 9;
            // 
            // teLogin
            // 
            this.teLogin.Location = new System.Drawing.Point(123, 111);
            this.teLogin.Name = "teLogin";
            this.teLogin.Size = new System.Drawing.Size(218, 20);
            this.teLogin.StyleController = this.layoutControl;
            this.teLogin.TabIndex = 8;
            // 
            // teDomain
            // 
            this.teDomain.Location = new System.Drawing.Point(15, 111);
            this.teDomain.Name = "teDomain";
            this.teDomain.Size = new System.Drawing.Size(98, 20);
            this.teDomain.StyleController = this.layoutControl;
            this.teDomain.TabIndex = 7;
            // 
            // tePatron
            // 
            this.tePatron.Location = new System.Drawing.Point(464, 65);
            this.tePatron.Name = "tePatron";
            this.tePatron.Size = new System.Drawing.Size(214, 20);
            this.tePatron.StyleController = this.layoutControl;
            this.tePatron.TabIndex = 6;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(245, 65);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(209, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 5;
            // 
            // teSurname
            // 
            this.teSurname.Location = new System.Drawing.Point(15, 65);
            this.teSurname.Name = "teSurname";
            this.teSurname.Size = new System.Drawing.Size(220, 20);
            this.teSurname.StyleController = this.layoutControl;
            this.teSurname.TabIndex = 4;
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(693, 203);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teSurname;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(230, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Фамилия";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 172);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(673, 11);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teName;
            this.layoutControlItem2.Location = new System.Drawing.Point(230, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(219, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Имя";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tePatron;
            this.layoutControlItem3.Location = new System.Drawing.Point(449, 34);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(224, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Отчество";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teDomain;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(108, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "Домен";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.teLogin;
            this.layoutControlItem5.Location = new System.Drawing.Point(108, 80);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(228, 46);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "Логин";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lueRole;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 126);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(336, 46);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.Text = "Роль";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(49, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(336, 126);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(337, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.teMail;
            this.layoutControlItem6.Location = new System.Drawing.Point(336, 80);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(337, 46);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "E-mail";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnLoadFromAD;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(673, 34);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // FxUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 240);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxUserEdit";
            this.Text = "Пользователь";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueRole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teDomain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePatron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lueRole;
        private DevExpress.XtraEditors.TextEdit teMail;
        private DevExpress.XtraEditors.TextEdit teLogin;
        private DevExpress.XtraEditors.TextEdit teDomain;
        private DevExpress.XtraEditors.TextEdit tePatron;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraEditors.TextEdit teSurname;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnLoadFromAD;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}