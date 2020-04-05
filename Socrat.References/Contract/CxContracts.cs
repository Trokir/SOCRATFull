using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.DataProvider;
using Socrat.Lib.Commands;

namespace Socrat.References.Contract
{
    public partial class CxContracts : CxGenericListTable<Core.Entities.Contract>
    {
        public event EventHandler PrintMainContract;
        public event EventHandler PrintPrice;
        public event EventHandler PrintAdditionalContracts;

        private ContractsFilter _filter;
        public ContractsFilter Filter { get => _filter; set => SetFilter(value); }
        private List<Socrat.Core.Entities.ContractType> _contractTypes;

        private ObservableCollection<Core.Entities.Contract> _contracts;
        private Core.Entities.Customer _customer;

        public ObservableCollection<Core.Entities.Contract> Contracts
        {
            get => _contracts;
            set => SetContracts(value);
        }

        private void SetContracts(ObservableCollection<Core.Entities.Contract> value)
        {
            _contracts = value;
            RefreshData();
        }

        public Core.Entities.Division Division { get; set; }


        public CxContracts()
        {
            InitializeComponent();
            _filter = new ContractsFilter();
            Contracts = new ObservableCollection<Core.Entities.Contract>();
            _contractTypes = DataHelper.GetAll<Socrat.Core.Entities.ContractType>();
        }

