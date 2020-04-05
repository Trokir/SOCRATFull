namespace Socrat.Module.Price
{
    partial class FxPriceCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxPriceCalculator));
            this.lcCalculationTest = new DevExpress.XtraLayout.LayoutControl();
            this.ceHeight = new DevExpress.XtraEditors.CalcEdit();
            this.ceWidth = new DevExpress.XtraEditors.CalcEdit();
            this.teSquare = new DevExpress.XtraEditors.TextEdit();
            this.tePrice = new DevExpress.XtraEditors.TextEdit();
            this.teSum = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciSquare = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciWidth = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciHeight = new DevExpress.XtraLayout.LayoutControlItem();
            this.ceQuantity = new DevExpress.XtraEditors.CalcEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCalculationTest)).BeginInit();
            this.lcCalculationTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSquare.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSquare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lcCalculationTest
            // 
            this.lcCalculationTest.Controls.Add(this.ceQuantity);
            this.lcCalculationTest.Controls.Add(this.ceHeight);
            this.lcCalculationTest.Controls.Add(this.ceWidth);
            this.lcCalculationTest.Controls.Add(this.teSquare);
            this.lcCalculationTest.Controls.Add(this.tePrice);
            this.lcCalculationTest.Controls.Add(this.teSum);
            this.lcCalculationTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcCalculationTest.Location = new System.Drawing.Point(0, 0);
            this.lcCalculationTest.Name = "lcCalculationTest";
            this.lcCalculationTest.Root = this.Root;
            this.lcCalculationTest.Size = new System.Drawing.Size(494, 450);
            this.lcCalculationTest.TabIndex = 5;
            this.lcCalculationTest.Text = "layoutControl1";
            // 
            // ceHeight
            // 
            this.ceHeight.Location = new System.Drawing.Point(15, 77);
            this.ceHeight.MenuManager = this.barManager;
            this.ceHeight.Name = "ceHeight";
            this.ceHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceHeight.Size = new System.Drawing.Size(464, 20);
            this.ceHeight.StyleController = this.lcCalculationTest;
            this.ceHeight.TabIndex = 6;
            this.ceHeight.ValueChanged += new System.EventHandler(this.DimensionsChanged);
            // 
            // ceWidth
            // 
            this.ceWidth.Location = new System.Drawing.Point(15, 31);
            this.ceWidth.MenuManager = this.barManager;
            this.ceWidth.Name = "ceWidth";
            this.ceWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceWidth.Size = new System.Drawing.Size(464, 20);
            this.ceWidth.StyleController = this.lcCalculationTest;
            this.ceWidth.TabIndex = 5;
            this.ceWidth.ValueChanged += new System.EventHandler(this.DimensionsChanged);
            // 
            // teSquare
            // 
            this.teSquare.EditValue = "0";
            this.teSquare.Enabled = false;
            this.teSquare.Location = new System.Drawing.Point(15, 123);
            this.teSquare.Name = "teSquare";
            this.teSquare.Size = new System.Drawing.Size(464, 20);
            this.teSquare.StyleController = this.lcCalculationTest;
            this.teSquare.TabIndex = 4;
            this.teSquare.TextChanged += new System.EventHandler(this.teSquare_TextChanged);
            // 
            // tePrice
            // 
            this.tePrice.EditValue = "0";
            this.tePrice.Enabled = false;
            this.tePrice.Location = new System.Drawing.Point(15, 169);
            this.tePrice.Name = "tePrice";
            this.tePrice.Size = new System.Drawing.Size(464, 20);
            this.tePrice.StyleController = this.lcCalculationTest;
            this.tePrice.TabIndex = 4;
            // 
            // teSum
            // 
            this.teSum.Enabled = false;
            this.teSum.Location = new System.Drawing.Point(15, 261);
            this.teSum.Name = "teSum";
            this.teSum.Size = new System.Drawing.Size(464, 20);
            this.teSum.StyleController = this.lcCalculationTest;
            this.teSum.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.lciSquare,
            this.lciPrice,
            this.lciSum,
            this.lciWidth,
            this.lciHeight,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(494, 450);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 276);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(474, 154);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciSquare
            // 
            this.lciSquare.Control = this.teSquare;
            this.lciSquare.CustomizationFormText = "Ширина";
            this.lciSquare.Location = new System.Drawing.Point(0, 92);
            this.lciSquare.Name = "lciSquare";
            this.lciSquare.Size = new System.Drawing.Size(474, 46);
            this.lciSquare.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciSquare.Text = "Площадь, кв.м.";
            this.lciSquare.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciSquare.TextSize = new System.Drawing.Size(130, 13);
            // 
            // lciPrice
            // 
            this.lciPrice.Control = this.tePrice;
            this.lciPrice.CustomizationFormText = "Ширина";
            this.lciPrice.Location = new System.Drawing.Point(0, 138);
            this.lciPrice.Name = "lciPrice";
            this.lciPrice.Size = new System.Drawing.Size(474, 46);
            this.lciPrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciPrice.Text = "Цена за ед. руб.";
            this.lciPrice.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciPrice.TextSize = new System.Drawing.Size(130, 13);
            // 
            // lciSum
            // 
            this.lciSum.Control = this.teSum;
            this.lciSum.CustomizationFormText = "Ширина";
            this.lciSum.Location = new System.Drawing.Point(0, 230);
            this.lciSum.Name = "lciSum";
            this.lciSum.Size = new System.Drawing.Size(474, 46);
            this.lciSum.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciSum.Text = "Цена за кол-во, руб.";
            this.lciSum.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciSum.TextSize = new System.Drawing.Size(130, 13);
            // 
            // lciWidth
            // 
            this.lciWidth.Control = this.ceWidth;
            this.lciWidth.Location = new System.Drawing.Point(0, 0);
            this.lciWidth.Name = "lciWidth";
            this.lciWidth.Size = new System.Drawing.Size(474, 46);
            this.lciWidth.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciWidth.Text = "Ширина, м.";
            this.lciWidth.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciWidth.TextSize = new System.Drawing.Size(130, 13);
            // 
            // lciHeight
            // 
            this.lciHeight.Control = this.ceHeight;
            this.lciHeight.Location = new System.Drawing.Point(0, 46);
            this.lciHeight.Name = "lciHeight";
            this.lciHeight.Size = new System.Drawing.Size(474, 46);
            this.lciHeight.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciHeight.Text = "Высота, м.";
            this.lciHeight.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciHeight.TextSize = new System.Drawing.Size(130, 13);
            // 
            // ceQuantity
            // 
            this.ceQuantity.Location = new System.Drawing.Point(15, 215);
            this.ceQuantity.MenuManager = this.barManager;
            this.ceQuantity.Name = "ceQuantity";
            this.ceQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceQuantity.Properties.Precision = 0;
            this.ceQuantity.Size = new System.Drawing.Size(464, 20);
            this.ceQuantity.StyleController = this.lcCalculationTest;
            this.ceQuantity.TabIndex = 7;
            this.ceQuantity.ValueChanged += new System.EventHandler(this.ceQuantity_ValueChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ceQuantity;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 184);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(474, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Количество изделий, шт.";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(130, 13);
            // 
            // FxCalculationTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(494, 487);
            this.Controls.Add(this.lcCalculationTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxCalculationTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тест расчета стоимости";
            this.Controls.SetChildIndex(this.lcCalculationTest, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcCalculationTest)).EndInit();
            this.lcCalculationTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSquare.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSquare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcCalculationTest;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit teSquare;
        private DevExpress.XtraLayout.LayoutControlItem lciSquare;
        private DevExpress.XtraEditors.TextEdit tePrice;
        private DevExpress.XtraLayout.LayoutControlItem lciPrice;
        private DevExpress.XtraEditors.TextEdit teSum;
        private DevExpress.XtraLayout.LayoutControlItem lciSum;
        private DevExpress.XtraEditors.CalcEdit ceHeight;
        private DevExpress.XtraEditors.CalcEdit ceWidth;
        private DevExpress.XtraLayout.LayoutControlItem lciWidth;
        private DevExpress.XtraLayout.LayoutControlItem lciHeight;
        private DevExpress.XtraEditors.CalcEdit ceQuantity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}