namespace Socrat.References.Params
{
    partial class FxParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxParams));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.gcParams = new DevExpress.XtraGrid.GridControl();
            this.gvParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lueDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.seOrderNumber = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.flowLayoutPanel);
            this.layoutControl.Controls.Add(this.gcParams);
            this.layoutControl.Controls.Add(this.btnSave);
            this.layoutControl.Controls.Add(this.btnClose);
            this.layoutControl.Controls.Add(this.lueDivision);
            this.layoutControl.Controls.Add(this.seOrderNumber);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1021, 701);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.btnAdd);
            this.flowLayoutPanel.Controls.Add(this.btnDelete);
            this.flowLayoutPanel.Location = new System.Drawing.Point(860, 46);
            this.flowLayoutPanel.MaximumSize = new System.Drawing.Size(134, 0);
            this.flowLayoutPanel.MinimumSize = new System.Drawing.Size(134, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(134, 601);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::Socrat.References.Properties.Resources.addfile_16x16;
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(3);
            this.btnAdd.Size = new System.Drawing.Size(129, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = global::Socrat.References.Properties.Resources.deletelist_16x16;
            this.btnDelete.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnDelete.Location = new System.Drawing.Point(3, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(3);
            this.btnDelete.Size = new System.Drawing.Size(129, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            // 
            // gcParams
            // 
            this.gcParams.Location = new System.Drawing.Point(24, 46);
            this.gcParams.MainView = this.gvParams;
            this.gcParams.Name = "gcParams";
            this.gcParams.Size = new System.Drawing.Size(832, 601);
            this.gcParams.TabIndex = 8;
            this.gcParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvParams});
            // 
            // gvParams
            // 
            this.gvParams.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategory,
            this.colAlias,
            this.colName,
            this.colValue});
            this.gvParams.GridControl = this.gcParams;
            this.gvParams.Name = "gvParams";
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Категория";
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            this.colCategory.Width = 114;
            // 
            // colAlias
            // 
            this.colAlias.Caption = "Алиас";
            this.colAlias.FieldName = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.Visible = true;
            this.colAlias.VisibleIndex = 1;
            this.colAlias.Width = 148;
            // 
            // colName
            // 
            this.colName.Caption = "Наименование";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 213;
            // 
            // colValue
            // 
            this.colValue.Caption = "Значение";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 3;
            this.colValue.Width = 306;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = global::Socrat.References.Properties.Resources.save_16x16;
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(765, 663);
            this.btnSave.MaximumSize = new System.Drawing.Size(120, 26);
            this.btnSave.MinimumSize = new System.Drawing.Size(120, 26);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 26);
            this.btnSave.StyleController = this.layoutControl;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.Image = global::Socrat.References.Properties.Resources.cancel_16x16;
            this.btnClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(889, 663);
            this.btnClose.MaximumSize = new System.Drawing.Size(120, 26);
            this.btnClose.MinimumSize = new System.Drawing.Size(120, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 26);
            this.btnClose.StyleController = this.layoutControl;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lueDivision
            // 
            this.lueDivision.Location = new System.Drawing.Point(154, 70);
            this.lueDivision.Name = "lueDivision";
            this.lueDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDivision.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameAlias", "Имя")});
            this.lueDivision.Properties.DisplayMember = "AliasName";
            this.lueDivision.Properties.ShowFooter = false;
            this.lueDivision.Properties.ShowHeader = false;
            this.lueDivision.Properties.ValueMember = "Id";
            this.lueDivision.Size = new System.Drawing.Size(202, 20);
            this.lueDivision.StyleController = this.layoutControl;
            this.lueDivision.TabIndex = 5;
            this.lueDivision.EditValueChanged += new System.EventHandler(this.lueDivision_EditValueChanged);
            // 
            // seOrderNumber
            // 
            this.seOrderNumber.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seOrderNumber.Location = new System.Drawing.Point(154, 46);
            this.seOrderNumber.Name = "seOrderNumber";
            this.seOrderNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seOrderNumber.Properties.DisplayFormat.FormatString = "N0";
            this.seOrderNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seOrderNumber.Properties.EditFormat.FormatString = "N0";
            this.seOrderNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.seOrderNumber.Size = new System.Drawing.Size(202, 20);
            this.seOrderNumber.StyleController = this.layoutControl;
            this.seOrderNumber.TabIndex = 4;
            this.seOrderNumber.EditValueChanged += new System.EventHandler(this.seOrderNumber_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1021, 701);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 651);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(753, 30);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClose;
            this.layoutControlItem3.Location = new System.Drawing.Point(877, 651);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(124, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnSave;
            this.layoutControlItem4.Location = new System.Drawing.Point(753, 651);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(124, 30);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1001, 651);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(977, 605);
            this.layoutControlGroup3.Text = "Все";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcParams;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(836, 605);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.flowLayoutPanel;
            this.layoutControlItem6.Location = new System.Drawing.Point(836, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(141, 605);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(977, 605);
            this.layoutControlGroup2.Text = "Основные";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueDivision;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(336, 24);
            this.layoutControlItem2.Text = "Текущee подразделение";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(127, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.seOrderNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(336, 24);
            this.layoutControlItem1.Text = "Номер заказа с";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(127, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(336, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(641, 605);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(336, 557);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FxParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 701);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxParams";
            this.Text = "Параметры приложения";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraEditors.SpinEdit seOrderNumber;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gcParams;
        private DevExpress.XtraGrid.Views.Grid.GridView gvParams;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LookUpEdit lueDivision;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}