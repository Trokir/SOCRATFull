using System;

namespace Socrat.Core.Entities
{
    public class PriceForm : Entity
    {
        public Guid PriceId { get; set; }
        public Guid FormTypeId { get; set; }

        private double _discount;
        public double Discount
        {
            get { return _discount; }
            set { SetField(ref _discount, value, () => Discount); }
        }
        public DateTime Edit { get; set; }

        private FormType _formType;
        public virtual FormType FormType
        {
            get
            {
                return _formType;
            }
            set
            {
                SetField(ref _formType, value, () => FormType);
            }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }
        public override string ToString()
        {
            return "Наценка за фигуру (по типам фигур)";
        }
    }
}