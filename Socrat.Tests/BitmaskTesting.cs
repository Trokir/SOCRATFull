using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Socrat.Tests
{
    [TestClass]
    public class BitmaskTesting
    {
        [TestMethod]
        public void TestWrireReadBit()
        {
            int _pos = 1;
            int _mask = 0;
            _mask = _mask | (1 << _pos);
            _mask = _mask & (0 >> _pos);
            int res = _mask;
        }
    }
}