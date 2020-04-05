using Socrat.Common.Enums;
using Socrat.Core;

namespace Socrat.Services.Price
{
    public interface IPriceModificator
    {
        PriceApplianceTypes ApplianceType { get; }
        IEntity Entity { get; }
        PriceModificatorTypes ModificatorType { get; }
        double Value { get; }
    }
}
