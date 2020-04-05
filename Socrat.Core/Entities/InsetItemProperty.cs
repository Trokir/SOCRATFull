using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class InsetItemProperty : Entity
    {
        [ParentItem]
        [NonSerialized]
        private InsetItem _insetItem;
        public virtual InsetItem InsetItem
        {
            get { return _insetItem; }
            set { SetField(ref _insetItem, value, () => InsetItem); }
        }
        private ObservableCollection<InsetPosition> _insetPositions = new ObservableCollection<InsetPosition>();
        public virtual ObservableCollection<InsetPosition> InsetPositions
        {
            get => _insetPositions;
            set => SetInsetPositions(value);
        }
        private void SetInsetPositions(ObservableCollection<InsetPosition> value)
        {
            _insetPositions = value;
            if (_insetPositions != null)
            {
                _insetPositions.CollectionChanged -= _CollectionChanged;
                _insetPositions.CollectionChanged += _CollectionChanged;
            }
        }
        private void _CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Changed = true;
        }
        public string VendorName
        {
            get { return this.InsetItem.VendorName; }
        }

        public string MaterialNomName
        {
            get { return this.InsetItem.MaterialNom.ToString(); }
        }

        public InsetItemProperty ItemClone()
        {
            InsetItemProperty _item = new InsetItemProperty();
            CopyFieldsValues(this, _item);
            _item.Id = Guid.NewGuid();
            return _item;
        }
    }
}
