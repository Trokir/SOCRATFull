using Socrat.Core;
using Socrat.Core.Entities.Materials;
using Socrat.References.Customer;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public class FxGlassLabelEdit : FxBaseSimpleDialog
    {
        ButtonEditAssistent<Core.Entities.Customer, FxGenericListTable2<Core.Entities.Customer>, FxCustomerEdit> _CustomerAssistant;
        ButtonEditAssistent<Core.Entities.MaterialNom, FxGenericListTable2<Core.Entities.MaterialNom>, FxMaterialNomEdit> _MaterialNomAssistant;

        public GlassLabel GlassLabel { get; set;}

        public FxGlassLabelEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return GlassLabel;
        }

        protected override void SetEntity(IEntity value)
        {
            GlassLabel = value as GlassLabel;
        }

        protected override void BindData()
        {
            BindEditor(teLabel, GlassLabel, x => x.Text);

            beCustomer.Enabled = GlassLabel.Customer == null;
            eButtonsType bTypeForCustomer = GlassLabel.Customer != null ? eButtonsType.Search : eButtonsType.All;

            _CustomerAssistant =
                    new ButtonEditAssistent<Core.Entities.Customer, FxGenericListTable2<Core.Entities.Customer>, FxCustomerEdit>
                    (beCustomer, GlassLabel.Customer, OnDialogOutput, bTypeForCustomer);
            _CustomerAssistant.BindProperty(GlassLabel, x => x.Customer);

            _MaterialNomAssistant =
                new ButtonEditAssistent<Core.Entities.MaterialNom, FxGenericListTable2<Core.Entities.MaterialNom>, FxMaterialNomEdit>(
                    beMaterialNom, GlassLabel.MaterialNom, OnDialogOutput, eButtonsType.All);
            _MaterialNomAssistant.BindProperty(GlassLabel, x => x.MaterialNom);
            _MaterialNomAssistant.ExternalFilterExp = x => x.Material.MaterialEnum == MaterialEnum.Glass;
            base.BindData();
        }

        #region Designer

        private DevExpress.XtraLayout.LayoutControl LayoutContainer;
        private DevExpress.XtraEditors.TextEdit teLabel;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ButtonEdit beMaterialNom;
        private DevExpress.XtraEditors.ButtonEdit beCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem LabelItem;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxGlassLabelEdit));
            this.LayoutContainer = new DevExpress.XtraLayout.LayoutControl();
            this.beMaterialNom = new DevExpress.XtraEditors.ButtonEdit();
            this.beCustomer = new DevExpress.XtraEditors.ButtonEdit();
            this.teLabel = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LabelItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutContainer)).BeginInit();
            this.LayoutContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialNom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LabelItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // LayoutContainer
            // 
            this.LayoutContainer.Controls.Add(this.beMaterialNom);
            this.LayoutContainer.Controls.Add(this.beCustomer);
            this.LayoutContainer.Controls.Add(this.teLabel);
            this.LayoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutContainer.Location = new System.Drawing.Point(0, 0);
            this.LayoutContainer.Name = "LayoutContainer";
            this.LayoutContainer.Root = this.Root;
            this.LayoutContainer.Size = new System.Drawing.Size(438, 161);
            this.LayoutContainer.TabIndex = 5;
            this.LayoutContainer.Text = "layoutControl1";
            // 
            // beMaterialNom
            // 
            this.beMaterialNom.Location = new System.Drawing.Point(15, 123);
            this.beMaterialNom.MenuManager = this.barManager;
            this.beMaterialNom.Name = "beMaterialNom";
            this.beMaterialNom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beMaterialNom.Size = new System.Drawing.Size(408, 20);
            this.beMaterialNom.StyleController = this.LayoutContainer;
            this.beMaterialNom.TabIndex = 6;
            // 
            // beCustomer
            // 
            this.beCustomer.Location = new System.Drawing.Point(15, 77);
            this.beCustomer.MenuManager = this.barManager;
            this.beCustomer.Name = "beCustomer";
            this.beCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.beCustomer.Size = new System.Drawing.Size(408, 20);
            this.beCustomer.StyleController = this.LayoutContainer;
            this.beCustomer.TabIndex = 5;
            // 
            // teLabel
            // 
            this.teLabel.Location = new System.Drawing.Point(15, 31);
            this.teLabel.MenuManager = this.barManager;
            this.teLabel.Name = "teLabel";
            this.teLabel.Properties.MaxLength = 256;
            this.teLabel.Size = new System.Drawing.Size(408, 20);
            this.teLabel.StyleController = this.LayoutContainer;
            this.teLabel.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LabelItem,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(438, 161);
            this.Root.TextVisible = false;
            // 
            // LabelItem
            // 
            this.LabelItem.Control = this.teLabel;
            this.LabelItem.Location = new System.Drawing.Point(0, 0);
            this.LabelItem.Name = "LabelItem";
            this.LabelItem.Size = new System.Drawing.Size(418, 46);
            this.LabelItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.LabelItem.Text = "Метка стекла";
            this.LabelItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.LabelItem.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.beCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(418, 46);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "Контрагент";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.beMaterialNom;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 92);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(418, 49);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "Номенклатура";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
            // 
            // FxGlassLabelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ButtonsPanelVisible = true;
            this.ClientSize = new System.Drawing.Size(443, 203);
            this.Controls.Add(this.LayoutContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 232);
            this.Name = "FxGlassLabelEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Метка спец.стекла заказчика";
            this.Controls.SetChildIndex(this.LayoutContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutContainer)).EndInit();
            this.LayoutContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.beMaterialNom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LabelItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void customerSelector1_DialogOutput(object sender, Socrat.Common.UI.WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}
