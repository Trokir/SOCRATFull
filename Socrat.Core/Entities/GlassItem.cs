using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class GlassItem : FormulaItem, IDentableItem
    {
        private GlassItemProperty _glassItemProperty;
        public virtual GlassItemProperty GlassItemProperty
        {
            get { return _glassItemProperty; }
            set { SetField(ref _glassItemProperty, value, () => GlassItemProperty);}
        }


        private bool _dentExists;
        [NotMapped]
        public bool DentExists
        {
            get { return _dentExists ||  (GlassItemProperty != null && GlassItemProperty.Dent); }
            set
            {
                SetField(ref _dentExists, value, () => DentExists);
                GlassItemProperty.Dent = value;
            }
        }

        public override void ResetDent()
        {
            _dentExists = false;
            if (_glassItemProperty != null)
                _glassItemProperty.ResetDent();
        }

        public override FormulaItem ItemClone(Formula formula)
        {
            GlassItem _item = new GlassItem();
            CopyFieldsValues(this, _item);
            _item.Formula = formula;
            if (GlassItemProperty != null)
                _item.GlassItemProperty = GlassItemProperty.ItemClone();
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }

    }
}