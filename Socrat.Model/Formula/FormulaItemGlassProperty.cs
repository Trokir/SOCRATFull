using System;
using System.Windows.Forms.VisualStyles;
using Socrat.Lib;

namespace Socrat.Model
{
    public class FormulaItemGlassProperty : Entity
    {
        [ParentItem]
        private FormulaItem _FormulaItem;
        public FormulaItem FormulaItem
        {
            get { return _FormulaItem; }
            set { SetField(ref _FormulaItem, value, () => FormulaItem); }
        }

        public Nullable<Guid> FormulaItem_Id
        {
            get { return FormulaItem?.Id; }
        }

        private bool _Dent;
        /// <summary>
        /// Зуб
        /// </summary>
        public bool Dent
        {
            get { return _Dent; }
            set { SetField(ref _Dent, value, () => Dent); }
        }

        private bool _Tolling;
        /// <summary>
        /// Давальческий материал
        /// </summary>
        public bool Tolling
        {
            get { return _Tolling; }
            set { SetField(ref _Tolling, value, () => Tolling); }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (FormulaItem != null && !FormulaItem.Changed && Changed)
            {
                FormulaItem.Changed = true;
                if (FormulaItem.Formula != null)
                {
                    FormulaItem.Formula.Changed = true;
                }
            }
        }
    }
}