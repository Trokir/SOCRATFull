namespace Socrat.UI.Core
{
    partial class FxEntityEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxEntityEditor));
            this.propertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControl
            // 
            this.propertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl.Name = "propertyGridControl";
            this.propertyGridControl.Size = new System.Drawing.Size(667, 549);
            this.propertyGridControl.TabIndex = 3;
            // 
            // FxEntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 583);
            this.Controls.Add(this.propertyGridControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxEntityEditor";
            this.Text = "Просмотр объекта";
            this.Controls.SetChildIndex(this.propertyGridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl;
    }
}