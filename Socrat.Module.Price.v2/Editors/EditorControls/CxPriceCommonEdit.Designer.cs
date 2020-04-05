namespace Socrat.Module.Price
{
    partial class CxPriceCommonEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.beCoworkerPosition = new DevExpress.XtraEditors.ButtonEdit();
            this.beCustomer = new DevExpress.XtraEditors.ButtonEdit();
            this.teName = new DevExpress.XtraEditors.TextEdit();
            this.beDivision = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.PriceNameItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.CustomerSelectionItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.DivisionSelectionItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCoworkerPosition = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beCoworkerPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNameItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSelectionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionSelectionItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCoworkerPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.beCoworkerPosition);
            this.layoutControl1.Controls.Add(this.beCustomer);
            this.layoutControl1.Controls.Add(this.teName);
            this.layoutControl1.Controls.Add(this.beDivision);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(564, 114);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // beCoworkerPosition
            // 
            this.beCoworkerPosition.Location = new System.Drawing.Point(381, 67);
            this.beCoworkerPosition.Name = "beCoworkerPosition";
            this.beCoworkerPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCoworkerPosition.Size = new System.Drawing.Size(178, 20);
            this.beCoworkerPosition.StyleController = this.layoutControl1;
            this.beCoworkerPosition.TabIndex = 7;
            // 
            // beCustomer
            // 
            this.beCustomer.Location = new System.Drawing.Point(5, 67);
            this.beCustomer.Name = "beCustomer";
            this.beCustomer.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Gray;
            this.beCustomer.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.beCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCustomer.Size = new System.Drawing.Size(178, 20);
            this.beCustomer.StyleController = this.layoutControl1;
            this.beCustomer.TabIndex = 5;
            this.beCustomer.Visible = false;
            // 
            // teName
            // 
            this.teName.Location = new System.Drawing.Point(5, 21);
            this.teName.Name = "teName";
            this.teName.Size = new System.Drawing.Size(554, 20);
            this.teName.StyleController = this.layoutControl1;
            this.teName.TabIndex = 4;
            // 
            // beDivision
            // 
            this.beDivision.Location = new System.Drawing.Point(193, 67);
            this.beDivision.Name = "beDivision";
            this.beDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beDivision.Size = new System.Drawing.Size(178, 20);
            this.beDivision.StyleController = this.layoutControl1;
            this.beDivision.TabIndex = 6;
            this.beDivision.EditValueChanged += new System.EventHandler(this.beDivision_EditValueChanged);
            this.beDivision.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.beDivision_EditValueChanging);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.PriceNameItem,
            this.CustomerSelectionItem,
            this.DivisionSelectionItem,
            this.lciCoworkerPosition});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(564, 114);
            this.Root.TextVisible = false;
            // 
            // PriceNameItem
            // 
            this.PriceNameItem.Control = this.teName;
            this.PriceNameItem.CustomizationFormText = "Наименование:";
            this.PriceNameItem.Location = new System.Drawing.Point(0, 0);
            this.PriceNameItem.Name = "PriceNameItem";
            this.PriceNameItem.Size = new System.Drawing.Size(564, 46);
            this.PriceNameItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.PriceNameItem.Text = "Наименование:";
            this.PriceNameItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.PriceNameItem.TextSize = new System.Drawing.Size(155, 13);
            // 
            // CustomerSelectionItem
            // 
            this.CustomerSelectionItem.Control = this.beCustomer;
            this.CustomerSelectionItem.CustomizationFormText = "Контрагент:";
            this.CustomerSelectionItem.Location = new System.Drawing.Point(0, 46);
            this.CustomerSelectionItem.Name = "CustomerSelectionItem";
            this.CustomerSelectionItem.Size = new System.Drawing.Size(188, 68);
            this.CustomerSelectionItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.CustomerSelectionItem.Text = "Контрагент:";
            this.CustomerSelectionItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.CustomerSelectionItem.TextSize = new System.Drawing.Size(155, 13);
            // 
            // DivisionSelectionItem
            // 
            this.DivisionSelectionItem.Control = this.beDivision;
            this.DivisionSelectionItem.CustomizationFormText = "Подразделение:";
            this.DivisionSelectionItem.Location = new System.Drawing.Point(188, 46);
            this.DivisionSelectionItem.Name = "DivisionSelectionItem";
            this.DivisionSelectionItem.Size = new System.Drawing.Size(188, 68);
            this.DivisionSelectionItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.DivisionSelectionItem.Text = "Производственная площадка:";
            this.DivisionSelectionItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.DivisionSelectionItem.TextSize = new System.Drawing.Size(155, 13);
            // 
            // lciCoworkerPosition
            // 
            this.lciCoworkerPosition.Control = this.beCoworkerPosition;
            this.lciCoworkerPosition.Location = new System.Drawing.Point(376, 46);
            this.lciCoworkerPosition.Name = "lciCoworkerPosition";
            this.lciCoworkerPosition.Size = new System.Drawing.Size(188, 68);
            this.lciCoworkerPosition.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciCoworkerPosition.Text = "Ответственный:";
            this.lciCoworkerPosition.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciCoworkerPosition.TextSize = new System.Drawing.Size(155, 13);
            // 
            // CxPriceCommonEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "CxPriceCommonEdit";
            this.Size = new System.Drawing.Size(564, 114);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beCoworkerPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNameItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSelectionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionSelectionItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCoworkerPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ButtonEdit beCustomer;
        private DevExpress.XtraLayout.LayoutControlItem CustomerSelectionItem;
        private DevExpress.XtraEditors.TextEdit teName;
        private DevExpress.XtraLayout.LayoutControlItem PriceNameItem;
        private DevExpress.XtraEditors.ButtonEdit beDivision;
        private DevExpress.XtraLayout.LayoutControlItem DivisionSelectionItem;
        private DevExpress.XtraEditors.ButtonEdit beCoworkerPosition;
        private DevExpress.XtraLayout.LayoutControlItem lciCoworkerPosition;
    }
}
