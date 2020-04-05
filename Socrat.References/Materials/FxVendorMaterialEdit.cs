using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxVendorMaterialEdit : FxBaseSimpleDialog
    {
        public VendorMaterial VendorMaterial { get; set; }

        public FxVendorMaterialEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return VendorMaterial;
        }

        protected override void SetEntity(IEntity value)
        {
            VendorMaterial = value as VendorMaterial;
        }

        protected override void BindData()
        {
            base.BindData();
            beMaterialType.EditValue = VendorMaterial?.Material;
        }

        private void beMaterialType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxMaterials _fx = new FxMaterials();
            _fx.SetSingleSelectMode(VendorMaterial.Material);
            _fx.ItemSelected += (o, args) =>
            {
                beMaterialType.EditValue = _fx.SelectedItem;
                VendorMaterial.Material = _fx.SelectedItem as Material;
            };
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beMaterialType };
        }
    }

}