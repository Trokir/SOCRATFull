using System;
using System.Collections.ObjectModel;
using Socrat.Lib;

namespace Socrat.Model
{
    /// <summary>
    /// Свойства монтажной вставки в камеру
    /// </summary>
    public class FormulaItemInsetProperty: Entity
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

        public string VendorName
        {
            get { return this.FormulaItem.VendorName; }
        }

        public string MaterialNomName
        {
            get { return this.FormulaItem.MaterialNom.ToString(); }
        }

        private ObservableCollection<InsetPosition> _insetPositions = new ObservableCollection<InsetPosition>();
        public ObservableCollection<InsetPosition> InsetPositions
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
    }
}