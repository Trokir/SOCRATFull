using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class TriplexItem : FormulaItem, IDentableItem
    {
        //public TriplexItem()
        //{
            //try
            //{
            //    MaterialNom = new MaterialNom();
            //    ItemStr = "()";
            //    MaterialNom.VendorMaterialNom = new VendorMaterialNom();
            //    MaterialNom.VendorMaterialNom.Material = new Material { EnumCode = MaterialEnum.Triplex.ToString(), Name = "Триплекс" };
            //    if (MaterialNom != null)
            //        MaterialNom.VendorMaterialNom.Material.EnumCode = MaterialEnum.Triplex.ToString();

            //}
            //catch (Exception e)
            //{

            //}
        //}

        public override double Thickness => GetThickness();
        private double GetThickness()
        {
            return FormulaItems.Sum(x => x.Thickness);
        }

        protected override void SetSelected(bool value)
        {
            _selected = value;
            foreach (var _formulaItem in FormulaItems)
                if (_formulaItem.MaterialNom.VendorMaterialNom.Material.MaterialEnum == MaterialEnum.Glass)
                    _formulaItem.Selected = value;
        }

        public override void RebuildItemStr()
        {
            base.RebuildItemStr();
            ItemStr = $"({ItemStr})";
        }

        private bool _dentExists;
        [NotMapped]
        public bool DentExists
        {
            get { return _dentExists || (TriplexItemProperty != null && TriplexItemProperty.Dent); }
            set
            {
                SetField(ref _dentExists, value, () => DentExists);
                TriplexItemProperty.Dent = value;
            }
        }

        public virtual TriplexItemProperty TriplexItemProperty { get; set; }
        
        public override FormulaItem ItemClone(Formula formula)
        {
            TriplexItem _item = new TriplexItem();
            _item.Formula = formula;
            if (TriplexItemProperty != null)
                _item.TriplexItemProperty = TriplexItemProperty.ItemClone();
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }

        protected override string GetNodeCaption()
        {
            string res = "Триплекс";
            if (FormulaItemProcessings.Count > 0)
                res += $"[{ProcessingsStr}]";
            return res;
        }

        protected override bool GetValidate()
        {
            bool valid = false;
            try
            {
                if (FormulaItems.Count > 1)
                {
                    valid = Items.Last().MaterialEnum == MaterialEnum.Glass
                            && Items.First().MaterialEnum == MaterialEnum.Glass
                            && Items.Count(x => x.MaterialEnum == MaterialEnum.TriplexFilm) > 0;
                }
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        public void AppendNextItem(FormulaItem focusedFormulaItem, TriplexFilmItem triplexFilmItem)
        {
            var _nextItems = FormulaItems.Where(x => x.Position > focusedFormulaItem.Position);
            foreach (FormulaItem formulaItem in _nextItems)
                formulaItem.Position++;
            triplexFilmItem.Position = (short)(focusedFormulaItem.Position + 1);
            triplexFilmItem.ParentItem = this;
            triplexFilmItem.Formula = Formula;
            triplexFilmItem.Changed = true;
            FormulaItems.Add(triplexFilmItem);
        }

        public void AppendBeforeItem(FormulaItem focusedFormulaItem, TriplexFilmItem triplexFilmItem)
        {
            short pos = focusedFormulaItem.Position;
            var _nextItems = FormulaItems.Where(x => x.Position >= focusedFormulaItem.Position);
            foreach (FormulaItem formulaItem in _nextItems)
                formulaItem.Position++;
            triplexFilmItem.Position = pos;
            triplexFilmItem.ParentItem = this;
            triplexFilmItem.Formula = Formula;
            triplexFilmItem.Changed = true;
            FormulaItems.Add(triplexFilmItem);
        }
    }
}