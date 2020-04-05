using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class FormulaItemFrameProperty: Entity
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
        
        private double _germDepth = 4;
        /// <summary>
        /// Глубина гермитизации
        /// </summary>
        public double GermDepth
        {
            get { return _germDepth; }
            set { SetField(ref _germDepth, value, () => GermDepth); }
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

        private bool _Gaz;
        /// <summary>
        /// Газ в камере
        /// </summary>
        public bool Gaz
        {
            get { return _Gaz; }
            set { SetField(ref _Gaz, value, () => Gaz); }
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