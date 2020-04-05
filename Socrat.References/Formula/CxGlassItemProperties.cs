using System.ComponentModel;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;


namespace Socrat.References.Formula
{
    public partial class CxGlassItemProperties : CxFormulaItemProperties
    {
        private GlassItem _glassItem;
        public GlassItem GlassItem
        {
            get => _glassItem;
            set => SetGlassItem(value);
        }

        private void SetGlassItem(GlassItem value)
        {
            _glassItem = value;
            if (_glassItem.GlassItemProperty == null)
                _glassItem.GlassItemProperty = new GlassItemProperty { Id = _glassItem.Id, GlassItem = _glassItem };
        }



        public MaterialNom MaterialNom
        {
            get { return GlassItem?.MaterialNom; }
        }

        public CxGlassItemProperties()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            beMaterialNom.EditValue = MaterialNom.Code;
            BindLabel(lcName, GlassItem, "MaterialNomName");
            BindLabel(lcVendor, GlassItem, "VendorName");
            BindEditor(ceDent, GlassItem, x => x.DentExists);
            BindEditor(ceCustomerGlass, GlassItem, x => x.CustomerMaterial);
            BindEditor(ceDent, GlassItem.GlassItemProperty, x => x.Dent);
            BindEditor(ceCustomerGlass, GlassItem, x => x.TollingEx);
        }

        private void beMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialNom();
        }

        private void SelectMaterialNom()
        {
            SetupMaterial(MaterialEnum.Glass, GlassItem);
        }

        protected override void UpdateComponent()
        {
            beMaterialNom.EditValue = GlassItem.MaterialNom.Code;
            OnNeedUpdateParentView(GlassItem);
        }

        private void ceDent_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!ceDent.Checked)
                OnNeedUpdateParentView(GlassItem);
        }
    }
}
