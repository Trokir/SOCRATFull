using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.DataProvider.Repos;

using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxVendorMaterialNomEdit : FxBaseSimpleDialog
    {
        public VendorMaterialNom VendorMaterialNom { get; set; }
        public bool LockVendor { get; set; }
        private ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit> _vendorButtonEditAssistent;
        private ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit> _materialButtonEditAssistent;
        private ButtonEditAssistent<Brand, FxVendorBrands, FxVendorEdit> _brandButtonEditAssistent;
        private ButtonEditAssistent<TradeMark, FxTradeMarks, FxTradeMarkEdit> _tradeMarkButtonEditAssistent;
        private ButtonEditAssistent<MaterialMarkType, FxMaterialMarkTypes, FxMaterialMarkTypeEdit>
            _markTypeButtonEditAssistent;

        public FxVendorMaterialNomEdit()
        {
            InitializeComponent();
            Load += FxVendorMaterialNomEdit_Load;
        }

        private void FxVendorMaterialNomEdit_Load(object sender, System.EventArgs e)
        {
            beVendor.Enabled = !LockVendor;

            _vendorButtonEditAssistent = 
                new ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit>(beVendor, VendorMaterialNom.Vendor, OnDialogOutput);
            _vendorButtonEditAssistent.BindProperty(VendorMaterialNom, x => x.Vendor);

            _materialButtonEditAssistent = 
                new ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit>(beMaterial, 
                    VendorMaterialNom.Material, OnDialogOutput);
            _materialButtonEditAssistent.BindProperty(VendorMaterialNom, x => x.Material);
            _materialButtonEditAssistent.ExternalFilterExp =
                material => material.ContainsVendor(VendorMaterialNom.Vendor);

            _brandButtonEditAssistent =
                new ButtonEditAssistent<Brand, FxVendorBrands, FxVendorEdit>(beBrend, VendorMaterialNom.Brand, OnDialogOutput);
            _brandButtonEditAssistent.BindProperty(VendorMaterialNom, x => x.Brand);
            _brandButtonEditAssistent.SelectionFormFiltersSetup = () => 
                new FxVendorBrands{Material = VendorMaterialNom.Material, Vendor = VendorMaterialNom.Vendor};

            _tradeMarkButtonEditAssistent = 
                new ButtonEditAssistent<TradeMark, FxTradeMarks, FxTradeMarkEdit>(beTradeMark, VendorMaterialNom.TradeMark, OnDialogOutput);
            _tradeMarkButtonEditAssistent.BindProperty(VendorMaterialNom, x => x.TradeMark);
            _tradeMarkButtonEditAssistent.SelectionFormFiltersSetup = () => 
                new FxTradeMarks
                {
                    Material = VendorMaterialNom.Material,
                    Vendor = VendorMaterialNom.Vendor, 
                    Brand = VendorMaterialNom.Brand
                };

            _markTypeButtonEditAssistent = 
                new ButtonEditAssistent<MaterialMarkType, FxMaterialMarkTypes, FxMaterialMarkTypeEdit>(beMarkMaterialType, 
                    VendorMaterialNom.MaterialMarkType, OnDialogOutput);
            _markTypeButtonEditAssistent.BindProperty(VendorMaterialNom, x => x.MaterialMarkType);
            _markTypeButtonEditAssistent.SelectionFormFiltersSetup = () =>
                new FxMaterialMarkTypes {Material = VendorMaterialNom.Material};
        }

        protected override IEntity GetEntity()
        {
            return VendorMaterialNom;
        }

        protected override void SetEntity(IEntity value)
        {
            VendorMaterialNom = value as VendorMaterialNom;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, VendorMaterialNom, x => x.Name);
            BindEditor(teMark, VendorMaterialNom, x => x.Mark);
            BindEditor(teRAL, VendorMaterialNom, x => x.ColorRal);
            BindEditor(seTransp, VendorMaterialNom, x => x.ColorTransparency);
        }
        
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beVendor, beMaterial, beMarkMaterialType };
        }

        private void Editor_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void SaveEntity<T>(T entity)
            where T : class, IEntity, new()
        {
            DataHelper.Save(entity);
        }

        private void beTradeMark_EditValueChanged(object sender, EventArgs e)
        {
            TradeMark _tradeMark = beTradeMark.EditValue as TradeMark;
            if (_tradeMark != null)
            {
                Material _material = beMaterial.EditValue as Material;
                if (_material == null || _material.Id != _tradeMark.Material.Id)
                    beMaterial.EditValue = _tradeMark.Material;

                Brand _brand = beBrend.EditValue as Brand;
                if ((_brand == null && _tradeMark.Brand != null) 
                    || (_brand != null && _tradeMark.Brand != null && _brand.Id != _tradeMark.Brand.Id))
                    beBrend.EditValue = _tradeMark.Brand;
            }
        }

        private void beBrend_EditValueChanged(object sender, EventArgs e)
        {
            Brand _brand = beBrend.EditValue as Brand;
            if (_brand != null)
            {
                Material _material = beMaterial.EditValue as Material;
                if (_material == null)
                    beMaterial.EditValue = _brand.Material;
            }
        }
    }
}