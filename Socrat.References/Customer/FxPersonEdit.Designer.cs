namespace Socrat.References.Customer
{
    partial class FxPersonEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxPersonEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lueGender = new DevExpress.XtraEditors.LookUpEdit();
            this.cxPersonContacts = new CxPersonContacts();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.tePatron = new DevExpress.XtraEditors.TextEdit();
            this.teSurname = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePatron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lueGender);
            this.layoutControl.Controls.Add(this.cxPersonContacts);
            this.layoutControl.Controls.Add(this.simpleButton1);
            this.layoutControl.Controls.Add(this.teName);
            this.layoutControl.Controls.Add(this.tePatron);
            this.layoutControl.Controls.Add(this.teSurname);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(494, 455);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lueGender
            // 
            this.lueGender.Location = new System.Drawing.Point(226, 68);
            this.lueGender.Name = "lueGender";
            this.lueGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueGender.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Alias", "Имя")});
            this.lueGender.Properties.DisplayMember = "Alias";
            this.lueGender.Properties.ShowHeader = false;
            this.lueGender.Properties.ValueMember = "Id";
            this.lueGender.Size = new System.Drawing.Size(256, 20);
            this.lueGender.StyleController = this.layoutControl;
            this.lueGender.TabIndex = 6;
            this.lueGender.EditValueChanged += new System.EventHandler(this.lueGender_EditValueChanged);
            // 
            // cxPersonContacts
            // 
            this.cxPersonContacts.Customer = null;
            this.cxPersonContacts.Location = new System.Drawing.Point(12, 92);
            this.cxPersonContacts.Name = "cxPersonContacts";
            this.cxPersonContacts.Personal = null;
            this.cxPersonContacts.ReadOnly = false;
            this.cxPersonContacts.Size = new System.Drawing.Size(470, 325);
            this.cxPersonContacts.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(406, 421);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(76, 22);
            this.simpleButton1.StyleController = this.layoutControl;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Ok";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(226, 28);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(256, 20);
            this.teName.StyleController = this.layoutControl;
            this.teName.TabIndex = 2;
            // 
            // tePatron
            // 
            this.tePatron.Location = new System.Drawing.Point(12, 68);
            this.tePatron.Name = "tePatron";
            this.tePatron.Size = new System.Drawing.Size(210, 20);
            this.tePatron.StyleController = this.layoutControl;
            this.tePatron.TabIndex = 3;
            // 
            // teSurname
            // 
            this.teSurname.Location = new System.Drawing.Point(12, 28);
            this.teSurname.Name = "teSurname";
            this.teSurname.Size = new System.Drawing.Size(210, 20);
            this.teSurname.StyleController = this.layoutControl;
            this.teSurname.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.lciName,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(494, 455);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teSurname;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(214, 40);
            this.layoutControlItem1.Text = "Фамилия";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tePatron;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(214, 40);
            this.layoutControlItem3.Text = "Отчество";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 13);
            // 
            // lciName
            // 
            this.lciName.Control = this.teName;
            this.lciName.Location = new System.Drawing.Point(214, 0);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(260, 40);
            this.lciName.Text = "Имя";
            this.lciName.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciName.TextSize = new System.Drawing.Size(49, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 409);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(394, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(394, 409);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cxPersonContacts;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(474, 329);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lueGender;
            this.layoutControlItem5.Location = new System.Drawing.Point(214, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(260, 40);
            this.layoutControlItem5.Text = "Пол";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(49, 13);
            // 
            // FxPersonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 455);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxPersonEdit";
            this.Text = "Карточка персоны";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePatron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit tePatron;
        private DevExpress.XtraEditors.TextEdit teSurname;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private CxPersonContacts cxPersonContacts;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LookUpEdit lueGender;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}