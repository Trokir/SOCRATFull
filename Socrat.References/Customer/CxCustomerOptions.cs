using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Customer
{
    public partial class CxCustomerOptions : CxCustomerControl
    {
        private List<Country> _countries = null;
        private List<Currency> _currencies = null;

        public CxCustomerOptions()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            Load += OnLoad;
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            _countries = DataHelper.GetAll<Country>();
            _currencies = DataHelper.GetAll<Currency>();

            lueCurrency.Properties.DataSource = null;
            lueCurrency.Properties.DataSource = _currencies;

            lueCountry.Properties.DataSource = null;
            lueCountry.Properties.DataSource = _countries;

            BindData();

            InitValidateControls();

            base.OnLoad(sender, e);
        }


        private bool _ReadOly;
        public bool ReadOly
        {
            get { return _ReadOly;}
            set { SetValue(value); }

        }

        private void SetValue(bool value)
        {
            _ReadOly = value;
            ceAccess.ReadOnly = value;
            teLogin.ReadOnly = value;
            tePassword.ReadOnly = value;
            ceBan.ReadOnly = value;
            ceBanOrders.ReadOnly = value;
            ceStopProcess.ReadOnly = value;
            lueCountry.ReadOnly = value;
            lueCurrency.ReadOnly = value;
        }

        private void BindData()
        {

            lueCountry.EditValue = _customer?.Country?.Id;
            lueCurrency.EditValue = _customer?.Currency?.Id;

            ceBanOrders.Checked = _customer.OrderLock ?? false;
            ceStopProcess.Checked = _customer.ProdLoсk ?? false;
        }

        private void ceVip_CheckedChanged(object sender, EventArgs e)
        {
            //Setting.VIP = ceVip.Checked;
        }

        private void ceBan_CheckedChanged(object sender, EventArgs e)
        {
            //Setting.DenyActions = ceBan.Checked;
        }

        private void ceBanOrders_CheckedChanged(object sender, EventArgs e)
        {
            _customer.OrderLock = ceBanOrders.Checked;
        }

        private void ceStopProcess_CheckedChanged(object sender, EventArgs e)
        {
            _customer.ProdLoсk = ceStopProcess.Checked;
        }

        private void lueCountry_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueCountry.EditValue != null && Guid.TryParse(lueCountry.EditValue.ToString(), out _id))
            {
                _customer.Country = _countries.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void lueCurrency_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueCurrency.EditValue != null && Guid.TryParse(lueCurrency.EditValue.ToString(), out _id))
            {
                _customer.Currency = _currencies.FirstOrDefault(x => x.Id == _id);

            }
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                lueCountry,
                lueCurrency
            };
        }
    }
}
