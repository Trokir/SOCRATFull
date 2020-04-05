using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Log;
using Socrat.References.Params;
using FormulaItem = Socrat.Core.Entities.FormulaItem;
using GlassItem = Socrat.Core.Added.GlassItem;
using TriplexFilmItem = Socrat.Core.Added.TriplexFilmItem;
using TriplexItem = Socrat.Core.Added.TriplexItem;

namespace Socrat.References.Formula
{
    /// <summary>
    /// Класс парсинга стрики в формулу изделия
    /// </summary>
    public static class FormulaParser
    {
        public readonly static string GlassFilmAttribute = "PL";
        /// <summary>
        /// Призак аргона (штатный)
        /// </summary>
        public readonly static string GasAttribute = "#Ar";
        /// <summary>
        /// Устаревший
        /// </summary>
        public readonly static string GasAttributeAdd = "Ar";
        /// <summary>
        /// С ошибкой А - русское
        /// </summary>
        public readonly static string GasAttributeR = "#Аr";
        /// <summary>
        /// С ошибкой А - русское
        /// </summary>
        public readonly static string GasAttributeAddR = "Аr";

        private static List<Socrat.Core.Entities.Material> _materials;

        public static Socrat.Core.Entities.Formula Parse(string formulaStr)
        {
            _materials = DataHelper.GetAll<Material>();
            Core.Entities.Formula _formula = new Core.Entities.Formula();

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
                XtraMessageBox.Show(e.Message, "Ошибка расшифровки формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return _formula;
        }

        //private static bool ValidateMap(SortedList<string, FrameItemTag> map)
        //{
        //    bool res = false;

        //    return res;
        //}

        public static bool Parse(Socrat.Core.Entities.Formula formula, string formulaStr)
        {
            bool res = false;
            //var _newMap = BuildMap(1, formulaStr);
            //if (formula.TagMap.Equals(_newMap))
            //    return;

            _materials = DataHelper.GetAll<Material>();
            formula.Clear();
            try
            {
                string[] _posits = SplitWithTriplex(formulaStr);
                int _cnt = _posits.Length;

                switch (_cnt)
                {
                    case 1:
                        if (formulaStr.StartsWith("("))
                            ParseTriplex(formula, ExtractTriplexFormula(formulaStr), null, false);
                        else
                            ParseGlass(formula, formulaStr.Trim());
                        break;
                    case 3:
                    case 5:
                        ParseGu(formula, formulaStr.Trim());
                        break;
                }

                if (formula != null)
                    formula.RebuildFormulaStr();

                res = true;
            }
            catch (Exception e)
            {
                formula.Valid = false;
                Logger.AddErrorEx("FormulaParser.Parse", e);
                XtraMessageBox.Show(e.Message, "Ошибка расшифровки формулы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res = false;
            }
            return res;
        }

        /// <summary>
        /// Строит карту изделия
        /// </summary>
        /// <param name="formulaStr">строковая формула</param>
        /// <returns>карта изделия</returns>
        public static SortedList<int, FrameItemTag> BuildMap(int startLevel, string formulaStr)
        {
            SortedList<int, FrameItemTag> _map = new SortedList<int, FrameItemTag>();

            int localLevel = startLevel;
            FrameItemTag _tag;
            if (startLevel == 1)
            {
                _tag = new FrameItemTag {Level = localLevel, Num = 1, ItemStr = formulaStr};
                _map.Add(_tag.Key, _tag);
                localLevel++;
            }

            string[] _items = SplitWithTriplex(formulaStr);
            
            for (var i = 0; i < _items.Length; i++)
            {
                _tag = new FrameItemTag {Level = localLevel, Num = i + 1, ItemStr = _items[i]};
                _map.Add(_tag.Key, _tag);
                if (_items[i].StartsWith("("))
                {
                    string _operations = string.Empty;
                    string _subFormula = SeparateOperations(_items[i], out _operations);
                    _subFormula = ExtractTriplexFormula(_subFormula);
                    var _subMap = BuildMap(localLevel + 1, _subFormula);
                    foreach (KeyValuePair<int, FrameItemTag> frameItemTag in _subMap)
                    {
                        _map.Add(frameItemTag.Key, frameItemTag.Value);
                    }
                }
            }

            return _map;
        }

        public static bool MapsEquals(SortedList<int, FrameItemTag> map1, SortedList<int, FrameItemTag> map2)
        {
            bool res = true;
            if (map1.Count != map2.Count)
                return false;
            foreach (KeyValuePair<int, FrameItemTag> frameItemTag in map1)
            {
                if (!map2.ContainsKey(frameItemTag.Key))
                {
                    res = false;
                    break;
                }
                if (!map2[frameItemTag.Key].Equals(frameItemTag.Value))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        private static string ExtractTriplexFormula(string triplex)
        {
            return triplex.Replace("(", String.Empty).Replace(")", String.Empty).Trim();
        }

        private static Material GetMaterialByEnum(MaterialEnum materialEnum)
        {
            if (_materials == null || _materials.Count < 1)
            {
                using (Socrat.Core.IRepository<Socrat.Core.Entities.Material> _repo = DataHelper.GetRepository<Socrat.Core.Entities.Material>())
                {
                    _materials = _repo.GetAll().ToList();
                }
            }
            else
                return _materials.FirstOrDefault(x => x.MaterialEnum == materialEnum);

            return null;
        }

        private static void ParseTriplex(Core.Entities.Formula formula, string formulaStr, string operations, bool insideUnit)
        {
            string[] _posits = formulaStr.Split('-');
            TriplexItem _triplex =
                (TriplexItem)formula.GetEmptyTriplex(GetMaterialByEnum(MaterialEnum.Triplex));
            _triplex.ItemStr = formulaStr;

            if (insideUnit)
                formula.ApendItem(_triplex);
            else
                formula.ApendRootItem(_triplex);
            using (MaterialFinder _repo = new MaterialFinder())
            {
                MaterialNom _mat;
                string _code = string.Empty;
                for (var i = 0; i < _posits.Length; i++)
                {
                    _code = SeparateOperations(_posits[i], out operations);
                    _mat = _repo.Find(x => x.Code == _code && (x.Material.MaterialEnum == MaterialEnum.Glass 
                                                               || x.Material.MaterialEnum == MaterialEnum.TriplexFilm));
                    if (_mat == null)
                        throw new Exception($"Не найден материал по коду {_code}");
                    FormulaItem _formulaItem = null;
                    switch (_mat.VendorMaterialNom.Material.MaterialEnum)
                    {
                        case MaterialEnum.Glass:
                            _formulaItem = new GlassItem {MaterialNom = _mat, Material = _mat.Material, ItemStr = _posits[i]};
                            break;
                        case MaterialEnum.TriplexFilm:
                            _formulaItem = new TriplexFilmItem {MaterialNom = _mat, Material = _mat.Material, ItemStr = _posits[i]};
                            break;
                    }
                    if (_formulaItem != null && _mat != null &&  !string.IsNullOrEmpty(operations))
                        ParseOperations(_formulaItem, _mat, operations);
                    if (_formulaItem != null)
                        _triplex.AppendItem(_formulaItem);
                }

                formula.Valid = true;
            }
        }

        public static TriplexItem ParseTriplex(string formuaStr)
        {
            TriplexItem _triplexItem = null;
            using (Core.Entities.Formula _trpxFromual = Parse(formuaStr))
            {
                _triplexItem = _trpxFromual.RootItem as TriplexItem;
                _triplexItem.Formula = null;
            }
            return _triplexItem;
        }

        public static GlassItem ParseGlass(string formulaStr)
        {
            GlassItem _glassItem = null;
            using (Core.Entities.Formula _glassFormula = Parse(formulaStr))
            {
                _glassItem = _glassFormula.RootItem as GlassItem;
                _glassItem.Formula = null;

            }
            return _glassItem;
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

        public static string SeparateOperations(string formulaStr, out string operations)
        {
            string _res = string.Empty;
            bool canCopy = true;
            bool isTriplexBlock = false;
            for (var i = 0; i < formulaStr.Length; i++)
            {
                if (formulaStr[i] == '(')
                    isTriplexBlock = true;
                if (formulaStr[i] == ')')
                    isTriplexBlock = false;

                if (canCopy && !isTriplexBlock && formulaStr[i] == '[')
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

            if (formulaStr.Length > _res.Length)
                operations = formulaStr.Replace(_res, String.Empty);
            else
                operations = string.Empty;
            return _res;
        }

        private static void ParseGu(Core.Entities.Formula _formula, string formulaStr)
        {
            _formula.FormulaItems.Clear();
            _formula.ApendRootItem(new GlassUnitItem { MaterialEnum = MaterialEnum.GU});

            string[] _posits = SplitWithTriplex(formulaStr);
            using (MaterialFinder _repo = new MaterialFinder())
            {
                MaterialNom _mat;
                string _operations;
                for (int i = 0; i < _posits.Length; i++)
                {
                    string _code = _posits[i].Trim();
                    FormulaItem _item;
                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 4:
                            if (_code.StartsWith("("))
                            {
                                _operations = String.Empty;
                                _code = SeparateOperations(_code, out _operations);
                                ParseTriplex(_formula, ExtractTriplexFormula(_code), _operations, true);
                            }
                            else
                            {
                                bool _filmOnGlass = _code.ToUpper().EndsWith(GlassFilmAttribute);
                                if (_filmOnGlass)
                                    _code = _code.Remove(_code.Length - GlassFilmAttribute.Length, GlassFilmAttribute.Length);
                                _operations = String.Empty;
                                _code = SeparateOperations(_code, out _operations);
                                _mat = _repo.Find(x => x.Code == _code && x.Material.MaterialEnum == MaterialEnum.Glass);
                                CheckGlass(_mat, _code, _formula);
                                _item = new GlassItem
                                {
                                    MaterialNom = _mat,
                                    ItemStr = _code,
                                    Material = _mat.VendorMaterialNom?.Material
                                };
                                //if (_filmOnGlass)
                                //    AddFilm(_item, _repo);
                                if (_item != null && _mat != null && _operations.Length > 0)
                                    ParseOperations(_item, _mat, _operations);
                                _formula.ApendItem(_item);
                            }
                            break;
                        case 1:
                        case 3:
                            bool _gasInFrame = false;
                            //определение признака аргона #Ar
                            _gasInFrame = _code.ToUpper().EndsWith(GasAttribute.ToUpper());
                            if (_gasInFrame)
                                _code = _code.Remove(_code.Length - GasAttribute.Length, GasAttribute.Length);
                            if (!_gasInFrame)
                            {
                                //Ar
                                _gasInFrame = _code.ToUpper().EndsWith(GasAttributeAdd.ToUpper());
                                if (_gasInFrame)
                                    _code = _code.Remove(_code.Length - GasAttributeAdd.Length, GasAttributeAdd.Length);
                            }
                            if (!_gasInFrame)
                            {
                                //#Аr(А - русское)
                                _gasInFrame = _code.ToUpper().EndsWith(GasAttributeR.ToUpper());
                                if (_gasInFrame)
                                    _code = _code.Remove(_code.Length - GasAttributeR.Length, GasAttributeR.Length);
                            }
                            if (!_gasInFrame)
                            {
                                //Аr(А - русское)
                                _gasInFrame = _code.ToUpper().EndsWith(GasAttributeAddR.ToUpper());
                                if (_gasInFrame)
                                    _code = _code.Remove(_code.Length - GasAttributeAddR.Length, GasAttributeAddR.Length);
                            }

                            _operations = String.Empty;
                            _code = SeparateOperations(_code, out _operations);
                            _mat = _repo.Find(x => x.Code == _code && x.Material.MaterialEnum == MaterialEnum.Frame);

                            CheckFrame(_mat, _code, _formula);
                            _item = new FrameItem
                            {
                                MaterialNom = _mat,
                                Material = _mat.VendorMaterialNom?.Material,
                                ItemStr = _code,
                                Gaz = _gasInFrame
                            };
                            if (_item != null && _mat != null && _operations.Length > 0)
                                ParseOperations(_item, _mat, _operations);
                            _formula.RootItem.ApendItem(_item);
                            break;
                        default:
                            throw new Exception($"Не верный формат формулы {formulaStr}");
                    }
                }
            }
        }

        private static void ParseOperations(FormulaItem formulaItem, MaterialNom materialNom, string operations)
        {
            string _ops = operations.Replace("[", string.Empty).Replace("]", string.Empty);
            string[] _opsList = _ops.Split('/');
            string procShortName = string.Empty;
            if (_opsList.Length > 0)
            {
                using (IRepository<Processing> _repository =
                    DataHelper.GetRepository<Processing>())
                {
                    Processing _processing = null;
                    for (var i = 0; i < _opsList.Length; i++)
                    {
                        procShortName = _opsList[i].Trim();
                        _processing = _repository.GetItem(x => x.ShortName == procShortName);
                        if (_processing != null)
                            formulaItem.FormulaItemProcessings.Add(new FormulaItemProcessing
                            {
                                FormulaItem = formulaItem,
                                Processing = _processing
                            });
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

        private static void ParseGlass(Socrat.Core.Entities.Formula _formula, string formulaStr)
        {
            MaterialNom _mat = null;
            FormulaItem _item;
            using (MaterialFinder _repo = new MaterialFinder())
            {
                string _code = formulaStr;
                bool _filmOnGlass = _code.ToUpper().EndsWith(GlassFilmAttribute);
                if (_filmOnGlass)
                    _code = _code.Remove(_code.ToUpper().IndexOf(GlassFilmAttribute), GlassFilmAttribute.Length);
                _mat = _repo.Find(x => x.Code == _code && x.Material.MaterialEnum == MaterialEnum.Glass);
                CheckGlass(_mat, _code, _formula);
                _item = new GlassItem
                {
                    MaterialNom = _mat,
                    Material = _mat.VendorMaterialNom?.Material,
                    ItemStr = formulaStr
                };
                //if (_filmOnGlass)
                //    AddFilm(_item, _repo);
                _formula.ApendRootItem(_item);
            }
        }

        private static void CheckGlass(MaterialNom regMaterial, string code, Core.Entities.Formula formula)
        {
            formula.Valid = false;
            if (code.Length<1)
                throw new Exception("Не указан код стекла");
            if (regMaterial == null)
                throw new Exception($"Не найдено стекло по указанному коду {code}");
            if (regMaterial.VendorMaterialNom?.Material == null)
                throw new Exception($"Не указан тип исходного стекла {regMaterial}");
            if (regMaterial.VendorMaterialNom?.Material.MaterialEnum != MaterialEnum.Glass)
                throw new Exception($"Код материал {regMaterial.Code} опредеяется недопустимо для позиции стекла ({regMaterial.VendorMaterialNom?.Material.Name})");
            formula.Valid = true;
        }

        private static void CheckFrame(MaterialNom regMaterial, string code, Core.Entities.Formula formula)
        {
            formula.Valid = false;
            if (code.Length < 1)
                throw new Exception("Не указан код рамки");
            if (regMaterial == null)
                throw new Exception($"Не найдена рамка по указанному коду {code}");
            if (regMaterial.VendorMaterialNom?.Material == null)
                throw new Exception($"Не указан тип исходной рамки {regMaterial}");
            if (regMaterial.VendorMaterialNom?.Material.MaterialEnum != MaterialEnum.Frame)
                throw new Exception($"Код материала {regMaterial.Code} опредеяется недопустимо для позиции рамки ({regMaterial.VendorMaterialNom?.Material.Name})");
            formula.Valid = true;
        }

        public static GlassItem GetDefaultGlass()
        {
            GlassItem _item = null;
            using (MaterialFinder _repo = new MaterialFinder())
            {
                MaterialNom _materialNom = _repo.Find(x => x.Code == AppParams.Params[ParamAlias.DefaultItem]
                                                           && x.Material.MaterialEnum == MaterialEnum.Glass);
                _item = new GlassItem { MaterialNom =  _materialNom, ItemStr = AppParams.Params[ParamAlias.DefaultItem] };
            }
            return _item;
        }

        public static FrameItem GetDefaultFarme()
        {
            FrameItem _item = null;
            using (MaterialFinder _repo = new MaterialFinder())
            {
                MaterialNom _materialNom = _repo.Find(x => x.Code == "10" && x.Material.MaterialEnum == MaterialEnum.Frame);
                _item = new FrameItem { MaterialNom = _materialNom, ItemStr = "10" };
            }
            return _item;
        }

        public static TriplexFilmItem GetDefaultTriplexFilm()
        {
            TriplexFilmItem _item = null;
            using (MaterialFinder _repo = new MaterialFinder())
            {
                MaterialNom _materialNom = _repo.Find(x => x.Code == "38PVB"
                                                           && x.Material.MaterialEnum == MaterialEnum.TriplexFilm);
                _item = new TriplexFilmItem { MaterialNom = _materialNom, ItemStr = "38PVB" };
            }
            return _item;
        }
    }
}