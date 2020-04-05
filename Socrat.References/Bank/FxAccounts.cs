using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Bank
{
    public partial class FxAccounts : FxBaseForm
    {
        private List<Account> _accounts = null;
        private IRepository<Account> _accountRepository = null;
        private Account _selectedAccount;
        public Account SelectedAccount { get => _selectedAccount;}

        private FormRegime _regime;
        public FormRegime Regime
        {
            get { return _regime; }
            set { _regime = value; }
        }

        private Account GetSelectedAccount()
        {
            Account _account = null;
            Guid _id = cxAccounts.GetCurrentRowId();
            if (_id != Guid.Empty && _accounts != null)
                _account = _accounts.FirstOrDefault(x => x.Id == _id);
            return _account;
        }

        public FxAccounts()
        {
            InitializeComponent();

            if (_regime == FormRegime.SingleSelect)
            {
                cxAccounts.SetSingleSelectMode();
                Refresh();
            }

            cxAccounts.AddItemEvent += CxAccounts_AddItemEvent;
            cxAccounts.DeleteItemEvent += CxAccountsOnDeleteItemEvent;
            cxAccounts.OpenItemEvent += CxAccountsOnOpenItemEvent;
            cxAccounts.SelectItemEvent += CxAccounts_SelectItemEvent;
            cxAccounts.ColumnsInitEvent += CxAccountsOnColumnsInitEvent;
            cxAccounts.DialogOutput += CxAccounts_DialogOutput;
            
            Load += FxBanks_Load;
        }

        private void CxAccounts_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void FxBanks_Load(object sender, System.EventArgs e)
        {
            _accountRepository = DataHelper.GetRepository<Account>();
            _accounts = _accountRepository.GetAll().ToList();

            cxAccounts.gcGrid.DataSource = null;
            cxAccounts.gcGrid.DataSource = _accounts;
        }

        private void CxAccountsOnColumnsInitEvent(object sender, EventArgs e)
        {
            cxAccounts.AddObjectColumn("Контрагент", "Customer", 120, 0);
            cxAccounts.AddColumn("Банк (Филиал/Отделение)", "Filial", 300, 0);
            cxAccounts.AddColumn("Расчетный счет", "RS", 120, 0);
            cxAccounts.AddColumn("Описание", "Comment", 120, 0);
        }

        private void CxAccounts_SelectItemEvent(object sender, ListItemEventArgs e)
        {
            _selectedAccount = _accounts.FirstOrDefault(x => x.Id == e.ItemId);
        }

        private void CxAccountsOnDeleteItemEvent(object sender, ListItemEventArgs e)
        {
            Account _account = _accounts.FirstOrDefault(x => x.Id == e.ItemId);

            DialogResult _dialogResult = XtraMessageBox.Show(string.Format("Удалить счет {0}?", _account.AccountTitle),
                "Удаление",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult != DialogResult.Cancel)
            {
                _accountRepository.Delete(e.ItemId);
                _accounts.RemoveAll(x => x.Id == e.ItemId);
                cxAccounts.gvGrid.RefreshData();
            }
        }

        private void CxAccounts_AddItemEvent(object sender, ListItemEventArgs e)
        {
            Account _account = new Account();

            FxAccountEdit _accountEdit = new FxAccountEdit(false);
            _accountEdit.StartPosition = FormStartPosition.CenterParent;
            _accountEdit.Account = _account;
            _accountEdit.FixedCustomer = false;
            _accountEdit.SaveButtonClick += (o, args) =>
            {
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?",
                    "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    _accountRepository.Save(_account);
                    _accounts.Add(_account);
                    cxAccounts.gvGrid.RefreshData();
                }
            };
            _accountEdit.DialogOutput += _accountEdit_DialogOutput;
            OnDialogOutput(_accountEdit, DialogOutputType.Dialog, this);
        }

        private void _accountEdit_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void CxAccountsOnOpenItemEvent(object sender, ListItemEventArgs e)
        {
            Account _account = _accounts.FirstOrDefault(x => x.Id == e.ItemId);

            FxAccountEdit _accountEdit = new FxAccountEdit(false);
            _accountEdit.StartPosition = FormStartPosition.CenterParent;
            _accountEdit.Account = _account;
            _accountEdit.Customer = _account.Customer;
            _accountEdit.FixedCustomer = false;
            _accountEdit.ReadOnly = this.ReadOnly;
            _accountEdit.SaveButtonClick += (o, args) =>
            {
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?",
                    "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                    _accountRepository.Save(_account);
                else
                    _accountRepository.Revert(_account);
                cxAccounts.gvGrid.RefreshData();
            };
            _accountEdit.DialogOutput += _accountEdit_DialogOutput;
            OnDialogOutput(_accountEdit, DialogOutputType.Dialog, this);
        }

        protected override string GetTitle()
        {
            return "Справочник счетов";
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            cxAccounts.ReadOnly = value;
        }
    }
}