using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Pdf.Native;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib.Commands;
using Socrat.References.Contract;

namespace Socrat.References.Customer
{
    public partial class CxCustomerContracts : CxGenericListTable<Core.Entities.Contract>, ICustomerControl
    {
        private Core.Entities.Customer _customer;

        public CxCustomerContracts()
        {
            InitializeComponent();
            Load += CxCustomerContracts_Load;
        }

        private void CxCustomerContracts_Load(object sender, EventArgs e)
        {
            _contractTypes = DataHelper.GetAll<Socrat.Core.Entities.ContractType>().ToList();
        }

        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public event EventHandler NeedFocus;

        private List<Socrat.Core.Entities.ContractType> _contractTypes;

        protected override void InitColumns()
        {
            AddColumn("№", x => x.Num, 60, 0);
            AddObjectColumn("Подразделение", "Division", 200, 1);
            AddColumn("Наименование", x => x.Title, 200, 2);
            AddColumn("Дата от", x => x.DateBegin, 100, 3);
            AddColumn("Дата до", x => x.DateEnd, 100, 4);
            AddObjectColumn("Менеджер", "Coworker", 100, 5);
            AddColumn("По умолчанию", "DefaultExt", 100, 6);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractEdit { Customer = this.Customer };
        }

        protected override Core.Entities.Contract GetNewInstance()
        {
            var _contract = new Core.Entities.Contract
            {
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now.AddYears(1),
                Division = Constants.CurrentDivision
            };
            _contract.Customer = this.Customer;
            return _contract;
        }

        protected override ObservableCollection<Core.Entities.Contract> GetItems()
        {
            return Customer.Contracts;
        }

        protected override void InitCommands()
        {
            ReferenceCommand _addCmd = new ReferenceCommand(MenuCommandType.Group, "Добавить", null, null)
            { Image = Properties.Resources.addfile_16x16, BeginGroup = true };
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Основной договор с покупателем", AddNewMainContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Тендерный договор с покупателем", AddNewTenderContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Договор с поставщиком", AddNewSupplyerContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });

            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 },
                _addCmd,
                new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true },
                new ReferenceCommand(MenuCommandType.Item, "Экспорт в Excel", ExpotrtToExcelExecute, null)
                    { Image = Properties.Resources.exporttoxlsx_16x16, BeginGroup = true, IsWriteCommand = true},
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отбор по значению текущей ячейки", FilterByCellValueExecute, null)
                    { Image = Properties.Resources.reapplyfilter_16x16, BeginGroup = true},
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отменить отбор", ResetFilterByCellValueExecute, null) { Image = Properties.Resources.clearfilter_16x16 },
            };
        }

        private void AddNewSupplyerContractExecute(object obj)
        {
            AddNewContract(
                new Core.Entities.Contract
                {
                    ContractType = GetContractType(ContractTypeEnum.Supplyer),
                    DateBegin = DateTime.Now,
                    DateEnd = DateTime.Now,
                    Changed = false
                });
        }

        private void AddNewTenderContractExecute(object obj)
        {
            AddNewContract(
                new Core.Entities.Contract
                {
                    ContractType = GetContractType(ContractTypeEnum.TenderCustomer),
                    DateBegin = DateTime.Now,
                    DateEnd = DateTime.Now,
                    Changed = false
                });
        }

        private void AddNewMainContractExecute(object obj)
        {
            AddNewContract(
                new Core.Entities.Contract
                {
                    ContractType = GetContractType(ContractTypeEnum.MainCustomer),
                    DateBegin = DateTime.Now,
                    DateEnd = DateTime.Now,
                    Changed = false
                });
        }

        private void AddNewContract(Core.Entities.Contract contract)
        {
            IEntityEditor _fx = GetEditor();
            _fx.Entity = contract;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    bool res = DependedSaving;
                    if (!DependedSaving)
                        res = Repository.Save(contract);
                    if (res && !Items.Contains(contract))
                    {
                        Items.Add(contract);
                        if (DependedSaving)
                            contract.Changed = false;
                    }

                    UpdateContractDefault(contract);
                }
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private Socrat.Core.Entities.ContractType GetContractType(ContractTypeEnum contractTypeEnum)
        {
            if (_contractTypes == null && _contractTypes.Count < 1)
            {
                _contractTypes = DataHelper.GetAll<Socrat.Core.Entities.ContractType>()?.ToList();
            }
            return _contractTypes.FirstOrDefault(x => x.Enum == contractTypeEnum);
        }

        protected override void OpenItem()
        {
            if (Items == null)
                return;
            Core.Entities.Contract _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            if (_entity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;//editedEntity;
                _fx.ReadOnly = this.ReadOnly;
                _fx.SaveButtonClick += (_sender, args) =>
                {
                    if (!_fx.Entity?.Changed ?? false)
                        return;
                    DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (_dialogResult != DialogResult.Yes || this.ReadOnly)
                    {
                        return;
                    }

                    bool res = DependedSaving;
                    if (!DependedSaving && _dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        Repository.Save(_entity);
                    }

                    if (DependedSaving && _dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        _entity.Changed = false;
                        _entity.SetParentsChanged(true);
                    }
                    UpdateContractDefault(_entity);
                    gvGrid.RefreshData();
                };
                _fx.DialogOutput += FxOnDialogOutput;
                _fx.StartPosition = FormStartPosition.CenterParent;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
            OnOpenItem();
            
        }

        private void UpdateContractDefault(Core.Entities.Contract contract)
        {
            if (contract != null && (contract.Default ?? false))
            {
                foreach (var _contract in Items.Where(x => x.Division.Id == contract.Division.Id))
                {
                    if (_contract.Id != contract.Id && (contract.Default ?? false))
                        _contract.Default = false;
                }
                gvGrid.RefreshData();
            }
        }
    }
}
