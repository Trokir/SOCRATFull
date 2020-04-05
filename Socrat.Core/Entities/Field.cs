using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class Field : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        private bool? _isFixed;
        public bool? IsFixed
        {
            get { return _isFixed; }
            set { SetField(ref _isFixed, value, () => IsFixed); }
        }
        private ObservableCollection<FieldValue> _fieldValues = new ObservableCollection<FieldValue>();
        public virtual ObservableCollection<FieldValue> FieldValues
        {
            get => _fieldValues;
            set => SetFieldValues(value);
        }

        private void SetFieldValues(ObservableCollection<FieldValue> value)
        {
            _fieldValues = value;
            _fieldValues.CollectionChanged -= _CollectionChanged;
            _fieldValues.CollectionChanged += _CollectionChanged;
        }

        private void _CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }
        public virtual ICollection<MaterialField> MaterialFields { get; set; } = new HashSet<MaterialField>();

        public override string ToString()
        {
            return Name;
        }
    }
}
