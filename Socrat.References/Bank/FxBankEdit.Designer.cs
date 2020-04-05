namespace Socrat.References.Bank
{
    partial class FxBankEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxBankEdit));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.teComment = new DevExpress.XtraEditors.TextEdit();
            this.tePhone = new DevExpress.XtraEditors.TextEdit();
            this.teKS = new DevExpress.XtraEditors.TextEdit();
            this.teBIK = new DevExpress.XtraEditors.TextEdit();
            this.teFilial = new DevExpress.XtraEditors.TextEdit();
            this.teShortName = new DevExpress.XtraEditors.TextEdit();
            this.teAlias = new DevExpress.XtraEditors.TextEdit();
            this.beAddress = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teComment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBIK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFilial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.layoutControl, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(594, 334);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.teComment);
            this.layoutControl.Controls.Add(this.tePhone);
            this.layoutControl.Controls.Add(this.teKS);
            this.layoutControl.Controls.Add(this.teBIK);
            this.layoutControl.Controls.Add(this.teFilial);
            this.layoutControl.Controls.Add(this.teShortName);
            this.layoutControl.Controls.Add(this.teAlias);
            this.layoutControl.Controls.Add(this.beAddress);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(3, 3);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(588, 328);
            this.layoutControl.TabIndex = 1;
            this.layoutControl.Text = "layoutControl1";
            // 
            // teComment
            // 
            this.teComment.Location = new System.Drawing.Point(15, 261);
            this.teComment.Name = "teComment";
            this.teComment.Size = new System.Drawing.Size(558, 20);
            this.teComment.StyleController = this.layoutControl;
            this.teComment.TabIndex = 11;
            // 
            // tePhone
            // 
            this.tePhone.Location = new System.Drawing.Point(15, 215);
            this.tePhone.Name = "tePhone";
            this.tePhone.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.tePhone.Properties.Mask.EditMask = "(\\(\\d\\d\\d\\) )?\\d{1,3}-\\d\\d-\\d\\d";
            this.tePhone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.tePhone.Size = new System.Drawing.Size(274, 20);
            this.tePhone.StyleController = this.layoutControl;
            this.tePhone.TabIndex = 10;
            // 
            // teKS
            // 
            this.teKS.Location = new System.Drawing.Point(299, 123);
            this.teKS.Name = "teKS";
            this.teKS.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teKS.Properties.Mask.EditMask = "\\d{20}";
            this.teKS.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teKS.Size = new System.Drawing.Size(274, 20);
            this.teKS.StyleController = this.layoutControl;
            this.teKS.TabIndex = 8;
            // 
            // teBIK
            // 
            this.teBIK.Location = new System.Drawing.Point(15, 123);
            this.teBIK.Name = "teBIK";
            this.teBIK.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            this.teBIK.Properties.Mask.EditMask = "\\d{9}";
            this.teBIK.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.teBIK.Size = new System.Drawing.Size(274, 20);
            this.teBIK.StyleController = this.layoutControl;
            this.teBIK.TabIndex = 7;
            // 
            // teFilial
            // 
            this.teFilial.Location = new System.Drawing.Point(15, 77);
            this.teFilial.Name = "teFilial";
            this.teFilial.Size = new System.Drawing.Size(558, 20);
            this.teFilial.StyleController = this.layoutControl;
            this.teFilial.TabIndex = 6;
            // 
            // teShortName
            // 
            this.teShortName.Location = new System.Drawing.Point(299, 31);
            this.teShortName.Name = "teShortName";
            this.teShortName.Size = new System.Drawing.Size(274, 20);
            this.teShortName.StyleController = this.layoutControl;
            this.teShortName.TabIndex = 5;
            // 
            // teAlias
            // 
            this.teAlias.Location = new System.Drawing.Point(15, 31);
            this.teAlias.Name = "teAlias";
            this.teAlias.Size = new System.Drawing.Size(274, 20);
            this.teAlias.StyleController = this.layoutControl;
            this.teAlias.TabIndex = 4;
            // 
            // beAddress
            // 
            this.beAddress.Location = new System.Drawing.Point(15, 169);
            this.beAddress.Name = "beAddress";
            this.beAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beAddress.Size = new System.Drawing.Size(558, 20);
            this.beAddress.StyleController = this.layoutControl;
            this.beAddress.TabIndex = 9;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(588, 328);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teAlias;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(284, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Наименование";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(99, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 276);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(568, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teShortName;
            this.layoutControlItem2.Location = new System.Drawing.Point(284, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(284, 46);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Кр. наименование";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teFilial;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(568, 46);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem3.Text = "Филиал/Отделение";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.teBIK;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(284, 46);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Text = "БИК";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.teKS;
            this.layoutControlItem5.Location = new System.Drawing.Point(284, 92);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(284, 46);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Text = "Кор.счет";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.beAddress;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(568, 46);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Text = "Адрес";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.tePhone;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 184);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(284, 46);
            this.layoutControlItem7.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem7.Text = "Телефон";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.teComment;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 230);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(568, 46);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem8.Text = "Описание";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(99, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(284, 184);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(284, 46);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FxBankEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 371);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxBankEdit";
            this.Text = "Карточка банка";
            this.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teComment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teKS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teBIK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFilial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit teComment;
        private DevExpress.XtraEditors.TextEdit tePhone;
        private DevExpress.XtraEditors.TextEdit teKS;
        private DevExpress.XtraEditors.TextEdit teBIK;
        private DevExpress.XtraEditors.TextEdit teFilial;
        private DevExpress.XtraEditors.TextEdit teShortName;
        private DevExpress.XtraEditors.TextEdit teAlias;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.ButtonEdit beAddress;
    }
}