using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.DataProvider;
using Socrat.DataProvider.Repos;
using Socrat.Model.Users;
using Socrat.Module.Order;

namespace Socrat.Tests
{
    [TestClass]
    public class RepsitoryTesting
    {
        [TestMethod]
        public void TestCustomer()
        {
            CustomerRepository _repo = new CustomerRepository();
            var _tmp = _repo.GetAll();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DivisionTest()
        {
            DivisionRepository _repo = new DivisionRepository();

            var _divs = _repo._socratEntities.Divisions;
            var _div1 = _repo._socratEntities.Divisions.First();

            var _divs1 = _repo.GetAll();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddressTest()
        {
            AddressRepository _repo = new AddressRepository();
            var _adrs = _repo.GetAll();
            var _adr = _adrs.First();
        }

        [TestMethod]
        public void CotractAddressesTest()
        {
            ContractAddressRepository _repo = new ContractAddressRepository();
            var _contractsAdrs = _repo.GetAll();
            var _ca = _contractsAdrs.Last();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MaterialNomenclatureTesting()
        {
            MaterialNomRepository _repo = new MaterialNomRepository();
            var _noms = _repo.GetAll();
            var _nom = _noms.FirstOrDefault();
        }

        [TestMethod]
        public void FormulaItemTesting()
        {
            FormulaItemRepository _repo = new FormulaItemRepository();
            Guid _id = Guid.Parse("ea25be96-ef0d-41a3-8c0c-a0380a1bb1f8");
            var _ent = _repo._socratEntities.FormulaItems.FirstOrDefault(x =>
                x.Id == _id);
            var _result = _repo.GetItem(_id);
        }

        [TestMethod]
        public void TreeItemTesting()
        {
            TreeItemRepository  _repo = new TreeItemRepository();
            var its = _repo._socratEntities.TreeItems;
            var _kat = its.Where(x => x.ParentTreeItem_Id != null);
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
            RoleRepository _repo = new RoleRepository();
            TreeItemRepository _repoTreeItem = new TreeItemRepository();
            var _roles = _repo.GetAll();
            var _items = _roles.Last().RoleTreeItems.Where(x => x.ParentTreeItem_Id == null).ToList();

            foreach (var roleTreeItem in _items)
            {
                var _treeItem = _repoTreeItem.GetItem(roleTreeItem.TreeItem_Id ?? Guid.Empty);
                Assert.IsTrue(_treeItem.ParentTreeItem_Id == roleTreeItem.ParentTreeItem_Id);
            }

            var _c = _items.Count();
        }
    }
}
