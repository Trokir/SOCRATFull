using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.DataProvider;

namespace Socrat.Tests  
{
    /// <summary>
    /// Тестирование соединения с базой через EF6
    /// </summary>
    [TestClass]
    public class DbContextTester
    {
        [TestMethod]
        public void DbContextTest()
        {
            using (SocratEntities _socratEntities = new SocratEntities())
            {
                _socratEntities.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                var _tmp = _socratEntities.Customers.ToList();
                Assert.IsTrue(true);
            }
        }
    }
}
