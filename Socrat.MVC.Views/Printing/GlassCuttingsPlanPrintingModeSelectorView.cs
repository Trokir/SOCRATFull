using Socrat.Common.Enums;
using Socrat.Common.Interfaces;
using System.Collections.Generic;


namespace Socrat.MVC.Views.Printing
{
    public class GlassCuttingsPlanPrintingModeSelectorView : BaseDialogView, ISelection<GlassCuttingsPlanPrintingModes>
    {
        GlassCuttingsPlanPrintingModes _selectedMode = GlassCuttingsPlanPrintingModes.All;

        public GlassCuttingsPlanPrintingModeSelectorView(bool makeSomeGlassesFromGarbage)
        {
            InitializeComponent();
            Selection = new List<GlassCuttingsPlanPrintingModes>();

            if (rgSelection.Properties.Items.Count == 3)
            {
                rgSelection.Properties.Items[0].Value = GlassCuttingsPlanPrintingModes.All;
                rgSelection.Properties.Items[1].Value = GlassCuttingsPlanPrintingModes.NotFromGarbage;
                rgSelection.Properties.Items[2].Value = GlassCuttingsPlanPrintingModes.OnlyFromGarbage;
            }

            rgSelection.DataBindings.Add("EditValue", this, "SelectedMode");
            rgSelection.EditValue = SelectedMode = GlassCuttingsPlanPrintingModes.All;

            rgSelection.Properties.Items[1].Enabled = rgSelection.Properties.Items[2].Enabled = makeSomeGlassesFromGarbage;
        }

        public object SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (value is GlassCuttingsPlanPrintingModes selectedMode)
                {
                    _selectedMode = selectedMode;
                    Selection.Clear();
                    Selection.Add(selectedMode);
                }
            }
        }

        public new List<GlassCuttingsPlanPrintingModes> Selection { get; }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlassCuttingsPlanPrintingModeSelectorView));
            this.rgSelection = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.PanelCancel)).BeginInit();
            this.PanelCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelApply)).BeginInit();
            this.PanelApply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelDo)).BeginInit();
            this.PanelDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelContent)).BeginInit();
            this.PanelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelBottom)).BeginInit();
            this.PanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelTop)).BeginInit();
            this.PanelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgSelection.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCancel
            // 
            this.PanelCancel.Location = new System.Drawing.Point(63, 0);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.ImageOptions.Image")));
            this.ButtonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelApply
            // 
            this.PanelApply.Location = new System.Drawing.Point(163, 0);
            this.PanelApply.Visible = false;
            // 
            // ButtonApply
            // 
            this.ButtonApply.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonApply.ImageOptions.Image")));
            this.ButtonApply.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelDo
            // 
            this.PanelDo.Location = new System.Drawing.Point(263, 0);
            // 
            // ButtonDo
            // 
            this.ButtonDo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDo.ImageOptions.Image")));
            this.ButtonDo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.rgSelection);
            this.PanelContent.Location = new System.Drawing.Point(2, 52);
            this.PanelContent.Size = new System.Drawing.Size(291, 99);
            // 
            // PanelRight
            // 
            this.PanelRight.Location = new System.Drawing.Point(297, 52);
            this.PanelRight.Size = new System.Drawing.Size(68, 99);
            // 
            // PanelBottom
            // 
            this.PanelBottom.Location = new System.Drawing.Point(2, 155);
            this.PanelBottom.Size = new System.Drawing.Size(363, 40);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.labelControl1);
            this.PanelTop.Size = new System.Drawing.Size(363, 45);
            // 
            // rgSelection
            // 
            this.rgSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgSelection.Location = new System.Drawing.Point(5, 5);
            this.rgSelection.Name = "rgSelection";
            this.rgSelection.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSelection.Properties.Appearance.Options.UseBackColor = true;
            this.rgSelection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSelection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Вся целиком"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Исключая нарезку из отхода", false),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Только нарезка из отхода", false)});
            this.rgSelection.Size = new System.Drawing.Size(281, 89);
            this.rgSelection.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.labelControl1.Size = new System.Drawing.Size(363, 45);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "План на резку стекла";
            // 
            // GlassCuttingsPlanPrintingModeSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(367, 197);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 229);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 229);
            this.Name = "GlassCuttingsPlanPrintingModeSelectorView";
            this.Text = "Выберите назначение печати";
            ((System.ComponentModel.ISupportInitialize)(this.PanelCancel)).EndInit();
            this.PanelCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelApply)).EndInit();
            this.PanelApply.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelDo)).EndInit();
            this.PanelDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelContent)).EndInit();
            this.PanelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelBottom)).EndInit();
            this.PanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelTop)).EndInit();
            this.PanelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgSelection.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.RadioGroup rgSelection;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
