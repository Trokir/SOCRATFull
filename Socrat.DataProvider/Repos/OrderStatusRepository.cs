using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class OrderStatusRepository : UniversalRepository<OrderStatus>
    {
        public override IQueryable<OrderStatus> GetAll()
        {
            return base.GetAll().OrderBy(x => x.OrderNum);
        }
    }
}