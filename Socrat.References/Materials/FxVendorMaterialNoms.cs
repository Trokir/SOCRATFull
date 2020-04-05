using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;


namespace Socrat.References.Materials
{
    public partial class FxVendorMaterialNoms : FxGenericListTable<VendorMaterialNom>
    {
        public Material Material { get; set; }
        public FxVendorMaterialNoms()
        {
            InitializeComponent();
        }

        protected override List<VendorMaterialNom> GetItems()
        {
            if (Material == null)
                base.GetItems();
            else
            {
                Nullable<Guid> Material_Id = Material?.Id;
                _items = Repository.GetAll(x => x.Material.Id == Material_Id).ToList();
            }
            return _items;
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип материала", "MaterialType", 120, 0);
            AddObjectColumn("Материал", "Material", 120, 0);
            AddObjectColumn("Производитель", "Vendor", 120, 1);
            AddObjectColumn("Бренд", "Brand", 120, 2);
            AddObjectColumn("Торговая марка", "TradeMark", 120, 3);
            AddColumn("Наименование", "Name", 120, 4);
            AddColumn("Маркировка", "Mark", 120, 5);
            GroupByColumn("MaterialType");
            GroupByColumn("Material");
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorMaterialNomEdit();
        }

        protected override string GetTitle()
        {
            return "Наменкалатура производителей";
        }
    }
}