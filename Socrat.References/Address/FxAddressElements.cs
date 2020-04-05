using Socrat.Core.Entities;

namespace Socrat.References.Address
{
    public partial class FxAddressElements : FxGenericListTable<AddressElement>
    {
        public FxAddressElements()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Тип элемента", "AddressElementType", 200, 0);
            AddColumn("Наименование", "Name", 200, 1);
            AddColumn("Соокращение", "ShortName", 100, 2);
            AddColumn("Код","Code", 80, 3);
            GroupByColumn("AddressElementType");
        }
    }
}