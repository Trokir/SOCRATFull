using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxContractTenderFormulaEdit : FxBaseSimpleDialog
    {
        public ContractTenderFormula ContractTenderFormula { get; set; }

        public FxContractTenderFormulaEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return ContractTenderFormula;
        }

        protected override void SetEntity(IEntity value)
        {
            ContractTenderFormula = value as ContractTenderFormula;
        }

        protected override void BindData()
        {
            base.BindData();
            beFormula.EditValue = ContractTenderFormula.Formula;
            BindEditor(tePrice, ContractTenderFormula, x => x.Price);
            BindEditor(teLimit, ContractTenderFormula, x => x.Limit);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{beFormula, tePrice, teLimit};
        }

        private void beFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (ContractTenderFormula != null)
            {
                if (ContractTenderFormula.Formula == null)
                    ContractTenderFormula.Formula = new Core.Entities.Formula();
                FxFormulaEdit _fx = new FxFormulaEdit();
                _fx.Entity = ContractTenderFormula.Formula;
                _fx.DialogOutput += _fx_DialogOutput;
                _fx.SaveButtonClick += (o, args) =>
                {
                    SaveEntity((Core.Entities.Formula) _fx.Entity);
                    beFormula.EditValue = ContractTenderFormula.Formula;
                };
                OnDialogOutput(_fx, DialogOutputType.Dialog, this);
            }
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void SaveEntity(Core.Entities.Formula formula)
        {
            DataHelper.Save<Core.Entities.Formula>(formula);
        }
    }
}