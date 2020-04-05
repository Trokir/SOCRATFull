namespace Sorat.Test
{
    partial class PackageVisualEditor
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCamNums = new System.Windows.Forms.ComboBox();
            this.nudG1 = new System.Windows.Forms.NumericUpDown();
            this.nudF1 = new System.Windows.Forms.NumericUpDown();
            this.nudG2 = new System.Windows.Forms.NumericUpDown();
            this.nudF2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudG3 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label10);
            this.splitContainer.Panel1.Controls.Add(this.label9);
            this.splitContainer.Panel1.Controls.Add(this.label8);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.nudG3);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.nudF2);
            this.splitContainer.Panel1.Controls.Add(this.nudG2);
            this.splitContainer.Panel1.Controls.Add(this.nudF1);
            this.splitContainer.Panel1.Controls.Add(this.nudG1);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.cbCamNums);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer.Size = new System.Drawing.Size(407, 503);
            this.splitContainer.SplitterDistance = 165;
            this.splitContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество камер:";
            // 
            // cbCamNums
            // 
            this.cbCamNums.FormattingEnabled = true;
            this.cbCamNums.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbCamNums.Location = new System.Drawing.Point(129, 12);
            this.cbCamNums.Name = "cbCamNums";
            this.cbCamNums.Size = new System.Drawing.Size(47, 21);
            this.cbCamNums.TabIndex = 0;
            this.cbCamNums.Text = "1";
            this.cbCamNums.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // nudG1
            // 
            this.nudG1.Location = new System.Drawing.Point(22, 84);
            this.nudG1.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudG1.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudG1.Name = "nudG1";
            this.nudG1.Size = new System.Drawing.Size(47, 20);
            this.nudG1.TabIndex = 2;
            this.nudG1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudF1
            // 
            this.nudF1.Location = new System.Drawing.Point(86, 84);
            this.nudF1.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudF1.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudF1.Name = "nudF1";
            this.nudF1.Size = new System.Drawing.Size(47, 20);
            this.nudF1.TabIndex = 3;
            this.nudF1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudG2
            // 
            this.nudG2.Location = new System.Drawing.Point(149, 84);
            this.nudG2.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudG2.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudG2.Name = "nudG2";
            this.nudG2.Size = new System.Drawing.Size(47, 20);
            this.nudG2.TabIndex = 4;
            this.nudG2.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudF2
            // 
            this.nudF2.Location = new System.Drawing.Point(215, 84);
            this.nudF2.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudF2.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudF2.Name = "nudF2";
            this.nudF2.Size = new System.Drawing.Size(47, 20);
            this.nudF2.TabIndex = 5;
            this.nudF2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Стекло1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Стекло2";
            // 
            // nudG3
            // 
            this.nudG3.Location = new System.Drawing.Point(277, 84);
            this.nudG3.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudG3.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudG3.Name = "nudG3";
            this.nudG3.Size = new System.Drawing.Size(47, 20);
            this.nudG3.TabIndex = 8;
            this.nudG3.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Стекло3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Рамка1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Рамка2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(72, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(135, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(200, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(263, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "-";
            // 
            // PackageVisualEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 503);
            this.Controls.Add(this.splitContainer);
            this.Name = "PackageVisualEditor";
            this.Text = "PackageVisualEditor";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudG1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCamNums;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudG3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudF2;
        private System.Windows.Forms.NumericUpDown nudG2;
        private System.Windows.Forms.NumericUpDown nudF1;
        private System.Windows.Forms.NumericUpDown nudG1;
    }
}