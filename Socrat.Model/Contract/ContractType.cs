using Socrat.Lib;

namespace Socrat.Model
{
    public class ContractType: Entity, INamedEntity
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name, () => Title); }
        }

        public override string ToString()
        {
            return Name;
        }


        private int _ContractTypeNum;
        public int ContractTypeNum
        {
            get { return _ContractTypeNum; }
            set { SetField(ref _ContractTypeNum, value, () => ContractTypeNum); }
        } 


        public ContractTypeEnum Enum
        {
            get { return EnumHelper<ContractTypeEnum>.FromNum(_ContractTypeNum); }
        }

        protected override string GetTitle()
        {
            return $"Тип договора: {Name}";
        }
    }
}
