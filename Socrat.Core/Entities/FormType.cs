using System;
using System.Collections.ObjectModel;

namespace Socrat.Core.Entities
{
    public class FormType : Entity, IValidable
    {
        public FormType()
        {
            PriceForms = new ObservableCollection<PriceForm>();
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        private void CollectionChange(object sender, EventArgs e)
        {
            Changed = true;
        }
        private ObservableCollection<PriceForm> _priceForms;

        public virtual ObservableCollection<PriceForm> PriceForms
        {
            get => _priceForms;
            set
            {
                _priceForms = value;
                _priceForms.CollectionChanged -= CollectionChange;
                _priceForms.CollectionChanged += CollectionChange;
            }
        }

        public override string ToString()
        {
            return "Тип фигуры";
        }

        public object Validate()
        {
            return "Something";
        }
    }
}
