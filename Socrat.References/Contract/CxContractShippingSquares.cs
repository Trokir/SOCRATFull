using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contract
{
    public partial class CxContractShippingSquares : CxGenericListTable<ContractShippingSquare>
    {
        public Core.Entities.Contract Contract { get; set; }

        public CxContractShippingSquares()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Объем от кв.м", "SquAmount", 120, 0);
            AddColumn("Цена доставки за 1 кв.м", "PriceSqu", 120, 1);
            AddColumn("colEditDate", "Изменен", "EditDate", DevExpress.Utils.FormatType.DateTime, "dd.MM.yyy HH.mm", 140, 2);
            AddColumn("Изменил", "User", 120, 3);
        }

        protected override ObservableCollection<ContractShippingSquare> GetItems()
        {
            return Contract.ContractShippingSquares;
        }

        protected override ContractShippingSquare GetNewInstance()
        {
            return new ContractShippingSquare { Contract = Contract };
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractShippingSquareEdit();
        }
    }
}
