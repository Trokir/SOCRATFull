using System.Collections.Generic;
using Socrat.Common.Interfaces;
using Socrat.Common.Interfaces.MVC;
using Socrat.MVC.ViewModels.Printing;

namespace Socrat.MVC.Views.Printing
{
    public class PrintTemplateSelectorView : BaseDialogView
    {
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl TemplatesList;

        public PrintTemplateSelectorView(object data, IViewModel viewModel)
            : this()
        {
            Data = data;
            ViewModel = viewModel;
            TemplatesList.DataSource = (viewModel as PrintTemplateSelectorViewModel).Items;
            TemplatesList.DisplayMember = "Title";
            TemplatesList.ValueMember = "Template";
            if(TemplatesList.DataSource != null)
                if (TemplatesList.ItemCount > 0)
                    TemplatesList.SelectedIndex = 0;
        }        

        public PrintTemplateSelectorView() : base()
        {
            InitializeComponent();
            ButtonDo.Enabled = false;
        }

        #region Designer code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintTemplateSelectorView));
            this.TemplatesList = new DevExpress.XtraEditors.ListBoxControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.TemplatesList)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCancel
            // 
            this.PanelCancel.Location = new System.Drawing.Point(92, 0);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCancel.ImageOptions.Image")));
            this.ButtonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelApply
            // 
            this.PanelApply.Location = new System.Drawing.Point(192, 0);
            this.PanelApply.Visible = false;
            // 
            // ButtonApply
            // 
            this.ButtonApply.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonApply.ImageOptions.Image")));
            this.ButtonApply.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            // 
            // PanelDo
            // 
            this.PanelDo.Location = new System.Drawing.Point(292, 0);
            // 
            // ButtonDo
            // 
            this.ButtonDo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDo.ImageOptions.Image")));
            this.ButtonDo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ButtonDo.Text = "Выбрать";
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.TemplatesList);
            this.PanelContent.Size = new System.Drawing.Size(314, 287);
            // 
            // PanelRight
            // 
            this.PanelRight.Location = new System.Drawing.Point(320, 51);
            this.PanelRight.Size = new System.Drawing.Size(74, 287);
            // 
            // PanelBottom
            // 
            this.PanelBottom.Location = new System.Drawing.Point(2, 342);
            this.PanelBottom.Size = new System.Drawing.Size(392, 40);
            // 
            // PanelTop
            // 
            this.PanelTop.Controls.Add(this.labelControl1);
            this.PanelTop.Padding = new System.Windows.Forms.Padding(2);
            this.PanelTop.Size = new System.Drawing.Size(392, 45);
            // 
            // TemplatesList
            // 
            this.TemplatesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplatesList.Location = new System.Drawing.Point(5, 5);
            this.TemplatesList.Name = "TemplatesList";
            this.TemplatesList.Size = new System.Drawing.Size(304, 277);
            this.TemplatesList.TabIndex = 0;
            this.TemplatesList.SelectedIndexChanged += new System.EventHandler(this.TemplatesList_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.labelControl1.Size = new System.Drawing.Size(247, 41);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Шаблоны печати";
            // 
            // PrintTemplateSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(396, 384);
            this.Name = "PrintTemplateSelectorView";
            this.PaneRightVisibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.Text = "Выберите шаблон";
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
            ((System.ComponentModel.ISupportInitialize)(this.TemplatesList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void TemplatesList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Selection = TemplatesList.SelectedItem;
            ButtonDo.Enabled = Selection != null;
        }
    }
}
