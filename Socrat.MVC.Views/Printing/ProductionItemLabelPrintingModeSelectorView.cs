using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Common.Interfaces;


namespace Socrat.MVC.Views.Printing
{
    public class ProductionItemLabelPrintingModeSelectorView : BaseDialogView, ISelection<ProductionItemLabelPrintingModes>
    {
        public new List<ProductionItemLabelPrintingModes> Selection { get; } = new List<ProductionItemLabelPrintingModes>();

        public ProductionItemLabelPrintingModeSelectorView(bool hasFilms, bool hasCustomerGlassLabel)
        {
            InitializeComponent();

            if (chPrintFilm.Checked == hasFilms)
            {
                Selection.Clear();
                Selection.Add(ProductionItemLabelPrintingModes.PrintFilmLabel);
            }
            else
                chPrintFilm.Enabled = chPrintFilm.Checked = hasFilms;
            chPrintFilm.Enabled = hasFilms;
            chGlassBeforeFilm.Enabled = hasCustomerGlassLabel;
        }

        #region Designer

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl pLabelPrintControl;
        private DevExpress.XtraEditors.CheckEdit chGlassBeforeFilm;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit chPrintFilm;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionItemLabelPrintingModeSelectorView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pLabelPrintControl = new DevExpress.XtraEditors.PanelControl();
            this.chGlassBeforeFilm = new DevExpress.XtraEditors.CheckEdit();
            this.chPrintFilm = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.pLabelPrintControl)).BeginInit();
            this.pLabelPrintControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chGlassBeforeFilm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPrintFilm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCancel
            // 
            this.PanelCancel.Location = new System.Drawing.Point(97, 0);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.ImageOptions.Image")));
            this.ButtonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelApply
            // 
            this.PanelApply.Location = new System.Drawing.Point(197, 0);
            this.PanelApply.Visible = false;
            // 
            // ButtonApply
            // 
            this.ButtonApply.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonApply.ImageOptions.Image")));
            this.ButtonApply.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelDo
            // 
            this.PanelDo.Location = new System.Drawing.Point(297, 0);
            // 
            // ButtonDo
            // 
            this.ButtonDo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDo.ImageOptions.Image")));
            this.ButtonDo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.pLabelPrintControl);
            this.PanelContent.Location = new System.Drawing.Point(2, 52);
            this.PanelContent.Size = new System.Drawing.Size(318, 94);
            // 
            // PanelRight
            // 
            this.PanelRight.Location = new System.Drawing.Point(324, 52);
            this.PanelRight.Size = new System.Drawing.Size(75, 94);
            this.PanelRight.Visible = false;
            // 
            // PanelBottom
            // 
            this.PanelBottom.Location = new System.Drawing.Point(2, 150);
            this.PanelBottom.Size = new System.Drawing.Size(397, 40);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.labelControl1);
            this.PanelTop.Size = new System.Drawing.Size(397, 45);
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
            this.labelControl1.Size = new System.Drawing.Size(397, 45);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Этикетка изделия";
            // 
            // pLabelPrintControl
            // 
            this.pLabelPrintControl.Controls.Add(this.chGlassBeforeFilm);
            this.pLabelPrintControl.Controls.Add(this.chPrintFilm);
            this.pLabelPrintControl.Controls.Add(this.labelControl2);
            this.pLabelPrintControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLabelPrintControl.Location = new System.Drawing.Point(5, 5);
            this.pLabelPrintControl.Name = "pLabelPrintControl";
            this.pLabelPrintControl.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pLabelPrintControl.Size = new System.Drawing.Size(308, 84);
            this.pLabelPrintControl.TabIndex = 2;
            // 
            // chGlassBeforeFilm
            // 
            this.chGlassBeforeFilm.Dock = System.Windows.Forms.DockStyle.Top;
            this.chGlassBeforeFilm.Enabled = false;
            this.chGlassBeforeFilm.Location = new System.Drawing.Point(22, 49);
            this.chGlassBeforeFilm.Name = "chGlassBeforeFilm";
            this.chGlassBeforeFilm.Properties.Caption = "Этикетка спецстекла перед этикеткой пленки";
            this.chGlassBeforeFilm.Size = new System.Drawing.Size(284, 19);
            this.chGlassBeforeFilm.TabIndex = 2;
            this.chGlassBeforeFilm.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chPrintFilm
            // 
            this.chPrintFilm.Dock = System.Windows.Forms.DockStyle.Top;
            this.chPrintFilm.EditValue = true;
            this.chPrintFilm.Location = new System.Drawing.Point(22, 30);
            this.chPrintFilm.Name = "chPrintFilm";
            this.chPrintFilm.Properties.Caption = "Включая этикетку пленки";
            this.chPrintFilm.Size = new System.Drawing.Size(284, 19);
            this.chPrintFilm.TabIndex = 0;
            this.chPrintFilm.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(22, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.labelControl2.Size = new System.Drawing.Size(53, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Печатать:";
            // 
            // ProductionItemLabelPrintingModeSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(401, 192);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(411, 224);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(411, 224);
            this.Name = "ProductionItemLabelPrintingModeSelectorView";
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
            ((System.ComponentModel.ISupportInitialize)(this.pLabelPrintControl)).EndInit();
            this.pLabelPrintControl.ResumeLayout(false);
            this.pLabelPrintControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chGlassBeforeFilm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPrintFilm.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            Selection.Clear();
            if ((!chPrintFilm.Checked & !chGlassBeforeFilm.Checked) ||
                (!chPrintFilm.Checked & chGlassBeforeFilm.Checked))
                Selection.Add(ProductionItemLabelPrintingModes.Default);
            else if (chPrintFilm.Checked & !chGlassBeforeFilm.Checked)
                Selection.Add(ProductionItemLabelPrintingModes.PrintFilmLabel);
            else if (chPrintFilm.Checked & chGlassBeforeFilm.Checked)
                Selection.Add(ProductionItemLabelPrintingModes.PrintGlassLabelBeforeFilmLabel);
        }
    }
}
