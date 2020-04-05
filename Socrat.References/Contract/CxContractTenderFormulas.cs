using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;


namespace Socrat.References.Contract
{
    public partial class CxContractTenderFormulas : CxGenericListTable<ContractTenderFormula>
    {
        private Core.Entities.Contract _contract;
        public Core.Entities.Contract Contract
        {
            get { return _contract; }
            set { _contract = value; }
        }

        public CxContractTenderFormulas()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Формула изделия", "Formula", 200, 0);
            AddColumn("Цена за кв.м", "Price", 150, 1);
            AddColumn("Использовано кв.м", "SquReady", 150, 2);
            AddColumn("Лимит кв.м", "Limit", 150, 3);
        }

        protected override ObservableCollection<ContractTenderFormula> GetItems()
        {
            return Contract.ContractTenderFormulas;
        }

        protected override ContractTenderFormula GetNewInstance()
        {
            return new ContractTenderFormula { Contract = this.Contract};
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractTenderFormulaEdit();
        }
    }
}
