using System.Collections.Generic;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class AddressElementType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set { SetField(ref _code, value, () => Code); }
        }

        private short? _sort;
        public short? Sort
        {
            get { return _sort; }
            set { SetField(ref _sort, value, () => Sort); }
        }
        private int? _addressElementTypeNum;
        public int? AddressElementTypeNum
        {
            get { return _addressElementTypeNum; }
            set { SetField(ref _addressElementTypeNum, value, () => AddressElementTypeNum); }
        }
        public virtual ICollection<AddressElement> AddressElements { get; set; } = new HashSet<AddressElement>();
        public AddressElementTypeEnum Enum
        {
            get { return EnumHelper<AddressElementTypeEnum>.FromNum(AddressElementTypeNum.Value); }
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
