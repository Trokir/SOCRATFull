using System.Collections.Generic;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class PriceSlozsCollection : HashSet<PriceSloz>
    {
        public List<PriceSloz> GetAppliedFor(List<OrderRowSloz> orderRowSlozsList)
        {
            return this.Where(sloz => orderRowSlozsList.Any(x => sloz.SlozTypeId == x.SlozTypeId)).ToList();
        }
    }
}
