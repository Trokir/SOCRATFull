using System;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.Core.Entities.WayBills
{
    /// <summary>
    /// Связь между экземпляром изделия и строкой накладной
    /// </summary>
    public class WaybillRowItem : Entity
    {
        #region Locals
        private OrderRowItem _orderRowItem;
        private WaybillRow _waybillRow;
        #endregion

        #region Properties
        /// <summary>
        /// Экземпляр продукции для строки накладной
        /// </summary>
        public virtual OrderRowItem OrderRowItem
        {
            get => _orderRowItem;
            set => SetField(ref _orderRowItem, value, () => OrderRowItem);
        }

        /// <summary>
        /// Строка накладной
        /// </summary>
        [ParentItem]
        public WaybillRow WaybillRow
        {
            get => _waybillRow;
            set => SetField(ref _waybillRow, value, () => WaybillRow);
        } 


        #endregion

        #region Foreign keys

        public Guid OrderRowItemId { get; set; }
        public Guid WaybillRowId { get; set; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{OrderRowItem}";
        }

        #endregion

        
    }
}
