using Socrat.Common;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Articles
{
    public class FxArticleEdit : FxBaseSimpleDialog
    {
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Formula.CxProductionFormula cxProductionFormula;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Components.DivisionSelector divisionSelector;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit meComments;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup Root;


        public FxArticleEdit()
        {
            InitializeComponent();
        }

        public Article Article { get; set; }
        protected override void BindData()
        {
            base.BindData();
            if (Article.Formula == null)
                Article.Formula = Formula.FormulaParser.Parse(Preferences.DEFAULT_FORMULA_SPD);
            BindEditor(meComments, Article, x => x.Comments);
            cxProductionFormula.DataBindings.Add("Formula", Article, "Formula");
            divisionSelector.DataBindings.Add("Division", Article, "Division");
        }
        protected override void SetEntity(IEntity value)
        {
            Article = value as Core.Entities.Article;
        }

        protected override IEntity GetEntity()
        {
            return Article;
        }

        #region Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxArticleEdit));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.meComments = new DevExpress.XtraEditors.MemoEdit();
            this.divisionSelector = new Socrat.References.Components.DivisionSelector();
            this.cxProductionFormula = new Socrat.References.Formula.CxProductionFormula();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meComments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.meComments);
            this.layoutControl1.Controls.Add(this.divisionSelector);
            this.layoutControl1.Controls.Add(this.cxProductionFormula);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(496, 342);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // meComments
            // 
            this.meComments.Location = new System.Drawing.Point(20, 152);
            this.meComments.MenuManager = this.barManager;
            this.meComments.Name = "meComments";
            this.meComments.Size = new System.Drawing.Size(456, 170);
            this.meComments.StyleController = this.layoutControl1;
            this.meComments.TabIndex = 6;
            // 
            // divisionSelector
            // 
            this.divisionSelector.ButtonsType = Socrat.References.eButtonsType.All;
            this.divisionSelector.Division = null;
            this.divisionSelector.Entity = null;
            this.divisionSelector.Location = new System.Drawing.Point(20, 96);
            this.divisionSelector.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.divisionSelector.Name = "divisionSelector";
            this.divisionSelector.ReadOnly = false;
            this.divisionSelector.SelectorEntity = null;
            this.divisionSelector.Size = new System.Drawing.Size(456, 20);
            this.divisionSelector.TabIndex = 5;
            this.divisionSelector.Title = "";
            this.divisionSelector.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            this.divisionSelector.DialogOutput += new System.EventHandler<Socrat.Common.UI.WindowOutputEventArgs>(this.onDialogOutput);
            // 
            // cxProductionFormula
            // 
            this.cxProductionFormula.Caption = "Изделие";
            this.cxProductionFormula.FlaggedProductionType = Socrat.Common.Enums.FlaggedProductionTypes.Unknown;
            this.cxProductionFormula.Formula = null;
            this.cxProductionFormula.Location = new System.Drawing.Point(12, 12);
            this.cxProductionFormula.Margin = new System.Windows.Forms.Padding(0);
            this.cxProductionFormula.MinimumSize = new System.Drawing.Size(123, 56);
            this.cxProductionFormula.ModuleId = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cxProductionFormula.Name = "cxProductionFormula";
            this.cxProductionFormula.ProductionFormulaOwner = Socrat.Common.Enums.ProductionFormulaOwners.Unknown;
            this.cxProductionFormula.ReadOnly = false;
            this.cxProductionFormula.Size = new System.Drawing.Size(472, 56);
            this.cxProductionFormula.TabIndex = 4;
            this.cxProductionFormula.Title = "";
            this.cxProductionFormula.WindowOutputType = Socrat.Common.UI.DialogOutputType.Dialog;
            this.cxProductionFormula.DialogOutput += new System.EventHandler<Socrat.Common.UI.WindowOutputEventArgs>(this.onDialogOutput);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(496, 342);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cxProductionFormula;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 60);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(127, 60);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(476, 60);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.divisionSelector;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 56);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(100, 56);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(476, 56);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem2.Text = "Подразделение";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.meComments;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(476, 206);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem3.Text = "Примечание";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 13);
            // 
            // FxArticleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(496, 379);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FxArticleEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meComments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void onDialogOutput(object sender, Socrat.Common.UI.WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}
