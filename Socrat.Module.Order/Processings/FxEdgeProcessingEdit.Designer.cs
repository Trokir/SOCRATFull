namespace Socrat.Module.Order.Processings
{
    partial class FxEdgeProcessingEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxEdgeProcessingEdit));
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lcName = new DevExpress.XtraEditors.LabelControl();
            this.peShape = new DevExpress.XtraEditors.PictureEdit();
            this.pgOutcrop = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.pgSizes = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peShape.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgOutcrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgSizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lcName);
            this.layoutControl.Controls.Add(this.peShape);
            this.layoutControl.Controls.Add(this.pgOutcrop);
            this.layoutControl.Controls.Add(this.pgSizes);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.Root;
            this.layoutControl.Size = new System.Drawing.Size(719, 607);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lcName
            // 
            this.lcName.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lcName.Appearance.Options.UseFont = true;
            this.lcName.Location = new System.Drawing.Point(12, 12);
            this.lcName.Name = "lcName";
            this.lcName.Size = new System.Drawing.Size(264, 23);
            this.lcName.StyleController = this.layoutControl;
            this.lcName.TabIndex = 7;
            this.lcName.Text = "Название фигуры                  ";
            // 
            // peShape
            // 
            this.peShape.Location = new System.Drawing.Point(280, 12);
            this.peShape.MenuManager = this.barManager;
            this.peShape.Name = "peShape";
            this.peShape.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peShape.Size = new System.Drawing.Size(427, 583);
            this.peShape.StyleController = this.layoutControl;
            this.peShape.TabIndex = 6;
            // 
            // pgOutcrop
            // 
            this.pgOutcrop.Location = new System.Drawing.Point(12, 326);
            this.pgOutcrop.Name = "pgOutcrop";
            this.pgOutcrop.Size = new System.Drawing.Size(264, 269);
            this.pgOutcrop.TabIndex = 5;
            this.pgOutcrop.CustomPropertyDescriptors += new DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventHandler(this.pgOutcrop_CustomPropertyDescriptors);
            // 
            // pgSizes
            // 
            this.pgSizes.Location = new System.Drawing.Point(12, 55);
            this.pgSizes.Name = "pgSizes";
            this.pgSizes.Size = new System.Drawing.Size(264, 251);
            this.pgSizes.TabIndex = 4;
            this.pgSizes.CustomPropertyDescriptors += new DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventHandler(this.pgSizes_CustomPropertyDescriptors);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(719, 607);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pgSizes;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(268, 271);
            this.layoutControlItem1.Text = "Габаритные размеры";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(108, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pgOutcrop;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 298);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(268, 289);
            this.layoutControlItem2.Text = "Стороны (отступ)";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(108, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.peShape;
            this.layoutControlItem3.Location = new System.Drawing.Point(268, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(431, 587);
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lcName;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(268, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // FxEdgeProcessingEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 644);
            this.Controls.Add(this.layoutControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxEdgeProcessingEdit";
            this.Text = "Ввод отступа обработки кромки";
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peShape.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgOutcrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgSizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PictureEdit peShape;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgOutcrop;
        private DevExpress.XtraVerticalGrid.PropertyGridControl pgSizes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl lcName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}