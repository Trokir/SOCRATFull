using System;

namespace Socrat.Services.Price
{
    public class WrontProductionTypeException : Exception
    {
        public ICalculationRequest Request { get; private set; }
        public WrontProductionTypeException(ICalculationRequest request)
            : base($"В запросе неверно указан тип продукции или неопределен: {request.ItemType}")
        {
            Request = request;
        }
    }
}
