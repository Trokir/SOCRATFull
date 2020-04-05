using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;


namespace Socrat.References.Materials
{
    public partial class FxMaterialSizeTypeList : FxGenericListTable<MaterialSizeType>
    {
        public Material Material { get; set; }
        public  MaterialMarkType MaterialMarkType { get; set; }
        public FxMaterialSizeTypeList()
        {
            InitializeComponent();
        }

        protected override void LoadData()
        {
            var _qry = Repository.GetAll();
            if (MaterialMarkType != null)
                _qry = _qry.Where(x => x.MaterialMarkTypeId == MaterialMarkType.Id);
            else if (Material != null)
                _qry = Repository.GetIncludeAll(x => x.MaterialMarkType.MaterialId == Material.Id,
                    m => m.MaterialMarkType);
            Items = _qry.ToList();
        }

        protected override void InitColumns()
        {
            AddColumn("Код", "Code", 160, 0);
            AddColumn("Толщина", "Thickness", 80, 1);
            AddColumn("Тип материала по ГОСТ", "MaterialMarkType", 160, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialSizeTypeEdit { Material = this.Material};
        }

        protected override string GetTitle()
        {
            return "Типоразмеры материала";
        }
    }
}