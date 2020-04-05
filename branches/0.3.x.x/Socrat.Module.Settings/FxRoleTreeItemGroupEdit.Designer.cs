namespace Socrat.Module.Settings
{
    partial class FxRoleTreeItemGroupEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxRoleTreeItemGroupEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tlRoleTreeItems = new DevExpress.XtraTreeList.TreeList();
            this.colItem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRead = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colWrite = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleTreeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.simpleButton2);
            this.layoutControl.Controls.Add(this.simpleButton1);
            this.layoutControl.Controls.Add(this.tlRoleTreeItems);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1027, 241, 650, 400);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(706, 660);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = global::Socrat.Module.Settings.Properties.Resources.save_16x16;
            this.simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton2.Location = new System.Drawing.Point(441, 617);
            this.simpleButton2.MinimumSize = new System.Drawing.Size(120, 28);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(120, 28);
            this.simpleButton2.StyleController = this.layoutControl;
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Сохранить";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::Socrat.Module.Settings.Properties.Resources.delete_16x16;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton1.Location = new System.Drawing.Point(571, 617);
            this.simpleButton1.MaximumSize = new System.Drawing.Size(120, 0);
            this.simpleButton1.MinimumSize = new System.Drawing.Size(120, 28);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(120, 28);
            this.simpleButton1.StyleController = this.layoutControl;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Отмена";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tlRoleTreeItems
            // 
            this.tlRoleTreeItems.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItem,
            this.colRead,
            this.colWrite});
            this.tlRoleTreeItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlRoleTreeItems.KeyFieldName = "TreeItemId";
            this.tlRoleTreeItems.Location = new System.Drawing.Point(12, 12);
            this.tlRoleTreeItems.Name = "tlRoleTreeItems";
            this.tlRoleTreeItems.ParentFieldName = "ParentTreeItemId";
            this.tlRoleTreeItems.Size = new System.Drawing.Size(682, 598);
            this.tlRoleTreeItems.TabIndex = 4;
            // 
            // colItem
            // 
            this.colItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.Caption = "Пункт меню";
            this.colItem.FieldName = "TreeItem";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            this.colItem.Width = 360;
            // 
            // colRead
            // 
            this.colRead.AppearanceHeader.Options.UseTextOptions = true;
            this.colRead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRead.Caption = "Чтение";
            this.colRead.FieldName = "Read";
            this.colRead.Name = "colRead";
            this.colRead.Visible = true;
            this.colRead.VisibleIndex = 1;
            this.colRead.Width = 142;
            // 
            // colWrite
            // 
            this.colWrite.AppearanceHeader.Options.UseTextOptions = true;
            this.colWrite.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWrite.Caption = "Запись";
            this.colWrite.FieldName = "Write";
            this.colWrite.Name = "colWrite";
            this.colWrite.Visible = true;
            this.colWrite.VisibleIndex = 2;
            this.colWrite.Width = 162;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(706, 660);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tlRoleTreeItems;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(686, 602);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(556, 602);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(130, 38);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 602);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(426, 38);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new System.Drawing.Point(426, 602);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(130, 38);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(130, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(130, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FxRoleTreeItemGroupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 660);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxRoleTreeItemGroupEdit";
            this.Text = "Групповое добавление прав";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleTreeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraTreeList.TreeList tlRoleTreeItems;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRead;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colWrite;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}