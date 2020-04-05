namespace Socrat.References.Contract
{
    partial class FxContracts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxContracts));
            this.tabPane = new DevExpress.XtraBars.Navigation.TabPane();
            this.tpAll = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tpCustomers = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tpSupplier = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pcList = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).BeginInit();
            this.tabPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPane
            // 
            this.tabPane.AllowCollapse = DevExpress.Utils.DefaultBoolean.Default;
            this.tabPane.Controls.Add(this.tpAll);
            this.tabPane.Controls.Add(this.tpCustomers);
            this.tabPane.Controls.Add(this.tpSupplier);
            this.tabPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPane.Location = new System.Drawing.Point(0, 0);
            this.tabPane.Name = "tabPane";
            this.tabPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tpAll,
            this.tpSupplier,
            this.tpCustomers});
            this.tabPane.RegularSize = new System.Drawing.Size(1060, 37);
            this.tabPane.SelectedPage = this.tpSupplier;
            this.tabPane.Size = new System.Drawing.Size(1060, 37);
            this.tabPane.TabIndex = 0;
            this.tabPane.Text = "tabPane1";
            this.tabPane.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabPane_SelectedPageChanged);
            // 
            // tpAll
            // 
            this.tpAll.Caption = "Все";
            this.tpAll.Name = "tpAll";
            this.tpAll.Size = new System.Drawing.Size(1060, 10);
            // 
            // tpCustomers
            // 
            this.tpCustomers.Caption = "Покупатели";
            this.tpCustomers.Name = "tpCustomers";
            this.tpCustomers.Size = new System.Drawing.Size(1060, 37);
            // 
            // tpSupplier
            // 
            this.tpSupplier.Caption = "Поставщики";
            this.tpSupplier.Name = "tpSupplier";
            this.tpSupplier.Size = new System.Drawing.Size(1060, 10);
            // 
            // pcList
            // 
            this.pcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcList.Location = new System.Drawing.Point(0, 37);
            this.pcList.Name = "pcList";
            this.pcList.Size = new System.Drawing.Size(1060, 663);
            this.pcList.TabIndex = 1;
            // 
            // FxContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 700);
            this.Controls.Add(this.pcList);
            this.Controls.Add(this.tabPane);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxContracts";
            this.Text = "Договоры";
            ((System.ComponentModel.ISupportInitialize)(this.tabPane)).EndInit();
            this.tabPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPane;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpAll;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpSupplier;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpCustomers;
        private DevExpress.XtraEditors.PanelControl pcList;
    }
}