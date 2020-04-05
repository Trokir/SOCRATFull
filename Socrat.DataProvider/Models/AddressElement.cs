using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class AddressElement : Entity
    {
        public AddressElement()
        {
            AddressItems = new HashSet<AddressItem>();
        }

        public Guid? AddressElementTypeId { get; set; }


        public string Name { get; set; }

        public string ShortName { get; set; }


        public string Code { get; set; }

        public virtual AddressElementType AddressElementType { get; set; }

        public virtual ICollection<AddressItem> AddressItems { get; set; }
    }
}