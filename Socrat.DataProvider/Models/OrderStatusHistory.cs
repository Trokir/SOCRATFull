using System;

namespace Socrat.Data.Model
{
    public class OrderStatusHistory : Entity
    {
        public Guid OrderId { get; set; }
        public DateTime? DateChange { get; set; }
        public Guid? NewOrderStatusId { get; set; }
        public Guid? UserId { get; set; }
        public virtual Order Order { get; set; }
        public virtual OrderStatus NewOrderStatus { get; set; }
        public virtual User User { get; set; }
    }
}