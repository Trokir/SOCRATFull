using Socrat.Core.Entities;
using System;

namespace Socrat.Services.Price
{
    [Serializable]
    public class PriceNotFoundException : Exception
    {
        public Order Order { get; private set; }

        public PriceNotFoundException(Order order)
            : base(
                  "Невозможно выполнить расчет стоимости, так как для данного заказа " +
                  "не существует прайс-лист или заказ сформирован некорректно " +
                  "(нет договора для площадки исполнения заказа)")
        {
            Order = order;
        }
    }
}