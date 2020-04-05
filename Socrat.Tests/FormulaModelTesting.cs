using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Formula;

namespace Socrat.Tests
{
    [TestClass]
    public class FormulaModelTesting
    {
        [TestMethod]
        public void TestGlass()
        {
            string _formulaStr = "4";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 1);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
        }

        [TestMethod]
        public void TestGlassWithFilm()
        {
            string _formulaStr = "4iPl";
            Formula _formula = new Formula();FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 1);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[0].FormulaItems
                              .Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Film) == 1);
        }

        [TestMethod]
        public void TestGU()
        {
            string _formulaStr = "4-10-4";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 3);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
        }

        [TestMethod]
        public void TestGUArgon()
        {
            string _formulaStr = "4-10Ar-4";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 3);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].FormulaItems.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestDoubleGU()
        {
            string _formulaStr = "4-10-4-10-4";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 5);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[4].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[3].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
        }

        [TestMethod]
        public void TestDoubleGUArgon()
        {
            string _formulaStr = "4-10Ar-4-10-4";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 5);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[4].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[3].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].FormulaItems.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestDoubleGUArgonGlassFilm()
        {
            string _formulaStr = "4pl-10Ar-4-10Ar-4i";
            Formula _formula = new Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 5);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[4].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[3].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].FormulaItems.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
            Assert.IsTrue(_formula.Items[3].FormulaItems.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestBuildMap()
        {
            string _f = "(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])[Зл]-16Поли#Ar-8М1[Пол/Т]-12Липо[Шуко]#Ar-12М1[Шл]";
            string _r = _f.Replace("(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])", "Triplex");
            var _map = FormulaParser.BuildMap(1,_f);
            var _cnt = _map.Count;

        }
        [TestMethod]
        public void FormulaMapsTestings()
        {
            var _formulas = EntityFrameworkConnection.SocratEntities.Formulae;
            bool _res = true;
            int _y = 0, _n = 0, _e = 0;
            foreach (Formula formula in _formulas)
            {
                try
                {
                    var _map1 = formula.TagMap;
                    if (_map1 == null)
                        continue;
                    var _map2 = FormulaParser.BuildMap(1, formula.FormulaStr);
                    _res = FormulaParser.MapsEquals(_map1, _map2);
                    if (!_res)
                        _n++;
                    else
                        _y++;
                }
                catch 
                {
                    _e++;
                }
            }
            Assert.IsTrue(_y > _n);
        }

        [TestMethod]
        public void TestSplitWithTriplex()
        {
            string _f = "(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])[Зл]-16Поли#Ar-8М1[Пол/Т]-12Липо[Шуко]#Ar-12М1[Шл]";
            string[] _parts = FormulaParser.SplitWithTriplex(_f);
        }
    }
}