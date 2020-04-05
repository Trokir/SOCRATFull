namespace Socrat.Startup
{
    partial class FxAbout
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
        protected void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxAbout));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.teConnect = new DevExpress.XtraEditors.TextEdit();
            this.meInfo = new DevExpress.XtraEditors.MemoEdit();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teConnect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel.BackgroundImage")));
            this.tableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanelButtons, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.meInfo, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.teConnect, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(652, 792);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelButtons.Controls.Add(this.btnClose, 1, 0);
            this.tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(3, 755);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(646, 34);
            this.tableLayoutPanelButtons.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.ImageOptions.Image = global::Socrat.Startup.Properties.Resources.apply_16x16;
            this.btnClose.Location = new System.Drawing.Point(529, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 28);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // teConnect
            // 
            this.teConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teConnect.Location = new System.Drawing.Point(10, 722);
            this.teConnect.Margin = new System.Windows.Forms.Padding(10);
            this.teConnect.Name = "teConnect";
            this.teConnect.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.teConnect.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teConnect.Properties.Appearance.Options.UseBackColor = true;
            this.teConnect.Properties.Appearance.Options.UseFont = true;
            this.teConnect.Size = new System.Drawing.Size(632, 22);
            this.teConnect.TabIndex = 2;
            // 
            // meInfo
            // 
            this.meInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meInfo.Location = new System.Drawing.Point(15, 95);
            this.meInfo.Margin = new System.Windows.Forms.Padding(15);
            this.meInfo.Name = "meInfo";
            this.meInfo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.meInfo.Properties.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.meInfo.Properties.Appearance.Options.UseBackColor = true;
            this.meInfo.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.meInfo.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.meInfo.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.Transparent;
            this.meInfo.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.meInfo.Properties.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.meInfo.Properties.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Transparent;
            this.meInfo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.meInfo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.meInfo.Size = new System.Drawing.Size(622, 602);
            this.meInfo.TabIndex = 1;
            // 
            // FxAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 792);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxAbout";
            this.Text = "О программе";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teConnect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.MemoEdit meInfo;
        private DevExpress.XtraEditors.TextEdit teConnect;
    }
}