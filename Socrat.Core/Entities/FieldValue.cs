using System;

namespace Socrat.Core.Entities
{
    public class FieldValue : Entity
    {
        public Guid? FieldId { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetField(ref _value, value, () => Value); }
        }


        [ParentItem]
        private Field _field;
        public virtual Field Field
        {
            get { return _field; }
            set { SetField(ref _field, value, () => Field); }
        }
        protected override string GetTitle()
        {
            return $"Значение поля {Field?.Name}";
        }

        public override string ToString()
        {
            return $"Значение поля {Field?.Name} {Value}";
        }
    }
}
