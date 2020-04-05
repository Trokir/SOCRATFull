using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Entities;


namespace Socrat.Core.Added
{
    public class FrameItem : Socrat.Core.Entities.FormulaItem, IGermContainer
    {
        private double _germDepth = 4;
        private double _frameHight = 6;

        /// <summary>
        /// Газ в камере
        /// </summary>
        [NotMapped]
        public bool? Gaz
        {
            get { return FrameItemProperty?.Gaz ?? false; }
            set
            {
                if (FrameItemProperty == null)
                    FrameItemProperty = new FrameItemProperty { Id = this.Id, FrameItem = this};
                FrameItemProperty.Gaz = value;
            }
        }

        /// <summary>
        /// Глубина гермитизации
        /// </summary>
        [NotMapped]
        public double? GermDepth
        {
            get { return FrameItemProperty?.GermDepth ?? 4; }
            set
            {
                if (FrameItemProperty == null)
                    FrameItemProperty = new FrameItemProperty { Id = this.Id, FrameItem = this};
                FrameItemProperty.GermDepth = value;
            }
        }

        /// <summary>
        /// Высота рамки
        /// </summary>
        [NotMapped]
        public double FrameHight
        {
            get { return _frameHight; }
            set { _frameHight = value; }
        }

        protected override void SetSelected(bool value)
        {
            _selected = value;
        }

        public bool BaseSideInset
        {
            get { return GetBaseSideInset(); }
        }

        private bool GetBaseSideInset()
        {
            bool res = false;
            var items = FormulaItems?.OfType<InsetItem>();
            res = items.Any();
            return res;
        }

        public bool VerticalSideInset
        {
            get { return GetVerticalSideInset(); }
        }

        public bool GetVerticalSideInset()
        {
            bool res = false;
            var _itms = FormulaItems.OfType<InsetItem>();
            if (_itms != null && _itms.Count() > 0)
            {
                res = _itms.Count(x => x.InsetItemProperty != null
                    && x.InsetItemProperty.InsetPositions.Count(y => y.Num > 1) > 0) > 0;
            }

            return res;
        }

        public bool InsetSelected
        {
            get { return GetInsetSelected(); }
        }

        private bool GetInsetSelected()
        {
            bool res = false;
            var _itms = FormulaItems.OfType<InsetItem>();
            if (_itms != null && _itms.Count() > 0)
            {
                res = _itms.Count(x => x.Selected) > 0;
            }
            return res;
        }

        public virtual FrameItemProperty FrameItemProperty { get; set; }
        
        protected override MaterialEnum[] GetWhatCanAppend()
        {
            return new MaterialEnum[] { MaterialEnum.Inset };
        }

        public override void RebuildItemStr()
        {
            if (MaterialNom != null)
            {
                _ItemStr = string.Empty;
                _ItemStr = MaterialNom?.Code;

                if (Gaz ?? false)
                    _ItemStr += "#Ar";

                if (FormulaItemProcessings.Count > 0)
                    _ItemStr += $"[{ProcessingsStr}]";
            }

            if (FormulaItems.Count > 0)
            {
                foreach (FormulaItem formulaItem in FormulaItems)
                {
                    formulaItem.RebuildItemStr();
                }
                _ItemStr = string.Join("-", FormulaItems.Select(x => x.ItemStr));
            }
        }

        protected override string GetNodeCaption()
        {
            return base.GetNodeCaption() + (Gaz ?? false ? " + Ar": String.Empty);
        }

        public override FormulaItem ItemClone(Formula formula)
        {
            FrameItem _item = new FrameItem();
            CopyFieldsValues(this, _item);
            _item.Formula = formula;
            if(FrameItemProperty != null)
                _item.FrameItemProperty = FrameItemProperty.ItemClone();
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }
    }
}