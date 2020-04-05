using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contract
{
    public partial class FxContractTypes : FxGenericListTable<ContractType>
    {
        public FxContractTypes()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxNamedEntityEdit("Тип договора");
        }

        protected override string GetTitle()
        {
            return "Типы договоров";
        }
    }
}