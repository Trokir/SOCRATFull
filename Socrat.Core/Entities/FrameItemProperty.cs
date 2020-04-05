using System;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    [Serializable]
    public class FrameItemProperty : Entity
    {
        private double? _germDepth = 4;
        /// <summary>
        /// Глубина гермитизации
        /// </summary>
        public double? GermDepth
        {
            get { return _germDepth; }
            set { SetField(ref _germDepth, value, () => GermDepth); }
        }

        private bool? _gaz;
        /// <summary>
        /// Газ в камере
        /// </summary>
        public bool? Gaz
        {
            get { return _gaz; }
            set
            {
                SetField(ref _gaz, value, () => Gaz);
                if (FrameItem != null && FrameItem.Formula != null)
                {
                    FrameItem.Formula.RebuildFormulaStr();
                    FrameItem.Formula.OnFrameItemGazChanged(FrameItem);
                }
            }
        }

        [ParentItem]
        [NonSerialized]
        private FrameItem _frameItem;
        public virtual FrameItem FrameItem
        {
            get { return _frameItem; }
            set { SetField(ref _frameItem, value, () => FrameItem); }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (FrameItem != null)
            {
                FrameItem.Changed = true;
                if (FrameItem.Formula != null)
                {
                    FrameItem.Formula.Changed = true;
                }
            }
        }

        public FrameItemProperty ItemClone()
        {
            FrameItemProperty _item = new FrameItemProperty();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            return _item;
        }
    }
}
