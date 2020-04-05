using DevExpress.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Entities
{
    [EntityFormConfiguration("Оплаты", "Оплата: {Title}")]
    [PropertyVisualisation("Дата", "Dated", 100, 1, false, HorzAlignment.Near, "-", "d")]
    [PropertyVisualisation("Контрагент", "Customer", 100, 2, true)]
    [PropertyVisualisation("Контракт", "Contract", 200, 3, true)]
    [PropertyVisualisation("Тип", "PaymentType", 100, 4, true)]
    [PropertyVisualisation("Сумма", "Sum", 100, 5, false, HorzAlignment.Near, "-", "c2")]
    [PropertyVisualisation("Баланс", "Balance", 100, 6, false,HorzAlignment.Near, "-", "c2")]
    [PropertyVisualisation("Код 1С", "IcRef", 100, 7)]
    public class Payment : Entity
    {

        #region Ctor
        public Payment()
        {
            Dated = DateTime.Today.Date;
            InvoicePayments = new AttachedList<InvoicePayment>(this);
        }

        #endregion

        #region Local variables

        private DateTime _dated;        
        private Contract _contract;
        private PaymentType _paymentType;
        private double _sum;
        private string _IcRef;
        private double _balance;
        private string _comments;
        #endregion

        #region Foreign keys

        public Guid ContractId { get; set; }

        public Guid PaymentTypeId { get; set; }

        #endregion

        #region Collections

        public virtual AttachedList<InvoicePayment> InvoicePayments { get; }

        #endregion

        #region Properties

        public virtual Contract Contract
        {
            get => _contract;
            set => SetField(ref _contract, value, () => Contract);
        }

        [NotMapped]
        public virtual Customer Customer { get => Contract?.Customer; }        

        public virtual PaymentType PaymentType
        {
            get => _paymentType;
            set => SetField(ref _paymentType, value, () => PaymentType);
        }

        public DateTime Dated
        {
            get => _dated;
            set => SetField(ref _dated, value, () => Dated);
        }       

        public double Sum
        {
            get => _sum;
            set => SetField(ref _sum, value, () => Sum);
        }

        public string IcRef
        {
            get => _IcRef;
            set => SetField(ref _IcRef, value, () => IcRef);
        }

        [NotMapped]
        public double Balance
        {
            get => _balance;
            set => SetField(ref _balance, value, () => Balance);
        }

        public string Comments
        {
            get => _comments;
            set => SetField(ref _comments, value, () => Comments);
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return GetTitle();
        }

        protected override string GetTitle()
        {
            if (_contract == null)
                return "Новая запись";
            else
                return $"Оплата по контракту {_contract}: {_sum:c2} от {_dated:d} ";
        }

        #endregion
       
    }
}
