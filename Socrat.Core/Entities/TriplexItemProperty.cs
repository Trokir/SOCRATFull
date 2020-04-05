using System;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class TriplexItemProperty : Entity
    {
        private bool _dent;
        /// <summary>
        /// «Û·
        /// </summary>
        public bool Dent
        {
            get { return _dent; }
            set { SetField(ref _dent, value, () => Dent); }
        }

        [ParentItem]
        [NonSerialized]
        private TriplexItem _triplexItem;
        public virtual TriplexItem TriplexItem
        {
            get { return _triplexItem; }
            set { _triplexItem = value; }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (TriplexItem != null)
            {
                TriplexItem.Changed = true;
                if (TriplexItem.Formula != null)
                {
                    TriplexItem.Formula.Changed = true;
                }
            }
        }

        public TriplexItemProperty ItemClone()
        {
            TriplexItemProperty _item = new TriplexItemProperty();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            return _item;
        }
    }
}
