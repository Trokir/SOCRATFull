using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Materials
{
    public partial class FxVendorBrands : FxGenericListTable<Brand>
    {
        public FxVendorBrands()
        {
            InitializeComponent();
        }
        public Vendor Vendor { get; set; }
        public Material Material { get; set; }


        protected override void InitColumns()
        {
            AddColumn("Материал", "Material", 160, 0);
            AddColumn("Наименование", "Name", 200, 1);
        }

        protected override void LoadData()
        {
            if (Vendor != null)
                _items = Vendor.Brands.ToList();
            if (Material != null)
                _items = Material.Brands.ToList();
            if (Vendor != null && Material != null)
                _items = Vendor.Brands.Where(x => x.MaterialId == Material.Id).ToList();
            if (Vendor == null && Material == null)
                base.LoadData();
        }


        protected override IEntityEditor GetEditor()
        {
            return new FxBrandEdit();
        }

        protected override Brand GetNewInstance()
        {
            return new Brand { Vendor = this.Vendor, Name = this.Vendor?.Name };
        }


        protected override string GetTitle()
        {
            return $"Бренды производителя {Vendor}";
        }
    }
}
