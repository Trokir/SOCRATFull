using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;


namespace Socrat.References.Materials
{
    public partial class CxMaterialSpecProperties : CxGenericListTable<MaterialSpecProperty>
    {
        public Material Material { get; set; }

        public CxMaterialSpecProperties()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", x => x.Name, 250, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxMaterialSpecPropertyEdit();
        }

        protected override MaterialSpecProperty GetNewInstance()
        {
            return new MaterialSpecProperty { Material = this.Material };
        }

        protected override ObservableCollection<MaterialSpecProperty> GetItems()
        {
            return Material?.MaterialSpecProperties;
        }
    }
}
