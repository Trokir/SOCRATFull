using System;
using System.ComponentModel;

namespace Socrat.Core.Entities
{
    public class MaterialField : Entity
    {
        public Guid? MaterialId { get; set; }
        public Guid? FieldId { get; set; }

        private Field _field;
        public virtual Field Field
        {
            get { return _field; }
            set
            {
                SetField(ref _field, value, () => Field);
                SubscribePropChanged(value);
            }
        }

        [ParentItem]
        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set
            {
                SetField(ref _material, value, () => Material);
                SubscribePropChanged(value);
            }
        }

        private void SubscribePropChanged(Entity value)
        {
            if (value == null)
                return;
            value.PropertyChanged -= ValueOnPropertyChanged;
            value.PropertyChanged += ValueOnPropertyChanged;
        }

        private void ValueOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Changed = this.Changed || ((IEntity)sender).Changed;
        }
        public string Name
        {
            get { return Field?.Name; }
        }

        public bool IsFixed
        {
            get { return Field?.IsFixed ?? false; }
        }

        protected override string GetTitle()
        {
            return $"Дополнительный параметр {Field?.Name}";
        }

        public override string ToString()
        {
            return $"Дополнительный параметр {Field?.Name}";
        }
    }
}
