using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class CxVendorMaterialNom : CxGenericListTable<VendorMaterialNom>
    {
        public Vendor Vendor { get; set; }

        public CxVendorMaterialNom()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 120, 0);
            AddObjectColumn("Бренд", "Brand", 200, 1);
            AddObjectColumn("Торговая марка", "TradeMark", 200, 2);
            AddColumn("Наименование", "Name", 200, 3);
            AddColumn("Маркировка", "Mark", 100, 4);
        }

        protected override ObservableCollection<VendorMaterialNom> GetItems()
        {
            return Vendor.VendorMaterialNoms;
        }

        protected override VendorMaterialNom GetNewInstance()
        {
            Material _defaultMaterial = Vendor.VendorMaterials?.Select(x => x.Material)?.FirstOrDefault();
            return new VendorMaterialNom { Vendor = this.Vendor, Material = _defaultMaterial };
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorMaterialNomEdit { LockVendor = true };
        }
    }
}
