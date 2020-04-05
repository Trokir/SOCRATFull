using System.Collections.Generic;
using System.Collections.ObjectModel;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{

    public class ContractType : Entity, INamedEntity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        private int _contractTypeNum;
        public int ContractTypeNum
        {
            get { return _contractTypeNum; }
            set { SetField(ref _contractTypeNum, value, () => ContractTypeNum); }
        }
        public virtual ObservableCollection<Contract> Contracts { get; set; } = new ObservableCollection<Contract>();

        public ContractTypeEnum Enum
        {
            get { return EnumHelper<ContractTypeEnum>.FromNum(_contractTypeNum); }
        }
        protected override string GetTitle()
        {
            return $"Тип договора: {Name}";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
