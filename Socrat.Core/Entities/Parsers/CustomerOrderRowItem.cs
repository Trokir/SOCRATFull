using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Socrat.Core.Entities.Parsers
{
    public class CustomerOrderRowItem: Entity
    {
        public CustomerOrderRowItem()
        {
            OrderRowItems = new AttachedList<OrderRowItem>(this);
        }

        public Guid CustomerOrderRowId { get; set; }
        [ParentItem]
        public virtual CustomerOrderRow CustomerOrderRow { get; set; }

        public short? Num { get; set; }

        [NotMapped]
        public OrderRowItem OrderRowItem
        {
            get => GetOrderRowItem();
            set => SetOrderRowItem(value);
        }

        private void SetOrderRowItem(OrderRowItem value)
        {
            OrderRowItems.Clear();
            OrderRowItems.Add(value);
        }

        private OrderRowItem GetOrderRowItem()
        {
            if (OrderRowItems.Count > 0)
                return OrderRowItems.FirstOrDefault();
            return null;
        }

        public virtual AttachedList<OrderRowItem> OrderRowItems { get; }

        [NotMapped]
        public bool Used
        {
            get => OrderRowItem != null;
        }

    }
}