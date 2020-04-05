using System;
using System.Data.Entity;
using System.Linq;
using Order = Socrat.Core.Entities.Order;

namespace Socrat.DataProvider.Repos
{
    internal class OrderRepository : UniversalRepository<Order>
    {
        public override void Delete(Guid id)
        {
            SocratEntities.Database.ExecuteSqlCommand($"Delete from [Order] where Id = '{id}'");
        }
    }
}