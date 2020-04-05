using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References;
using Socrat.References.Address;
using Socrat.References.Contract;
using Socrat.References.Customer;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrderEdit : FxBaseSimpleDialog
    {
        public Core.Entities.Order Order { get; set; }
        private CxOrderRows cxOrderRows;
        private List<Division> _divisions;
        private List<Customer> _customers;
        private List<Contract> _contracts;
        private List<Account> _accounts;
        private List<OrderStatus> _orderStatuses;
        private List<PaymentType> _paymentTypes;
        private ButtonEditAssistent<Contract, FxCustomersContract, FxContractEdit> _contractButtonAssistent;
        private ButtonEditAssistent<Customer, FxCustomers, FxCustomerEdit> _customerButtonAssistent;
        private AddressButtonEditAssistent _addressButtonEditAssistent;
        private bool NoCntrolReaction = false;


        public FxOrderEdit()
        {
            InitializeComponent();

            cxOrderRows = new CxOrderRows();
            cxOrderRows.Order = Order;
            pnlRows.Controls.Add(cxOrderRows);
            cxOrderRows.Dock = DockStyle.Fill;
            cxOrderRows.DialogOutput += CxOrderRows_DialogOutput;

            Load += FxOrderEdit_Load;
            Resize += FxOrderEdit_Resize;
        }

        private void FxOrderEdit_Resize(object sender, EventArgs e)
        {
            Update();
        }

        private void CxOrderRows_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void FxOrderEdit_Load(object sender, EventArgs e)
        {
            _contractButtonAssistent =
                new ButtonEditAssistent<Contract, FxCustomersContract, FxContractEdit>(beContract, Order.Contract, OnDialogOutput);
            _contractButtonAssistent.BindProperty(Order, x => x.Contract);
            _contractButtonAssistent.ExternalFilterExp =
                contract => (contract.DivisionId == Order.Division.Id);

            _customerButtonAssistent = 
                new ButtonEditAssistent<Customer, FxCustomers, FxCustomerEdit>(beCustomer, Order.Customer, OnDialogOutput);
            _customerButtonAssistent.BindProperty(Order, x => x.Customer);

            _addressButtonEditAssistent = new AddressButtonEditAssistent(lueAddress, Order.Address, Order.GetAddreses,  OnDialogOutput);
            _addressButtonEditAssistent.BindProperty(Order, x => x.Address);
        }

        private void LoadComboboxData()
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<Division> _divisionRepo = _factory.CreateRepository<IRepository<Division>>();
                _divisions = _divisionRepo.GetAll().ToList();
            }

            lueDivision.Properties.DataSource = null;
            lueDivision.Properties.DataSource = _divisions;

            using (IRepository<OrderStatus> _repo = DataHelper.GetRepository<OrderStatus>())
            {
                _orderStatuses = _repo.GetAll()?.OrderBy(x => x.OrderNum).ToList();
            }

            lueStatus.Properties.DataSource = null;
            lueStatus.Properties.DataSource = _orderStatuses;
        }

        protected override IEntity GetEntity()
        {
            return Order;
        }

        protected override void SetEntity(IEntity value)
        {
            Order = value as Core.Entities.Order;
            cxOrderRows.Order = Order;
        }

        protected override void BindData()
        {
            base.BindData();

            BindEditor(deInput, Order, x => x.DateInput);
            BindEditor(deWork, Order, x => x.DateWork);
            BindEditor(deCustomer, Order, x => x.DateCustomer);

            this.DataBindings.Clear();
            this.DataBindings.Add("Text", Order, "Title", true, DataSourceUpdateMode.OnPropertyChanged);

            btnOrderSave.DataBindings.Clear();
            btnOrderSave.DataBindings.Add("Enabled", Order, "Changed", true, DataSourceUpdateMode.OnPropertyChanged);

            teNumCustomer.DataBindings.Clear();
            teNumCustomer.DataBindings.Add("EditValue", Order, "NumCustomer", true, DataSourceUpdateMode.OnPropertyChanged);
            meComment.DataBindings.Clear();
            meComment.DataBindings.Add("EditValue", Order, "Comment", true, DataSourceUpdateMode.OnPropertyChanged);

            LoadComboboxData();
            NoCntrolReaction = true;
            lueDivision.EditValue = Order.Division?.Id;
            lueAccunt.EditValue = Order.Account?.Id;
            ceSelfShipping.Checked = Order.SelfShipping ?? false;

            if (Order.OrderStatus == null && _orderStatuses.Count > 0)
                Order.OrderStatus = _orderStatuses.First();
            lueStatus.EditValue = Order.OrderStatus?.Id;

            if (Order.PaymentType != null)
                luePaymentType.EditValue = Order.PaymentType?.Id;

            if (Order.Contract != null && Order.Contract.PaymentType != null)
            {
                _paymentTypes = new List<PaymentType> { Order.Contract.PaymentType };
                luePaymentType.Properties.DataSource = null;
                luePaymentType.Properties.DataSource = _paymentTypes;
            }

            if (Order.Customer != null && Order.Customer.Accounts != null)
            {
                _accounts = new List<Account>(Order.Customer.Accounts);
                lueAccunt.Properties.DataSource = null;
                lueAccunt.Properties.DataSource = _accounts;
            }

            if (Order.Account != null)
                lueAccunt.EditValue = Order.Account.Id;

            lueAddress.EditValue = Order.Address?.Id;
            NoCntrolReaction = false;
        }

        private void lueDivision_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            Guid _id;
            if (lueDivision.EditValue != null && Guid.TryParse(lueDivision.EditValue.ToString(), out _id))
            {
                Order.Division = _divisions.FirstOrDefault(x => x.Id == _id);
                _customers = null;
                _contracts = null;
                _contracts = DataHelper.GetAll<Contract>()
                    .Where(y => y.Division?.Id == Order.Division?.Id).ToList();
                _customers = DataHelper.GetAll<Customer>();
            }
        }

        private void lueCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            if (beCustomer.EditValue != null)
            {
                Order.Customer = beCustomer.EditValue as Customer;
                if (Order.Customer != null)
                    _contractButtonAssistent.ExternalFilterExp = contract =>
                        contract.DivisionId == Order.Division.Id && contract.CustomerId == Order.Customer.Id;

                if (Order.Customer != null && Order.Contract != null 
                    && Order.Contract.Customer != null && Order.Contract.Customer.Id != Order.Customer.Id)
                {
                    Order.Contract = null;
                    Order.ContractId = null;

                    Order.PaymentType = null;
                    Order.PaymentTypeId = null;
                    luePaymentType.EditValue = null;

                    if (Order.Account == null)
                    {
                        lueAccunt.EditValue = null;
                    }

                }
                if (Order.Customer != null 
                     && Order.Account != null 
                     && Order.Account.Customer != null 
                     && Order.Customer.Id != Order.Account.Customer.Id)
                {
                    _accounts = null;
                }
                
                if (_accounts == null)
                    _accounts = new List<Account>();
                _accounts = _accounts.Distinct().ToList();
                if (Order.Customer != null)
                {
                    _customers = new List<Customer> { Order.Customer };
                    _contracts = Order.Customer?.Contracts.ToList();

                    if (Order.Account == null || Order?.Account?.Customer.Id != Order.Customer.Id)
                    {
                        Order.Account = Order.Customer.Accounts?.FirstOrDefault();
                        _accounts = Order.Customer.Accounts.ToList();
                        lueAccunt.Properties.DataSource = _accounts;
                        lueAccunt.EditValue = Order.Account?.Id;
                    }
                }
                else
                {
                    var _ContractAccounts = _customers.Where(x => x != null).SelectMany(x => x.Accounts);
                    foreach (var _contractAccount in _ContractAccounts)
                    {
                        if (!_accounts.Exists(x => x.Id == _contractAccount.Id))
                            _accounts.Add(_contractAccount);
                    }

                    lueAccunt.Properties.DataSource = null;
                    lueAccunt.Properties.DataSource = _accounts;

                    var _cts = _contracts.Where(x => x.Customer?.Id == Order.Customer?.Id).ToList();
                    _paymentTypes = new List<PaymentType>();
                    foreach (var _contract in _cts)
                    {
                        if (_contract.PaymentType?.Id != null &&
                            !_paymentTypes.Exists(x => x.Id == _contract.PaymentType?.Id))
                            _paymentTypes.Add(_contract.PaymentType);

                    }

                    if (_paymentTypes.Count > 0)
                    {
                        luePaymentType.Properties.DataSource = null;
                        luePaymentType.Properties.DataSource = _paymentTypes;
                    }
                }

                if (Order.Contract == null && _contracts.Exists(x => x.Default ?? false))
                {
                    var _defContract = _contracts.FirstOrDefault(x => x.Default ?? false);

                    Order.Contract = _defContract;
                    Order.PaymentType = _defContract.PaymentType;
                    beContract.EditValue = _defContract;
                    luePaymentType.EditValue = _defContract.PaymentType?.Id;
                }
            }
        }

        private void lueAccunt_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            Guid _id;
            if (_accounts != null && lueAccunt.EditValue != null && Guid.TryParse(lueAccunt.EditValue.ToString(), out _id))
            {
                Order.Account = _accounts.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void lueStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            Guid _id;
            if (lueStatus.EditValue != null && Guid.TryParse(lueStatus.EditValue.ToString(), out _id))
            {
                try
                {
                    Order.OrderStatus = _orderStatuses.FirstOrDefault(x => x.Id == _id);
                }
                catch (Exception exception)
                {
                    lueStatus.EditValue = Order.OrderStatus?.Id;
                    XtraMessageBox.Show(exception.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void ceSelfShipping_EditValueChanged(object sender, EventArgs e)
        {
            Order.SelfShipping = ceSelfShipping.Checked;
            lueAddress.Enabled = !ceSelfShipping.Checked;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                lueDivision,
                beCustomer,
                lueAccunt,
                deInput,
                deWork,
                deCustomer
            };
        }

        public override bool Validate()
        {
            return base.Validate() && cxOrderRows.Validate();
        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {
            if (Validate())
             OnSaveButtonClick();
        }

        private void btnOkNew_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                OnSaveButtonClick();
                SetEntity(new Core.Entities.Order());
                BindData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lueContract_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            if (beContract.EditValue != null)
            {
                Order.Contract = beContract.EditValue as Contract;

                Order.PaymentType = Order.Contract?.PaymentType;
                _paymentTypes = new List<PaymentType> { Order.Contract?.PaymentType };
                luePaymentType.Properties.DataSource = _paymentTypes;
                luePaymentType.EditValue = Order.Contract?.PaymentType.Id;

                if (Order.Customer == null)
                {
                    Order.Customer = Order.Contract.Customer;
                }
            }
        }
        
        private void luePaymentType_EditValueChanged(object sender, EventArgs e)
        {
            if (NoCntrolReaction)
                return;
            Guid _id;
            if (_paymentTypes != null && luePaymentType.EditValue != null && Guid.TryParse(luePaymentType.EditValue.ToString(), out _id))
            {
                Order.PaymentType = _paymentTypes.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}