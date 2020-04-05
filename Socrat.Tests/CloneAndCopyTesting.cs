using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;

namespace Socrat.Tests
{
    [TestClass]
    public class CloneAndCopyTesting
    {
        [TestMethod]
        public void TestClone()
        {
            var _formulas = EntityFrameworkConnection.SocratEntities.Formulae;
            Formula _copy;
            string _fstr;
            byte[] _buffer;
            //ObjectCopier _copier = new ObjectCopier();
            //foreach (Formula formula in _formulas)
            //{
            //    _copy = _copier.Clone(formula);
            //    _fstr = _copy.FormulaStr;
            //}
        }
    }
}