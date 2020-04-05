using System;

namespace Socrat.Core.Entities
{
    public class ContractPrice : Entity
    {
        public Guid? ContractId { get; set; }
        public Guid? PriceTypeId { get; set; }
        public Guid? PriceId { get; set; }

        private double? _discount;
        public double? Discount
        {
            get { return _discount; }
            set { SetField(ref _discount, value, () => Discount); }
        }

        private double? _delta;
        public double? Delta
        {
            get { return _delta; }
            set { SetField(ref _delta, value, () => Delta); }
        }

        public DateTime? EditDate { get; set; }

        private string _editor;
        public string Editor
        {
            get { return _editor; }
            set { SetField(ref _editor, value, () => Editor); }
        }

        [ParentItem]
        private Contract _contract;
        public virtual Contract Contract
        {
            get { return _contract; }
            set { SetField(ref _contract, value, () => Contract); }
        }

        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        private PriceType _priceType;
        public virtual PriceType PriceType
        {
            get { return _priceType; }
            set { SetField(ref _priceType, value, () => PriceType); }
        }
        public string PriceColumn
        {
            get { return Price?.Name; }
        }
        protected override string GetTitle()
        {
            return $"Договор № {Contract?.Num} праис {Price?.Name}";
        }
    }
}
