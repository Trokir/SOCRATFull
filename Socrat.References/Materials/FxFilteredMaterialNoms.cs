using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Core;

namespace Socrat.References.Materials
{
    public partial class FxFilteredMaterialNoms : FxGenericListTable<MaterialNom>
    {
        public Material Material { get; set; }
        public MaterialMarkType MaterialMarkType { get; set; }

        public FxFilteredMaterialNoms()
        {
            InitializeComponent();
        }

        protected override void LoadData()
        {
            IQueryable<MaterialNom> qry = Repository.GetAll();
            if (MaterialMarkType != null)
                qry = Repository.GetIncludeAll(x => x.VendorMaterialNom.MaterialMarkTypeId == MaterialMarkType.Id, i => i.VendorMaterialNom);
            else if (Material != null)
                qry = Repository.GetIncludeAll(x => x.VendorMaterialNom.MaterialId == Material.Id, i => i.VendorMaterialNom);
            Items = qry.ToList();
        }

        protected override void InitColumns()
        {
            AddColumn("Код", "Code", 180, 2);
            AddObjectColumn("Материал", "VendorMaterialNom", 120, 3);
            AddColumn("Толщина", "Thickness", 120, 4);
            AddColumn("Код 1С", "Code1C", 180, 5);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialNomEdit();
        }

        protected override string GetTitle()
        {
            return $"Номенклатура материала {Material}";
        }
    }
}