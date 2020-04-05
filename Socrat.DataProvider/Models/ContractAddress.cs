using System;

namespace Socrat.Data.Model
{
    public class ContractAddress : Entity
    {
        public Guid? ContractId { get; set; }
        public Guid? AddressId { get; set; }
        public string District { get; set; }
        public string DistanceMark { get; set; }
        public int? DistanceLength { get; set; }
        public string Comment { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contract Contract { get; set; }
    }
}