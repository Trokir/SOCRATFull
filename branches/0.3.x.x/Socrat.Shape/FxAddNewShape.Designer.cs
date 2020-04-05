namespace Socrat.Shape
{
    partial class FxAddNewShape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxAddNewShape));
            this.CatalogNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.prpTecnical = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatalogNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prpTecnical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // CatalogNumber
            // 
            this.CatalogNumber.AutoHeight = false;
            this.CatalogNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CatalogNumber.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CatalogNumber.Name = "CatalogNumber";
            // 
            // prpTecnical
            // 
            this.prpTecnical.DefaultEditors.AddRange(new DevExpress.XtraVerticalGrid.Rows.DefaultEditor[] {
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(typeof(bool), this.repositoryItemCheckEdit1),
            new DevExpress.XtraVerticalGrid.Rows.DefaultEditor(typeof(int), this.CatalogNumber)});
            this.prpTecnical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpTecnical.Location = new System.Drawing.Point(0, 0);
            this.prpTecnical.Name = "prpTecnical";
            this.prpTecnical.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.prpTecnical.Size = new System.Drawing.Size(461, 437);
            this.prpTecnical.TabIndex = 5;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // FxAddNewShape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 474);
            this.Controls.Add(this.prpTecnical);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxAddNewShape";
            this.Text = "Новая фигура";
            this.Controls.SetChildIndex(this.prpTecnical, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatalogNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prpTecnical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl prpTecnical;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit CatalogNumber;
    }
}