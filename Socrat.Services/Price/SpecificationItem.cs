using Socrat.Core.Entities;

namespace Socrat.Services.Price
{
    public class SpecificationItem
    {
        private Replacement _replacement;
        private double _quantity;
        private Measure _measure;
        private double _sum;

        public Replacement Replacement
        {
            get => _replacement;
            set => _replacement = value;
        }

        public double Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }
        public Measure Measure
        {
            get => _measure;
            set => _measure = value;
        }
        public double Sum
        {
            get => _sum;
            set => _sum = value;
        }

        public MaterialNom MaterialNom
        {
            get => Replacement?.MaterialNom;
        }

        public double? Price
        {
            get => Replacement?.Price;
        }

        public SpecificationItem(Replacement replacement, double quantity)
        {
            _replacement = replacement;
            _quantity = quantity;
            _sum = replacement.Price * _quantity;
        }

        public override string ToString()
        {
            return $"{Replacement.MaterialNom}:{Replacement.Price:c2} * {Quantity:f} = {Sum:f0}";
        }
    }
}
