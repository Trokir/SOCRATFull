namespace Socrat.Module.Price.v1
{
    partial class FxPricePeriodEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxPricePeriodEdit));
            this.lcPricePeriod = new DevExpress.XtraLayout.LayoutControl();
            this.deDateBegin = new DevExpress.XtraEditors.DateEdit();
            this.meBaseSpo = new DevExpress.XtraEditors.SpinEdit();
            this.meBaseSpd = new DevExpress.XtraEditors.SpinEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciBeginDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBaseSpo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBaseSpd = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPricePeriod)).BeginInit();
            this.lcPricePeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDateBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBaseSpo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBaseSpd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBeginDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseSpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseSpd)).BeginInit();
            this.SuspendLayout();
            // 
            // lcPricePeriod
            // 
            this.lcPricePeriod.Controls.Add(this.deDateBegin);
            this.lcPricePeriod.Controls.Add(this.meBaseSpo);
            this.lcPricePeriod.Controls.Add(this.meBaseSpd);
            this.lcPricePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcPricePeriod.Location = new System.Drawing.Point(0, 0);
            this.lcPricePeriod.Name = "lcPricePeriod";
            this.lcPricePeriod.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1041, 173, 650, 400);
            this.lcPricePeriod.Root = this.Root;
            this.lcPricePeriod.Size = new System.Drawing.Size(397, 165);
            this.lcPricePeriod.TabIndex = 5;
            this.lcPricePeriod.Text = "layoutControl1";
            // 
            // deDateBegin
            // 
            this.deDateBegin.EditValue = null;
            this.deDateBegin.Location = new System.Drawing.Point(15, 31);
            this.deDateBegin.MenuManager = this.barManager;
            this.deDateBegin.Name = "deDateBegin";
            this.deDateBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateBegin.Size = new System.Drawing.Size(367, 20);
            this.deDateBegin.StyleController = this.lcPricePeriod;
            this.deDateBegin.TabIndex = 5;
            // 
            // meBaseSpo
            // 
            this.meBaseSpo.CausesValidation = false;
            this.meBaseSpo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.meBaseSpo.Location = new System.Drawing.Point(15, 77);
            this.meBaseSpo.MenuManager = this.barManager;
            this.meBaseSpo.Name = "meBaseSpo";
            this.meBaseSpo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.meBaseSpo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.meBaseSpo.Properties.Mask.BeepOnError = true;
            this.meBaseSpo.Properties.Mask.EditMask = "c2";
            this.meBaseSpo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.meBaseSpo.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.meBaseSpo.Properties.NullText = "0";
            this.meBaseSpo.Size = new System.Drawing.Size(367, 20);
            this.meBaseSpo.StyleController = this.lcPricePeriod;
            this.meBaseSpo.TabIndex = 6;
            // 
            // meBaseSpd
            // 
            this.meBaseSpd.CausesValidation = false;
            this.meBaseSpd.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.meBaseSpd.Location = new System.Drawing.Point(15, 123);
            this.meBaseSpd.MenuManager = this.barManager;
            this.meBaseSpd.Name = "meBaseSpd";
            this.meBaseSpd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.meBaseSpd.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.meBaseSpd.Properties.Mask.BeepOnError = true;
            this.meBaseSpd.Properties.Mask.EditMask = "c2";
            this.meBaseSpd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.meBaseSpd.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.meBaseSpd.Size = new System.Drawing.Size(367, 20);
            this.meBaseSpd.StyleController = this.lcPricePeriod;
            this.meBaseSpd.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciBeginDate,
            this.lciBaseSpo,
            this.lciBaseSpd});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(397, 165);
            this.Root.TextVisible = false;
            // 
            // lciBeginDate
            // 
            this.lciBeginDate.Control = this.deDateBegin;
            this.lciBeginDate.Location = new System.Drawing.Point(0, 0);
            this.lciBeginDate.Name = "lciBeginDate";
            this.lciBeginDate.Size = new System.Drawing.Size(377, 46);
            this.lciBeginDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciBeginDate.Text = "Дата начала действия прайса";
            this.lciBeginDate.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciBeginDate.TextSize = new System.Drawing.Size(154, 13);
            // 
            // lciBaseSpo
            // 
            this.lciBaseSpo.Control = this.meBaseSpo;
            this.lciBaseSpo.Location = new System.Drawing.Point(0, 46);
            this.lciBaseSpo.Name = "lciBaseSpo";
            this.lciBaseSpo.Size = new System.Drawing.Size(377, 46);
            this.lciBaseSpo.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciBaseSpo.Text = "Базовая цена СПО";
            this.lciBaseSpo.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciBaseSpo.TextSize = new System.Drawing.Size(154, 13);
            // 
            // lciBaseSpd
            // 
            this.lciBaseSpd.Control = this.meBaseSpd;
            this.lciBaseSpd.Location = new System.Drawing.Point(0, 92);
            this.lciBaseSpd.Name = "lciBaseSpd";
            this.lciBaseSpd.Size = new System.Drawing.Size(377, 53);
            this.lciBaseSpd.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.lciBaseSpd.Text = "Базовая цена СПД";
            this.lciBaseSpd.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciBaseSpd.TextSize = new System.Drawing.Size(154, 13);
            // 
            // FxPricePeriodEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(397, 202);
            this.Controls.Add(this.lcPricePeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(407, 234);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(407, 234);
            this.Name = "FxPricePeriodEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый период действия";
            this.Controls.SetChildIndex(this.lcPricePeriod, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcPricePeriod)).EndInit();
            this.lcPricePeriod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deDateBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBaseSpo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meBaseSpd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBeginDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseSpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBaseSpd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcPricePeriod;
        private DevExpress.XtraEditors.DateEdit deDateBegin;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciBeginDate;
        private DevExpress.XtraLayout.LayoutControlItem lciBaseSpo;
        private DevExpress.XtraLayout.LayoutControlItem lciBaseSpd;
        private DevExpress.XtraEditors.SpinEdit meBaseSpo;
        private DevExpress.XtraEditors.SpinEdit meBaseSpd;
    }
}