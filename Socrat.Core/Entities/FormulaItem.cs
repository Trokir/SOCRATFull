using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Элемент формулы изделия
    /// </summary>
    public class FormulaItem : Entity, IDrawableItem, IThickableItem
    {
        protected string _ItemStr;
        public string ItemStr
        {
            get { return _ItemStr; }
            set { SetField(ref _ItemStr, value, () => ItemStr); }
        }

        protected bool _selected;
        public bool Selected
        {
            get => _selected;
            set => SetSelected(value);
        }

        protected virtual void SetSelected(bool value)
        {
            _selected = value;
            foreach (var _formulaItem in FormulaItems)
            {
                _formulaItem.Selected = value;
            }
        }

        private short _Position;
        public short Position
        {
            get { return _Position; }
            set { SetField(ref _Position, value, () => Position); }
        }

        public Nullable<Guid> ParentItemId { get; set; }
        [ParentItem]
        private FormulaItem _ParentItem;
        public virtual FormulaItem ParentItem
        {
            get { return _ParentItem; }
            set { SetField(ref _ParentItem, value, () => ParentItem); }
        }

        private bool? _Tolling;
        /// <summary>
        /// Признак довальческого сырья
        /// </summary>
        public bool? Tolling
        {
            get { return _Tolling; }
            set { SetField(ref _Tolling, value, () => Tolling, () => TollingEx); }
        }

        [NotMapped]
        public bool TollingEx
        {
            get { return Tolling ?? false; }
            set { SetTollingEx(value); }
        }

        [ParentItem]
        private Formula _Formula;
        public virtual Formula Formula
        {
            get { return _Formula; }
            set
            {
                SetField(ref _Formula, value, () => Formula);
                if (FormulaItems != null && FormulaItems.Count > 0)
                    foreach (FormulaItem formulaItem in FormulaItems)
                        formulaItem.Formula = value;
            }
        }

        private Guid? _formulaId;
        public Nullable<Guid> FormulaId
        {
            get => _formulaId;
            set => _formulaId = value;
        }

        public Guid? MaterialNomId { get; set; }
        protected MaterialNom _materialNom;
        public virtual MaterialNom MaterialNom
        {
            get { return _materialNom; }
            set
            {
                if (value == null)
                {
                    _Changed = _materialNom != value;
                    _materialNom = value;
                }
                else
                {
                    SetField(ref _materialNom, value, () => MaterialNom, () => VendorName, () => MaterialNomName);
                    if (_materialNom.Material == null)
                        Material = _materialNom.Material;
                }
            }
        }

        public string VendorName
        {
            get { return MaterialNom?.VendorMaterialNom?.Vendor?.Name; }
        }

        public string MaterialNomName
        {
            get { return MaterialNom?.FullName; }
        }

        public virtual double Thickness
        {
            get { return MaterialNom?.Thickness ?? 0; }
        }

        public virtual double DrawThickness
        {
            get { return Math.Max(Math.Max(this.Thickness, FormulaItems.Sum(x => x.DrawThickness)), 1); }
        }

        private bool _CustomerMaterial;
        public bool CustomerMaterial
        {
            get { return _CustomerMaterial; }
            set { SetField(ref _CustomerMaterial, value, () => CustomerMaterial); }
        }

        public Guid? MaterialId { get; set; }

        private Material _Material;
        [NotMapped]
        public Material Material
        {
            get { return _Material ?? MaterialNom?.Material; }
            set { SetField(ref _Material, value, () => Material); }
        }

        protected MaterialEnum _materialEnum;
        public MaterialEnum MaterialEnum
        {
            get { return GetMaterialEnum(); }
            set { SetMaterialEnum(value); }
        }

        protected virtual void SetMaterialEnum(MaterialEnum value)
        {
            _materialEnum = value;
        }

        protected virtual MaterialEnum GetMaterialEnum()
        {
            return MaterialNom?.Material?.MaterialEnum ?? Material?.MaterialEnum ??  _materialEnum;
        }

        /// <summary>
        /// Уровень элемента
        /// </summary>
        [NotMapped]
        public int Level
        {
            get { return GetLevel(); }
        }

        protected virtual int GetLevel()
        {
            return ParentItem != null ? ParentItem.Level+1 : 0;
        }

        public void AppendItem(FormulaItem item)
        {
            item.Position = (short)(FormulaItems != null && FormulaItems.Count > 0 ? FormulaItems.Max(x => x.Position) + 1 : 0);
            item.Formula = this.Formula;
            item.ParentItem = this;
            item.Changed = true;
            FormulaItems.Add(item);
        }

        public void ResetSelection()
        {
            this.Selected = false;
            foreach (FormulaItem formulaItem in FormulaItems)
                formulaItem.ResetSelection();
        }

        public FormulaItem LastItem
        {
            get { return FormulaItems.OrderBy(x => x.Position).LastOrDefault(); }
        }


        public List<FormulaItem> GetAllItems()
        {
            List<FormulaItem> _items = new List<FormulaItem>();
            short i = 0;
            foreach (FormulaItem item in FormulaItems)
            {
                item.ParentItem = this;
                _items.Add(item);
                _items.AddRange(item.GetAllItems());
                i++;
            }
            return _items;
        }

        public MaterialEnum[] CanAppend
        {
            get { return GetWhatCanAppend(); }
        }

        /// <summary>
        /// Определяет что можно добавить в формулу
        /// </summary>
        /// <returns></returns>
        protected virtual MaterialEnum[] GetWhatCanAppend()
        {
            MaterialEnum[] _materials = null;
            return _materials;
        }

        public MaterialEnum[] CanChangeTo
        {
            get { return GetCanChangeTo(); }
        }

        public bool IsRoot
        {
            get { return Formula != null && Formula.RootItem != null && Formula.RootItem.Id == Id; }
        }

        /// <summary>
        /// Для меню Изменить на
        /// </summary>
        /// <returns></returns>
        protected virtual MaterialEnum[] GetCanSwap()
        {
            if (!IsRoot)
                return null;
            List<MaterialEnum> _materials = new List<MaterialEnum>()
                { MaterialEnum.Glass, MaterialEnum.GU, MaterialEnum.Triplex };
            _materials.Remove(MaterialEnum);
            return _materials.ToArray();
        }

        public object NodeCaption
        {
            get { return GetNodeCaption(); }

        }

        public FormulaItemProcessingEnum[] CanProcess
        {
            get { return GetWhatCanProcess(); }
        }

        private FormulaItemProcessingEnum[] GetWhatCanProcess()
        {
            FormulaItemProcessingEnum[] _processings = null;
            switch (MaterialEnum)
            {
                case MaterialEnum.Glass:
                    _processings = new FormulaItemProcessingEnum[]
                    {
                        FormulaItemProcessingEnum.SurfaseProcessing,
                        FormulaItemProcessingEnum.SideProcessing
                    };
                    break;
            }

            return _processings;
        }

        protected virtual string GetNodeCaption()
        {
            string res = String.Empty;
            if (Material == null)
                return res;
            if (MaterialNom != null)
                res = MaterialNom.Material.Name + " " + MaterialNom.Code;
            if (FormulaItemProcessings.Count > 0)
                res += $"[{ProcessingsStr}]";
            return res;
        }

        public MaterialEnum[] GetCanChangeTo()
        {
            MaterialEnum[] _materials = null;

            if (IsRoot)
                return null;

            switch (MaterialEnum)
            {
                case MaterialEnum.Glass:
                    if (ParentItem != null && ParentItem.MaterialEnum != MaterialEnum.Triplex)
                        _materials = new MaterialEnum[] { MaterialEnum.Triplex };
                    break;
                case MaterialEnum.Triplex:
                    _materials = new MaterialEnum[] { MaterialEnum.Glass };
                    break;
            }
            return _materials;
        }

        public virtual void RebuildItemStr()
        {
            if (MaterialNom != null)
            {
                _ItemStr = String.Empty;
                _ItemStr = MaterialNom?.Code;
                if (FormulaItemProcessings.Count > 0)
                    _ItemStr += $"[{ProcessingsStr}]";
            }

            if (FormulaItems.Count > 0)
            {
                var _ordered = FormulaItems.OrderBy(x => x.GetGloabalPosition());
                foreach (FormulaItem formulaItem in _ordered)
                {
                    formulaItem.RebuildItemStr();
                }
                _ItemStr = String.Join("-", _ordered.Select(x => x.ItemStr));
            }
        }

        /// <summary>
        /// Упорядочивание дочерних элементов
        /// </summary>
        public void Ordering()
        {
            byte i = 0;
            foreach (FormulaItem formulaItem in FormulaItems)
            {
                formulaItem.Formula = this.Formula;
                formulaItem.ParentItem = this;
                formulaItem.Position = i;
                i++;
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (Formula != null && !Formula.Changed && Changed)
                Formula.Changed = true;
        }

        public List<GlassItem> GetAllGlasses()
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

        [NotMapped]
        public List<FormulaItem> Items
        {
            get { return GetItems(); }
        }

        private List<FormulaItem> GetItems()
        {
            if (FormulaItems != null)
                return FormulaItems.Where(x => x.ParentItem?.Id == this.Id).OrderBy(x => x.Position).ToList();
            return null;
        }


        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public virtual List<FormulaItem> FormulaItems { get; set; } = new List<FormulaItem>();
        /// <summary>
        /// Обработки/операции
        /// </summary>
        public virtual ObservableCollection<FormulaItemProcessing> FormulaItemProcessings { get; set; } = 
            new ObservableCollection<FormulaItemProcessing>();

        public string ProcessingsStr
        {
            get { return GetProcessingsStr(); }
        }

        public MaterialEnum[] CanSwap
        {
            get { return GetCanSwap(); }
        }



        private string GetProcessingsStr()
        {
            return string.Join("/", FormulaItemProcessings
                .Where(x => x != null &&  x.Processing != null)
                .Select(x => x.Processing.ShortName));
        }

        public FormulaItem FindItem(Guid id)
        {
            FormulaItem _item = FormulaItems.FirstOrDefault(x => x.Id == id);
            if (_item == null)
                foreach (FormulaItem item in FormulaItems)
                {
                    _item = item.FindItem(id);
                    if (_item != null)
                        break;
                }
            return _item;
        }

        public bool DeleteItem(Guid id)
        {
            bool res = false;
            res = FormulaItems.RemoveAll(x => x.Id == id) > 0;
            if (!res)
                foreach (var formulaItem in FormulaItems)
                {
                    res = formulaItem.DeleteItem(id);
                    if (res)
                        break;
                }
            return res;
        }

        public bool ReplaceFormulaItem(FormulaItem oldItem, FormulaItem newItem)
        {
            bool res = false;
            int _indx = FormulaItems.IndexOf(oldItem);
            if (_indx > -1)
            {
                FormulaItems.RemoveAt(_indx);
                newItem.Formula = Formula;
                newItem.ParentItem = oldItem.ParentItem;
                FormulaItems.Insert(_indx, newItem);
                res = true;
            }
            else
                foreach (FormulaItem formulaItem in FormulaItems)
                {
                    res = formulaItem.ReplaceFormulaItem(oldItem, newItem);
                    if (res)
                        break;
                }
            return res;
        }

        public void CopyOperatinsFrom(FormulaItem oldItem)
        {
            foreach (var itemFormulaItemProcessing in oldItem.FormulaItemProcessings)
            {
                FormulaItemProcessings.Add(FormulaItemProcessingBuilder.CreateByEnum(itemFormulaItemProcessing.Enumerator,
                    this, itemFormulaItemProcessing.Processing));
            }
        }

        public virtual void ResetDent()
        {
        }

        private void SetTollingEx(bool value)
        {
            SetField(ref _Tolling, value, () => Tolling, () => TollingEx);
        }

        public virtual SortedList<int, FrameItemTag> GetMap()
        {
            SortedList<int, FrameItemTag> _list = new SortedList<int, FrameItemTag>();
            FrameItemTag _tag;
            foreach (FormulaItem formulaItem in FormulaItems)
            {
                if (formulaItem is InsetItem)
                    continue;
                _tag = new FrameItemTag
                {
                    Level = formulaItem.Level,
                    Num = formulaItem.Position + 1,
                    ItemStr = formulaItem.ItemStr
                };
                _list.Add(_tag.Key, _tag);
                if (formulaItem.FormulaItems.Count > 0)
                {
                    var _map = formulaItem.GetMap();
                    foreach (KeyValuePair<int, FrameItemTag> frameItemTag in _map)
                    {
                        _list.Add(frameItemTag.Key, frameItemTag.Value);
                    }
                }
            }
            return _list;
        }

        public virtual FormulaItem ItemClone(Formula formula)
        {
            FormulaItem _item = new FormulaItem();
            CopyFieldsValues(this, _item);
            _item.Formula = Formula;
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }

        protected void CopyCollectionsAndObjProps(FormulaItem toItem)
        {
            foreach (FormulaItemProcessing formulaItemProcessing in FormulaItemProcessings)
                toItem.FormulaItemProcessings.Add(formulaItemProcessing.Clone());
            foreach (FormulaItem formulaItem in FormulaItems.OrderBy(x => x.Position))
                toItem.AppendItem(formulaItem.ItemClone(toItem.Formula));
            toItem.MaterialNom = MaterialNom;
            toItem.Material = Material;
        }

        public void ApendItem(FormulaItem item)
        {
            item.Formula = Formula;
            item.ParentItem = this;
            int pos = FormulaItems.Count > 0
                ? FormulaItems.Max(x => x.Position) + 1
                : 0;
            item.Position = (short)pos;
            FormulaItems.Add(item);
            Changed = true;
        }

        public FormulaItem GetSubling()
        {
            if (ParentItem == null || ParentItem.FormulaItems == null || ParentItem.FormulaItems.Count == 1)
                return null;
            int _maxPos = ParentItem.FormulaItems.Max(x => x.Position);
            var _poses = ParentItem.FormulaItems.Select(x => x.Position).OrderBy(x => x).ToList();
            
            if ((Position == 0 && _maxPos > 0) || _poses.IndexOf(Position) == 0)
                return ParentItem.FormulaItems.FirstOrDefault(x => x.Position == _poses[_poses.IndexOf(Position) + 1]);
            if (Position - 1 > 0)
                return ParentItem.FormulaItems.FirstOrDefault(x => x.Position == _poses[_poses.IndexOf(Position) - 1]);
            return null;
        }

        public int GetGloabalPosition()
        {
            int res = -1;
            int _maxLevels = Formula.GetAllItems().Max(x => x.Level);
            int _levelFactor = (int) Math.Pow(100, _maxLevels - Level);
            int _parentGlobalPos = 0;
            if (ParentItem != null)
                _parentGlobalPos = ParentItem.GetGloabalPosition();
            res = _parentGlobalPos + Position * _levelFactor;
            return res;
        }

        public bool Valid
        {
            get { return GetValidate(); }
        }

        protected virtual bool GetValidate()
        {
            return true;
        }
    }
}