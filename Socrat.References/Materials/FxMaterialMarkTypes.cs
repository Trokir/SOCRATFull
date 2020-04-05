using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class FxMaterialMarkTypes : FxGenericListTable<MaterialMarkType>
    {
        public FxMaterialMarkTypes()
        {
            InitializeComponent();
        }

        public Material Material { get; set; }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип материала", "MaterialType", 160, 0);
            AddObjectColumn("Материал", "Material", 200, 1);
            AddColumn("Наименование", "Name", 200, 2);
            AddColumn("Марка", "Mark", 200, 3);
            AddColumn("Марка ГОСТ", "GostMark", 200, 4);
            GroupByColumn("MaterialType");
            GroupByColumn("Material");
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialMarkTypeEdit();
        }

        protected override MaterialMarkType GetNewInstance()
        {
            return new MaterialMarkType { Material = this.Material};
        }

        protected override void LoadData()
        {
            if (Material == null)
                Items = Repository.GetAll().ToList();
            else
                Items = Repository.GetAll().Where(x => x.Material.Id == Material.Id).ToList();
            if (Items != null && Items.Count > 0)
                Items.OrderBy(x => x.Material.MaterialType.Id).OrderBy(x => x.Material.Id);
        }

        protected override string GetTitle()
        {
            return "Типы материалов по ГОСТ и назначению";
        }
    }
}