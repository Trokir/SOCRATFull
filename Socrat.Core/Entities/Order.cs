using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class Order : Entity
    {
        public event EventHandler<OrderRow> OrderRowChanged; 

        public Order()
        {
            OrderRows = new ObservableCollection<OrderRow>();
            SubscribeRows();

            _dateInput = DateTime.Now;
            _dateWork = DateTime.Now.AddDays(1);
            _dateCustomer = DateTime.Now.AddDays(2);
        }

        private void OrderRows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }

        protected override string GetTitle()
        {
            return $"Заявка №{_num} ({_division?.AliasName})";
        }
        private string _num;
        /// <summary>
        /// Номер закза
        /// </summary>
        public string Num
        {
            get { return _num; }
            set { SetField(ref _num, value, () => Num, () => Title); }
        }
        public Guid? DivisionId { get; set; }

        private DateTime _dateInput;
        /// <summary>
        /// Дата ввода
        /// </summary>
        public DateTime DateInput
        {
            get { return _dateInput; }
            set
            {
                SetField(ref _dateInput, value, () => DateInput);
            }
        }
        private DateTime? _dateWork;
        /// <summary>
        /// Дата плана/производства
        /// </summary>
        public DateTime? DateWork
        {
            get { return _dateWork; }
            set
            {
                SetField(ref _dateWork, value, () => DateWork);
            }
        }
        public Guid? CustomerId { get; set; }

        private string _numCustomer;
        /// <summary>
        /// Номер заказчика
        /// </summary>
        public string NumCustomer
        {
            get { return _numCustomer; }
            set { SetField(ref _numCustomer, value, () => NumCustomer); }
        }

        private DateTime? _dateCustomer;
        /// <summary>
        /// Дата доставки/заказчика
        /// </summary>
        public DateTime? DateCustomer
        {
            get { return _dateCustomer; }
            set
            {

                SetField(ref _dateCustomer, value, () => DateCustomer);
            }
        }
        public Guid? PartyId { get; set; }
        public Guid? ContractId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? AddressId { get; set; }

        private bool? _selfShipping;
        /// <summary>
        /// Самовывоз
        /// </summary>
        public bool? SelfShipping
        {
            get { return _selfShipping; }
            set { SetField(ref _selfShipping, value, () => SelfShipping); }
        }
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        private double? _priceAmount;
        public double? PriceAmount
        {
            get { return _priceAmount; }
            set { SetField(ref _priceAmount, value, () => PriceAmount); }
        }

        private double? _priceRun;
        public double? PriceRun
        {
            get { return _priceRun; }
            set { SetField(ref _priceRun, value, () => PriceRun); }
        }

        public Guid? PaymentTypeId { get; set; }
        public Guid? OrderStatusId { get; set; }

        private int? _itemsCount;
        public int? ItemsCount
        {
            set { _itemsCount = value; }
            get { return _itemsCount; }
        }

        private Account _account;
        public virtual Account Account
        {
            get { return _account; }
            set { SetField(ref _account, value, () => Account); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetCustomer(value); }
        }
        private void SetCustomer(Customer value)
        {
            SetField(ref _customer, value, () => Customer);
            if (DateInput == DateWork)
            {
                DateWork = _customer?.ActualContract?.CalcDateProduct(DateInput) ?? DateInput.AddDays(2);
                DateCustomer = DateWork;
            }
        }
        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division, () => Title); }
        }

        private OrderStatus _orderStatus;
        public virtual OrderStatus OrderStatus
        {
            get { return _orderStatus; }
            set
            {
                SetOrderStatus(value);
            }
        }
        private void SetOrderStatus(OrderStatus value)
        {
            if (value != null && _orderStatus != null && _orderStatus.Id != value.Id)
            {
                OrderStatusChangeMap _changeMap = new OrderStatusChangeMap(_orderStatus);
                if (!_changeMap.CanChangeToStatusState(value))
                    throw new Exception($"Переход со статуса '{_orderStatus.Name}' на статус '{value.Name}' не разрешен!");
            }
            //ведем историю
            if (_orderStatus != null && value?.Id != _orderStatus.Id)
            {
                if (OrderStatusHistories == null)
                    OrderStatusHistories = new List<OrderStatusHistory>();
                OrderStatusHistories.Add(new OrderStatusHistory
                {
                    Order = this,
                    NewOrderStatus = value,
                    DateChange = DateTime.Now
                });
            }
            SetField(ref _orderStatus, value, () => OrderStatus);
        }
        private PaymentType _paymentType;
        public virtual PaymentType PaymentType
        {
            get { return _paymentType; }
            set { SetField(ref _paymentType, value, () => PaymentType); }
        }
        private Contract _contract;
        public virtual Contract Contract
        {
            get { return _contract; }
            set { SetField(ref _contract, value, () => Contract); }
        }

        private Address _address;
        public virtual Address Address
        {
            get { return _address; }
            set { SetField(ref _address, value, () => Address); }
        }

        private ObservableCollection<OrderRow> _orderRows;
        public virtual ObservableCollection<OrderRow> OrderRows
        {
            get { return _orderRows; }
            set { SetOrderRows(value); }
        }

        //private ObservableCollection<OrderRow> GetOrderRows()
        //{
        //    _orderRows = new ObservableCollection<OrderRow>(_orderRows.OrderBy(x => x.Num));
        //    return _orderRows;
        //}

        private void SetOrderRows(ObservableCollection<OrderRow> value)
        {
            _orderRows = value;
            SubscribeRows();
        }
        private List<OrderStatusHistory> _orderStatusHistories;
        public virtual List<OrderStatusHistory> OrderStatusHistories
        {
            get { return _orderStatusHistories; }
            set { SetField(ref _orderStatusHistories, value, () => OrderStatusHistories); }
        }
        public int MaxRowNum
        {
            get
            {
                return OrderRows.Count > 0
                    ? OrderRows.Max(x => x.Num)
                    : 0;
            }
        }

        //public void ReloadRows(IEnumerable<OrderRow> rows)
        //{
        //    if (rows != null)
        //    {
        //        if (rows.Count() > 1)
        //            _orderRows = new ObservableCollection<OrderRow>(rows.OrderBy(x => x.Num));
        //        else
        //            _orderRows = new ObservableCollection<OrderRow>(rows);
        //        SubscribeRows();
        //    }
        //}

        private void SubscribeRows()
        {
            if (OrderRows == null)
                return;
            OrderRows.CollectionChanged -= OrderRows_CollectionChanged;
            OrderRows.CollectionChanged += OrderRows_CollectionChanged;
            foreach (OrderRow row in OrderRows)
            {
                row.PropertyChanged -= Row_PropertyChanged;
                row.PropertyChanged += Row_PropertyChanged;
            }
        }

        private void Row_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Changed")
                Changed = true;
        }

        public int GetNextRowNum()
        {
            return OrderRows.Count > 0
                ?  + 1
                : 1;
        }

        public List<Address> GetAddreses()
        {
            List<Address> _addresses = new List<Address>();
            if (Customer != null && Customer.CustomerAddresses != null)
                _addresses.AddRange(Customer.CustomerAddresses.Select( x => x.Address));
            if (Contract != null && Contract.ContractAddresses != null)
                _addresses.AddRange(Contract.ContractAddresses.Select(x =>x.Address));
            if (Address != null)
                _addresses.Add(Address);
            _addresses = _addresses.Distinct().ToList();
            return _addresses;
        }

        public override string ToString()
        {
            return GetTitle();
        }

        public void UpdateNums()
        {
            List<OrderRow> _ordered = OrderRows.OrderBy(x => x.Num).ToList();
            for (var i = 0; i < _ordered.Count; i++)
            {
                _ordered[i].Num = i + 1;
            }
        }

        
        public OrderRow GetLastRow()
        {
            OrderRow _lastRow = null;
            int _lastNum = OrderRows.Max(x => x.Num);
            _lastRow = OrderRows.FirstOrDefault(x => x.Num == _lastNum);
            return _lastRow;
        }

        public void OnRowChanged(OrderRow orderRow)
        {
            OrderRowChanged?.Invoke(this, orderRow);
        }
    }
}
