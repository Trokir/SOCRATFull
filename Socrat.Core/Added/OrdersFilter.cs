using System;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class OrdersFilter : Entity
    {
        public OrdersFilter()
        {
            _dateStart = DateTime.Today.AddDays(-7);
            _dateEnd = DateTime.Today.AddDays(1).AddSeconds(-1);
            _dateType = OrdersFilterDateType.Input;
            _numberType = OrdersFilterNumberType.Own;
            _number = "";
        }

        private DateTime _dateStart;
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { SetField(ref _dateStart, value, () => DateStart, () => Title); }
        }

        private DateTime _dateEnd;
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { SetField(ref _dateEnd, value, () => DateEnd, () => Title); }
        }

        private OrdersFilterDateType _dateType;
        public OrdersFilterDateType DateType
        {
            get { return _dateType; }
            set { SetField(ref _dateType, value, () => DateType, () => Title); }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { SetField(ref _number, value, () => Number, () => Title); }
        }

        private OrdersFilterNumberType _numberType;
        public OrdersFilterNumberType NumberType
        {
            get { return _numberType; }
            set { SetField(ref _numberType, value, () => NumberType, () => Title); }
        }


        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer, () => Title); }
        }

        private Division _division;
        public Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division, () => Title); }
        }

        private OrderStatus _orderStatus;
        public OrderStatus OrderStatus
        {
            get { return _orderStatus; }
            set { SetField(ref _orderStatus, value, () => OrderStatus, () => Title); }
        }

        public Nullable<Guid> OrderStatusId
        {
            get { return OrderStatus?.Id; }
        }

        protected override string GetTitle()
        {
            string _title =
                $"Дата {GetDateTypeName()} c {_dateStart.ToString("dd.MM.yyyy")} по {_dateEnd.ToString("dd.MM.yyyy")}.";
            if (null != Customer)
                _title += $" Заказчик {Customer}.";
            if (Number.Length > 0)
                _title += $" Заказ {GetNumberType()} № {_number}.";
            if (OrderStatus != null)
                _title += $" Статус: {OrderStatus.Name}";
            return "           " + _title;
        }

        private string GetNumberType()
        {
            switch (_numberType)
            {
                case OrdersFilterNumberType.Num1C:
                    return "1С";
                case OrdersFilterNumberType.Customer:
                    return "заказчика";
                case OrdersFilterNumberType.Own:
                default:
                    return "наш";
            }
        }

        private string GetDateTypeName()
        {
            switch (_dateType)
            {
                case OrdersFilterDateType.Complit:
                    return "изготовления";
                case OrdersFilterDateType.Customer:
                    return "заказчика";
                case OrdersFilterDateType.Work:
                    return "плана";
                case OrdersFilterDateType.Input:
                default:
                    return "ввода";
            }
        }
    }


}