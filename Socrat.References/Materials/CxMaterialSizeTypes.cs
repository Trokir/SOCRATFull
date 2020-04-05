using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;


namespace Socrat.References.Materials
{
    public partial class CxMaterialSizeTypes : CxGenericListTable<MaterialSizeType>
    {
        public MaterialMarkType MaterialMarkType { get; set; }  

        public CxMaterialSizeTypes()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<MaterialSizeType> GetItems()
        {
            if (MaterialMarkType != null)
                return MaterialMarkType.MaterialSizeTypes;
            return new ObservableCollection<MaterialSizeType>(DataHelper.GetAll<MaterialSizeType>());
        }

        protected override void InitColumns()
        {
            AddColumn("Толщина", "Thickness", 70, 0);
            AddColumn("Код", "Code", 70, 1);
            AddColumn("Единица измерения", "Measure", 150, 2);
            AddObjectColumn("Номенклатура по-умолчанию", "DefaultMaterialNom", 200, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialSizeEdit {MaterialMarkType = MaterialMarkType};
        }

        protected override MaterialSizeType GetNewInstance()
        {
            return new MaterialSizeType {MaterialMarkType = MaterialMarkType};
        }

        protected override string GetTitle()
        {
            return "Типоразмеры материалов";
        }
    }
}
