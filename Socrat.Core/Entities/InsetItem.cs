using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class InsetItem : FormulaItem
    {
        public virtual InsetItemProperty InsetItemProperty { get; set; }

        public override FormulaItem ItemClone(Formula formula)
        {
            InsetItem _item = new InsetItem();
            CopyFieldsValues(this, _item);
            _item.Formula = formula;
            if (InsetItemProperty != null)
                _item.InsetItemProperty = InsetItemProperty.ItemClone();
            _item.Id = Guid.NewGuid();
            CopyCollectionsAndObjProps(_item);
            return _item;
        }
    }
}