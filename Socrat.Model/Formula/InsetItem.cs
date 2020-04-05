using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Socrat.Model
{
    public class InsetItem: FormulaItem
    {
        public IEnumerable<FormulaItemInsetProperty> FormulaItemInsetProperties
        {
            get { return GetFormulaItemInsetPropertyLikeCollection(); }
            set { SetFormulaItemInsetProperty(value); }
        }

        private void SetFormulaItemInsetProperty(IEnumerable<FormulaItemInsetProperty> value)
        {
            if (value != null && value.Count() > 0)
            {
                _FormulaItemInsetProperty = value.OrderBy(x => x.Id).Last();
                _FormulaItemInsetProperty.PropertyChanged -= PropertyOnPropertyChanged;
                _FormulaItemInsetProperty.PropertyChanged += PropertyOnPropertyChanged;
            }
        }

        private void PropertyOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Changed = true;
        }

        private IEnumerable<FormulaItemInsetProperty> GetFormulaItemInsetPropertyLikeCollection()
        {
            return new FormulaItemInsetProperty[] { _FormulaItemInsetProperty };
        }

        private FormulaItemInsetProperty _FormulaItemInsetProperty;
        public FormulaItemInsetProperty FormulaItemInsetProperty
        {
            get { return GetFormulaItemInsetProperty(); }
            set { SetField(ref _FormulaItemInsetProperty, value, () => FormulaItemInsetProperty); }
        }

        private FormulaItemInsetProperty GetFormulaItemInsetProperty()
        {
            if (_FormulaItemInsetProperty == null)
            {
                _FormulaItemInsetProperty = new FormulaItemInsetProperty
                {
                    FormulaItem = this
                };
                _FormulaItemInsetProperty.PropertyChanged -= PropertyOnPropertyChanged;
                _FormulaItemInsetProperty.PropertyChanged += PropertyOnPropertyChanged;
            }
            return _FormulaItemInsetProperty;
        }
    }
}