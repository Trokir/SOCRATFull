using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxContractPriceEdit : FxBaseSimpleDialog
    {
        public ContractPrice ContractPrice { get; set; }

        public FxContractPriceEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return ContractPrice;
        }

        protected override void SetEntity(IEntity value)
        {
            ContractPrice = value as ContractPrice;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueColumn, teDiscoint, teCorrect};
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teDiscoint, ContractPrice, x => x.Discount);
            BindEditor(teCorrect, ContractPrice, x => x.Delta);
        }
    }
}