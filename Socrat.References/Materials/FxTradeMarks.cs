using System;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxTradeMarks : FxGenericListTable<TradeMark>
    {
        private Material _material;
        private Brand _brand;
        private Vendor _vendor;
        public Brand Brand
        {
            get => _brand;
            set => SetBrand(value);
        }
        public Vendor Vendor
        {
            get => _vendor;
            set => SetVendor(value);
        }
        public Material Material
        {
            get { return _material; }
            set { SetMaterial(value); }
        }

        public FxTradeMarks()
        {
            InitializeComponent();
            RowHighlightingExp = mark => mark.VendorId == null && mark.BrandId == null;
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 160, 0);
            AddObjectColumn("Производитель", "Vendor", 160, 1);
            AddObjectColumn("Бренд", "Brand", 160, 2);
            AddColumn("Наименование", "Name", 200, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxTradeMarkEdit{ Vendor = _vendor ?? Brand?.Vendor};
        }

        protected override string GetTitle()
        {
            return "Торговые марки";
        }

        protected override TradeMark GetNewInstance()
        {
            return new TradeMark { Vendor = _vendor, Brand = this.Brand};
        }

        private void SetMaterial(Material value)
        {
            _material = value;
            RefreshData();
        }

        private void SetBrand(Brand value)
        {
            _brand = value;
            RefreshData();
        }

        private void SetVendor(Vendor value)
        {
            _vendor = value;
            RefreshData();
        }

        protected override void LoadData()
        {
            IQueryable<TradeMark> _query = Repository.GetAll();
            if (Vendor == null)
            {
                if (Material != null)
                    _query = _query.Where(x => x.MaterialId == Material.Id);
                if (Material == null && Vendor != null && Vendor.VendorMaterials != null &&
                    Vendor.VendorMaterials.Count > 0)
                {
                    var _materials = Vendor.VendorMaterials.Select(x => x.MaterialId);
                    _query = _query.Where(x => _materials.Contains(x.MaterialId ?? Guid.Empty));
                }

                if (Brand != null)
                    _query = _query.Where(x => x.BrandId == Brand.Id);
                _items = _query.ToList();

            }
            else
            {
                _items = Vendor.TradeMarks.ToList();
                if (Material != null)
                    _items = _items.Where(x => x.MaterialId == Material.Id).ToList();
                if (Brand != null)
                    _items = _items.Where(x => x.BrandId == Brand.Id).ToList();
            }
        }
    }
}
