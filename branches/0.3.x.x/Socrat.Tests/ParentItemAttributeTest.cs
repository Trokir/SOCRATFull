using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core;
using Socrat.Core.Entities;
using ParentItemAttribute = Socrat.Lib.ParentItemAttribute;

namespace Socrat.Tests
{
    [TestClass]
    public class ParentItemAttributeTest
    {
        [TestMethod]
        public void TestMethod()
        { 
            CoworkerPosition _coworker = new CoworkerPosition();
            List<FieldInfo> _fields = _coworker.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            List<FieldInfo> _fields1 = _fields.Where(x => x.FieldType.GetInterfaces().Contains(typeof(IEntity))).ToList();
            List<FieldInfo> _fields2 = _fields1.Where(x => x.GetCustomAttribute(typeof(ParentItemAttribute)) == null).ToList();
            int cnt = _fields2.Count();
        }
    }
}