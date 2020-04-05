using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.DataProvider.Repos;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxBrandEdit : FxBaseSimpleDialog
    {
        public Brand Brand { get; set; }
        private List<Material> _Material;

        public FxBrandEdit()
        {
            InitializeComponent();
            Load += FxBrandNameEdit_Load;
        }

        private void FxBrandNameEdit_Load(object sender, EventArgs e)
        {
            if (Brand.Vendor != null && Brand.Vendor.VendorMaterials != null)
            {
                _Material = Brand.Vendor.VendorMaterials.Select(x => x.Material).ToList();
            }
            else
            {
                _Material = DataHelper.GetAll<Material>();
            }

            lueType.Properties.DataSource = _Material;
            if (Brand.Material == null && _Material != null && _Material.Count > 0)
            {
                Brand.Material = _Material.First();
                lueType.EditValue = Brand.Material.Id;
            }
        }

        protected override IEntity GetEntity()
        {
            return Brand;
        }

        protected override void SetEntity(IEntity value)
        {
            Brand = value as Brand;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Brand, x => x.Name);
            lueType.EditValue = Brand?.Material?.Id;
        }

        private void lueType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_Material != null && lueType.EditValue != null && Guid.TryParse(lueType.EditValue.ToString(), out _id))
            {
                Brand.Material = _Material.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueType, teName };
        }
    }
}