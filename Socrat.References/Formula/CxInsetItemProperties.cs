using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;

namespace Socrat.References.Formula
{
    public partial class CxInsetItemProperties : CxFormulaItemProperties
    {
        private InsetItem _insetItem;

        public InsetItem InsetItem
        {
            get => _insetItem;
            set => SetInsetItem(value);
        }

        private void SetInsetItem(InsetItem value)
        {
            _insetItem = value;
            if (_insetItem != null)
            {
                if (_insetItem.InsetItemProperty == null)
                    _insetItem.InsetItemProperty = new InsetItemProperty { Id = _insetItem.Id, InsetItem = _insetItem};
            }
        }

        public CxInsetItemProperties()
        {
            InitializeComponent();
        }

        public MaterialNom MaterialNom
        {
            get { return InsetItem?.MaterialNom; }
        }

        public override void BindData()
        {
            beMaterialNom.EditValue = MaterialNom.Code;
            lcMatNomName.Text = InsetItem.InsetItemProperty.MaterialNomName;
            lcVendor.Text = InsetItem.InsetItemProperty.VendorName;
        }

        private void SelectMaterialNom()
        {
            SetupMaterial(MaterialEnum.Inset, InsetItem);
        }

        protected override void UpdateComponent()
        {
            beMaterialNom.EditValue = InsetItem.MaterialNom.Code;
            OnNeedUpdateParentView(InsetItem);
        }

        private void beMaterialNom_ButtonClick_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialNom();
        }
    }
}
