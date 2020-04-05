using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxVendors : FxGenericListTable<Vendor>
    {
        private Material _material;

        public FxVendors()
        {
            InitializeComponent();
        }

        public Material Material
        {
            get { return _material; }
            set { _material = value; }
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Доп. информация", "Description", 200, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorEdit();
        }

        protected override List<Vendor> GetItems()
        {
            if (Material != null)
                _items = Repository
                    .GetIncludeAll(c => c.VendorMaterials.Count(x => x.Material.Id == Material.Id) > 0, x => x.VendorMaterials)
                    .ToList();
            else
                base.GetItems();
            return _items;
        }
    }
}