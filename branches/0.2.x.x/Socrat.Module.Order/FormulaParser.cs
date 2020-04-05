using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider.Repos;
using Socrat.Log;
using Socrat.Model;

namespace Socrat.Module.Order
{
    /// <summary>
    /// Класс парсинга стрики в формулу изделия
    /// </summary>
    public static  class FormulaParser
    {
        public readonly static string GlassFilmAttribute = "PL";
        public readonly static string GasAttribute = "#Ar";

        private static List<Model.Material> _Materials;

        public static Model.Formula Parse(string formulaStr)
        {
            Model.Formula _formula = new Formula();

            if (string.IsNullOrEmpty(formulaStr))
                return _formula;

            _formula.FormulaStr = formulaStr;
            try
            {
                Parse(_formula, formulaStr);
            }
            catch (Exception e)
            {
                _formula.Valid = false;
                Logger.AddErrorEx("FormulaParser.Parse", e);
                XtraMessageBox.Show(e.Message, "Ошибка рсшифровки формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return _formula;
        }

        public static void Parse(Model.Formula formula, string formulaStr)
        {
            formula.Items.Clear();

            string[] _posits = SplitWithTriplex(formulaStr);
            int _cnt = _posits.Length;

            switch (_cnt)
            {
                case 1:
                    if (formulaStr.StartsWith("("))
                        ParseTriplex(formula, ExtractTriplexFormula(formulaStr));
                    else
                        ParseGlass(formula, formulaStr);
                    break;
                case 3:
                case 5:
                    ParseGU(formula, formulaStr);
                    break;
            }

            if (formula != null)
                formula.FormulaStr = formulaStr;

            if (formula != null)
                formula.FormulaStr = formulaStr;
        }

        private static string ExtractTriplexFormula(string triplex)
        {
            return triplex.Replace("(", String.Empty).Replace(")", String.Empty).Trim();
        }

        private static Material GetMaterialByEnum(MaterialEnum materialEnum)
        {
            if (_Materials == null || _Materials.Count < 1)
            {
                using (MaterialRepository _repo = new MaterialRepository())
                {
                    _Materials = _repo.GetAll().ToList();
                }
            }
            else
                return _Materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);

            return null;
        }

        private static void ParseTriplex(Formula formula, string formulaStr)
        {
            string[] _posits = formulaStr.Split('-');

            TriplexItem _triplex = 
                (TriplexItem)formula.GetEmptyTriplex(GetMaterialByEnum(MaterialEnum.Triplex));
            _triplex.ItemStr = formulaStr;
            
            formula.ApendItem(_triplex);
            using (MaterialFinder _repo = new MaterialFinder())
            {
                Model.MaterialNom _mat;
                string _code = string.Empty;
                for (var i = 0; i < _posits.Length; i++)
                {
                    _code = ClearFromOperations(_posits[i]).Trim();
                    _mat = _repo.Find(x => x.Code == _code);
                    if (_mat == null)
                        throw new Exception($"Не найден материал по коду {_code}");
                    switch (_mat.Material.MaterialEnum)
                    {
                        case MaterialEnum.Glass:
                            _triplex.AppendItem(new GlassItem { MaterialNom = _mat, ItemStr = _posits[i] });
                            break;
                        case MaterialEnum.TriplexFilm:
                            _triplex.AppendItem(new TriplexFilmItem { MaterialNom = _mat, ItemStr = _posits[i] });
                            break;
                    }
                }
            }
        }

        public static string[] SplitWithTriplex(string formula)
        {
            List<string> _list = null;
            Dictionary<string, string> _triplexes = new Dictionary<string, string>();
            string _modedFormula = formula;

            //заменяем триплексы псевдонимами
            Regex _triplexRegex = new Regex(@"\(.*\)");
            MatchCollection _triplexMatches = _triplexRegex.Matches(formula);
            string _triplexAlias;
            for (var index = 0; index < _triplexMatches.Count; index++)
            {
                _triplexAlias = $"Triplex{index}";
                _modedFormula = _modedFormula.Remove(_triplexMatches[index].Index, _triplexMatches[index].Length);
                _modedFormula = _modedFormula.Insert(_triplexMatches[index].Index, _triplexAlias);
                _triplexes.Add(_triplexAlias, _triplexMatches[index].Value);
            }
            //разбиваем формулу
            _list = new List<string>(_modedFormula.Split('-'));

            //заменяем обратно псевдонимы на формулы триплексов
            for (var i = 0; i < _list.Count; i++)
            {
                foreach (string key in _triplexes.Keys)
                {
                    if (_list[i].Contains(key))
                        _list[i] = _list[i].Replace(key, _triplexes[key]);
                }
            }

            return _list.ToArray();
        }

        public static string ClearFromOperations(string formulaStr)
        {
            string _res = string.Empty;
            bool canCopy = true;
            for (var i = 0; i < formulaStr.Length; i++)
            {
                if (canCopy && formulaStr[i] == '[')
                {
                    canCopy = false;
                    continue;
                }
                if (!canCopy && formulaStr[i] == ']')
                {
                    canCopy = true;
                    continue;
                }
                if (canCopy)
                    _res = string.Concat(_res, formulaStr[i]);
            }

            return _res;
        }

        private static void ParseGU(Formula _formula, string formulaStr)
        {
            string[] _posits = SplitWithTriplex(formulaStr);
            using (MaterialFinder _repo = new MaterialFinder())
            {
                Model.MaterialNom _mat;
                for (int i = 0; i < _posits.Length; i++)
                {
                    string _code = _posits[i];
                    FormulaItem _item;
                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 4:
                            if (_code.StartsWith("("))
                            {
                                _code = ClearFromOperations(_code);
                                ParseTriplex(_formula, ExtractTriplexFormula(_code));
                            }
                            else
                            {
                                bool _filmOnGlass = _code.ToUpper().EndsWith(GlassFilmAttribute);
                                if (_filmOnGlass)
                                    _code = _code.Remove(_code.Length - GlassFilmAttribute.Length, GlassFilmAttribute.Length);
                                _code = ClearFromOperations(_code);
                                _mat = _repo.Find(x => x.Code == _code);
                                CheckGlass(_mat, _code, _formula);
                                _item = new GlassItem {MaterialNom = _mat, ItemStr = _code};
                                //if (_filmOnGlass)
                                //    AddFilm(_item, _repo);
                                _formula.ApendItem(_item);
                            }
                            break;
                        case 1:
                        case 3:
                            bool _gasInFrame = _code.ToUpper().EndsWith(GasAttribute.ToUpper());
                            if (_gasInFrame)
                                _code = _code.Remove(_code.Length - GasAttribute.Length, GasAttribute.Length);
                            _code = ClearFromOperations(_code);
                            _mat = _repo.Find(x => x.Code == _code);
                            CheckFrame(_mat, _code, _formula);
                            _item = new FrameItem {MaterialNom = _mat, ItemStr = _code, Gaz = _gasInFrame };
                            _formula.ApendItem(_item);
                            break;
                        default:
                            throw new Exception($"Не верный формат формулы {formulaStr}");
                    }
                }
            }
        }

