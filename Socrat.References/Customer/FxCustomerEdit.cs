using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using Socrat.Core;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxCustomerEdit : FxBaseEditForm
    {
        private CxLegalCommon _cxLegalCommon;
        private CxIpCommon _cxIpCommon;
        private CxCustomerAccounts _cxCustomerAccounts;
        private CxCustomerOptions _cxCustomerOptions;
        private CxCustomerContracts _cxCustomerContracts;
        private CxCustomerAddresses _cxCustomerAddresses;
        private CxCustomerFeedbackContacts _cxCustomerFeedbackContacts;

        private Core.Entities.Customer _customer;
        public Core.Entities.Customer Customer
        {
            get { return _customer; }
            set { SetCustomer(value); }
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
        }

        private void SetCustomer(Core.Entities.Customer value)
        {
            _customer = value;
            //SetTabsVisible();
            //SetCustomerControlsCustomerAndHandles(value);
        }

        private Dictionary<ICustomerControl, PanelControl> _customerControls = null;


        public FxCustomerEdit()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            tcgCustomer.SelectedTabPageIndex = 0;

            Load += OnLoad;
        }

        private void InitTabs()
        {
            if (!(Customer?.Opf?.IsIP ?? false))
            {
                _cxLegalCommon = new CxLegalCommon();
                lcgIP.Visibility = LayoutVisibility.Never;
                lcgCommonLegal.Visibility = LayoutVisibility.Always;
            }
            else
            {
                lcgIP.Visibility = LayoutVisibility.Always;
                lcgCommonLegal.Visibility = LayoutVisibility.Never;
                _cxIpCommon = new CxIpCommon();
            }

            _cxCustomerOptions = new CxCustomerOptions();

            _cxCustomerAccounts = new CxCustomerAccounts();
            _cxCustomerAccounts.DependedSaving = true;

            _cxCustomerFeedbackContacts = new CxCustomerFeedbackContacts();
            _cxCustomerFeedbackContacts.DependedSaving = true;

            _cxCustomerContracts = new CxCustomerContracts();
            _cxCustomerContracts.DependedSaving = true;

            _cxCustomerAddresses = new CxCustomerAddresses();
            _cxCustomerAddresses.DependedSaving = true;

            _customerControls = new Dictionary<ICustomerControl, PanelControl>();

            if (_cxLegalCommon != null)
            {
                _customerControls.Add(_cxLegalCommon, pcLegal);
            }
            if (_cxIpCommon != null)
                _customerControls.Add(_cxIpCommon, pcIP);

            _customerControls.Add(_cxCustomerAccounts, pcAccounts);

            _customerControls.Add(_cxCustomerContracts, pcContracts);
            _customerControls.Add(_cxCustomerAddresses, pcAddresses);
            _customerControls.Add(_cxCustomerFeedbackContacts, pcCustomerContacts);
            _customerControls.Add(_cxCustomerOptions, pcOptions);

            SetCustomerControlsCustomerAndHandles(_customer);

            foreach (KeyValuePair<ICustomerControl, PanelControl> pair in _customerControls)
            {
                pair.Value.Controls.Add((Control)pair.Key);
                ((Control)pair.Key).Dock = DockStyle.Fill;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                InitTabs();
                SetCustomerControlsReadOnly(ReadOnly);
                BindData();
                //SetTabsVisible();
            }
        }

        //private void SetTabsVisible()
        //{
        //    if (!_customer.IsLegal && lcgCommonLegal != null)
        //    {
        //        lcgIP.Visibility = LayoutVisibility.Always;
        //        lcgCommonLegal.Visibility = LayoutVisibility.Never;
        //        _customerControls.Remove(_cxLegalCommon);
        //        if (_cxLegalCommon != null)
        //            _cxLegalCommon.Dispose();
        //        int _indx = tcgCustomer.TabPages.IndexOf(lcgCommonLegal);
        //        if (_indx > -1)
        //            tcgCustomer.TabPages.RemoveAt(_indx);
        //    }

        //    if (_customer.IsLegal && lcgIP != null)
        //    {
        //        lcgIP.Visibility = LayoutVisibility.Never;
        //        lcgCommonLegal.Visibility = LayoutVisibility.Always;
        //        _customerControls.Remove(_cxIpCommon);
        //        if (_cxIpCommon != null)
        //            _cxIpCommon.Dispose();
        //        lcgIP.Dispose();
        //        int _indx = tcgCustomer.TabPages.IndexOf(lcgIP);
        //        if (_indx > -1)
        //            tcgCustomer.TabPages.RemoveAt(_indx);
        //    }
        //}

        private void SetCustomerControlsReadOnly(bool readOnly)
        {
            foreach (ICustomerControl controlsKey in _customerControls.Keys)
                controlsKey.ReadOnly = readOnly;
        }

        private void SetCustomerControlsCustomerAndHandles(Core.Entities.Customer customer)
        {
            foreach (ICustomerControl controlsKey in _customerControls.Keys)
            {
                controlsKey.Customer = customer;
                controlsKey.DialogOutput += FxCustomerEdit_DialogOutput;
                controlsKey.NeedFocus += OnNeedFocus;
            }
        }

        private void OnNeedFocus(object sender, EventArgs e)
        {
            ICustomerControl _customerControl = sender as ICustomerControl;
            if (null != _customerControl)
            {

                Control _control = _customerControls[_customerControl];
                LayoutControlItem _item = layoutControl.Items.OfType<LayoutControlItem>()?.FirstOrDefault(x => x.Control == _control);
                foreach (LayoutGroup tabPage in tcgCustomer.TabPages)
                {
                    if (tabPage.Contains(_item))
                    {
                        tcgCustomer.SelectedTabPage = tabPage;
                        break;
                    }
                }
            }
        }

        private void FxCustomerEdit_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }


        private void BindData()
        {

            this.DataBindings.Clear();
            this.DataBindings.Add("Text", Customer, "Title", true, DataSourceUpdateMode.OnPropertyChanged);
            lcTitleName.DataBindings.Clear();
            lcTitleName.DataBindings.Add("Text", _customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add("Enabled", _customer, "Changed", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void FxLegalEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        protected override void SetEntity(IEntity value)
        {
            Customer = value as Core.Entities.Customer;
        }

        protected override IEntity GetEntity()
        {
            return Customer;
        }

        protected override void OnSaveButtonClick()
        {
            if (Customer.Changed)
            {
                bool res = false;
                if (_cxLegalCommon != null)
                    res = _cxLegalCommon.Validate() && OptionsValidate();
                else if (_cxIpCommon != null)
                    res = _cxIpCommon.Validate() && OptionsValidate();
                if (res)
                    base.OnSaveButtonClick();
            }
        }

        private bool OptionsValidate()
        {
            if (Customer.Country == null || Customer.Currency == null)
                return _cxCustomerOptions.Validate();
            return true;
        }

        protected override string GetTitle()
        {
            return $"Карточка заказчика {Customer?.Title}";
        }

        protected override void ShowObject()
        {
            FxEntityEditor _fx = new FxEntityEditor();
            _fx.Entity = this.Entity;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }
    }
}
