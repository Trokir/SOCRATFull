namespace Socrat.UI.Core
{
    partial class FxLoading
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
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // progressPanel
            // 
            this.progressPanel.AnimationToTextDistance = 15;
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressPanel.AppearanceCaption.Options.UseFont = true;
            this.progressPanel.AppearanceDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.progressPanel.AppearanceDescription.Options.UseFont = true;
            this.progressPanel.BarAnimationElementLength = 100;
            this.progressPanel.BarAnimationElementThickness = 4;
            this.progressPanel.Caption = "Пожалуйста подождите";
            this.progressPanel.Description = "Идет загрузка ...";
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel.Location = new System.Drawing.Point(0, 0);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(323, 66);
            this.progressPanel.TabIndex = 0;
            this.progressPanel.Text = "progressPanel";
            // 
            // FxLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 66);
            this.Controls.Add(this.progressPanel);
            this.Name = "FxLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FxLoading";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
    }
}