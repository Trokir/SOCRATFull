namespace Socrat.References.Customer
{
    partial class FxCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxCustomers));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.tpAll = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tpLegals = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tpIP = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this._cxRefCustomers = new CxRefCustomers();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).BeginInit();
            this.tabPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this._cxRefCustomers, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tabPane, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1057, 716);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // _cxRefCustomers
            // 
            this._cxRefCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cxRefCustomers.Location = new System.Drawing.Point(3, 43);
            this._cxRefCustomers.Name = "_cxRefCustomers";
            this._cxRefCustomers.ReadOnly = false;
            this._cxRefCustomers.Size = new System.Drawing.Size(1051, 670);
            this._cxRefCustomers.TabIndex = 0;
            // 
            // tabPane
            // 
            this.tabPane.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.tabPane.Controls.Add(this.tpAll);
            this.tabPane.Controls.Add(this.tpLegals);
            this.tabPane.Controls.Add(this.tpIP);
            this.tabPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane.Location = new System.Drawing.Point(3, 3);
            this.tabPane.Name = "tabPane";
            this.tabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tpAll,
            this.tpLegals,
            this.tpIP});
            this.tabPane.RegularSize = new System.Drawing.Size(1051, 34);
            this.tabPane.SelectedPage = this.tpAll;
            this.tabPane.Size = new System.Drawing.Size(1051, 34);
            this.tabPane.TabIndex = 1;
            this.tabPane.Text = "tabPane1";
            this.tabPane.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabPane_SelectedPageChanged);
            // 
            // tpAll
            // 
            this.tpAll.Caption = "Все";
            this.tpAll.Name = "tpAll";
            this.tpAll.Size = new System.Drawing.Size(1051, 7);
            // 
            // tpLegals
            // 
            this.tpLegals.Caption = "Юр.лица";
            this.tpLegals.Name = "tpLegals";
            this.tpLegals.Size = new System.Drawing.Size(1051, 7);
            // 
            // tpIP
            // 
            this.tpIP.Caption = "  ИП  ";
            this.tpIP.Name = "tpIP";
            this.tpIP.Size = new System.Drawing.Size(1051, 7);
            // 
            // FxCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 716);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxCustomers";
            this.Text = "Контрагенты";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).EndInit();
            this.tabPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private CxRefCustomers _cxRefCustomers;
        private DevExpress.XtraBars.Navigation.TabPane tabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpAll;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpLegals;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpIP;
    }
}