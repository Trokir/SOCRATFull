using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Common.Interfaces;

namespace Socrat.MVC.Views.Printing 
{
    public class PyramidPackingPrintingModeSelectorView: BaseDialogView, ISelection<PackingListPrintingModes>
    {
        public PyramidPackingPrintingModeSelectorView()
        {
            InitializeComponent();
            Selection = new List<PackingListPrintingModes>();

            if (rgSelection.Properties.Items.Count == 2)
            {
                rgSelection.Properties.Items[0].Value = PackingListPrintingModes.Internal;
                rgSelection.Properties.Items[1].Value = PackingListPrintingModes.External;
            }

            rgSelection.DataBindings.Add("EditValue", this, "SelectedMode");
            rgSelection.EditValue = SelectedMode = PackingListPrintingModes.Internal;
        }

        PackingListPrintingModes _selectedMode = PackingListPrintingModes.Internal;

        public object SelectedMode
        {
            get => _selectedMode;
            set
            {
                if (value is PackingListPrintingModes selectedMode)
                {
                    _selectedMode = selectedMode;
                    Selection.Clear();
                    Selection.Add(selectedMode);
                }
            }
        }

        public new List<PackingListPrintingModes> Selection { get; }

        #region Designer code

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rgSelection;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PyramidPackingPrintingModeSelectorView));
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
            this.PanelCancel.Location = new System.Drawing.Point(13, 0);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.ImageOptions.Image")));
            this.ButtonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelApply
            // 
            this.PanelApply.Location = new System.Drawing.Point(113, 0);
            this.PanelApply.Visible = false;
            // 
            // ButtonApply
            // 
            this.ButtonApply.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonApply.ImageOptions.Image")));
            this.ButtonApply.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelDo
            // 
            this.PanelDo.Location = new System.Drawing.Point(213, 0);
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
            this.PanelContent.Padding = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.PanelContent.Size = new System.Drawing.Size(251, 69);
            // 
            // PanelRight
            // 
            this.PanelRight.Location = new System.Drawing.Point(257, 52);
            this.PanelRight.Size = new System.Drawing.Size(58, 69);
            // 
            // PanelBottom
            // 
            this.PanelBottom.Location = new System.Drawing.Point(2, 125);
            this.PanelBottom.Size = new System.Drawing.Size(313, 40);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.labelControl1);
            this.PanelTop.Size = new System.Drawing.Size(313, 45);
            // 
            // rgSelection
            // 
            this.rgSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgSelection.Location = new System.Drawing.Point(15, 5);
            this.rgSelection.Name = "rgSelection";
            this.rgSelection.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgSelection.Properties.Appearance.Options.UseBackColor = true;
            this.rgSelection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgSelection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Упаковочный лист для РСК"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Упаковочный лист для клиента")});
            this.rgSelection.Size = new System.Drawing.Size(231, 59);
            this.rgSelection.TabIndex = 0;
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
            this.labelControl1.Size = new System.Drawing.Size(313, 45);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Упаковочный лист";
            // 
            // PyramidPackingPrintingModeSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(317, 167);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PyramidPackingPrintingModeSelectorView";
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

        #endregion
    }
}
