namespace Socrat.Module.Connectors.Lisec.UI
{
    partial class FxExportList<T>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxExportList<T>));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcPositionRuler = new DevExpress.XtraEditors.LabelControl();
            this.pcControls = new DevExpress.XtraEditors.PanelControl();
            this.cbeExportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbeSortType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlData = new DevExpress.XtraTreeList.TreeList();
            this.pcButtons = new DevExpress.XtraEditors.PanelControl();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciButtons = new DevExpress.XtraLayout.LayoutControlItem();
            this.tcgData = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgData = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciData = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cmsPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcPreview = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcControls)).BeginInit();
            this.pcControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeExportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeSortType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).BeginInit();
            this.pcButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            this.cmsPreview.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.xtraScrollableControl1);
            this.lcMain.Controls.Add(this.pcControls);
            this.lcMain.Controls.Add(this.tlData);
            this.lcMain.Controls.Add(this.pcButtons);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1160, 198, 650, 400);
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(836, 578);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcPositionRuler
            // 
            this.lcPositionRuler.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lcPositionRuler.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lcPositionRuler.Appearance.Options.UseBackColor = true;
            this.lcPositionRuler.Appearance.Options.UseFont = true;
            this.lcPositionRuler.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lcPositionRuler.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lcPositionRuler.Location = new System.Drawing.Point(-2, 0);
            this.lcPositionRuler.Name = "lcPositionRuler";
            this.lcPositionRuler.Size = new System.Drawing.Size(802, 18);
            this.lcPositionRuler.TabIndex = 9;
            this.lcPositionRuler.Text = "........10........20........30........40........50........60........70........80." +
    ".......90.......100";
            // 
            // pcControls
            // 
            this.pcControls.Controls.Add(this.cbeExportType);
            this.pcControls.Controls.Add(this.cbeSortType);
            this.pcControls.Controls.Add(this.labelControl2);
            this.pcControls.Controls.Add(this.labelControl1);
            this.pcControls.Location = new System.Drawing.Point(14, 36);
            this.pcControls.Name = "pcControls";
            this.pcControls.Size = new System.Drawing.Size(804, 26);
            this.pcControls.TabIndex = 8;
            // 
            // cbeExportType
            // 
            this.cbeExportType.Enabled = false;
            this.cbeExportType.Location = new System.Drawing.Point(94, 2);
            this.cbeExportType.Name = "cbeExportType";
            this.cbeExportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeExportType.Size = new System.Drawing.Size(160, 20);
            this.cbeExportType.TabIndex = 3;
            // 
            // cbeSortType
            // 
            this.cbeSortType.Enabled = false;
            this.cbeSortType.Location = new System.Drawing.Point(350, 2);
            this.cbeSortType.Name = "cbeSortType";
            this.cbeSortType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeSortType.Size = new System.Drawing.Size(100, 20);
            this.cbeSortType.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(260, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Тип сортировки:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Что выгружаем:";
            // 
            // tlData
            // 
            this.tlData.Location = new System.Drawing.Point(14, 66);
            this.tlData.Name = "tlData";
            this.tlData.Size = new System.Drawing.Size(804, 459);
            this.tlData.TabIndex = 5;
            // 
            // pcButtons
            // 
            this.pcButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcButtons.Controls.Add(this.sbCancel);
            this.pcButtons.Controls.Add(this.sbExport);
            this.pcButtons.Location = new System.Drawing.Point(2, 545);
            this.pcButtons.Name = "pcButtons";
            this.pcButtons.Size = new System.Drawing.Size(832, 31);
            this.pcButtons.TabIndex = 4;
            // 
            // sbCancel
            // 
            this.sbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbCancel.Location = new System.Drawing.Point(622, 5);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(99, 23);
            this.sbCancel.TabIndex = 1;
            this.sbCancel.Text = "Отмена";
            // 
            // sbExport
            // 
            this.sbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            
            this.sbExport.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.sbExport.Location = new System.Drawing.Point(727, 5);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(99, 23);
            this.sbExport.TabIndex = 0;
            this.sbExport.Text = "Выгрузить";
            this.sbExport.Click += new System.EventHandler(this.sbExport_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciButtons,
            this.tcgData});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(836, 578);
            this.Root.TextVisible = false;
            // 
            // lciButtons
            // 
            this.lciButtons.Control = this.pcButtons;
            this.lciButtons.Location = new System.Drawing.Point(0, 543);
            this.lciButtons.MinSize = new System.Drawing.Size(5, 5);
            this.lciButtons.Name = "lciButtons";
            this.lciButtons.Size = new System.Drawing.Size(836, 35);
            this.lciButtons.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciButtons.TextSize = new System.Drawing.Size(0, 0);
            this.lciButtons.TextVisible = false;
            // 
            // tcgData
            // 
            this.tcgData.Location = new System.Drawing.Point(0, 0);
            this.tcgData.Name = "tcgData";
            this.tcgData.SelectedTabPage = this.layoutControlGroup2;
            this.tcgData.Size = new System.Drawing.Size(836, 543);
            this.tcgData.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.tcgData.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgData,
            this.layoutControlGroup2});
            // 
            // lcgData
            // 
            this.lcgData.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciData,
            this.layoutControlItem2});
            this.lcgData.Location = new System.Drawing.Point(0, 0);
            this.lcgData.Name = "lcgData";
            this.lcgData.Size = new System.Drawing.Size(808, 493);
            this.lcgData.Text = "Данные для выгрузки";
            // 
            // lciData
            // 
            this.lciData.Control = this.tlData;
            this.lciData.Location = new System.Drawing.Point(0, 30);
            this.lciData.Name = "lciData";
            this.lciData.Size = new System.Drawing.Size(808, 463);
            this.lciData.TextSize = new System.Drawing.Size(0, 0);
            this.lciData.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pcControls;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(808, 30);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "lcgExportPreview";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(808, 493);
            this.layoutControlGroup2.Text = "Предпросмотр экспорта";
            // 
            // cmsPreview
            // 
            this.cmsPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy});
            this.cmsPreview.Name = "contextMenuStrip1";
            this.cmsPreview.Size = new System.Drawing.Size(182, 26);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiCopy.Size = new System.Drawing.Size(181, 22);
            this.tsmiCopy.Text = "&Копировать";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.ContextMenuStrip = this.cmsPreview;
            this.xtraScrollableControl1.Controls.Add(this.lcPreview);
            this.xtraScrollableControl1.Controls.Add(this.lcPositionRuler);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(14, 36);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(804, 489);
            this.xtraScrollableControl1.TabIndex = 10;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.xtraScrollableControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(808, 493);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lcPreview
            // 
            this.lcPreview.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lcPreview.Appearance.Options.UseFont = true;
            this.lcPreview.Appearance.Options.UseTextOptions = true;
            this.lcPreview.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lcPreview.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lcPreview.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.lcPreview.Location = new System.Drawing.Point(2, 21);
            this.lcPreview.Name = "lcPreview";
            this.lcPreview.Size = new System.Drawing.Size(104, 16);
            this.lcPreview.TabIndex = 10;
            this.lcPreview.Text = "labelControl3";
            // 
            // FxExportList
            // 
            this.AcceptButton = this.sbCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 578);
            this.Controls.Add(this.lcMain);
            this.KeyPreview = true;
            this.Name = "FxExportList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выгрузка в GPS Opt";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcControls)).EndInit();
            this.pcControls.ResumeLayout(false);
            this.pcControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeExportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeSortType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcButtons)).EndInit();
            this.pcButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            this.cmsPreview.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraTreeList.TreeList tlData;
        private DevExpress.XtraEditors.PanelControl pcButtons;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.SimpleButton sbExport;
        private DevExpress.XtraLayout.LayoutControlItem lciButtons;
        private DevExpress.XtraLayout.TabbedControlGroup tcgData;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup lcgData;
        private DevExpress.XtraLayout.LayoutControlItem lciData;
        private DevExpress.XtraEditors.PanelControl pcControls;
        private DevExpress.XtraEditors.ComboBoxEdit cbeExportType;
        private DevExpress.XtraEditors.ComboBoxEdit cbeSortType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.ContextMenuStrip cmsPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private DevExpress.XtraEditors.LabelControl lcPositionRuler;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.LabelControl lcPreview;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}