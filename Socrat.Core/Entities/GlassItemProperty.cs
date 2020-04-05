using System;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class GlassItemProperty : Entity
    {
        private bool _dent;
        /// <summary>
        /// «Û·
        /// </summary>
        public bool Dent
        {
            get { return _dent; }
            set
            {
                if (GlassItem != null && GlassItem.Formula != null)
                    GlassItem.Formula.ResetDents();
                SetField(ref _dent, value, () => Dent);
            }
        }

        [ParentItem]
        [NonSerialized]
        private GlassItem _GlassItem;
        public virtual GlassItem GlassItem
        {
            get { return _GlassItem; }
            set { SetField(ref _GlassItem, value, () => GlassItem); }
        }
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (GlassItem != null)
            {
                GlassItem.Changed = true;
                if (GlassItem.Formula != null)
                {
                    GlassItem.Formula.Changed = true;
                }
            }
        }

        public void ResetDent()
        {
            _dent = false;
        }

        public GlassItemProperty ItemClone()
        {
            GlassItemProperty _item = new GlassItemProperty();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            return _item;
        }
    }
}
