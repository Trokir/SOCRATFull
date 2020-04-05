using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Address;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxContractAddressEdit : FxBaseSimpleDialog
    {
        private AddressButtonEditAssistent _addressButtonEditAssistent;

        private ContractAddress _contractAddress;
        public ContractAddress ContractAddress
        {
            get => _contractAddress;
            set => SetcontractAddress(value);
        }

        private void SetcontractAddress(ContractAddress value)
        {
            _contractAddress = value;
            InitContacts();
        }

        private CxAddressContacts _cxAddressContacts;


        public FxContractAddressEdit()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _addressButtonEditAssistent = new AddressButtonEditAssistent(beAddress, ContractAddress.Address, null, OnDialogOutput);
            _addressButtonEditAssistent.BindProperty(ContractAddress, x => x.Address);
        }

        private void InitContacts()
        {
            _cxAddressContacts = new CxAddressContacts();
            _cxAddressContacts.Address = this.ContractAddress.Address;
            pcContacts.Controls.Add(_cxAddressContacts);
            _cxAddressContacts.DialogOutput += CxAddressContactsDialogOutput;
            _cxAddressContacts.Dock = DockStyle.Fill;
        }

        private void CxAddressContactsDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override IEntity GetEntity()
        {
            return ContractAddress;
        }

        protected override void SetEntity(IEntity value)
        {
            ContractAddress = value as ContractAddress;
        }


        protected override void BindData()
        {
            base.BindData();
            beAddress.EditValue = ContractAddress.Address;
            beDivision.EditValue = ContractAddress.Contract.Division;
            beDivision.Enabled = false;
            BindEditor(teRegionCode, ContractAddress, x => x.District);
            BindEditor(teDisatanceMark, ContractAddress, x => x.DistanceMark);
            BindEditor(teDistanceLength, ContractAddress, x => x.DistanceLength);
            BindEditor(teComment, ContractAddress, x => x.Comment);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beAddress, teRegionCode, teDisatanceMark};
        }
    }
}