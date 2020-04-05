namespace Socrat.Module.Settings
{
    partial class FxGeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxGeneralSettings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tpMainMenu = new DevExpress.XtraTab.XtraTabPage();
            this._cxMenuEditor1 = new Socrat.Module.Settings.CxMenuTree();
            this.tpUsers = new DevExpress.XtraTab.XtraTabPage();
            this.cxUserList1 = new Socrat.Module.Settings.CxUserList();
            this.tpRoles = new DevExpress.XtraTab.XtraTabPage();
            this.cxRoles = new Socrat.Module.Settings.CxRoles();
            this.tpModules = new DevExpress.XtraTab.XtraTabPage();
            this.cxModules1 = new Socrat.Module.Settings.CxModules();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.tpMainMenu.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.tpRoles.SuspendLayout();
            this.tpModules.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.xtraTabControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 753);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(3, 3);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.tpMainMenu;
            this.xtraTabControl.Size = new System.Drawing.Size(1111, 707);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpMainMenu,
            this.tpUsers,
            this.tpRoles,
            this.tpModules});
            // 
            // tpMainMenu
            // 
            this.tpMainMenu.Controls.Add(this._cxMenuEditor1);
            this.tpMainMenu.Name = "tpMainMenu";
            this.tpMainMenu.Size = new System.Drawing.Size(1105, 679);
            this.tpMainMenu.Text = "Главное меню";
            // 
            // _cxMenuEditor1
            // 
            this._cxMenuEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cxMenuEditor1.Location = new System.Drawing.Point(0, 0);
            this._cxMenuEditor1.Name = "_cxMenuEditor1";
            this._cxMenuEditor1.Size = new System.Drawing.Size(1105, 679);
            this._cxMenuEditor1.TabIndex = 0;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.cxUserList1);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(1105, 679);
            this.tpUsers.Text = "Пользователи";
            // 
            // cxUserList1
            // 
            this.cxUserList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxUserList1.Location = new System.Drawing.Point(0, 0);
            this.cxUserList1.Name = "cxUserList1";
            this.cxUserList1.Size = new System.Drawing.Size(1105, 679);
            this.cxUserList1.TabIndex = 0;
            // 
            // tpRoles
            // 
            this.tpRoles.Controls.Add(this.cxRoles);
            this.tpRoles.Name = "tpRoles";
            this.tpRoles.Size = new System.Drawing.Size(1105, 679);
            this.tpRoles.Text = "Роли";
            // 
            // cxRoles
            // 
            this.cxRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxRoles.Location = new System.Drawing.Point(0, 0);
            this.cxRoles.Name = "cxRoles";
            this.cxRoles.Size = new System.Drawing.Size(1105, 679);
            this.cxRoles.TabIndex = 0;
            // 
            // tpModules
            // 
            this.tpModules.Controls.Add(this.cxModules1);
            this.tpModules.Name = "tpModules";
            this.tpModules.Size = new System.Drawing.Size(1105, 679);
            this.tpModules.Text = "Подключенные модули";
            // 
            // cxModules1
            // 
            this.cxModules1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxModules1.Location = new System.Drawing.Point(0, 0);
            this.cxModules1.Name = "cxModules1";
            this.cxModules1.Size = new System.Drawing.Size(1105, 679);
            this.cxModules1.TabIndex = 0;
            // 
            // FxGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxGeneralSettings";
            this.Text = "Основные настройки";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.tpMainMenu.ResumeLayout(false);
            this.tpUsers.ResumeLayout(false);
            this.tpRoles.ResumeLayout(false);
            this.tpModules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage tpMainMenu;
        private DevExpress.XtraTab.XtraTabPage tpUsers;
        private DevExpress.XtraTab.XtraTabPage tpRoles;
        private DevExpress.XtraTab.XtraTabPage tpModules;
        private CxMenuTree _cxMenuEditor1;
        private CxModules cxModules1;
        private CxUserList cxUserList1;
        private CxRoles cxRoles;
    }
}