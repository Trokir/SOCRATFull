using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomenclature : FxGenericListTable<MaterialNom>
    {
        public FxMaterialNomenclature()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип", "MaterialType", 180, 0);
            AddObjectColumn("Материал", "Material", 180, 1);
            AddObjectColumn("Производитель", "Vendor", 180, 2);
            GroupByColumn("MaterialType");
            GroupByColumn("Material");
            GroupByColumn("VendorId");
            AddColumn("Код", "Code", 180, 3);
            AddObjectColumn("Наименование", "VendorMaterialNom", 120, 4);
            AddColumn("Толщина", "Thickness", 120, 5);
            AddColumn("Код 1С", "Code1C", 180, 6);
        }

        protected override IEntityEditor GetEditor()
        {
            MaterialNom _focusedItem = GetFocusedItem();
            if (_focusedItem != null)
                return new FxMaterialNomEdit
                {
                    Material = _focusedItem.Material,
                    MaterialMarkType = _focusedItem?.VendorMaterialNom.MaterialMarkType
                };
            return new FxMaterialNomEdit();
        }

        protected override string GetTitle()
        {
            return "Номенклатура материалов";
        }
    }
}