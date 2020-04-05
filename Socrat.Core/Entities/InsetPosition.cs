using System;

namespace Socrat.Core.Entities
{
    public class InsetPosition : Entity
    {
        private byte? _num = 1;
        public byte? Num
        {
            get { return _num; }
            set { SetField(ref _num, value, () => Num); }
        }

        private byte? _sideNum = 1;
        public byte? SideNum
        {
            get { return _sideNum; }
            set { SetField(ref _sideNum, value, () => SideNum); }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set { SetField(ref _position, value, () => Position); }
        }
        public Guid? InsetItemPropertyId { get; set; }


        [ParentItem]
        [NonSerialized]
        private InsetItemProperty _insetItemProperty;
        public virtual InsetItemProperty InsetItemProperty
        {
            get { return _insetItemProperty; }
            set { SetField(ref _insetItemProperty, value, () => InsetItemProperty); }
        }

        public string NumTitle
        {
            get { return $"Элемент {Num}"; }
        }

        public string SideTitle
        {
            get { return $"Сторона {SideNum}"; }
        }

        protected override string GetTitle()
        {
            return $"Вставка {NumTitle} {SideTitle}";
        }

        public override string ToString()
        {
            return $"{NumTitle} {SideTitle}";
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (_insetItemProperty != null && _insetItemProperty.InsetItem != null)
            {
                _insetItemProperty.InsetItem.Changed = true;
                if (InsetItemProperty.InsetItem.Formula != null)
                    InsetItemProperty.InsetItem.Formula.Changed = true;
            }
        }

        public InsetPosition ItemClone()
        {
            InsetPosition _item = new InsetPosition();
            CopyFieldsValues(this, _item);
            _item.Id = new Guid();
            return _item;
        }
    }
}
