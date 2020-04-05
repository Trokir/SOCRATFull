using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomEdit : FxBaseSimpleDialog
    {
        public MaterialNom MaterialNom { get; set; }
        public Material Material { get; set; }
        public MaterialMarkType MaterialMarkType { get; set; }

        private ButtonEditAssistent<VendorMaterialNom, FxVendorMaterialNoms, FxVendorMaterialNomEdit>
            _vendorMaterialButtonEditAssistent;

        private ButtonEditAssistent<MaterialSizeType, FxMaterialSizeTypeList, FxMaterialSizeTypeEdit>
            _materialSizeTypeButtonEditAssistent;

        public FxMaterialNomEdit()
        {
            InitializeComponent();
            Load += FxMaterialNomEdit_Load;
        }

        private void FxMaterialNomEdit_Load(object sender, System.EventArgs e)
        {
            _vendorMaterialButtonEditAssistent = new ButtonEditAssistent<VendorMaterialNom, FxVendorMaterialNoms, FxVendorMaterialNomEdit>(
                beVendorMaterialNom, MaterialNom.VendorMaterialNom, OnDialogOutput);
            _vendorMaterialButtonEditAssistent.BindProperty(MaterialNom, x => x.VendorMaterialNom);
            _vendorMaterialButtonEditAssistent.SelectionFormFiltersSetup = 
                () => new FxVendorMaterialNoms { Material = this.Material ?? this.MaterialNom.Material};

            _materialSizeTypeButtonEditAssistent = new ButtonEditAssistent<MaterialSizeType, FxMaterialSizeTypeList, FxMaterialSizeTypeEdit>(
                beThickness, MaterialNom.MaterialSizeType, OnDialogOutput);
            _materialSizeTypeButtonEditAssistent.BindProperty(MaterialNom, x => x.MaterialSizeType);
            _materialSizeTypeButtonEditAssistent.SelectionFormFiltersSetup = 
                () => new FxMaterialSizeTypeList
                {
                    Material = this.Material ?? this.MaterialNom.Material,
                    MaterialMarkType = this.MaterialNom.VendorMaterialNom?.MaterialMarkType
                };
        }

        protected override IEntity GetEntity()
        {
            return MaterialNom;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialNom = value as MaterialNom;
        }

        protected override void BindData()
        {
            base.BindData();
            beVendorMaterialNom.EditValue = MaterialNom.VendorMaterialNom;
            beThickness.EditValue = MaterialNom.MaterialSizeType;
            BindEditor(teCode1C, MaterialNom, x => x.Code1C);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ beVendorMaterialNom, beThickness, teCode1C};
        }

        //private void teVendorMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    SelectVendorMaterialNom();
        //}

        //private void SelectVendorMaterialNom()
        //{
        //    FxVendorMaterialNoms _fx = new FxVendorMaterialNoms();
        //    _fx.SetSingleSelectMode(MaterialNom.VendorMaterialNom);
        //    _fx.Material = Material ?? MaterialNom.Material;
        //    _fx.ItemSelected += (sender, args) =>
        //    {
        //        MaterialNom.VendorMaterialNom = _fx.SelectedItem as VendorMaterialNom;
        //        teVendorMaterialNom.EditValue = MaterialNom.VendorMaterialNom;
        //    };
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        //private void beThickness_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    SelectThickness();
        //}

        //private void SelectThickness()
        //{
        //    FxMaterialSizeTypeList _fx = new FxMaterialSizeTypeList();
        //    _fx.SetSingleSelectMode(MaterialNom.MaterialSizeType);
        //    _fx.Material = Material ?? MaterialNom.Material;
        //    _fx.ItemSelected += (sender, args) =>
        //    {
        //        MaterialNom.MaterialSizeType = _fx.SelectedItem as MaterialSizeType;
        //        beThickness.EditValue = MaterialNom.MaterialSizeType;
        //    };
        //    _fx.DialogOutput += _fx_DialogOutput;
        //    OnDialogOutput(_fx, Core.DialogOutputType.Dialog);
        //}
    }
}