using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class ContractShippingSquare: Entity
    {
        [ParentItem]
        private Contract _Contract;
        public Contract Contract
        {
            get { return _Contract; }
            set { SetField(ref _Contract, value, () => Contract); }
        }

        public Nullable<Guid> Contract_Id
        {
            get => Contract?.Id;
        }

        private double _SquAmount;
        /// <summary>
        /// Объем от кв.м
        /// </summary>
        public double SquAmount
        {
            get { return _SquAmount; }
            set
            {
                if (_SquAmount != value)
                    EditDate = DateTime.Now;
                SetField(ref _SquAmount, value, () => SquAmount);
            }
        }

        private double _PriceSqu;
        /// <summary>
        /// Цена доставки за 1 кв.м
        /// </summary>
        public double PriceSqu
        {
            get { return _PriceSqu; }
            set
            {
                if (_PriceSqu != value)
                    EditDate = DateTime.Now;
                SetField(ref _PriceSqu, value, () => PriceSqu);
            }
        }

        private Nullable<DateTime> _EditDate = DateTime.Now;
        public Nullable<DateTime> EditDate
        {
            get { return _EditDate; }
            set { SetField(ref _EditDate, value, () => EditDate); }
        }
        
        private Model.Users.User _User;
        public Model.Users.User User
        {
            get { return _User; }
            set
            {
                SetField(ref _User, value, () => User);
            }
        }

        public Nullable<Guid> User_Id
        {
            get { return User?.Id; }
        }

        protected override string GetTitle()
        {
           return $"Договор № {Contract?.Num} Цена за доставку";
        }

    }
}