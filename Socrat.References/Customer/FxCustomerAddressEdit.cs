using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Address;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxCustomerAddressEdit : FxBaseSimpleDialog
    {
        public CustomerAddress CustomerAddress { get; set; }
        private CxAddressContacts _cxAddressContacts;
        private AddressButtonEditAssistent _customerAddressButtonEditAssistent;

        public FxCustomerAddressEdit()
        {
            InitializeComponent();
            Load += FxCustomerAddressEdit_Load;
        }

        private void FxCustomerAddressEdit_Load(object sender, System.EventArgs e)
        {
            InitContacts();
            _customerAddressButtonEditAssistent = new AddressButtonEditAssistent(beAddress, CustomerAddress.Address, null, OnDialogOutput);
            _customerAddressButtonEditAssistent.BindProperty(CustomerAddress, x => x.Address);
        }

        private void InitContacts()
        {
            _cxAddressContacts = new CxAddressContacts();
            _cxAddressContacts.Address = CustomerAddress?.Address;
            pcContacts.Controls.Add(_cxAddressContacts);
            _cxAddressContacts.Dock = DockStyle.Fill;
            _cxAddressContacts.DialogOutput += _cxAddressContacts_DialogOutput;
        }

        private void _cxAddressContacts_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override IEntity GetEntity()
        {
            return CustomerAddress;
        }

        protected override void SetEntity(IEntity value)
        {
            CustomerAddress = value as CustomerAddress;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beAddress };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(beAddress, CustomerAddress, x => x.Address);
            BindEditor(teComment, CustomerAddress, x => x.Comment);
            ceProduction.Checked = CustomerAddress.IsProduction ?? false;
        }

        private void ceProduction_CheckedChanged(object sender, System.EventArgs e)
        {
            CustomerAddress.IsProduction = ceProduction.Checked;
        }
    }
}