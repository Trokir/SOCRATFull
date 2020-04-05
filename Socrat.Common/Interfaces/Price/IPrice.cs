using System.Collections.Generic;

namespace Socrat.Common.Interfaces.Price
{
    public interface IPrice
    {
        IList<IPricePeriod> IPricePeriods { get; }
    }
}
