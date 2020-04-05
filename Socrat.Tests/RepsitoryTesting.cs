using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.DataProvider;

namespace Socrat.Tests
{
    [TestClass]
    public class RepsitoryTesting
    {
        [TestMethod]
        public void TestCustomer()
        {
            IRepository<Customer> _repo = DataHelper.GetRepository<Customer>();
            var _tmp = _repo.GetAll();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DivisionTest()
        {
            IRepository<Division> _repo = DataHelper.GetRepository<Division>();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddressTest()
        {
            IRepository<Address> _repo = DataHelper.GetRepository<Address>();
            var _adrs = _repo.GetAll();
            var _adr = _adrs.First();
        }

        [TestMethod]
        public void CotractAddressesTest()
        {
            IRepository<ContractAddress> _repo = DataHelper.GetRepository<ContractAddress>();
            var _contractsAdrs = _repo.GetAll();
            var _ca = _contractsAdrs.Last();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MaterialNomenclatureTesting()
        {
            IRepository<MaterialNom> _repo = DataHelper.GetRepository<MaterialNom>();
            var _noms = _repo.GetAll();
            var _nom = _noms.FirstOrDefault();
        }

        [TestMethod]
        public void FormulaItemTesting()
        {
            IRepository<FormulaItem> _repo = DataHelper.GetRepository<FormulaItem>();
            var _result = _repo.GetAll();
        }

        [TestMethod]
        public void TreeItemTesting()
        {
            IRepository<TreeItem> _repo = DataHelper.GetRepository< TreeItem>();
            var its = _repo.GetAll();
            var _kat = its.Where(x => x.ParentTreeItemId != null);
            object _parent = null;
            object _res = null;
            foreach (var treeItem in _kat)
            {
                _parent = treeItem.ParentTreeItem;
                _res = _repo.GetItem(treeItem.Id);
            }

            var _all = _repo.GetAll();
        }

        [TestMethod]
        public void RoleTesting()
        {
            IRepository<Role> _repo1 = DataHelper.GetRepository<Role>();
            IRepository<TreeItem> _repo2 = DataHelper.GetRepository<TreeItem>();
            var _roles = _repo1.GetAll();
            var _items = _roles.Last().RoleTreeItems.Where(x => x.TreeItemId == null).ToList();

            foreach (var roleTreeItem in _items)
            {
                var _treeItem = _repo2.GetItem(roleTreeItem.TreeItemId);
                Assert.IsTrue(_treeItem.ParentTreeItemId == roleTreeItem.TreeItemId);
            }

            var _c = _items.Count();
        }

        [TestMethod]
        public void ContractTypeTesting()
        {
            DataFactory _dataFactory = new DataFactory();
            IRepository<ContractType> _repo = _dataFactory.CreateRepository<IRepository<ContractType>>();
            var _contractType = _repo.GetAll().ToList();
            int tmp = _contractType.Count;
        }

        [TestMethod]
        public void ContractTesting()
        {
            DataFactory _dataFactory = new DataFactory();
            IRepository<Contract> _repo = _dataFactory.CreateRepository<IRepository<Contract>>();
            var _contracts = _repo.GetAll().ToList();
            int tmp = _contracts.Count;
        }

        [TestMethod]
        public void OrderAddressTesting()
        {

            var Orders = DataHelper.GetAll<Order>();
            var Order = Orders.FirstOrDefault(x =>x.Id == Guid.Parse("0e940ac6-1c23-4465-92e2-a1a9212906ad"));
            Assert.IsTrue(Order.Address != null);
        }

        [TestMethod]
        public void MaterialTesting()
        {
            var Materials = DataHelper.GetAll<Material>();
            var material = Materials.FirstOrDefault();
            var MatType = material.MaterialType;
        }

        [TestMethod]
        public void OrderComplexTest()
        {
            var _orders = DataHelper.GetAll<Order>();
            var _order = _orders.First();
            var _material = _order.OrderRows.First().Formula.FormulaItems.First().Material;
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FormulaLoadTesting()
        {
            var _formulas = DataHelper.GetAll<Formula>();
            int _cnt = 0;
            foreach (Formula _formula in _formulas)
            {
                _cnt = _formula.FormulaItems.Count;
                if (_cnt > 0)
                    break;
            }
            Assert.IsTrue(_cnt>0);
        }

        [TestMethod]
        public void FormulaItemLoadTesting()
        {
            var _Items = DataHelper.GetAll<FormulaItem>();
            bool _materialPresent = false;
            foreach (FormulaItem _item in _Items)
            {
                _materialPresent = _item.Material != null;
                if (_materialPresent)
                    break;
            }

            Assert.IsTrue(_materialPresent);
        }

        [TestMethod]
        public void MaerialLoadTesting()
        {
            var _mateials = DataHelper.GetAll<Material>();
            bool _enumCodePresent = false;
            foreach (var _mateial in _mateials)
            {
                _enumCodePresent = !string.IsNullOrEmpty(_mateial.EnumCode);
                if (_enumCodePresent)
                {
                    _enumCodePresent = _mateial.MaterialEnum == EnumHelper<MaterialEnum>.Parse(_mateial.EnumCode);
                    break;
                }
            }
            Assert.IsTrue(_enumCodePresent);
        }

        [TestMethod]
        public void DivisionLoadTesting()
        {
            var _divisions = DataHelper.GetAll<Division>();
        }

        [TestMethod]
        public void ContractLoadtesting()
        {
            var _contracts = DataHelper.GetAll<Contract>();
            var _customeres = DataHelper.GetAll<Customer>().GetEnumerator();
            _customeres.MoveNext();
            List<Customer> _customers = new List<Customer>();
            foreach (var _contract in _contracts)
            {
                if (_contract.Customer != null && !_customers.Exists(x => x.Id == (_contract.Customer.Id)))
                    _customers.Add(_contract.Customer);
                if (_contract.Customer == null)
                {
                    _contract.Customer = _customeres.Current;
                    _customeres.MoveNext();
                    DataHelper.Save(_contract);
                }
            }
            Assert.IsTrue(_customers.Count > 0);
        }

        [TestMethod]
        public void FormulaItemDentableTest()
        {
            var _items = DataHelper.GetAll<FormulaItem>();
            IDentableItem _dentableItem;
            foreach (var _formulaItem in _items)
            {
                _dentableItem = _formulaItem as IDentableItem;
                switch (_formulaItem.Material.MaterialEnum)
                {
                    case MaterialEnum.Triplex:
                    case MaterialEnum.Glass:
                        Assert.IsNotNull(_dentableItem);
                        break;    
                }
            }
        }

        [TestMethod]
        public void MaterialLoadingTesting()
        {
            var _mats = DataHelper.GetAll<Material>();
            int _cnt = -1;
            foreach (Material mat in _mats)
            {
                _cnt = mat.TradeMarks.Count;
            }
            Assert.IsTrue(_cnt > -1);
        }
    }
}
