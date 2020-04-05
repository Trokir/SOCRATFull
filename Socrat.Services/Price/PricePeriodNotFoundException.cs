using Socrat.Common.Interfaces.Price;
using Socrat.Core.Entities;
using System;

namespace Socrat.Services.Price
{
    /// <summary>
    /// Исключюение в ситуации, когда не существует действующего периода прайс-лист на дату расчета. 
    /// </summary>
    public class PricePeriodNotFoundException : Exception
    {
        public Order Order { get; private set; }
        public DateTime? Date { get; private set; }
        public object Price { get; private set; }

        public PricePeriodNotFoundException(Order order)
            : base(
                  "Невозможно выполнить расчет стоимости, так как для данного заказа " +
                  "не существует действующего периода прайс-лист на дату расчета.")
        {
            Order = order;
        }

        public PricePeriodNotFoundException(IPrice price, DateTime? date)
            : base($"Для прайс-листа {price} не найдено действующего периода на дату {date:d}")
        {
            Price = price;
            Date = date;
        }
    }
}