        //private static void AddFilm(FormulaItem item, MaterialFinder repo)
        //{
        //    FormulaItem gasItem = new FilmItem();;
        //    gasItem.MaterialNom = repo.Find(x => x.Code.ToUpper() == GlassFilmAttribute.ToUpper());
        //    gasItem.MaterialNom.Material = new Model.Material {Name = "Пленка"};
        //    gasItem.ItemStr = GlassFilmAttribute;
        //    item.Items.Add(gasItem);
        //}

        //private static void AddGas(FormulaItem item, MaterialFinder repo)
        //{
        //    FormulaItem gasItem = new GasItem();
        //    gasItem.MaterialNom = repo.Find(x => x.Code.ToUpper() == GasAttribute.ToUpper());
        //    gasItem.ItemStr = GasAttribute;
        //    gasItem.MaterialNom.Material = new Model.Material { Name = "Газ" };
        //    item.Items.Add(gasItem);
        //}

        private static void ParseGlass(Model.Formula _formula, string formulaStr)
        {
            Model.MaterialNom _mat = null;
            FormulaItem _item;
            using (MaterialFinder _repo = new MaterialFinder())
            {
                string _code = formulaStr;
                bool _filmOnGlass = _code.ToUpper().EndsWith(GlassFilmAttribute);
                if (_filmOnGlass)
                    _code = _code.Remove(_code.ToUpper().IndexOf(GlassFilmAttribute), GlassFilmAttribute.Length);
                _mat = _repo.Find(x => x.Code == _code);
                CheckGlass(_mat, _code, _formula);
                _item = new GlassItem { MaterialNom = _mat, ItemStr = formulaStr };
                //if (_filmOnGlass)
                //    AddFilm(_item, _repo);
                _formula.ApendItem(_item);
            }
        }

        private static void CheckGlass(Model.MaterialNom regMaterial, string code, Formula formula)
        {
            formula.Valid = false;
            if (regMaterial == null)
                throw new Exception($"Не найден материал по указанному коду {code}");
            if (regMaterial.Material == null)
                throw new Exception($"Не указан тип исходного материала {regMaterial}");
            if (regMaterial.Material.MaterialEnum != MaterialEnum.Glass)
                throw new Exception($"Код материала {regMaterial.Code} опредеяется недопустимо для позиции материала ({regMaterial.Material.Name})");
            formula.Valid = true;
        }

        private static void CheckFrame(Model.MaterialNom regMaterial, string code, Formula formula)
        {
            formula.Valid = false;
            if (regMaterial == null)
                throw new Exception($"Не найден материал по указанному коду {code}");
            if (regMaterial.Material == null)
                throw new Exception($"Не указан тип исходного материала {regMaterial}");
            if (regMaterial.Material.MaterialEnum != MaterialEnum.Frame)
                throw new Exception($"Код материала {regMaterial.Code} опредеяется недопустимо для позиции материала ({regMaterial.Material.Name})");
            formula.Valid = true;
        }
    }
}