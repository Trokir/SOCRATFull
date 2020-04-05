using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Lib.Users;

namespace Socrat.Tests
{
    /// <summary>
    /// Тестирование подключения ActiveDirectory
    /// </summary>
    [TestClass]
    public class ADWorckerTest
    {
        [TestMethod]
        public void TestADWorker()
        {
            ActiveDirectoryWorker _adw = new ActiveDirectoryWorker();
            _adw.Test();
            Assert.IsTrue(true);
        }
    }
}
