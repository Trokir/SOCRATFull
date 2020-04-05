using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.References.Address;
using Socrat.UI.Core;

namespace Socrat.References.Bank
{
    public partial class FxBankEdit : FxBaseSimpleDialog
    {
        private AddressButtonEditAssistent _addressButtonEditAssistent;

        private Core.Entities.Bank _bank;
        public Core.Entities.Bank Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        public FxBankEdit()
        {
            InitializeComponent();
            Load += FxBankEdit_Load;
        }

        private void FxBankEdit_Load(object sender, System.EventArgs e)
        {
            _addressButtonEditAssistent = new AddressButtonEditAssistent(beAddress, Bank.Address, null, OnDialogOutput);
            _addressButtonEditAssistent.BindProperty(Bank, x => x.Address);
        }


        protected override void BindData()
        {
            base.BindData();
            BindEditor(teAlias, _bank, x => x.Alias);
            BindEditor(teShortName, _bank, x => x.ShortName);
            BindEditor(teFilial, _bank, x => x.Filial);
            BindEditor(teBIK, _bank, x => x.Bik);
            BindEditor(teKS, _bank, x => x.Ks);
            BindEditor(tePhone, _bank, x => x.Phone);
            BindEditor(teComment, _bank, x => x.Comment);
            beAddress.EditValue = Bank.Address;
        }

        protected override void SetEntity(IEntity value)
        {
            _bank = value as Core.Entities.Bank;
        }

        protected override IEntity GetEntity()
        {
            return _bank;
        }

        protected override string GetTitle()
        {
            return Bank?.Title;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            layoutControl.Controls.OfType<BaseEdit>().ForEach(x => x.ReadOnly = value);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teAlias, teShortName, teBIK, teKS};
        }
    }
}
