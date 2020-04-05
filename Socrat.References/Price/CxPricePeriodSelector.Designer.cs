namespace Socrat.References.Price
{
    partial class CxPricePeriodSelector
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
            this.sbPrevPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.sbCurrentPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.sbNextPeriod = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.deSpecificPeriod = new DevExpress.XtraEditors.DateEdit();
            this.dePeriodEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.deSpecificPeriod.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSpecificPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbPrevPeriod
            // 
            this.sbPrevPeriod.Location = new System.Drawing.Point(5, 23);
            this.sbPrevPeriod.Name = "sbPrevPeriod";
            this.sbPrevPeriod.Size = new System.Drawing.Size(33, 23);
            this.sbPrevPeriod.TabIndex = 0;
            this.sbPrevPeriod.Text = "<";
            this.sbPrevPeriod.Click += new System.EventHandler(this.sbPrevPeriod_Click);
            // 
            // sbCurrentPeriod
            // 
            this.sbCurrentPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sbCurrentPeriod.Location = new System.Drawing.Point(44, 23);
            this.sbCurrentPeriod.Name = "sbCurrentPeriod";
            this.sbCurrentPeriod.Size = new System.Drawing.Size(124, 23);
            this.sbCurrentPeriod.TabIndex = 1;
            this.sbCurrentPeriod.Text = "Текущий";
            this.sbCurrentPeriod.Click += new System.EventHandler(this.sbCurrentPeriod_Click);
            // 
            // sbNextPeriod
            // 
            this.sbNextPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbNextPeriod.Location = new System.Drawing.Point(174, 23);
            this.sbNextPeriod.Name = "sbNextPeriod";
            this.sbNextPeriod.Size = new System.Drawing.Size(33, 23);
            this.sbNextPeriod.TabIndex = 2;
            this.sbNextPeriod.Text = ">";
            this.sbNextPeriod.Click += new System.EventHandler(this.sbNextPeriod_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.Location = new System.Drawing.Point(210, 23);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(33, 23);
            this.simpleButton4.TabIndex = 3;
            this.simpleButton4.Text = ">";
            // 
            // deSpecificPeriod
            // 
            this.deSpecificPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deSpecificPeriod.EditValue = new System.DateTime(2019, 7, 23, 17, 9, 58, 401);
            this.deSpecificPeriod.Location = new System.Drawing.Point(18, 50);
            this.deSpecificPeriod.Name = "deSpecificPeriod";
            this.deSpecificPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deSpecificPeriod.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deSpecificPeriod.Size = new System.Drawing.Size(100, 20);
            this.deSpecificPeriod.TabIndex = 4;
            this.deSpecificPeriod.EditValueChanged += new System.EventHandler(this.deSpecificPeriod_EditValueChanged);
            // 
            // dePeriodEnd
            // 
            this.dePeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dePeriodEnd.EditValue = new System.DateTime(2019, 7, 23, 17, 9, 10, 955);
            this.dePeriodEnd.Enabled = false;
            this.dePeriodEnd.Location = new System.Drawing.Point(142, 50);
            this.dePeriodEnd.Name = "dePeriodEnd";
            this.dePeriodEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePeriodEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePeriodEnd.Properties.ReadOnly = true;
            this.dePeriodEnd.Size = new System.Drawing.Size(100, 20);
            this.dePeriodEnd.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Location = new System.Drawing.Point(7, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(5, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "с";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Location = new System.Drawing.Point(124, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "по";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.sbPrevPeriod);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.sbCurrentPeriod);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.sbNextPeriod);
            this.groupControl1.Controls.Add(this.dePeriodEnd);
            this.groupControl1.Controls.Add(this.simpleButton4);
            this.groupControl1.Controls.Add(this.deSpecificPeriod);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(5, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(248, 75);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Период";
            // 
            // CxPricePeriodSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "CxPricePeriodSelector";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(258, 85);
            ((System.ComponentModel.ISupportInitialize)(this.deSpecificPeriod.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSpecificPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbPrevPeriod;
        private DevExpress.XtraEditors.SimpleButton sbCurrentPeriod;
        private DevExpress.XtraEditors.SimpleButton sbNextPeriod;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.DateEdit deSpecificPeriod;
        private DevExpress.XtraEditors.DateEdit dePeriodEnd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
