using System;

namespace Socrat.Data.Model
{
    public class AddressItem : Entity
    {
        public Guid? AddressId { get; set; }

        public Guid? AddressElementId { get; set; }


        public string Value { get; set; }


        public virtual Address Address { get; set; }

        public virtual AddressElement AddressElement { get; set; }
    }
}