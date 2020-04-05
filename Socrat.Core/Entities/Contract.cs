using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    public class Contract : Entity
    {
        private long _num;
        public long Num
        {
            get { return _num; }
            set { SetField(ref _num, value, () => Num, () => Title); }
        }
        protected override string GetTitle()
        {
            return $"Карточка договора № {Num}";
        }
        public Guid? ContractTypeId { get; set; }
        public Guid? DivisionId { get; set; }
        [NotMapped]
        public Guid? PriceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? CoworkerId { get; set; }
        private DateTime? _dateBegin;
        public DateTime? DateBegin
        {
            get { return _dateBegin; }
            set { SetField(ref _dateBegin, value, () => DateBegin); }
        }

        private DateTime? _dateEnd;
        public DateTime? DateEnd
        {
            get { return _dateEnd; }
            set { SetField(ref _dateEnd, value, () => DateEnd); }
        }
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }
        private Nullable<bool> _confirmed;
        /// <summary>
        /// С (подтверждением/без подтверждения) оплаты
        /// </summary>
        public Nullable<bool> Confirmed
        {
            get { return _confirmed; }
            set { SetField(ref _confirmed, value, () => Confirmed); }
        }
        public Guid? PaymentTypeId { get; set; }
        private short? _paymentBeforeDay;
        public short? PaymentBeforeDay
        {
            get { return _paymentBeforeDay; }
            set { SetField(ref _paymentBeforeDay, value, () => PaymentBeforeDay); }
        }
        private double? _paymentBeforePercent;
        public double? PaymentBeforePercent
        {
            get { return _paymentBeforePercent; }
            set { SetField(ref _paymentBeforePercent, value, () => PaymentBeforePercent); }
        }
        private int? _paymentBeforeAmount;
        public int? PaymentBeforeAmount
        {
            get { return _paymentBeforeAmount; }
            set { SetField(ref _paymentBeforeAmount, value, () => PaymentBeforeAmount); }
        }
        private double? _paymentReadyPercent;
        public double? PaymentReadyPercent
        {
            get { return _paymentReadyPercent; }
            set { SetField(ref _paymentReadyPercent, value, () => PaymentReadyPercent); }
        }
        private int? _paymentReadyAmount;
        public int? PaymentReadyAmount
        {
            get { return _paymentReadyAmount; }
            set { SetField(ref _paymentReadyAmount, value, () => PaymentReadyAmount); }
        }

        private short? _paymentAfterDay;
        public short? PaymentAfterDay
        {
            get { return _paymentAfterDay; }
            set { SetField(ref _paymentAfterDay, value, () => PaymentAfterDay); }
        }

        private int? _paymentCreditLimit;
        public int? PaymentCreditLimit
        {
            get { return _paymentCreditLimit; }
            set { SetField(ref _paymentCreditLimit, value, () => PaymentCreditLimit); }
        }

        private short? _billValidityPeriod;
        public short? BillValidityPeriod
        {
            get { return _billValidityPeriod; }
            set { SetField(ref _billValidityPeriod, value, () => BillValidityPeriod); }
        }

        public Guid? PriceRegionId { get; set; }

        private short? _priceChangeDayInfo;
        public short? PriceChangeDayInfo
        {
            get { return _priceChangeDayInfo; }
            set { SetField(ref _priceChangeDayInfo, value, () => PriceChangeDayInfo); }
        }
        private Nullable<DateTime> _priceChangeDate;
        public Nullable<DateTime> PriceChangeDate
        {
            get { return _priceChangeDate; }
            set { SetField(ref _priceChangeDate, value, () => PriceChangeDate); }
        }
        private string _editorPrice;
        public string EditorPrice
        {
            get { return _editorPrice; }
            set { SetField(ref _editorPrice, value, () => EditorPrice); }
        }
        private string _editorShippingPrice;
        public string EditorShippingPrice
        {
            get { return _editorShippingPrice; }
            set { SetField(ref _editorShippingPrice, value, () => EditorShippingPrice); }
        }

        private Nullable<DateTime> _shippingPriceChangeDate;
        public Nullable<DateTime> ShippingPriceChangeDate
        {
            get { return _shippingPriceChangeDate; }
            set { SetField(ref _shippingPriceChangeDate, value, () => ShippingPriceChangeDate); }
        }
        /// <summary>
        /// Специальный договор
        /// </summary>
        private Nullable<bool> _spec;
        public Nullable<bool> Spec
        {
            get { return _spec; }
            set { SetField(ref _spec, value, () => Spec); }
        }

        /// <summary>
        /// Через сколько дней ставится дата изготовления
        /// </summary>
        private byte? _daysForProduct;
        public byte? DaysForProduct
        {
            get { return _daysForProduct; }
            set { SetField(ref _daysForProduct, value, () => DaysForProduct); }
        }
        private Nullable<TimeSpan> _dateTransferTime;
        public Nullable<TimeSpan> DateTransferTime
        {
            get { return _dateTransferTime; }
            set { SetField(ref _dateTransferTime, value, () => DateTransferTime); }
        }

        private ContractType _contractType;
        public virtual ContractType ContractType
        {
            get { return _contractType; }
            set { SetField(ref _contractType, value, () => ContractType); }
        }
        private Coworker _coworker;
        public virtual Coworker Coworker
        {
            get { return _coworker; }
            set { SetField(ref _coworker, value, () => Coworker); }
        }

        [ParentItem]
        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }

        [ParentItem]
        private Price _price;
        public virtual Price Price
        {
            get { return _price; }
            set { SetField(ref _price, value, () => Price); }
        }

        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set
            {
                SetField(ref _division, value, () => Division);
            }
        }

        private PaymentType _paymentType;
        /// <summary>
        /// Условия расчетов
        /// </summary>
        public virtual PaymentType PaymentType
        {
            get { return _paymentType; }
            set { SetField(ref _paymentType, value, () => PaymentType); }
        }

        private void _CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }
        private ObservableCollection<ContractAddress> _contractAddresses = new ObservableCollection<ContractAddress>();
        public virtual ObservableCollection<ContractAddress> ContractAddresses
        {
            get => _contractAddresses;
            set => SetContractAddresses(value);
        }

        private void SetContractAddresses(ObservableCollection<ContractAddress> value)
        {
            _contractAddresses = value;
            _contractAddresses.CollectionChanged -= _CollectionChanged;
            _contractAddresses.CollectionChanged += _CollectionChanged;
        }
        public virtual ICollection<ContractPrice> ContractPrices { get; set; } = new HashSet<ContractPrice>();
        public virtual ObservableCollection<ContractShippingSquare> ContractShippingSquares { get; set; } = new ObservableCollection<ContractShippingSquare>();
        public virtual ObservableCollection<ContractTenderFormula> ContractTenderFormulas { get; set; } = new ObservableCollection<ContractTenderFormula>();
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        /// <summary>
        /// Вычисляем дату производства согласно настройкам действующего договора
        /// </summary>
        /// <param name="inputDate">дата ввода</param>
        /// <returns>дата производства</returns>
        public DateTime CalcDateProduct(DateTime inputDate)
        {
            DateTime _protuctDate = inputDate.AddDays(2);
            if (DaysForProduct > 0)
            {
                if (null != DateTransferTime)
                {
                    if (inputDate - inputDate.Date < DateTransferTime)
                        _protuctDate = inputDate.AddDays(DaysForProduct.Value);
                    else
                        _protuctDate = inputDate.AddDays(DaysForProduct.Value + 1);
                }
            }
            return _protuctDate;
        }

        private Nullable<TimeSpan> _dateTransferDateTime;

        public DateTime DateTransferDateTime
        {
            get { return GetDateTransferDateTime(); }
            set { SetDateTransferDateTime(value); }
        }

        private void SetDateTransferDateTime(DateTime value)
        {
            TimeSpan _time = value - value.Date;
            SetField(ref _dateTransferDateTime, _time, () => DateTransferTime, () => DateTransferDateTime);
        }

        private DateTime GetDateTransferDateTime()
        {
            return DateTime.Today + DateTransferTime ?? new DateTime();
        }

        private bool? _Default;
        public bool? Default
        {
            get { return Actual ? _Default : false; }
            set
            {
                if (Actual)
                    SetField(ref _Default, value, () => Default, () => DefaultExt);
            }
        }
        [NotMapped]
        public bool DefaultExt
        {
            get { return _Default ?? false; }
            set { Default = value; }
        }

        public bool Actual
        {
            get { return DateBegin != null 
                         && DateBegin.Value <= DateTime.Now 
                         && (DateEnd == null || DateEnd.Value >= DateTime.Now); }
        }

        public string ContractTitle
        {
            get { return $"№{Num} {Customer?.FullName} ({ContractType})"; }
        }

        public override string ToString()
        {
            return ContractTitle;
        }

        public bool IsActualByDate(DateTime actualDateTime)
        {
            return DateBegin != null
                   && DateBegin.Value <= actualDateTime
                   && (DateEnd == null || DateEnd.Value >= actualDateTime);
        }
    }
}