        protected override void InitCommands()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 }
            };

            ReferenceCommand _printCmd = new ReferenceCommand(MenuCommandType.ContextMenuGroup, "Печать", null, null)
            { Image = Properties.Resources.print_16x16, BeginGroup = true };
            _printCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Типовой договор", PrintMainContractExecute, null)
            { Image = Properties.Resources.print_16x16 });
            _printCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Праис", PrintPriceExecute, null)
            { Image = Properties.Resources.print_16x16 });
            _printCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Список допсоглашений", PrintAdditionalContractsExecute, null)
            { Image = Properties.Resources.print_16x16 });
            _commands.Add(_printCmd);

            ReferenceCommand _addCmd = new ReferenceCommand(MenuCommandType.Group, "Добавить", null, null)
            { Image = Properties.Resources.addfile_16x16, BeginGroup = true };
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Основной договор с покупателем", AddNewMainContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Тендерный договор с покупателем", AddNewTenderContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Договор с поставщиком", AddNewSupplyerContractExecute, null)
            { Image = Properties.Resources.addfile_16x16 });
            _commands.Add(_addCmd);

            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Копировать в новый договор", CopyNewExecute, null) { Image = Properties.Resources.addfile_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Экспорт в Excel", ExpotrtToExcelExecute, null) { Image = Properties.Resources.exporttoxlsx_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Фильтр", FilterExecute, null) { Image = Properties.Resources.reapplyfilter_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Сбросить", ResetFilterExecute, null) { Image = Properties.Resources.clearfilter_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отбор по значению текущей ячейки", FilterByCellValueExecute, null)
            { Image = Properties.Resources.reapplyfilter_16x16, BeginGroup = true });
            _commands.Add(new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Отменить отбор", ResetFilterByCellValueExecute, null) { Image = Properties.Resources.clearfilter_16x16 });
        }

        private void ResetFilterExecute(object obj)
        {
            Filter.CurrentYear = false;
            RefreshData();
        }

        private void FilterExecute(object obj)
        {
            Filter.CurrentYear = true;
            RefreshData();
        }

        private void CopyNewExecute(object obj)
        {
            Core.Entities.Contract _contract = _contracts.FirstOrDefault(x => x.Id == GetCurrentRowId());
            if (_contract != null)
            {

            }
        }

        private void PrintAdditionalContractsExecute(object obj)
        {
            PrintMainContract?.Invoke(this, EventArgs.Empty);
        }

        private void PrintPriceExecute(object obj)
        {
            PrintPrice?.Invoke(this, EventArgs.Empty);
        }

        private void PrintMainContractExecute(object obj)
        {
            PrintAdditionalContracts.Invoke(this, EventArgs.Empty);
        }

        private Socrat.Core.Entities.ContractType GetContractType(ContractTypeEnum contractTypeEnum)
        {
            if (_contractTypes == null && _contractTypes.Count < 1)
            {
                _contractTypes = DataHelper.GetAll<Socrat.Core.Entities.ContractType>()?.ToList();
            }
            return _contractTypes.FirstOrDefault(x => x.Enum == contractTypeEnum);
        }

        private void AddNewSupplyerContractExecute(object obj)
        {
            AddNewContract(
                new Core.Entities.Contract
                {
                    ContractType = GetContractType(ContractTypeEnum.Supplyer),
                    DateBegin = DateTime.Now,
                    DateEnd = DateTime.Now,
                    Division = Division,
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
                    Division = Division,
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
                    Division = Division,
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
                    Repository.Save(contract);
                    if (!Items.Contains(contract))
                        Items.Add(contract);
                }

                UpdateContractDefault(contract);
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        protected override void OpenItem()
        {
            if (Items == null)
                return;
            Core.Entities.Contract _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            if (_entity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;
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
                        UpdateContractDefault(_entity);
                    }

                    if (DependedSaving && _dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        _entity.Changed = false;
                        _entity.SetParentsChanged(true);
                    }

                    gvGrid.RefreshData();
                };
                _fx.DialogOutput += FxOnDialogOutput;
                _fx.StartPosition = FormStartPosition.CenterParent;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }

            OnOpenItem();
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override void InitColumns()
        {
            AddColumn("№", x => x.Num, 30, 0);
            AddObjectColumn("Вид", x => x.ContractType, 60, 1);
            AddObjectColumn("Подразделение", x => x.Division, 120, 2);
            AddObjectColumn("Контрагент", x => x.Customer, 120, 3);
            AddColumn("От", x => x.DateBegin, 80, 4);
            AddColumn("Действует до", x => x.DateEnd, 80, 5);
            AddColumn("Лимит", x => x.PaymentCreditLimit, 60, 6);
            AddObjectColumn("Условия расчетов", x => x.PaymentType, 120, 7);
            AddColumn("По умолчанию", x =>x.DefaultExt, 30, 8);
        }

        protected override ObservableCollection<Core.Entities.Contract> GetItems()
        {
            return Contracts;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractEdit();
        }

        public void SetFilter(ContractsFilter filter)
        {
            _filter = filter;
            RefreshData();
        }

        public override void RefreshData()
        {
            IQueryable<Core.Entities.Contract> _contractQuery;
            UpdateFilterStatus(Filter.CurrentYear);
            if (Filter.CurrentYear)
                _contractQuery = Repository.GetAll().Where(x => x.DateEnd.Value.Year >= DateTime.Today.Year);
            else
                _contractQuery = Repository.GetAll();
            Guid _contractTypeId = Guid.Empty;
            switch (_filter.FilterType)
            {
                case ContractFilterType.Supplay:
                    _contractTypeId = GetContractTypeIdByEnum(ContractTypeEnum.Supplyer);
                    _contractQuery = _contractQuery.Where(x => x.ContractTypeId == _contractTypeId);
                    break;
                case ContractFilterType.Customer:
                    _contractTypeId = GetContractTypeIdByEnum(ContractTypeEnum.Supplyer);
                    _contractQuery = _contractQuery.Where(x => x.ContractTypeId != _contractTypeId);
                    break;
            }

            if (ExternalFilterExp != null)
            {
                _contractQuery =_contractQuery.Where(ExternalFilterExp);
            }

            _contracts = new ObservableCollection<Core.Entities.Contract>(_contractQuery);
            base.RefreshData();
        }

        public Guid GetContractTypeIdByEnum(ContractTypeEnum enumerator)
        {
            Guid _guid = Guid.Empty;
            var _types = DataHelper.GetAll<Socrat.Core.Entities.ContractType>();
            _guid = _types.FirstOrDefault(x => x.Enum == enumerator)?.Id ?? Guid.Empty;   
            return _guid;
        }

        private void UpdateFilterStatus(bool filterCurrentYear)
        {
            if (filterCurrentYear)
                SetActionLabel("Фильтр: Скрыты договоры закрытые в прошлом году и ранее.");
            else
                SetActionLabel("Фильтр: Показаны договоры закрытые в прошлом году и ранее.");
        }

        public void UpdateData()
        {
            RefreshData();
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
                RefreshData();
            }
        }
    }
}
