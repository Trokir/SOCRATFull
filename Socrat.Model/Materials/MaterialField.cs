using System;
using System.ComponentModel;
using Socrat.Lib;

namespace Socrat.Model
{
    public class MaterialField: Entity
    {
        [ParentItem]
        private Material _Material;
        public Material Material
        {
            get { return _Material; }
            set
            {
               SetField(ref _Material, value, () => Material);
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

        public Nullable<Guid> Material_Id
        {
            get { return Material?.Id; }
        }

        private Field _Field;
        public Field Field
        {
            get { return _Field; }
            set
            {
                SetField(ref _Field, value, () => Field);
                SubscribePropChanged(value);
            }
        }

        public Nullable<Guid> Field_Id
        {
            get { return Field?.Id; }
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
    }
}