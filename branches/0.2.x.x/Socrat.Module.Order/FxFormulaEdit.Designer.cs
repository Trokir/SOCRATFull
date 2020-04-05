namespace Socrat.Module.Order
{
    partial class FxFormulaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxFormulaEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnParseFormula = new DevExpress.XtraEditors.SimpleButton();
            this.teFormulaStr = new DevExpress.XtraEditors.TextEdit();
            this.tlFormula = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pcDrow = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pmTree = new DevExpress.XtraBars.PopupMenu(this.components);
            this.biSetMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.biChangeTo = new DevExpress.XtraBars.BarSubItem();
            this.biCopyToNextLayer = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.biSetByStrFormula = new DevExpress.XtraBars.BarButtonItem();
            this.pcProperties = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teFormulaStr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.panelControl2);
            this.layoutControl.Controls.Add(this.pcProperties);
            this.layoutControl.Controls.Add(this.btnParseFormula);
            this.layoutControl.Controls.Add(this.teFormulaStr);
            this.layoutControl.Controls.Add(this.tlFormula);
            this.layoutControl.Controls.Add(this.pcDrow);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(60, 256, 650, 400);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1043, 658);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnParseFormula
            // 
            this.btnParseFormula.ImageOptions.Image = global::Socrat.Module.Order.Properties.Resources.forward_16x16;
            this.btnParseFormula.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnParseFormula.Location = new System.Drawing.Point(955, 12);
            this.btnParseFormula.Name = "btnParseFormula";
            this.btnParseFormula.Size = new System.Drawing.Size(76, 30);
            this.btnParseFormula.StyleController = this.layoutControl;
            this.btnParseFormula.TabIndex = 8;
            this.btnParseFormula.Text = " ->";
            this.btnParseFormula.Click += new System.EventHandler(this.btnParseFormula_Click);
            // 
            // teFormulaStr
            // 
            this.teFormulaStr.Location = new System.Drawing.Point(12, 12);
            this.teFormulaStr.MenuManager = this.barManager;
            this.teFormulaStr.Name = "teFormulaStr";
            this.teFormulaStr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teFormulaStr.Properties.Appearance.Options.UseFont = true;
            this.teFormulaStr.Size = new System.Drawing.Size(939, 30);
            this.teFormulaStr.StyleController = this.layoutControl;
            this.teFormulaStr.TabIndex = 7;
            this.teFormulaStr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.teFormulaStr_KeyUp);
            // 
            // tlFormula
            // 
            this.tlFormula.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.tlFormula.Location = new System.Drawing.Point(12, 314);
            this.tlFormula.Name = "tlFormula";
            this.tlFormula.OptionsBehavior.Editable = false;
            this.tlFormula.OptionsBehavior.ReadOnly = true;
            this.tlFormula.OptionsView.ShowFirstLines = true;
            this.tlFormula.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.tlFormula.Size = new System.Drawing.Size(291, 308);
            this.tlFormula.TabIndex = 5;
            this.tlFormula.ViewStyle = DevExpress.XtraTreeList.TreeListViewStyle.TreeView;
            this.tlFormula.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlFormula_FocusedNodeChanged);
            this.tlFormula.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlFormula_MouseDown);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // pcDrow
            // 
            this.pcDrow.Location = new System.Drawing.Point(12, 46);
            this.pcDrow.Name = "pcDrow";
            this.pcDrow.Size = new System.Drawing.Size(291, 264);
            this.pcDrow.TabIndex = 4;
            this.pcDrow.Paint += new System.Windows.Forms.PaintEventHandler(this.pcDrow_Paint);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1043, 658);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pcDrow;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(295, 268);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tlFormula;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 302);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(295, 312);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teFormulaStr;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(943, 34);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnParseFormula;
            this.layoutControlItem3.Location = new System.Drawing.Point(943, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(80, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(80, 34);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // pmTree
            // 
            this.pmTree.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biSetMaterial),
            new DevExpress.XtraBars.LinkPersistInfo(this.biChangeTo),
            new DevExpress.XtraBars.LinkPersistInfo(this.biCopyToNextLayer),
            new DevExpress.XtraBars.LinkPersistInfo(this.biDelete, true)});
            this.pmTree.Manager = this.barManager;
            this.pmTree.Name = "pmTree";
            this.pmTree.BeforePopup += new System.ComponentModel.CancelEventHandler(this.pmTree_BeforePopup);
            // 
            // biSetMaterial
            // 
            this.biSetMaterial.Caption = "Выбрать";
            this.biSetMaterial.Id = 2;
            this.biSetMaterial.Name = "biSetMaterial";
            this.biSetMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biSetMaterial_ItemClick);
            // 
            // biChangeTo
            // 
            this.biChangeTo.Caption = "Заменить на";
            this.biChangeTo.Id = 3;
            this.biChangeTo.Name = "biChangeTo";
            // 
            // biCopyToNextLayer
            // 
            this.biCopyToNextLayer.Caption = "Копировать следующий слой";
            this.biCopyToNextLayer.Id = 4;
            this.biCopyToNextLayer.Name = "biCopyToNextLayer";
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Удалить";
            this.biDelete.Id = 6;
            this.biDelete.Name = "biDelete";
            // 
            // biSetByStrFormula
            // 
            this.biSetByStrFormula.Caption = "Задать изделие по формуле";
            this.biSetByStrFormula.Id = 5;
            this.biSetByStrFormula.Name = "biSetByStrFormula";
            // 
            // pcProperties
            // 
            this.pcProperties.Location = new System.Drawing.Point(307, 46);
            this.pcProperties.Name = "pcProperties";
            this.pcProperties.Size = new System.Drawing.Size(724, 576);
            this.pcProperties.TabIndex = 9;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.pcProperties;
            this.layoutControlItem5.Location = new System.Drawing.Point(295, 34);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(728, 580);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Location = new System.Drawing.Point(12, 626);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1019, 20);
            this.panelControl2.TabIndex = 10;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.panelControl2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 614);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(1023, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // FxFormulaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 695);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxFormulaEdit";
            this.Text = "Формула изделия";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teFormulaStr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTreeList.TreeList tlFormula;
        private DevExpress.XtraEditors.PanelControl pcDrow;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.TextEdit teFormulaStr;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnParseFormula;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.PopupMenu pmTree;
        private DevExpress.XtraBars.BarButtonItem biSetMaterial;
        private DevExpress.XtraBars.BarSubItem biChangeTo;
        private DevExpress.XtraBars.BarButtonItem biCopyToNextLayer;
        private DevExpress.XtraBars.BarButtonItem biSetByStrFormula;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl pcProperties;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}