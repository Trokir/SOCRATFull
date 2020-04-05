using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Socrat.Lib.Order;

namespace Socrat.Model
{
    public class GlassItem : FormulaItem, IDentableItem
    {
        #region Свойства стекла

        public IEnumerable<FormulaItemGlassProperty> FormulaItemGlassProperties
        {
            get { return GetFormulaItemGlassPropertyLikeCollection(); }
            set { SetFormulaItemGlassProperty(value); }
        }

        private void SetFormulaItemGlassProperty(IEnumerable<FormulaItemGlassProperty> value)
        {
            if (value != null && value.Count() > 0)
            {
                _FormulaItemGlassProperty = value.OrderBy(x => x.Id).Last();
                _FormulaItemGlassProperty.PropertyChanged -= PropertyOnPropertyChanged;
                _FormulaItemGlassProperty.PropertyChanged += PropertyOnPropertyChanged;
            }
        }

        private void PropertyOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Changed = true;
        }

        private IEnumerable<FormulaItemGlassProperty> GetFormulaItemGlassPropertyLikeCollection()
        {
            return  new FormulaItemGlassProperty[] { _FormulaItemGlassProperty};
        }

        private FormulaItemGlassProperty _FormulaItemGlassProperty;
        public FormulaItemGlassProperty FormulaItemGlassProperty
        {
            get { return GetFormulaItemGlassProperty(); }
            set { SetField(ref _FormulaItemGlassProperty, value, () => FormulaItemGlassProperty); }
        }

        private FormulaItemGlassProperty GetFormulaItemGlassProperty()
        {
            if (_FormulaItemGlassProperty == null)
            {
                _FormulaItemGlassProperty = new FormulaItemGlassProperty
                {
                    FormulaItem = this
                };
                _FormulaItemGlassProperty.PropertyChanged -= PropertyOnPropertyChanged;
                _FormulaItemGlassProperty.PropertyChanged += PropertyOnPropertyChanged;
            }
            return _FormulaItemGlassProperty;
        }

        #endregion

        private bool _DentExists;
        public bool DentExists
        {
            get { return _DentExists || FormulaItemGlassProperty.Dent; }
            set
            {
                SetField(ref _DentExists, value, () => DentExists);
                FormulaItemGlassProperty.Dent = value;
            }
        }
    }
}