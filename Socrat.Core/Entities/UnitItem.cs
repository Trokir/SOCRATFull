using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class GlassUnitItem : FormulaItem
    {
        public GlassUnitItem(MaterialEnum value)
        {
            SetMaterialEnum(value);
        }

        public GlassUnitItem()
        {
            SetMaterialEnum(MaterialEnum.GU);
        }
        protected override void SetMaterialEnum(MaterialEnum value)
        {
            _materialEnum = value;
        }

        protected override MaterialEnum GetMaterialEnum()
        {
            return _materialEnum;
        }

        private UnitItemProperty _UnitItemProperty;
        [NotMapped]
        public UnitItemProperty UnitItemProperty
        {
            get { return _UnitItemProperty; }
            set { SetField(ref _UnitItemProperty, value, () => UnitItemProperty); }
        }

        [NotMapped]
        public List<FormulaItem> Items
        {
            get { return FormulaItems.Where(x => x.ParentItem?.Id == this.Id).OrderBy(x => x.Position).ToList(); }
        }

        protected override void SetSelected(bool value)
        {
            base.SetSelected(false);
        }

        public bool DentExists
        {
            get { return GetDentExists(); }
        }

        private bool GetDentExists()
        {
            bool res = false;
            foreach (var item in FormulaItems)
            {
                PropertyInfo _property = item.GetType().GetProperty("DentExists");
                if (null != _property)
                {
                    var tmp = _property.GetValue(item);
                    if (tmp != null)
                        bool.TryParse(tmp.ToString(), out res);
                    if (res)
                        break;
                }
            }
            return res;
        }

        protected override int GetLevel()
        {
            return 1;
        }

        public override FormulaItem ItemClone(Formula formula)
        {
            GlassUnitItem _item = new GlassUnitItem(formula.RootItem.MaterialEnum);
            CopyFieldsValues(this, _item);
            _item.Formula = formula;
            if (UnitItemProperty != null)
                _item.UnitItemProperty.ItemClone();
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }

        protected override string GetNodeCaption()
        {
            string res = "Стеклопакет";
            int _cnt = FormulaItems.Count(x => x.MaterialEnum == MaterialEnum.Frame);
            switch (_cnt)
            {
                case 1:
                    res = "СПО";
                    break;
                case 2:
                    res = "СПД";
                    break;
            }
            if (FormulaItemProcessings.Count > 0)
                res += $"[{ProcessingsStr}]";
            return res;
        }

        protected override bool GetValidate()
        {
            bool valid = false;
            try
            {
                MaterialEnum[] _types = new MaterialEnum[] { MaterialEnum.Glass, MaterialEnum.Triplex} ;
                valid = FormulaItems.Count > 0
                      && _types.Contains(Items.First().MaterialEnum)
                      && _types.Contains(Items.Last().MaterialEnum)
                      && Items.Count(x => x.MaterialEnum == MaterialEnum.Frame) > 0;
                if (valid)
                    foreach (var formulaItem in Items)
                    {
                        valid = formulaItem.Valid;
                        if (!valid)
                            break;
                    }
            }
            catch
            {
                valid = false;
            }
            return valid;
        }
    }
}