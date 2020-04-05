using Socrat.Core.Entities;

namespace Socrat.References.Address
{
    public partial class FxAddressElementType : FxGenericListTable<AddressElementType>
    {
        public FxAddressElementType()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
            AddColumn("Код", "Code", 160, 1);
            AddColumn("Порядок сортировки", "Sort", 60, 2);
            AddColumn("Энумератор", "AddressElementTypeNum", 100, 3);
        }
    }
}