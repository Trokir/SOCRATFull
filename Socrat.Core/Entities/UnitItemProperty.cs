using System;

namespace Socrat.Core.Entities
{
    public class UnitItemProperty : Entity
    {
        public UnitItemProperty ItemClone()
        {
            UnitItemProperty _item = new UnitItemProperty();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            return _item;
        }
    }
}