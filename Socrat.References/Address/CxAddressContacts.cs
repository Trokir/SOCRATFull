using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Contract;

namespace Socrat.References.Address
{
    public partial class CxAddressContacts : CxGenericListTable<AddressContact>
    {
        public Core.Entities.Address Address { get; set; }

        public CxAddressContacts()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Тел.", "Value", 200, 0);
            AddColumn("Контактное лицо", "Name", 200, 1);
            AddColumn("Должность", "WorkPosition", 200, 1);
        }

        protected override ObservableCollection<AddressContact> GetItems()
        {
            return new ObservableCollection<AddressContact>(Address?.AddressContacts);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxAddressContactEdit();
        }

        protected override AddressContact GetNewInstance()
        {
            return new AddressContact { Address = this.Address };
        }
    }
}
