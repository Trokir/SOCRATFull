using System.Collections.Generic;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class PaymentType : Entity, INamedEntity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        private int? _paymentTypeNum;
        public int? PaymentTypeNum
        {
            get { return _paymentTypeNum; }
            set { SetField(ref _paymentTypeNum, value, () => PaymentTypeNum); }
        }
        public string EnumCode { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public PaymentTypeEnum PaymentTypeEnum
        {
            get { return EnumHelper<PaymentTypeEnum>.FromNum(_paymentTypeNum.Value); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
