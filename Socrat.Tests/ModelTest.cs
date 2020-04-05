using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void CustomerTesting()
        {
            Guid _id = Guid.Empty;
            IRepository<Customer> _repo = DataHelper.GetRepository<Customer>();
            List<Customer> _customers = _repo.GetAll().ToList();
            Customer _customer = _customers.FirstOrDefault(x => x.Contracts != null && x.Contracts.Count > 0);
            Guid _newId = Guid.NewGuid();
            _customer.Id = _newId;
            Assert.IsTrue(_customer.Id == _customer.Contracts.First().Customer.Id && 
                          _customer.Contracts.First()?.ParentEntities.FirstOrDefault()?.Id == _customer.Id);
        }
    }
}
