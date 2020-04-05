using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Order;

namespace Socrat.Tests
{
    [TestClass]
    public class OrderTesting
    {
        [TestMethod]
        public void TestOrderSloz()
        {
            var rows = EntityFrameworkConnection.SocratEntities.OrderRows;
            foreach (OrderRow row in rows)
            {
                OrderRowSlozAnalizer.Analise(row);
            }

            EntityFrameworkConnection.SocratEntities.SafetySaveChanges();
        }
    }
}