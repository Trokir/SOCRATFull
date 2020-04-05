using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxTradeMarkEdit : FxBaseSimpleDialog
    {
        public TradeMark TradeMark { get; set; }
        private ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit> _vendorButtonEditAssistent;
        private ButtonEditAssistent<Brand, FxVendorBrands, FxBrandEdit> _brandButtonEditAssistent;

        public Vendor Vendor
        {
            get => _vendor;
            set => SetVendor(value);
        }

        public Material Material { get; set; }

        private List<Material> _materials;
        private List<Brand> _brandNames;
        private Vendor _vendor;
        public bool FixVendor { get; set; }

        public FxTradeMarkEdit()
        {
            InitializeComponent();
            Load += FxTradeMarkEdit_Load;
        }

        private void FxTradeMarkEdit_Load(object sender, System.EventArgs e)
        {
            LoadData();

            _vendorButtonEditAssistent = 
                new ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit>(beVendor, TradeMark.Vendor, OnDialogOutput);
            _vendorButtonEditAssistent.BindProperty(TradeMark, x => x.Vendor);
            _vendorButtonEditAssistent.ExternalFilterExp = vendor => vendor.ContainsMaterial(TradeMark.Material);

            _brandButtonEditAssistent = new ButtonEditAssistent<Brand, FxVendorBrands, FxBrandEdit>(beBrand, TradeMark.Brand, OnDialogOutput);
            _brandButtonEditAssistent.BindProperty(TradeMark, x => x.Brand);
            _brandButtonEditAssistent.ExternalFilterExp = brand =>
                brand.MaterialVendorMaching(TradeMark.Material, TradeMark.Vendor);
            _brandButtonEditAssistent.SelectionFormFiltersSetup = 
                () => new FxVendorBrands { Vendor = this.Vendor, Material = this.Material};
        }

        private void LoadData()
        {
            if (Vendor != null)
            {
                _materials = Vendor.VendorMaterials.Select(x => x.Material).Distinct().ToList();
                if (_materials != null && _materials.Count == 1)
                    TradeMark.Material = _materials.First();
                TradeMark.Vendor = Vendor;
                beVendor.Enabled = !FixVendor;
            }
            else
            {
                _materials = DataHelper.GetAll<Material>();
            }

            lueMaterial.Properties.DataSource = null;
            lueMaterial.Properties.DataSource = _materials;

        }

        protected override IEntity GetEntity()
        {
            return TradeMark;
        }

        protected override void SetEntity(IEntity value)
        {
            TradeMark = value as TradeMark;
        }

        protected override void BindData()
        {
            LoadData();
            base.BindData();
            BindEditor(teName, TradeMark, x => x.Name);
            beBrand.EditValue = TradeMark.Brand;
            beVendor.EditValue = TradeMark.Vendor;
            lueMaterial.EditValue = TradeMark?.Material?.Id;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ lueMaterial, teName };
        }

        private void lueMaterialType_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (_materials != null && lueMaterial.EditValue != null && Guid.TryParse(lueMaterial.EditValue.ToString(), out _id))
            {
                Material material = _materials.FirstOrDefault(x => x.Id == _id);
                if (null != material)
                {
                    if (TradeMark != null)
                        TradeMark.Material = material;
                    beBrand.Enabled = material != null;
                    beVendor.Enabled = material != null && !FixVendor;
                }
            }
        }

        private void SetVendor(Vendor value)
        {
            _vendor = value;
            if (TradeMark != null)
                TradeMark.Vendor = value;
            beVendor.EditValue = value;
            beVendor.Enabled = !FixVendor;

            if (FixVendor)
                _materials = value.VendorMaterials.Select(x => x.Material).Distinct()?.ToList();

            if (value != null && value.VendorMaterials.Count == 1)
            {
                if (TradeMark != null)
                    TradeMark.Material = value.VendorMaterials.First().Material;
                lueMaterial.EditValue = value.VendorMaterials.First().Material.Id;
                lueMaterial.Enabled = !FixVendor;
            }
        }

        private void beBrand_EditValueChanged(object sender, EventArgs e)
        {
            Brand _brand = beBrand.EditValue as Brand;
            if (_brand != null)
            {
                if (TradeMark.Material == null)
                    lueMaterial.EditValue = _brand.Material?.Id;

                if (TradeMark.Vendor == null)
                    beVendor.EditValue = _brand.Vendor;
            }
        }
    }
}