using System;

namespace Socrat.Core.Entities
{
    public class ContractShippingSquare : Entity
    {
        public Guid? ContractId { get; set; }

        private double? _squAmount;
        /// <summary>
        /// Объем от кв.м
        /// </summary>
        public double? SquAmount
        {
            get { return _squAmount; }
            set
            {
                if (_squAmount != value)
                    EditDate = DateTime.Now;
                SetField(ref _squAmount, value, () => SquAmount);
            }
        }

        private double? _priceSqu;
        /// <summary>
        /// Цена доставки за 1 кв.м
        /// </summary>
        public double? PriceSqu
        {
            get { return _priceSqu; }
            set
            {
                if (_priceSqu != value)
                    EditDate = DateTime.Now;
                SetField(ref _priceSqu, value, () => PriceSqu);
            }
        }
        private DateTime? _editDate = DateTime.Now;
        public DateTime? EditDate
        {
            get { return _editDate; }
            set { SetField(ref _editDate, value, () => EditDate); }
        }

        public Guid? UserId { get; set; }

        [ParentItem]
        private Contract _contract;
        public virtual Contract Contract
        {
            get { return _contract; }
            set { SetField(ref _contract, value, () => Contract); }
        }
        private User _user;
        public virtual User User
        {
            get { return _user; }
            set
            {
                SetField(ref _user, value, () => User);
            }
        }

        protected override string GetTitle()
        {
            return $"Договор № {Contract?.Num} Цена за доставку";
        }
    }
}
