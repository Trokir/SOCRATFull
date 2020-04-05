using System.Collections.Generic;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class PaymentType : Entity
    {
        public PaymentType()
        {
            Contracts = new HashSet<Contract>();
            Orders = new HashSet<Order>();
        }


        public string Name { get; set; }

        public PaymentTypeEnum? PaymentTypeNum { get; set; }
        public string EnumCode { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}