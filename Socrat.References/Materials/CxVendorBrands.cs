using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Materials
{
    public partial class CxVendorBrands : CxGenericListTable<Brand>
    {
        public Vendor Vendor { get; set; }
        public Material Material { get; set; }
        public ObservableCollection<Brand> _Items;
        public CxVendorBrands()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Материал", "Material", 160, 0);
            AddColumn("Наименование", "Name", 200, 1);
        }

        protected override ObservableCollection<Brand> GetItems()
        {
            if (Vendor != null && Material != null)
                return new ObservableCollection<Brand>(Vendor.Brands.Where(x => x.MaterialId == Material.Id));
            if (Vendor != null)
                return Vendor.Brands;
            if (Material != null)
                return Material.Brands;
            return new ObservableCollection<Brand>(DataHelper.GetAll<Brand>());
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxBrandEdit();
        }

        protected override Brand GetNewInstance()
        {
            return new Brand { Vendor = this.Vendor, Name = this.Vendor.Name };
        }
    }
}
