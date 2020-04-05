using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace Socrat.Shape
{
    partial class FxShapeEditor
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxShapeEditor));
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridCmbShape = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.prpGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.tglToothVector = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.repSidesCountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnRotate = new DevExpress.XtraEditors.SimpleButton();
            this.pkbDraw = new DevExpress.XtraEditors.PictureEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutPicpure = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.triangleBindingSource = new System.Windows.Forms.BindingSource();
            this.fxShapeEditorBindingSource = new System.Windows.Forms.BindingSource();
            this.baseFigureBindingSource = new System.Windows.Forms.BindingSource();
            this.CatalogNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShapeImage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCmbShape.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglToothVector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSidesCountEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkbDraw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPicpure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fxShapeEditorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseFigureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // layoutControl
            // 
            this.layoutControl.Appearance.ControlDisabled.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.ControlDisabled.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.ControlDropDown.Options.UseFont = true;
            this.layoutControl.Appearance.ControlDropDownHeader.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.ControlDropDownHeader.Options.UseFont = true;
            this.layoutControl.Appearance.ControlFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.ControlFocused.Options.UseFont = true;
            this.layoutControl.Appearance.ControlReadOnly.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.ControlReadOnly.Options.UseFont = true;
            this.layoutControl.Appearance.DisabledLayoutGroupCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.DisabledLayoutGroupCaption.Options.UseFont = true;
            this.layoutControl.Appearance.DisabledLayoutItem.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.Appearance.DisabledLayoutItem.Options.UseFont = true;
            this.layoutControl.Controls.Add(this.gridCmbShape);
            this.layoutControl.Controls.Add(this.prpGrid);
            this.layoutControl.Controls.Add(this.btnClear);
            this.layoutControl.Controls.Add(this.btnRotate);
            this.layoutControl.Controls.Add(this.pkbDraw);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(743, 272, 650, 400);
            this.layoutControl.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControl.OptionsPrint.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControl.OptionsPrint.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(990, 742);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // gridCmbShape
            // 
            this.gridCmbShape.EditValue = "";
            this.gridCmbShape.Location = new System.Drawing.Point(12, 28);
            this.gridCmbShape.MenuManager = this.barManager;
            this.gridCmbShape.Name = "gridCmbShape";
            this.gridCmbShape.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gridCmbShape.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridCmbShape.Properties.Appearance.Options.UseFont = true;
            this.gridCmbShape.Properties.Appearance.Options.UseTextOptions = true;
            this.gridCmbShape.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCmbShape.Properties.Appearance.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.gridCmbShape.Properties.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.gridCmbShape.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridCmbShape.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridCmbShape.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gridCmbShape.Properties.AppearanceDisabled.Options.UseFont = true;
            this.gridCmbShape.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gridCmbShape.Properties.AppearanceDropDown.Options.UseFont = true;
            this.gridCmbShape.Properties.AppearanceFocused.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridCmbShape.Properties.AppearanceFocused.Options.UseFont = true;
            this.gridCmbShape.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridCmbShape.Properties.AppearanceReadOnly.Options.UseFont = true;
            serializableAppearanceObject4.FontStyleDelta = System.Drawing.FontStyle.Bold;
            serializableAppearanceObject4.Options.UseFont = true;
            this.gridCmbShape.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.gridCmbShape.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(0, 40);
            this.gridCmbShape.Properties.NullText = "Каталог фигур";
            this.gridCmbShape.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.gridCmbShape.Properties.PopupFormSize = new System.Drawing.Size(0, 600);
            this.gridCmbShape.Properties.PopupSizeable = false;
            this.gridCmbShape.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridCmbShape.Size = new System.Drawing.Size(326, 26);
            this.gridCmbShape.StyleController = this.layoutControl;
            this.gridCmbShape.TabIndex = 15;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.gridLookUpEdit1View.Appearance.ColumnFilterButton.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.gridLookUpEdit1View.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.EvenRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.EvenRow.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.Appearance.EvenRow.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.gridLookUpEdit1View.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14F);
            this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.GroupRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.GroupRow.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.OddRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.OddRow.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.Row.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridLookUpEdit1View.Appearance.SelectedRow.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.SelectedRow.Options.UseTextOptions = true;
            this.gridLookUpEdit1View.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridLookUpEdit1View.OptionsCustomization.AllowRowSizing = true;
            this.gridLookUpEdit1View.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridLookUpEdit1View.OptionsFilter.ColumnFilterPopupRowCount = 40;
            this.gridLookUpEdit1View.OptionsFind.AlwaysVisible = true;
            this.gridLookUpEdit1View.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gridLookUpEdit1View.OptionsFind.FindFilterColumns = "***";
            this.gridLookUpEdit1View.OptionsFind.FindNullPrompt = "Такая фигура отсутствует";
            this.gridLookUpEdit1View.OptionsFind.SearchInPreview = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.RowHeight = 100;
            // 
            // prpGrid
            // 
            this.prpGrid.DefaultEditors.AddRange(new DevExpress.XtraVerticalGrid.Rows.DefaultEditor[] {
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(typeof(bool), this.tglToothVector)});
            this.prpGrid.Location = new System.Drawing.Point(15, 77);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tglToothVector,
            this.repSidesCountEdit});
            this.prpGrid.Size = new System.Drawing.Size(478, 650);
            this.prpGrid.TabIndex = 10;
            // 
            // tglToothVector
            // 
            this.tglToothVector.AutoHeight = false;
            this.tglToothVector.Name = "tglToothVector";
            this.tglToothVector.OffText = "-";
            this.tglToothVector.OnText = "+";
            this.tglToothVector.Toggled += new System.EventHandler(this.tglToothVector_Toggled);
            // 
            // repSidesCountEdit
            // 
            this.repSidesCountEdit.AutoHeight = false;
            this.repSidesCountEdit.Name = "repSidesCountEdit";
            // 
            // btnClear
            // 
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(415, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 22);
            this.btnClear.StyleController = this.layoutControl;
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Обновить";
            // 
            // btnRotate
            // 
            this.btnRotate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRotate.ImageOptions.Image")));
            this.btnRotate.Location = new System.Drawing.Point(345, 15);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(60, 22);
            this.btnRotate.StyleController = this.layoutControl;
            this.btnRotate.TabIndex = 5;
            // 
            // pkbDraw
            // 
            this.pkbDraw.Location = new System.Drawing.Point(503, 31);
            this.pkbDraw.Name = "pkbDraw";
            this.pkbDraw.Properties.Caption.Offset = new System.Drawing.Point(1, 1);
            this.pkbDraw.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pkbDraw.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True;
            this.pkbDraw.Size = new System.Drawing.Size(472, 696);
            this.pkbDraw.StyleController = this.layoutControl;
            this.pkbDraw.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutPicpure,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.layoutControlItem6,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(990, 742);
            this.Root.TextVisible = false;
            // 
            // layoutPicpure
            // 
            this.layoutPicpure.Control = this.pkbDraw;
            this.layoutPicpure.Location = new System.Drawing.Point(488, 0);
            this.layoutPicpure.Name = "layoutPicpure";
            this.layoutPicpure.Size = new System.Drawing.Size(482, 722);
            this.layoutPicpure.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutPicpure.Text = "Поле редактирования";
            this.layoutPicpure.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutPicpure.TextSize = new System.Drawing.Size(192, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.prpGrid;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(488, 676);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(488, 676);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(488, 676);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.Text = "Свойства";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(192, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridCmbShape;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(330, 46);
            this.layoutControlItem1.Text = "Выбор фигуры по номеру из каталога";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(192, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClear;
            this.layoutControlItem6.Location = new System.Drawing.Point(400, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(88, 46);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRotate;
            this.layoutControlItem2.Location = new System.Drawing.Point(330, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(70, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // CatalogNumber
            // 
            this.CatalogNumber.Caption = "Номер в каталоге";
            this.CatalogNumber.Name = "CatalogNumber";
            this.CatalogNumber.OptionsColumn.AllowEdit = false;
            this.CatalogNumber.Visible = true;
            this.CatalogNumber.VisibleIndex = 0;
            // 
            // ShapeImage
            // 
            this.ShapeImage.Caption = "С";
            this.ShapeImage.Name = "ShapeImage";
            this.ShapeImage.Visible = true;
            this.ShapeImage.VisibleIndex = 1;
            // 
            // FxShapeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 779);
            this.Controls.Add(this.layoutControl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 811);
            this.Name = "FxShapeEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор фигур";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCmbShape.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglToothVector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSidesCountEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkbDraw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutPicpure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fxShapeEditorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseFigureBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraVerticalGrid.PropertyGridControl prpGrid;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnRotate;
        private DevExpress.XtraEditors.PictureEdit pkbDraw;
        private DevExpress.XtraLayout.LayoutControlItem layoutPicpure;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.BindingSource fxShapeEditorBindingSource;
        private System.Windows.Forms.BindingSource triangleBindingSource;
        private System.Windows.Forms.BindingSource baseFigureBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch tglToothVector;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSidesCountEdit;
        private GridLookUpEdit gridCmbShape;
        private GridView gridLookUpEdit1View;
        private LayoutControlItem layoutControlItem1;
        private GridColumn CatalogNumber;
        private GridColumn ShapeImage;
    }
}