using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Формула изделия
    /// </summary>
    public class Formula : Entity, IDrawableItem, IThickableItem, IDentableItem
    {
        public Formula()
        {
        }

        private string _FormulaStr;

        public string FormulaStr
        {
            get { return _FormulaStr; }
            set { SetField(ref _FormulaStr, value, () => FormulaStr); }
        }

        [NotMapped]
        public FormulaItem RootItem
        {
            get { return GetRootItem(); }
            set { SetRootItem(value); }
        }

        private void SetRootItem(FormulaItem value)
        {
            if (FormulaItems == null)
                FormulaItems = new List<FormulaItem>();
            if (FormulaItems.Count > 0)
                FormulaItems.Clear();
            FormulaItems.Add(value);
        }

        private FormulaItem GetRootItem()
        {
            if (FormulaItems == null || FormulaItems.Count < 1)
                SetRootItem(new FormulaItem { Formula = this});
            return FormulaItems.FirstOrDefault();
        }

        [NotMapped]
        public List<FormulaItem> Items
        {
            get { return FormulaItems.Where(x => x.ParentItemId == null).OrderBy(x => x.Position).ToList(); }
        }
        public double Thickness
        {
            get { return Items.Sum(x => x.Thickness); }
        }

        public double DrawThickness
        {
            get { return Items.Sum(x => x.DrawThickness); }
        }

        public bool DentExists
        {
            get { return GetDentexists(); }
        }

        private bool GetDentexists()
        {
            bool res = false;
            PropertyInfo _propInfo = RootItem.GetType().GetProperty("DentExists");
            if (_propInfo != null)
            {
                var tmp = _propInfo.GetValue(RootItem);
                if (tmp != null)
                    bool.TryParse(tmp.ToString(), out res);
            } 
            return res;
        }

        public override string ToString()
        {
            return FormulaStr;
        }

        public void ApendRootItem(FormulaItem item)
        {
            FormulaItems.Clear();
            item.Formula = this;
            item.Position = 0;
            FormulaItems.Add(item);
            item.Changed = false;
            
        }

        public void ApendItem(FormulaItem item)
        {
            item.Formula = this;
            item.Position = (short)(RootItem.FormulaItems?.Count ?? 0);
            RootItem.FormulaItems.Add(item);
            item.ParentItem = RootItem;
            //if (IsStartTriplexSet(LastItem, item))
            //{
            //    FormulaItem _formulaItem = LastItem;
            //    RootItem.FormulaItems.Remove(_formulaItem);
            //    FormulaItem _triplex = new TriplexItem { Formula = this };
            //    RootItem.AppendItem(_triplex);
            //    _triplex.AppendItem(_formulaItem);
            //    _triplex.AppendItem(item);
            //}
            //else
            //{
            //    RootItem.AppendItem(item);

            //    //if (LastItem.Id == RootItem.Id)
            //    //{
            //    //    
            //    //}
            //    //else if (LastItem != null
            //    //    && LastItem.Material.MaterialEnum == MaterialEnum.Triplex
            //    //    && item.Material.MaterialEnum != MaterialEnum.Triplex
            //    //    && LastItem.CanAppend.Contains(item.Material.MaterialEnum))
            //    //    LastItem.AppendItem(item);
            //}

            item.Changed = true;
        }

        private bool IsStartTriplexSet(FormulaItem lastItem, FormulaItem item)
        {
            bool res = lastItem != null;
            res = res && lastItem.MaterialEnum == MaterialEnum.Glass;
            res = res && item.MaterialEnum == MaterialEnum.TriplexFilm;
            return res;
        }

        private bool _valid = true;
        public bool Valid
        {
            get => GetValid();
            set => _valid = value;
        }

        private bool GetValid()
        {
            return RootItem.Valid && !string.IsNullOrEmpty(FormulaStr);
        }

        public FormulaItem LastItem
        {
            get { return RootItem.FormulaItems.LastOrDefault() ?? RootItem; }
        }

        public virtual List<FormulaItem> FormulaItems { get; set; } = new List<FormulaItem>();

        public void ResetSelection()
        {
            if (RootItem != null)
                foreach (FormulaItem formulaItem in RootItem.Items)
                    formulaItem.ResetSelection();
        }

        public void RebuildFormulaStr()
        {
            _FormulaStr = string.Empty;
            if (RootItem != null)
            {
                RootItem.RebuildItemStr();
                FormulaStr = RootItem.ItemStr;
            }
        }

        /// <summary>
        /// Доступные добавления
        /// </summary>
        public MaterialEnum[] CanAppend
        {
            get { return GetWhatCanAppend(); }
        }

        /// <summary>
        /// Определяет что можно добавить в формулу
        /// </summary>
        /// <returns></returns>
        private MaterialEnum[] GetWhatCanAppend()
        {
            MaterialEnum[] _materials = null;
            if (RootItem.Items.Count < 1)
            {
                _materials = new MaterialEnum[]
                {
                    MaterialEnum.Glass,
                    MaterialEnum.Triplex
                };
            }
            else
            {
                switch (LastItem.MaterialEnum)
                {
                    case MaterialEnum.Glass:
                    case MaterialEnum.Triplex:
                        _materials = new MaterialEnum[]
                        {
                            MaterialEnum.TriplexFilm,
                            MaterialEnum.Frame
                        };
                        break;
                    case MaterialEnum.Frame:
                        _materials = new MaterialEnum[]
                        {
                            MaterialEnum.Glass,
                            MaterialEnum.Triplex
                        };
                        break;
                    case MaterialEnum.TriplexFilm:
                        _materials = new MaterialEnum[] { MaterialEnum.TriplexFilm, MaterialEnum.Glass };
                        break;
                }
            }

            return _materials;
        }

        /// <summary>
        /// Доступные замены
        /// </summary>
        public MaterialEnum[] CanChangeTo
        {
            get { return GetCanChangeTo(); }
        }
        public MaterialEnum[] GetCanChangeTo()
        {
            MaterialEnum[] _materials = null;
            return _materials;
        }

        /// <summary>
        /// Доступные операции
        /// </summary>
        public FormulaItemProcessingEnum[] CanProcess
        {
            get { return GetWhatCanProcess(); }
        }

        private FormulaItemProcessingEnum[] GetWhatCanProcess()
        {
            FormulaItemProcessingEnum[] _processings = null;
            return _processings;
        }

        public FormulaItem GetEmptyTriplex(Material triplexMaterial)
        {
            FormulaItem _formulaItem = new TriplexItem { Formula = this };
            _formulaItem.MaterialEnum = MaterialEnum.Triplex;
            return _formulaItem;
        }

        public void AddEmptyTriplex(Material triplexMaterial)
        {
            FormulaItem _formulaItem = GetEmptyTriplex(triplexMaterial);
            FormulaItems.Add(_formulaItem);
            string _joinSeparator = String.Empty;
            if (RootItem.Items.Count > 0)
                _joinSeparator = "-";
            FormulaStr = string.Join(_joinSeparator, new string[] { FormulaStr, "()" });
        }

        public void ReplaceFormulaItem(FormulaItem oldItem, FormulaItem newItem)
        {
            int _indx = RootItem.FormulaItems.IndexOf(oldItem);
            if (_indx > -1)
            {
                RootItem.FormulaItems.RemoveAt(_indx);
                newItem.Formula = this;
                newItem.ParentItem = oldItem.ParentItem;
                newItem.Position = oldItem.Position;
                newItem.CopyOperatinsFrom(oldItem);
                RootItem.FormulaItems.Insert(_indx, newItem);
                DeletedItem(oldItem);
            }
            else
            {
                bool res = false;
                foreach (var formulaItem in FormulaItems)
                {
                    res = formulaItem.ReplaceFormulaItem(oldItem, newItem);
                    if (res)
                        break;
                }
            }
        }

        public void ReplaceToEptyTriplex(FormulaItem oldItem, FormulaItem triplex)
        {
            FormulaItem _formulaItem = triplex;
            oldItem.FormulaItemProcessings.Clear();
            ReplaceFormulaItem(oldItem, _formulaItem);
        }

        public void DeletedItem(FormulaItem item)
        {
            int _indx = FormulaItems.IndexOf(item);
            if (_indx > -1)
            {
                FormulaItems.RemoveAt(_indx);
            }
            RootItem.DeleteItem(item.Id);
        }

        public void Clear()
        {
            if (RootItem != null)
                RootItem.FormulaItems.Clear();
            else
                FormulaItems.Clear();
            Valid = false;
        }

        /// <summary>
        /// Упорядочивание формулы
        /// </summary>
        public void Ordering()
        {
            byte i = 0;
            foreach (FormulaItem formulaItem in RootItem.Items)
            {
                formulaItem.Formula = this;
                formulaItem.Position = i;
                formulaItem.Ordering();
                i++;
            }
        }

        private bool _ShowPositionsNumbers = true;
        public bool ShowPositionsNumbers
        {
            get { return _ShowPositionsNumbers; }
            set
            {
                _ShowPositionsNumbers = value;
                OnPropertyChanged("ShowPositionsNumbers");
            }
        }

        public int[] GetGlassPositionsNumbers(GlassItem item)
        {
            int[] _res = null;
            var _glasses = GatAllGlasses().Distinct().ToList();
            SortedList<int, FormulaItem> _sortedGlasses = new SortedList<int, FormulaItem>();
            int _globalPos = -1;
            foreach (GlassItem glassItem in _glasses)
            {
                _globalPos = glassItem.GetGloabalPosition();
                if (!_sortedGlasses.ContainsKey(_globalPos))
                    _sortedGlasses.Add(_globalPos, glassItem);
            }
            if (_sortedGlasses.Count > 0)
            {
                int _glassNum = _sortedGlasses.Values.IndexOf(item);
                if (_glassNum > -1)
                    _glassNum++;
                _res = new int[] { (_glassNum * 2 - 1), (_glassNum * 2) };
            }

            return _res;
        }

        private List<GlassItem> GatAllGlasses()
        {
            List<GlassItem> _glasses = new List<GlassItem>();
            foreach (FormulaItem _item in FormulaItems)
            {
                if (_item.MaterialEnum == MaterialEnum.Glass)
                    _glasses.Add((GlassItem)_item);
                else
                {
                    var _itemGlasses = _item.GetAllGlasses();
                    if (_itemGlasses.Count > 0)
                        _glasses.AddRange(_itemGlasses);
                }
            }
            return _glasses;
        }

        public virtual ICollection<ContractTenderFormula> ContractTenderFormulas { get; set; } = new HashSet<ContractTenderFormula>();
        public virtual ICollection<OrderRow> OrderRows { get; set; } = new HashSet<OrderRow>();

        public FormulaItem FindItem(Guid id)
        {
            FormulaItem _item = null;
            _item =FormulaItems.FirstOrDefault(x => x.Id == id);
            if (_item == null)
                foreach (var formulaItem in FormulaItems)
                {
                    _item = formulaItem.FindItem(id);
                    if (_item != null)
                        break;
                }
            return _item;
        }

        public void ResetDents()
        {
            foreach (FormulaItem formulaItem in RootItem.FormulaItems)
            {
                formulaItem.ResetDent();
            }
        }

        public event EventHandler<FrameItem> FrameItemGazChanged;

        public void OnFrameItemGazChanged(FrameItem frameItem)
        {
            FrameItemGazChanged?.Invoke(this, frameItem);
        }

        /// <summary>
        /// Карта формулы
        /// </summary>
        [NotMapped]
        public SortedList<int, FrameItemTag> TagMap
        {
            get { return GetFormulaMap(); }
        }

        private SortedList<int, FrameItemTag> GetFormulaMap()
        {
            if (RootItem == null)
                return null;
            SortedList<int, FrameItemTag> _map = RootItem.GetMap();
            FrameItemTag _rootTag = new FrameItemTag { Level = 1, Num = 1, ItemStr = FormulaStr};
            _map.Add(_rootTag.Key, _rootTag);
            return _map;
        }

        public SlozEnum[] GetProcessingSlozes()
        {
            var _Processings = GetAllItems()
                .SelectMany(x => x.FormulaItemProcessings)
                .Select(x => x.Processing)
                .Select(x => x.SlozType).Distinct();

            return _Processings.Where(x => x !=null).Select(x => x.Enumerator).ToArray();
        }

        public Formula GetCopy()
        {
            Formula _cloneFormula = new Formula();
            CopyFieldsValues(this, _cloneFormula);
            if (RootItem != null)
                _cloneFormula.RootItem = RootItem.ItemClone(_cloneFormula);
            _cloneFormula.RootItem.Formula = _cloneFormula;
            _cloneFormula.Id = Guid.NewGuid();
            _cloneFormula.RebuildFormulaStr();
            return _cloneFormula;
        }

        public List<FormulaItem> GetAllItems()
        {
            List<FormulaItem> _list = new List<FormulaItem>();
            _list.Add(RootItem);
            _list.AddRange(RootItem.GetAllItems());
            return _list;
        }
    }
}
