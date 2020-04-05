using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.DataProvider;
using Socrat.Model;

namespace Socrat.Tests
{
    [TestClass]
    public class AutomapperTesting
    {
        [TestMethod]
        public void FormulaItemTesting()
        {
            using (FormulaItemRepository _repo = new FormulaItemRepository())
            {
                Model.FormulaItem _formulaItem = _repo.GetItem(88);

            }
        }
    }
}