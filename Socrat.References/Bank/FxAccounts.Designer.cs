namespace Socrat.References.Bank
{
    partial class FxAccounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxAccounts));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tpAll = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.cxAccounts = new Socrat.UI.Core.CxTableList();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.tabPane1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.cxAccounts, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.097561F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.90244F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(857, 574);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tpAll);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(3, 3);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tpAll});
            this.tabPane1.RegularSize = new System.Drawing.Size(851, 28);
            this.tabPane1.SelectedPage = this.tpAll;
            this.tabPane1.Size = new System.Drawing.Size(851, 28);
            this.tabPane1.TabIndex = 1;
            this.tabPane1.Text = "Все";
            // 
            // tpAll
            // 
            this.tpAll.BackgroundPadding = new System.Windows.Forms.Padding(2);
            this.tpAll.Caption = "Все";
            this.tpAll.Margin = new System.Windows.Forms.Padding(0);
            this.tpAll.Name = "tpAll";
            this.tpAll.Size = new System.Drawing.Size(851, 1);
            // 
            // cxAccounts
            // 
            this.cxAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cxAccounts.FilterVisible = true;
            this.cxAccounts.Location = new System.Drawing.Point(3, 37);
            this.cxAccounts.MultiSelect = false;
            this.cxAccounts.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.cxAccounts.Name = "cxAccounts";
            this.cxAccounts.ReadOnly = false;
            this.cxAccounts.Size = new System.Drawing.Size(851, 534);
            this.cxAccounts.TabIndex = 2;
            // 
            // FxAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 574);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxAccounts";
            this.Text = "Справочник счетов";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpAll;
        private UI.Core.CxTableList  cxAccounts;
    }
}