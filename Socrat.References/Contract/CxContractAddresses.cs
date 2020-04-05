using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contract
{
    public partial class CxContractAddresses : CxGenericListTable<ContractAddress>
    {
        public Core.Entities.Contract Contract { get; set; }

        public CxContractAddresses()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<ContractAddress> GetItems()
        {
            return Contract?.ContractAddresses;
        }

        protected override void InitColumns()
        {
            AddColumn("Регион", "District", 200, 0);
            AddColumn("Удаленность", "DistanceLength", 120, 1);
            AddObjectColumn("Адрес", "Address", 120, 2);
            AddColumn("По умолчанию", "Default", 120, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractAddressEdit();
        }

        protected override ContractAddress GetNewInstance()
        {
            return new ContractAddress { Contract = this.Contract, Address = new Core.Entities.Address() };
        }
    }
}
