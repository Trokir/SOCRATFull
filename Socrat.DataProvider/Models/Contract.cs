using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Contract : Entity
    {
        public Contract()
        {
            ContractAddresses = new HashSet<ContractAddress>();
            ContractShippingSquares = new HashSet<ContractShippingSquare>();
            Orders = new HashSet<Order>();
        }

        public long Num { get; set; }
        public Guid? ContractTypeId { get; set; }
        public Guid? DivisionId { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Comment { get; set; }

        /// <summary>
        ///     С (подтверждением/без подтверждения) оплаты
        /// </summary>
        public bool? Confirmed { get; set; }

        public Guid? PaymentTypeId { get; set; }
        public short? PaymentBeforeDay { get; set; }
        public double? PaymentBeforePercent { get; set; }
        public int? PaymentBeforeAmount { get; set; }
        public double? PaymentReadyPercent { get; set; }
        public int? PaymentReadyAmount { get; set; }
        public short? PaymentAfterDay { get; set; }
        public int? PaymentCreditLimit { get; set; }
        public short? BillValidityPeriod { get; set; }
        public short? PriceChangeDayInfo { get; set; }
        public DateTime? PriceChangeDate { get; set; }
        public string EditorPrice { get; set; }
        public string EditorShippingPrice { get; set; }
        public DateTime? ShippingPriceChangeDate { get; set; }

        /// <summary>
        ///     Специальный договор
        /// </summary>
        public bool? Spec { get; set; }

        /// <summary>
        ///     Через сколько дней ставится дата изготовления
        /// </summary>
        public byte? DaysForProduct { get; set; }

        public TimeSpan? DateTransferTime { get; set; }
        public virtual ContractType ContractType { get; set; }
        public Guid? CoworkerId { get; set; }
        public virtual Coworker Coworker { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public Guid? PriceId { get; set; }
        public virtual Price Price { get; set; }
        public virtual Division Division { get; set; }

        /// <summary>
        ///     Условия расчетов
        /// </summary>
        public virtual PaymentType PaymentType { get; set; }

        public virtual ICollection<ContractAddress> ContractAddresses { get; set; }
        public virtual ICollection<ContractShippingSquare> ContractShippingSquares { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
      //  public DateTime DateTransferDateTime { get; set; }
        public bool? Default { get; set; }
        public virtual Tender Tender { get; set; }
        public Guid? TenderId { get; set; }
    }
}