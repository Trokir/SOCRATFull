using Socrat.Core.Entities;
using System;


namespace Socrat.Services.Price
{
    /// <summary>
    /// В строках заказа смешаны тендерные и нетендерные цены
    /// </summary>
    public class TenderCalculationRequestNotCompleteException : Exception
    {
        /// <summary>
        /// Заказ, породивший данное исключение
        /// </summary>
        public Order Order { get; private set; }
        public TenderCalculationRequestNotCompleteException(Order order)
            :base(
                 "Для части заказа тендерные цены установлены, а для части - нет. Расчет невозможен!\r\n" +
                 "Укажиье тендерные цены там где они не установлены если для всего заказа нужен расчет" +
                 "по тендерным ценам, либо удалите там, где они установлены -" +
                 " для выполнения расчета по прайс-листу")
        {
            Order = order;
        }
    }
}
