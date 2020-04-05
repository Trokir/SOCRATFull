using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socrat.Model;
using Socrat.Module.Order;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Socrat.DataProvider;

namespace Socrat.Tests
{
    [TestClass]
    public class FormulaModelTesting
    {
        [TestMethod]
        public void TestGlass()
        {
            string _formulaStr = "4";
            Model.Formula _formula = new Model.Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 1);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
        }

        [TestMethod]
        public void TestGlassWithFilm()
        {
            string _formulaStr = "4iPl";
            Model.Formula _formula = new Model.Formula();FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 1);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[0].Items
                              .Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Film) == 1);
        }

        [TestMethod]
        public void TestGU()
        {
            string _formulaStr = "4-10-4";
            Model.Formula _formula = new Model.Formula();
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
            Model.Formula _formula = new Model.Formula();
            FormulaParser.Parse(_formula, _formulaStr);FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 3);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].Items.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestDoubleGU()
        {
            string _formulaStr = "4-10-4-10-4";
            Model.Formula _formula = new Model.Formula();
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
            Model.Formula _formula = new Model.Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 5);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[4].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[3].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].Items.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestDoubleGUArgonGlassFilm()
        {
            string _formulaStr = "4pl-10Ar-4-10Ar-4i";
            Model.Formula _formula = new Model.Formula();
            FormulaParser.Parse(_formula, _formulaStr);
            Assert.IsTrue(_formula.Items.Count == 5);
            Assert.IsTrue(_formula.Items[0].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[2].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[4].MaterialNom.Material.MaterialEnum == MaterialEnum.Glass);
            Assert.IsTrue(_formula.Items[1].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[3].MaterialNom.Material.MaterialEnum == MaterialEnum.Frame);
            Assert.IsTrue(_formula.Items[1].Items.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
            Assert.IsTrue(_formula.Items[3].Items.Count(x => x.MaterialNom.Material.MaterialEnum == MaterialEnum.Gas) == 1);
        }

        [TestMethod]
        public void TestClearFromOperations()
        {
            string _f = "(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])[Зл]-16Поли#Ar-8М1[Пол/Т]-12Липо[Шуко]#Ar-12М1[Шл]";
            string _r = _f.Replace("(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])", "Triplex");
            _r = FormulaParser.ClearFromOperations(_r);
            Assert.IsFalse(_r.Contains("["));
            Assert.IsFalse(_r.Contains("]"));
        }

        [TestMethod]
        public void TestSplitWithTriplex()
        {
            string _f = "(6Т1[Пр/Зак]-38PVB-38PVBСиняя-8М1[Шл/Зак]-76PVB-4М1[Пр/ЗО/Т])[Зл]-16Поли#Ar-8М1[Пол/Т]-12Липо[Шуко]#Ar-12М1[Шл]";
            string[] _parts = FormulaParser.SplitWithTriplex(_f);
        }
    }
}