using System;

namespace Socrat.Core.Entities
{
    public class OrderRowSloz : Entity
    {
        public Guid? OrderRowId { get; set; }
        public Guid? SlozTypeId { get; set; }

        private OrderRow _orderRow;
        public virtual OrderRow OrderRow
        {
            get { return _orderRow; }
            set { SetField(ref _orderRow, value, () => OrderRow); }
        }
        private SlozType _slozType;
        public virtual SlozType SlozType
        {
            get { return _slozType; }
            set { SetField(ref _slozType, value, () => SlozType); }
        }
    }
}
