using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class AddressElement : Entity
    {
        //public Guid Id { get; set; }
        public Guid? AddressElementTypeId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName); }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set { SetField(ref _code, value, () => Code); }
        }
        private AddressElementType _addressElementType;
        public virtual AddressElementType AddressElementType
        {
            get { return _addressElementType; }
            set { SetField(ref _addressElementType, value, () => AddressElementType); }
        }
        public virtual ICollection<AddressItem> AddressItems { get; set; } = new HashSet<AddressItem>();
    }
}
