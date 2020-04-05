using System;

namespace Socrat.Core.Entities
{
    public class OrderStatusHistory : Entity
    {
        public Guid? OrderId { get; set; }

        private DateTime? _dateChange;
        public DateTime? DateChange
        {
            get { return _dateChange; }
            set { SetField(ref _dateChange, value, () => DateChange); }
        }
        public Guid? NewOrderStatusId { get; set; }
        public Guid? UserId { get; set; }

        private Order _order;
        public virtual Order Order
        {
            get { return _order; }
            set { SetField(ref _order, value, () => Order); }
        }

        private OrderStatus _newOrderStatus;
        public virtual OrderStatus NewOrderStatus
        {
            get { return _newOrderStatus; }
            set { SetField(ref _newOrderStatus, value, () => NewOrderStatus); }
        }
        private User _user;
        public virtual User User
        {
            get { return _user; }
            set { SetField(ref _user, value, () => User); }
        }
    }
}
