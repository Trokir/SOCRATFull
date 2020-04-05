using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class InsetPosition: Entity
    {
        [ParentItem]
        private FormulaItemInsetProperty _FormulaItemInsetProperty;
        public FormulaItemInsetProperty FormulaItemInsetProperty
        {
            get { return _FormulaItemInsetProperty; }
            set { SetField(ref _FormulaItemInsetProperty, value, () => FormulaItemInsetProperty); }
        }

        public Nullable<Guid> FormulaItemInsetProperties_Id
        {
            get { return FormulaItemInsetProperty?.Id; }
        }

        private byte _Num = 1;
        public byte Num
        {
            get { return _Num; }
            set { SetField(ref _Num, value, () => Num); }
        }


        private byte _SideNum = 1;
        public byte SideNum
        {
            get { return _SideNum; }
            set { SetField(ref _SideNum, value, () => SideNum); }
        }

        private string _Position;
        public string Position
        {
            get { return _Position; }
            set { SetField(ref _Position, value, () => Position); }
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

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (_FormulaItemInsetProperty != null && _FormulaItemInsetProperty.FormulaItem != null)
            {
                _FormulaItemInsetProperty.FormulaItem.Changed = true;
                if (FormulaItemInsetProperty.FormulaItem.Formula != null)
                    FormulaItemInsetProperty.FormulaItem.Formula.Changed = true;
            }
        }
    }
}