using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Customer;
using Socrat.UI.Core;

namespace Socrat.References.Bank
{
    public partial class FxAccountEdit : FxBaseSimpleDialog
    {
        private Account _account;
        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private List<Currency> _currency;

        private Core.Entities.Customer _customer;
        public Core.Entities.Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        private bool _fixedCustomer;
        public bool FixedCustomer
        {
            get { return _fixedCustomer; }
            set { _fixedCustomer = value; }
        }

        public FxAccountEdit(bool fixedCuromer)
        {
            InitializeComponent();

            if (Site != null && Site.DesignMode)
                return;

            _fixedCustomer = fixedCuromer;

            Load += FxAccountEdit_Load;

            teAlias.Enabled = false;
            ceSetUser.Checked = false;
        }

        private void FxAccountEdit_Load(object sender, System.EventArgs e)
        {
            Socrat.Core.IRepository<Currency> _currencyRepository = DataHelper.GetRepository<Currency>();
            _currency = _currencyRepository.GetAll().ToList();


            lueCurrency.Properties.DataSource = _currency;
            beCustomer.Enabled = !FixedCustomer;
            BindData();
        }

        protected override void BindData()
        {
            base.BindData();
            lcKs.DataBindings.Clear();
            lcKs.DataBindings.Add("Text", _account, "Ks", true, DataSourceUpdateMode.OnPropertyChanged);
            teRs.DataBindings.Clear();
            teRs.DataBindings.Add("EditValue", _account, "Rs", true, DataSourceUpdateMode.OnPropertyChanged);
            teAlias.DataBindings.Clear();
            teAlias.DataBindings.Add("EditValue", _account, "Alias", true, DataSourceUpdateMode.OnPropertyChanged);
            beBank.DataBindings.Clear();
            beBank.DataBindings.Add("EditValue", _account, "Bank", true, DataSourceUpdateMode.OnPropertyChanged);
            teComment.DataBindings.Clear();
            teComment.DataBindings.Add("EditValue", _account, "Comment", true, DataSourceUpdateMode.OnPropertyChanged);
            lcBik.DataBindings.Clear();
            lcBik.DataBindings.Add("Text", _account, "Bik", true, DataSourceUpdateMode.OnPropertyChanged);
            beCustomer.DataBindings.Clear();
            beCustomer.DataBindings.Add("EditValue", _account, "Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DataBindings.Clear();
            this.DataBindings.Add("Text", _account, "Title", true, DataSourceUpdateMode.OnPropertyChanged);

            lueCurrency.EditValue = _account?.Currency?.Id;
        }

        private void lueCurrency_EditValueChanged(object sender, System.EventArgs e)
        {
            if (lueCurrency.EditValue != null && _currency != null)
            {
                Guid _id;
                if (Guid.TryParse(lueCurrency.EditValue.ToString(), out _id))
                {
                    _account.Currency = _currency.FirstOrDefault(x => x.Id == _id);
                }
            }
        }

        private void ceSetUser_CheckedChanged(object sender, System.EventArgs e)
        {
            teAlias.Enabled = ceSetUser.Checked;
        }

        private void beBank_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "1")
                    OpenBankList();
                if (e.Button.Tag.ToString() == "2")
                    OpenBank();
            }
        }

        private void OpenBankList()
        {
            FxBanks _fx = new FxBanks();
            _fx.SetSingleSelectMode(Account?.Bank);
            _fx.StartPosition = FormStartPosition.CenterParent;
            _fx.DialogOutput += _fx_DialogOutput;
            DialogResult _dlgRes = _fx.ShowDialog(this);
            if (_dlgRes == DialogResult.OK)
            {
                if (_fx.SelectedItem != null)
                    _account.Bank = (Core.Entities.Bank)_fx.SelectedItem;
            }
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, DialogOutputType.Dialog, this);
        }

        private void FxAccountEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_account.Changed)
            {
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                    OnSaveButtonClick();
            }
        }

        private void beCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "1")
                    OpenCustomerList();
                if (e.Button.Tag.ToString() == "2")
                    OpenCustomer();
            }
        }

        private void OpenCustomerList()
        {
            FxCustomers _customers = new FxCustomers();
            _customers.SetSingleSelectMode(Account.Customer);
            DialogResult _dialogResult = _customers.ShowDialog(this);
            if (_dialogResult != DialogResult.Cancel && _customers.SelectedItem != null)
                Account.Customer = _customers.SelectedItem as Core.Entities.Customer;
        }

        private void beBank_DoubleClick(object sender, EventArgs e)
        {
            OpenBank();
        }

        private void OpenBank()
        {
            if (beBank.EditValue != null && _account.Bank != null)
            {
                FxBankEdit _fx = new FxBankEdit();
                _fx.Bank = _account.Bank;
                _fx.SaveButtonClick += (o, args) => SaveBank(_account.Bank);
                OnDialogOutput(_fx, DialogOutputType.Dialog, this);
            }
        }

        private void SaveBank(Core.Entities.Bank bank)
        {
            DataHelper.Save(bank);
        }

        private void beCustomer_DoubleClick(object sender, EventArgs e)
        {
            OpenCustomer();
        }

        private void OpenCustomer()
        {
            if (beCustomer.EditValue != null && _account.Customer != null)
            {
                FxCustomerEdit _fx = new FxCustomerEdit();
                _fx.Customer = _account.Customer;
                _fx.SaveButtonClick += (o, args) => SaveCustomer(_account.Customer);
                OnDialogOutput(_fx, DialogOutputType.Dialog, this);
            }
        }

        private void SaveCustomer(Core.Entities.Customer customer)
        {
            DataHelper.Save(customer);
        }

        protected override void SetEntity(IEntity value)
        {
            _account = value as Account;
        }

        protected override IEntity GetEntity()
        {
            return _account;
        }

        protected override string GetTitle()
        {
            return Account?.Title;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
            {
                layoutControl.Controls.OfType<BaseEdit>().ForEach(x => x.ReadOnly = value);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beBank, teRs, lueCurrency, beCustomer };
        }
    }
}