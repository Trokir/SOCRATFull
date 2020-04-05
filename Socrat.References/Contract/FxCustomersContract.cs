using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;

namespace Socrat.References.Contract
{
    public partial class FxCustomersContract : FxGenericListTable<Core.Entities.Contract>
    {
        private List<Socrat.Core.Entities.ContractType> _contractTypes;
        private Core.Entities.Contract _Contract;
        public Core.Entities.Customer Customer { get; set; }
        public Core.Entities.Division Division { get; set; }
        public DateTime ActualDate { get; set; }

        public FxCustomersContract()
        {
            InitializeComponent();
            ItemSaved += FxCustomersContract_ItemSaved;
        }

        protected override void InitColumns()
        {
            AddColumn("№","Num", 60, 0);
            AddObjectColumn("Подразделение", "Division", 120, 2);
            AddObjectColumn("Контрагент", "Customer", 120, 3);
            AddColumn("От", "DateBegin", 80, 4);
            AddColumn("Действует до", "DateEnd", 80, 5);
            AddColumn("Лимит", "PaymentCreditLimit", 60, 6);
            AddObjectColumn("Условия расчетов", "PaymentType", 120, 7);
            AddColumn("По умолчанию", "DefaultExt", 30, 6);
        }

        protected override void LoadData()
        {
            Guid _contractTypeId = GetContractTypeIdByEnum(ContractTypeEnum.Supplyer);
            IQueryable<Core.Entities.Contract> _contractQuery =
                Repository.GetAll().Where(x => x.ContractTypeId != _contractTypeId 
                                               && (x.DateEnd == null ||x.DateEnd.Value >= ActualDate)
                                               && (x.DateBegin != null && x.DateBegin.Value <= ActualDate));
            try
            {
                if (ExternalFilterExp != null)
                {
                    _contractQuery = _contractQuery.Where(ExternalFilterExp);
                }
                Items = _contractQuery.ToList();
            }
            catch
            {
                Guid _divisionId = Division?.Id ?? Guid.Empty;
                ExternalFilterExp = contract => contract.DivisionId == _divisionId;
                _contractQuery =
                    Repository.GetAll().Where(x => x.ContractTypeId != _contractTypeId && (x.DateEnd == null || x.DateEnd.Value >= ActualDate));
                if (Division != null)
                    _contractQuery.Where(x => x.DivisionId == Division.Id);
                Items = _contractQuery.ToList();
            }
        }

        public Guid GetContractTypeIdByEnum(ContractTypeEnum enumerator)
        {
            Guid _guid = Guid.Empty;
            var _types = DataHelper.GetAll<Socrat.Core.Entities.ContractType>();
            _guid = _types.FirstOrDefault(x => x.Enum == enumerator)?.Id ?? Guid.Empty;
            return _guid;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractEdit
            {
                Customer = Customer,
                CustomerFixed = (Customer != null),
                Division = Division,
                DivisionFixed = (Division != null)
            };
        }

        protected override Core.Entities.Contract GetNewInstance()
        {
            return new Core.Entities.Contract
            {
                Customer = Customer,
                Division = Division,
                ContractType = GetContractType(ContractTypeEnum.MainCustomer),
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now,
                Changed = false
            };
        }

        private Socrat.Core.Entities.ContractType GetContractType(ContractTypeEnum contractTypeEnum)
        {
            if (_contractTypes == null || _contractTypes.Count < 1)
            {
                _contractTypes = DataHelper.GetAll<Socrat.Core.Entities.ContractType>()?.ToList();
            }
            return _contractTypes.FirstOrDefault(x => x.Enum == contractTypeEnum);
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

        private void FxCustomersContract_ItemSaved(object sender, Core.Entities.Contract e)
        {
            UpdateContractDefault(e);
        }
    }
}