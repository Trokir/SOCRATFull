namespace Socrat.Log.Viewer
{
    partial class FxLogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxLogView));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRequery = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.cbMsgType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.deFinish = new DevExpress.XtraEditors.DateEdit();
            this.deStart = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gcLog = new DevExpress.XtraGrid.GridControl();
            this.gvLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMsgType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinish.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.48413F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.51587F));
            this.tableLayoutPanel.Controls.Add(this.layoutControl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.gcLog, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.treeList1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1103, 688);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // layoutControl
            // 
            this.tableLayoutPanel.SetColumnSpan(this.layoutControl, 2);
            this.layoutControl.Controls.Add(this.panelControl2);
            this.layoutControl.Controls.Add(this.panelControl1);
            this.layoutControl.Controls.Add(this.cbMsgType);
            this.layoutControl.Controls.Add(this.deFinish);
            this.layoutControl.Controls.Add(this.deStart);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(3, 3);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(502, 321, 916, 636);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1097, 73);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnRequery);
            this.panelControl2.Location = new System.Drawing.Point(466, 12);
            this.panelControl2.MaximumSize = new System.Drawing.Size(83, 42);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(83, 42);
            this.panelControl2.TabIndex = 9;
            // 
            // btnRequery
            // 
            this.btnRequery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRequery.ImageOptions.Image = global::Socrat.Log.Viewer.Properties.Resources.convert_32x32;
            this.btnRequery.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRequery.Location = new System.Drawing.Point(2, 2);
            this.btnRequery.MaximumSize = new System.Drawing.Size(80, 38);
            this.btnRequery.MinimumSize = new System.Drawing.Size(80, 38);
            this.btnRequery.Name = "btnRequery";
            this.btnRequery.Size = new System.Drawing.Size(80, 38);
            this.btnRequery.TabIndex = 0;
            this.btnRequery.Click += new System.EventHandler(this.btnRequery_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnFilter);
            this.panelControl1.Location = new System.Drawing.Point(380, 12);
            this.panelControl1.MaximumSize = new System.Drawing.Size(82, 42);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(82, 42);
            this.panelControl1.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.ImageOptions.Image = global::Socrat.Log.Viewer.Properties.Resources.crossdatasourcefiltering_32x32;
            this.btnFilter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFilter.Location = new System.Drawing.Point(2, 2);
            this.btnFilter.MaximumSize = new System.Drawing.Size(80, 38);
            this.btnFilter.MinimumSize = new System.Drawing.Size(80, 38);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(80, 38);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cbMsgType
            // 
            this.cbMsgType.Location = new System.Drawing.Point(92, 36);
            this.cbMsgType.Name = "cbMsgType";
            this.cbMsgType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMsgType.Properties.Items.AddRange(new object[] {
            "Все",
            "Ошибки",
            "Пердупреждения",
            "Информация"});
            this.cbMsgType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbMsgType.Size = new System.Drawing.Size(284, 20);
            this.cbMsgType.StyleController = this.layoutControl;
            this.cbMsgType.TabIndex = 7;
            this.cbMsgType.EditValueChanged += new System.EventHandler(this.cbMsgType_EditValueChanged);
            // 
            // deFinish
            // 
            this.deFinish.EditValue = null;
            this.deFinish.Location = new System.Drawing.Point(276, 12);
            this.deFinish.MaximumSize = new System.Drawing.Size(100, 20);
            this.deFinish.Name = "deFinish";
            this.deFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFinish.Size = new System.Drawing.Size(100, 20);
            this.deFinish.StyleController = this.layoutControl;
            this.deFinish.TabIndex = 6;
            this.deFinish.EditValueChanged += new System.EventHandler(this.deFinish_EditValueChanged);
            // 
            // deStart
            // 
            this.deStart.EditValue = null;
            this.deStart.Location = new System.Drawing.Point(92, 12);
            this.deStart.MaximumSize = new System.Drawing.Size(100, 20);
            this.deStart.Name = "deStart";
            this.deStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deStart.Size = new System.Drawing.Size(100, 20);
            this.deStart.StyleController = this.layoutControl;
            this.deStart.TabIndex = 5;
            this.deStart.EditValueChanged += new System.EventHandler(this.deStart_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1097, 73);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deStart;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(184, 24);
            this.layoutControlItem2.Text = "Дата с";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deFinish;
            this.layoutControlItem1.Location = new System.Drawing.Point(184, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(184, 24);
            this.layoutControlItem1.Text = "Дата по";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cbMsgType;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(368, 29);
            this.layoutControlItem3.Text = "Тип сообщений";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(541, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(536, 53);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.BestFitWeight = 86;
            this.layoutControlItem4.Control = this.panelControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(368, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(86, 53);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.BestFitWeight = 86;
            this.layoutControlItem5.Control = this.panelControl2;
            this.layoutControlItem5.Location = new System.Drawing.Point(454, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(87, 53);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // gcLog
            // 
            this.gcLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLog.Location = new System.Drawing.Point(250, 82);
            this.gcLog.MainView = this.gvLog;
            this.gcLog.Name = "gcLog";
            this.gcLog.Size = new System.Drawing.Size(850, 563);
            this.gcLog.TabIndex = 1;
            this.gcLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLog});
            // 
            // gvLog
            // 
            this.gvLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvLog.GridControl = this.gcLog;
            this.gvLog.Name = "gvLog";
            this.gvLog.OptionsBehavior.Editable = false;
            this.gvLog.OptionsBehavior.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "...";
            this.gridColumn1.FieldName = "LogIcon";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 62;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Время";
            this.gridColumn2.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "Date";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Сообщение";
            this.gridColumn3.FieldName = "Message";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 261;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Версия";
            this.gridColumn4.FieldName = "Version";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 852;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Тип";
            this.gridColumn5.FieldName = "LogType";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 88;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Заголовок";
            this.gridColumn6.FieldName = "Header";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 187;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Компьютер";
            this.gridColumn7.FieldName = "MachineName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 69;
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(3, 82);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(241, 563);
            this.treeList1.TabIndex = 2;
            // 
            // FxLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 688);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxLogView";
            this.Text = "Лог";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FxLogView_FormClosing);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbMsgType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFinish.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.ComboBoxEdit cbMsgType;
        private DevExpress.XtraEditors.DateEdit deFinish;
        private DevExpress.XtraEditors.DateEdit deStart;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.GridControl gcLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLog;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRequery;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
    }
}