namespace Socrat.Module.Price.v1
{
    partial class FxFormTypeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxFormTypeEdit));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.cxShapes = new Socrat.Module.Price.v1.CxShapes();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciShapes = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShapes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.labelControl1);
            this.lcMain.Controls.Add(this.cxShapes);
            this.lcMain.Controls.Add(this.teName);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(389, 647);
            this.lcMain.TabIndex = 5;
            this.lcMain.Text = "layoutControl1";
            // 
            // cxShapes
            // 
            this.cxShapes.ActionPaneVisible = false;
            this.cxShapes.BottomPaneVisible = false;
            this.cxShapes.CanAdd = false;
            this.cxShapes.CanDelete = false;
            this.cxShapes.CanOpen = false;
            this.cxShapes.DependedSaving = false;
            this.cxShapes.ExternalFilterExp = null;
            this.cxShapes.ExternalFilterExp2 = null;
            this.cxShapes.FilterVisible = false;
            this.cxShapes.FormType = null;
            this.cxShapes.GroupPaneVisible = false;
            this.cxShapes.HeaderText = "Табличная форма";
            this.cxShapes.Location = new System.Drawing.Point(12, 74);
            this.cxShapes.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cxShapes.MultiSelect = false;
            this.cxShapes.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.cxShapes.Name = "cxShapes";
            this.cxShapes.ReadOnly = false;
            this.cxShapes.RestoreUserGridSettings = false;
            this.cxShapes.RightPaneVisible = false;
            this.cxShapes.RowHighlightingExp = null;
            this.cxShapes.SearchPaneVisible = false;
            this.cxShapes.SelectedItem = null;
            this.cxShapes.Size = new System.Drawing.Size(365, 531);
            this.cxShapes.SourceItems = null;
            this.cxShapes.TabIndex = 5;
            this.cxShapes.TopPaneVisible = false;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(15, 31);
            this.teName.MenuManager = this.barManager;
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(359, 20);
            this.teName.StyleController = this.lcMain;
            this.teName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciName,
            this.lciShapes,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(389, 647);
            this.Root.TextVisible = false;
            // 
            // lciName
            // 
            this.lciName.Control = this.teName;
            this.lciName.Location = new System.Drawing.Point(0, 0);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(369, 46);
            this.lciName.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciName.Text = "Наименование:";
            this.lciName.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciName.TextSize = new System.Drawing.Size(148, 13);
            // 
            // lciShapes
            // 
            this.lciShapes.Control = this.cxShapes;
            this.lciShapes.Location = new System.Drawing.Point(0, 46);
            this.lciShapes.Name = "lciShapes";
            this.lciShapes.Size = new System.Drawing.Size(369, 551);
            this.lciShapes.Text = "Связанные фигуры каталога";
            this.lciShapes.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciShapes.TextSize = new System.Drawing.Size(148, 13);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(12, 609);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelControl1.Size = new System.Drawing.Size(365, 26);
            this.labelControl1.StyleController = this.lcMain;
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Подкрашенным фоном выделены каталожные фигуры не привязанные ни к одному обобщенн" +
    "ому типу формы";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.labelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 597);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(369, 30);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FxFormTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(389, 684);
            this.Controls.Add(this.lcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxFormTypeEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Обобщенный тип формы";
            this.Controls.SetChildIndex(this.lcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciShapes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private CxShapes cxShapes;
        private DevExpress.XtraLayout.LayoutControlItem lciShapes;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}