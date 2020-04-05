using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterialSizeTypes : FxGenericListTable<MaterialSizeType>
    {
        public FxMaterialSizeTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 120, 0);
            AddColumn("Код", "Code", 70, 1);
            AddColumn("Толщина", "Thickness", 70, 2);
            AddColumn("Единица измерения", "Measure", 150, 3);
            AddObjectColumn("Тип материала по ГОСТ", "MaterialMarkType", 200, 4);
            AddObjectColumn("Номенклатура по-умолчанию", "DefaultMaterialNom", 200, 5);
            GroupByColumn("Material");
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialSizeTypeEdit();
        }

        protected override string GetTitle()
        {
            return "Типоразмеры материалов";
        }
    }
}