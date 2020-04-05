using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Address;

namespace Socrat.References.Customer
{
    public partial class CxLegalCommon : CxCustomerControl
    {
        private AddressButtonEditAssistent _legalAddressButtonEditAssistent;
        private AddressButtonEditAssistent _actualAddressButtonEditAssistent;

        public CxLegalCommon()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            Load += OnLoad;

    }

        private List<Opf> _opfs = null;
        private List<Country> _countries = null;

        protected override void OnLoad(object sender, EventArgs e)
        {
            _opfs = DataHelper.GetAll<Opf>().Where(x => (x.IsIP ?? false) != true).ToList();
            _countries = DataHelper.GetAll<Country>();

            if (_customer != null)
                    BindData();

            lueLegalForm.Properties.DataSource = null;
            lueLegalForm.Properties.DataSource = _opfs;

            InitValidateControls();

            _legalAddressButtonEditAssistent = new AddressButtonEditAssistent(beLegalAddress, Customer.LegalAddress, null, OnDialogOutput);
            _legalAddressButtonEditAssistent.BindProperty(Customer, x => x.LegalAddress);

            _actualAddressButtonEditAssistent = new AddressButtonEditAssistent(beActualAddress, Customer.ActualAddress, null, OnDialogOutput);
            _actualAddressButtonEditAssistent.BindProperty(Customer, x => x.ActualAddress);

            base.OnLoad(sender, e);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                lueLegalForm,
                teName,
                teShortName,
                teAlias
            };
        }

        private void BindData()
        {
            lcFullName.DataBindings.Clear();
            lcFullName.DataBindings.Add("Text", Customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", _customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            teShortName.DataBindings.Clear();
            teShortName.DataBindings.Add("EditValue", _customer, "ShortName", true, DataSourceUpdateMode.OnPropertyChanged);
            teForaign.DataBindings.Clear();
            teForaign.DataBindings.Add("EditValue", _customer, "ForeignName", true, DataSourceUpdateMode.OnPropertyChanged);
            teOGRN.DataBindings.Clear();
            teOGRN.DataBindings.Add("EditValue", _customer, "Ogrn", true, DataSourceUpdateMode.OnPropertyChanged);
            teINN.DataBindings.Clear();
            teINN.DataBindings.Add("EditValue", _customer, "Inn", true, DataSourceUpdateMode.OnPropertyChanged);
            te1cCode.DataBindings.Clear();
            te1cCode.DataBindings.Add("EditValue", _customer, "Code1C", true, DataSourceUpdateMode.OnPropertyChanged);
            teKPP.DataBindings.Clear();
            teKPP.DataBindings.Add("EditValue", _customer, "Kpp", true, DataSourceUpdateMode.OnPropertyChanged);
            deReg.DataBindings.Clear();
            deReg.DataBindings.Add("DateTime", _customer, "DateReg", true, DataSourceUpdateMode.OnPropertyChanged);
            teAlias.DataBindings.Clear();
            teAlias.DataBindings.Add("EditValue", _customer, "AliasName", true, DataSourceUpdateMode.OnPropertyChanged);

            deReg.DateTime = _customer.DateReg ?? DateTime.Today;
            ceSimpleTax.Checked = _customer.TaxUsn ?? false;
            ceEnvdTax.Checked = _customer.TaxEnvd ?? false;

            beLegalAddress.EditValue = Customer.LegalAddress;
            beActualAddress.EditValue = Customer.ActualAddress;
            lueLegalForm.EditValue = Customer?.Opf?.Id;
        }


        protected override void SetReadOnly(bool value)
        {
            _readOnly = value;
            lueLegalForm.ReadOnly = value;
            teName.ReadOnly = value;
            teShortName.ReadOnly = value;
            teForaign.ReadOnly = value;
            teOGRN.ReadOnly = value;
            teINN.ReadOnly = value;
            te1cCode.ReadOnly = value;
            teKPP.ReadOnly = value;
            deReg.ReadOnly = value;
            teAlias.ReadOnly = value;
            beActualAddress.ReadOnly = value;
            beLegalAddress.ReadOnly = value;
        }

        private void deReg_EditValueChanged(object sender, EventArgs e)
        {
            _customer.DateReg = deReg.DateTime;
        }

        private void ceSimpleTax_CheckedChanged(object sender, EventArgs e)
        {
            _customer.TaxUsn = ceSimpleTax.Checked;
        }

        private void ceEnvdTax_CheckedChanged(object sender, EventArgs e)
        {
            _customer.TaxEnvd = ceEnvdTax.Checked;
        }

        private void lueLegalForm_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueLegalForm.EditValue != null && Guid.TryParse(lueLegalForm.EditValue.ToString(), out _id))
            {
                _customer.Opf = _opfs.FirstOrDefault(x => x.Id == _id);
            }
        }

        //private void beUrAdr_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    //if (Customer.LegalAddress == null)
        //    //    Customer.LegalAddress = new Core.Entities.Address();
        //    //FxAddressEdit _fx = new FxAddressEdit();
        //    //_fx.Address = Customer.LegalAddress;
        //    //_fx.SaveButtonClick += (o, args) =>
        //    //{
        //    //    Customer.LegalAddress = _fx.Address;
        //    //    DevExpress.XtraEditors.ButtonEdit edit = sender as DevExpress.XtraEditors.ButtonEdit;
        //    //    edit.Text = _fx.Address.ToString();
        //    //    edit.EditValue = _fx.Address;
        //    //};
        //    //_fx.DialogOutput += (o, ta) => { OnDialogOutput(ta); };
        //    //OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}

        //private void beActualAddress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    //if (Customer.ActualAddress == null)
        //    //    Customer.ActualAddress = new Core.Entities.Address();
        //    //FxAddressEdit _fx = new FxAddressEdit();
        //    //_fx.Address = Customer.ActualAddress;
        //    //_fx.SaveButtonClick += (o, args) =>
        //    //{
        //    //    Customer.ActualAddress = _fx.Address;
        //    //    DevExpress.XtraEditors.ButtonEdit edit = sender as DevExpress.XtraEditors.ButtonEdit;
        //    //    edit.Text = _fx.Address.ToString();
        //    //    edit.EditValue = _fx.Address;
        //    //};
        //    //_fx.DialogOutput += (o, ta) => { OnDialogOutput(ta); };
        //    //OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}
    }
}
