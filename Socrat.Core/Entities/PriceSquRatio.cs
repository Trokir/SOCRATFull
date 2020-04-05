using System;

namespace Socrat.Core.Entities
{
    public class PriceSquRatio : Entity
    {
        public Guid? PriceId { get; set; }

        private double _squ;
        public double Squ
        {
            get { return _squ; }
            set { SetField(ref _squ, value, () => Squ); }
        }

        private double _ratio;
        public double Ratio
        {
            get { return _ratio; }
            set { SetField(ref _ratio, value, () => Ratio); }
        }

        private DateTime? _editDate;
        public DateTime? EditDate
        {
            get { return _editDate; }
            set { SetField(ref _editDate, value, () => EditDate); }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }
        public override string ToString()
        {
            return "Наценка за площадь изделия";
        }
    }
}
