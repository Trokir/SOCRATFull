using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Lib.Commands;
using Socrat.References;
using Socrat.References.Address;
using Socrat.References.Contract;
using Socrat.References.Customer;
using Socrat.References.Order;
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
        public List<Guid> _customersIds;
        public event EventHandler CloseAndAddNewItem;

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

            Activated += FxOrderEdit_Activated;
        }

        private void FxOrderEdit_Activated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("FxOrderEdit actived");
        }

        private void FxOrderEdit_Resize(object sender, EventArgs e)
        {
            Update();
        }

        private void CxOrderRows_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void FxOrderEdit_Load(object sender, EventArgs e)
        {
            _contractButtonAssistent =
                new ButtonEditAssistent<Contract, FxCustomersContract, FxContractEdit>(beContract, Order.Contract, OnDialogOutput);
            _contractButtonAssistent.BindProperty(Order, x => x.Contract);
            Guid _divisionId = Order?.Division?.Id ?? Guid.Empty;
            _contractButtonAssistent.ExternalFilterExp =
                contract => (contract.DivisionId == _divisionId);
            _contractButtonAssistent.SelectionFormFiltersSetup = SelectionFormFiltersSetup;

            _customerButtonAssistent = 
                new ButtonEditAssistent<Customer, FxCustomers, FxCustomerEdit>(beCustomer, Order.Customer, OnDialogOutput);
            _customerButtonAssistent.BindProperty(Order, x => x.Customer);
            _customerButtonAssistent.SelectionFormFiltersSetup = CustomersSelectionForm;

            _addressButtonEditAssistent = new AddressButtonEditAssistent(lueAddress, Order.Address, null,  OnDialogOutput);
            _addressButtonEditAssistent.BindProperty(Order, x => x.Address);
            _addressButtonEditAssistent.GetOrderAddresesList = GetOrderAddresesList;

            if (Order != null)
                Order.OrderRowChanged += Order_OrderRowChanged;

            BuildMainMenu();
        }

        private FxCustomers CustomersSelectionForm()
        {
            if (Order.Division != null)
                _customersIds = Order.Division.GetActualContracts(GetActualDate())
                        .Select(x => x.Customer)
                        .Where(x => x != null)
                        .Select(x => x.Id).ToList();
            else
                _customersIds = new List<Guid>();

           if (_customersIds.Count > 0)
               return new FxCustomers
               {
                   ExternalFilterExp = customer => _customersIds.Contains(customer.Id)

               };
            return new FxCustomers();
        }

        private void Order_OrderRowChanged(object sender, OrderRow e)
        {
            OrderRowSlozAnalizer.Analise(e);
            cxOrderRows.gvGrid.RefreshData();
        }

        private FxCustomersContract SelectionFormFiltersSetup()
        {
            return new FxCustomersContract { Customer = Order.Customer, Division = Order.Division, ActualDate = GetActualDate()};
        }

        private DateTime GetActualDate()
        {
            DateTime _date = Order.DateCustomer ?? DateTime.Now;
            string _actualDateStr = String.Empty;
            

            ActualDateType _actualDateType = GetActualDateSetting();
            switch (_actualDateType)
            {
                case ActualDateType.Input:
                default:
                    _date = Order.DateInput;
                    break;
                case ActualDateType.Work:
                    _date = Order.DateWork ?? DateTime.Now;
                    break;
                case ActualDateType.Customer:
                    _date = Order.DateCustomer ?? DateTime.Now;
                    break;
            }

            return _date;
        }

        private ActualDateType GetActualDateSetting()
        {
            ActualDateType _actualDateType = ActualDateType.Input;
            string _actualDateStr = String.Empty;
            if (_UserSettings.TryGetValue("ActualDate", out _actualDateStr))
                _actualDateType = EnumHelper<ActualDateType>.Parse(_UserSettings["ActualDate"]);
            return _actualDateType;
        }

        private BarItemLink _bilExtendedInput;
        private void BuildMainMenu()
        {
            bool _tmp = false;
            if (_UserSettings.ContainsKey("ExtendedInput"))
                bool.TryParse(_UserSettings["ExtendedInput"], out _tmp);
            cxOrderRows.SimpleInput = !_tmp;
            BarItemLink TopMenuItemSettings = AddTopMenu("Настройки");

            _bilExtendedInput = AddTopMenuCheckItem(TopMenuItemSettings, "Расширенный ввод одним потоком", 
                new ReferenceCommand( MenuCommandType.Item, "Расширенный ввод одним потоком", SetExtendedInput, CanExtendedInput), _tmp);

            ActualDateType _actualDateType = GetActualDateSetting();
            BarItemLink _actyalDateBarItem = AddTopMenuSubItem(TopMenuItemSettings, "Дату действия договора определять по");

            AddTopMenuCheckItem(_actyalDateBarItem, "дате ввода заказа", 
                new ReferenceCommand(MenuCommandType.Item, "дате ввода заказа", SetActualInputDate, CanExtendedInput), 
                _actualDateType == ActualDateType.Input, 1);

            //AddTopMenuCheckItem(_actyalDateBarItem, "дате производства заказа",
            //    new ReferenceCommand(MenuCommandType.Item, "дате производства заказа", SetActualWorkDate, CanExtendedInput),
            //    _actualDateType == ActualDateType.Work, 1);

            AddTopMenuCheckItem(_actyalDateBarItem, "дате отгрузки заказа",
                new ReferenceCommand(MenuCommandType.Item, "дате отгрузки заказа", SetActualCustomerDate, CanExtendedInput),
                _actualDateType == ActualDateType.Customer, 1);
        }

        private void SetActualCustomerDate(object obj)
        {
            _UserSettings["ActualDate"] = ActualDateType.Customer.ToString();
        }

        private void SetActualWorkDate(object obj)
        {
            _UserSettings["ActualDate"] = ActualDateType.Work.ToString();
        }

        private void SetActualInputDate(object obj)
        {
            _UserSettings["ActualDate"] = ActualDateType.Input.ToString();
        }

        private bool CanExtendedInput(object arg)
        {
            return true;
        }

        private void SetExtendedInput(object obj)
        {
            if (_bilExtendedInput != null)
            {
                BarCheckItem _barCheckItem = _bilExtendedInput.Item as BarCheckItem;
                if (_barCheckItem != null && cxOrderRows != null)
                {
                    cxOrderRows.SimpleInput = !_barCheckItem.Checked;
                    _UserSettings["ExtendedInput"] = _barCheckItem.Checked.ToString();
                }
            }
        }

        private void GetOrderAddresesList(object obj)
        {
            FxOrderAddresses _fx = new FxOrderAddresses();
            _fx.Order = Order;
            _fx.AddressSelected += _fx_AddressSelected;
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        private void _fx_AddressSelected(object sender, Address addres)
        {
            Order.Address = addres;
            //_addressButtonEditAssistent.ButtonEdit.EditValue = addres;
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

            noUpdateDatesLimits = true;
            deInput.DateTime = Order.DateInput;
            deWork.DateTime = Order.DateWork ?? Order.DateInput.AddDays(1);
            deCustomer.DateTime = Order.DateCustomer ?? deWork.DateTime.AddDays(1);
            noUpdateDatesLimits = false;

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
                //_paymentTypes = new List<PaymentType> { Order.Contract.PaymentType };
                //luePaymentType.Properties.DataSource = null;
                //luePaymentType.Properties.DataSource = _paymentTypes;
            }

            _paymentTypes = DataHelper.GetAll<PaymentType>();
            luePaymentType.Properties.DataSource = null;
            luePaymentType.Properties.DataSource = _paymentTypes;

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

            UpdateDateLimits();
        }

        bool noUpdateDatesLimits = false;
        private void UpdateDateLimits()
        {
            if (noUpdateDatesLimits)
                return;
            deInput.Properties.MaxValue = Order.DateWork ?? Order.DateInput;
            deWork.Properties.MinValue = Order.DateInput;
            deWork.Properties.MaxValue = Order.DateCustomer ?? Order.DateWork ?? Order.DateInput.AddDays(1);
            deCustomer.Properties.MinValue = Order.DateWork ?? Order.DateInput.AddDays(1);
        }

        private void lueDivision_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (!NoCntrolReaction && lueDivision.EditValue != null && Guid.TryParse(lueDivision.EditValue.ToString(), out _id))
            {
                Order.Division = _divisions.FirstOrDefault(x => x.Id == _id);
                _customers = null;
                _contracts = null;
                _contracts = DataHelper.GetAll<Contract>()
                    .Where(y => y.Division?.Id == Order.Division?.Id).ToList();
                if (_contracts != null && _customerButtonAssistent != null)
                {
                    _customersIds = Order.Division.Contracts.Select(x => x.Customer).Where(x => x != null).Select(x => x.Id).ToList();
                    _customerButtonAssistent.ExternalFilterExp = customer => _customersIds.Contains(customer.Id);
                }

                if (Order.Customer != null)
                {
                    if (!Order.Division.IsDivisionCustomer(Order.Customer))
                    {
                        Order.Customer = null;
                        Order.Contract = null;
                        Order.Account = null;
                        Order.AccountId = null;
                        Order.PaymentType = null;
                        Order.PaymentTypeId = null;
                        if (lueAccunt != null)
                            lueAccunt.EditValue = null;
                        if (luePaymentType != null)
                            luePaymentType.EditValue = null;
                    }

                }

                if (!Order.Division.IsDivisionContract(Order.Contract))
                {
                    Order.Contract = null;
                    Order.PaymentType = null;
                    Order.PaymentTypeId = null;
                    if (luePaymentType != null)
                        luePaymentType.EditValue = null;
                }

                if (Order.Customer != null)
                    Order.Contract = Order.Customer.GetDefaultContract(Order.Division);
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
                    }
                    lueAccunt.EditValue = Order.Account?.Id;
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

                    //if (_paymentTypes.Count > 0)
                    //{
                    //    luePaymentType.Properties.DataSource = null;
                    //    luePaymentType.Properties.DataSource = _paymentTypes;
                    //}
                }

                if (Order.Customer != null && Order.Contract == null)
                {
                    var _defContract = Order.Customer.GetDefaultContract(Order.Division);
                    if (_defContract != null)
                    {
                        Order.Contract = _defContract;
                        Order.PaymentType = _defContract.PaymentType;
                        //beContract.EditValue = _defContract;
                        luePaymentType.EditValue = _defContract.PaymentType?.Id;
                    }
                }
            }
            else if (beCustomer.EditValue == null && Order.Customer == null)
            {
                Order.Contract = null;
                Order.Account = null;
                lueAccunt.EditValue = null;
                Order.PaymentType = null;
                luePaymentType.EditValue = null;
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
                deInput,
                deWork,
                deCustomer,
                beContract,
                luePaymentType
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
            OnCloseAndAddNewItem();
        }

        private void OnCloseAndAddNewItem()
        {
            CloseAndAddNewItem?.Invoke(this, EventArgs.Empty);
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
                if (Order.PaymentType == null)
                {
                    Order.PaymentType = Order.Contract?.PaymentType;
                }

                if (Order.PaymentType != null)
                    luePaymentType.EditValue = Order.PaymentType.Id;

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

        private void deInput_EditValueChanged(object sender, EventArgs e)
        {
            Order.DateInput = deInput.DateTime;
            UpdateDateLimits();
            CheckSelectedCustomerContract();
        }

        private void deWork_EditValueChanged(object sender, EventArgs e)
        {
            Order.DateWork = deWork.DateTime;
            UpdateDateLimits();
            CheckSelectedCustomerContract();
        }

        private void deCustomer_EditValueChanged(object sender, EventArgs e)
        {
            Order.DateCustomer = deCustomer.DateTime;
            UpdateDateLimits();
            CheckSelectedCustomerContract();
        }

        private void CheckSelectedCustomerContract()
        {
            if (Order.Customer != null)
            {
                DateTime _actualDate = GetActualDate();
                if (!Order.Customer.HasActualContractsByDate(_actualDate))
                {
                    XtraMessageBox.Show(
                        $"Заказчик '{Order.Customer}' не имеет действующих договоров на действующую дату {_actualDate.ToString("MM.dd.yyyy")}",
                        "Контроль дат заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (Order.Contract != null)
                        Order.Contract = null;
                }
                else if (Order.Contract != null)
                {
                    if (!Order.Contract.IsActualByDate(_actualDate))
                    {
                        DialogResult _dialogResult = XtraMessageBox.Show(
                            $"Действующая дата {_actualDate.ToString("MM.dd.yyyy")} не попадает в период действия выбранного " +
                            $"договора '{Order.Contract}'.{Environment.NewLine}" + 
                            $"Выбрать другой договор?",
                            "Контроль дат заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Order.Contract = null;
                        if (_dialogResult == DialogResult.Yes)
                        {
                            _contractButtonAssistent.OpenSelectDialog();
                        }
                    }
                }
            
            }
        }

    }
}