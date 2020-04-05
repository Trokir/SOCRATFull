using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Socrat.Common;
using Socrat.Core.Services;

namespace Socrat.Core.Entities.Invoices
{
    [EntityFormConfiguration("Счета", "Счет: {Title}")]
    //[EntityPrintTemplate("InvoiceForm")]
    [PropertyVisualisation("Номер", "NumberText", 100, 0)]
    [PropertyVisualisation("Дата", "Dated", 100, 1, false, DevExpress.Utils.HorzAlignment.Center, "", "d", "")]
    [PropertyVisualisation("Заказчик", "Buyer", 200, 2, true)]
    [PropertyVisualisation("Сумма", "Sum", 100, 3, false, DevExpress.Utils.HorzAlignment.Far, "", "c2", "")]
    [PropertyVisualisation("Состояние", "StatusText", 130, 4, false, DevExpress.Utils.HorzAlignment.Center)]
    [PropertyVisualisation("Код 1С", "IcRef", 100, 5)]

    //[Printable(
    //   "Счет",
    //   "Socrat.MVC.PrintModels",
    //   "Socrat.MVC.PrintModels.Invoices.Invoice",
    //   "Socrat.Reports",
    //   "Socrat.Reports.Invoices.RxInvoice")]
    public class Invoice : Entity
    {
        #region Ctors

        public Invoice()
        {
            Items = new AttachedList<InvoiceItem>(this);
            Payments = new AttachedList<InvoicePayment>(this);
            OrderInvoices = new AttachedList<OrderInvoice>(this);
        }

        public Invoice(Order order, InvoiceMeasurementUnit defaultInvoiceMeasurementUnit) : this()
        {
            if (!(order.Division.DivisionCustomers.FirstOrDefault() is DivisionCustomer divisionCustomer))
                throw new Exception("Производственная площадка не сконфигурирована - отсутствуют юр.лица. Невозможно выставить счет!");

            Dated = order.DateInput;
            Number = Invoice.GetNewNumber(order.Division, order.DateInput);
            NumberText = $"{order.Division.Number.PadLeft(2, '0')}-{Number}";
            Seller = divisionCustomer;
            Consignor = Seller;
            Buyer = order.Customer;
            Consignee = Buyer;

            if (order.Customer?.InvoiceMeasurementUnit is InvoiceMeasurementUnit measure)
                InvoiceMeasurementUnit = measure;
            else
                InvoiceMeasurementUnit = defaultInvoiceMeasurementUnit;

            order.OrderRows.ForEach(orderRow =>
                Items.Add(new InvoiceItem(orderRow, this)));
            Sum = Items.Sum(x => x.Sum);

            if (OrderInvoices.All(x => x.Invoice.Id != Id && x.Order.Id != order.Id))
                OrderInvoices.Add(new OrderInvoice(this, order));
        }


        public void Refill(Order order)
        {
            Items.Clear();
            order.OrderRows.ForEach(orderRow =>
                Items.Add(new InvoiceItem(orderRow, this)));
            Sum = Items.Sum(x => x.Sum);
        }

        #endregion

        #region Local variables

        private int _number;
        private string _numberText;
        private DateTime _dated;
        private string _IcRef;
        private string _comments;
        private InvoiceMeasurementUnit _invoiceMeasurementUnit;
        private InvoiceStatus _status = InvoiceStatus.Draft;
        private DivisionCustomer _seller;
        private DivisionCustomer _consignor;
        private Customer _buyer;
        private Customer _consignee;
        private double _sum;

        #endregion

        #region Foreign keys

        public Guid InvoiceMeasurementUnitId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public Guid ConsignorId { get; set; }
        public Guid ConsigneeId { get; set; }

        #endregion

        #region Collections
        public virtual AttachedList<InvoiceItem> Items { get; }

        public virtual AttachedList<InvoicePayment> Payments { get; }

        #endregion

        #region Properties
        /// <summary>
        /// Ед.измерения по умолчанию
        /// </summary>
        public virtual InvoiceMeasurementUnit InvoiceMeasurementUnit
        {
            get => _invoiceMeasurementUnit;
            set => SetField(ref _invoiceMeasurementUnit, value, () => InvoiceMeasurementUnit);
        }

        /// <summary>
        /// Продавец
        /// </summary>
        public DivisionCustomer Seller
        {
            get => _seller;
            set => SetField(ref _seller, value, () => Seller);
        }

        /// <summary>
        /// Грузоотправитель
        /// </summary>
        public DivisionCustomer Consignor
        {
            get => _consignor ?? (_consignor = Seller);
            set => SetField(ref _consignor, value, () => Consignor);
        }

        /// <summary>
        /// Покупатель
        /// </summary>
        public Customer Buyer
        {
            get => _buyer;
            set => SetField(ref _buyer, value, () => Buyer);
        }

        /// <summary>
        /// Грузополучатель
        /// </summary>
        public Customer Consignee
        {
            get => _consignee ?? (_consignee = Customer);
            set => SetField(ref _consignee, value, () => Consignee);
        }

        /// <summary>
        /// Номер автонумерациии
        /// </summary>
        public int Number
        {
            get => _number;
            set => SetField(ref _number, value, () => Number);
        }

        /// <summary>
        /// Номер
        /// </summary>
        public string NumberText
        {
            get => _numberText;
            set => SetField(ref _numberText, value, () => NumberText);
        }

        /// <summary>
        /// Дата счета
        /// </summary>
        [PropertyPrint("d")]
        public DateTime Dated
        {
            get => _dated;
            set => SetField(ref _dated, value, () => Dated); }


        public InvoiceStatus Status
        {
            get => _status;
            set => SetField(ref _status, value, () => Status);
        }

        public string IcRef
        {
            get => _IcRef;
            set => SetField(ref _IcRef, value, () => IcRef);
        }

        public string Comments
        {
            get => _comments;
            set => SetField(ref _comments, value, () => Comments);
        }

        public virtual AttachedList<OrderInvoice> OrderInvoices { get; }

        #endregion

        #region Viewmodel props
        /// <summary>
        /// Связка с заказом - пока один к одному автоматом. Порождается со стороны заказа через Order.GetInvoice()
        /// </summary>
        [NotMapped]
        public virtual OrderInvoice OrderInvoice { get => OrderInvoices.FirstOrDefault(); }

        /// <summary>
        /// Заказ
        /// </summary>
        [NotMapped]
        public virtual Order Order { get => OrderInvoice?.Order; }

        /// <summary>
        /// Площадка
        /// </summary>
        [NotMapped]
        public virtual Division Division { get => OrderInvoice?.Order?.Division; }

        /// <summary>
        /// Грузоотправитель
        /// </summary>
        [NotMapped]
        public Customer ConsignorCustomer { get => Consignor?.Customer; }
        
        /// <summary>
        /// Продавец
        /// </summary>
        [NotMapped]
        public Customer SellerCustomer { get => OrderInvoice.Order.Division.DivisionCustomers.FirstOrDefault()?.Customer; }

        /// <summary>
        /// Сумма счета
        /// </summary>
        [NotMapped]
        public double Sum
        {
            get => _sum;
            set => SetField(ref _sum, value, () => Sum);
        }

        //Для формы счета
        [NotMapped]
        public Account OwnAccountForInvoice { get; set; }
        [NotMapped]
        public Account CustomerAccountForInvoice { get; set; }
        [NotMapped]
        public string OwnPhone { get; set; }
        [NotMapped]
        public string OwnEmail { get; set; }        //Для формы счета


        [NotMapped]
        [PropertyPrintTemplate("InvoiceForm", "CustomerForInvoice")]
        public virtual Customer Customer { get => Order?.Customer; }

        [NotMapped]
        public string StatusText
        {
            get
            {
                if (_status == InvoiceStatus.Draft) return "Проект";
                else if (_status == InvoiceStatus.Released) return "Выставлен";
                else if (_status == InvoiceStatus.Payed) return "Оплачен";
                return "Не определено";
            }
        }

        [NotMapped]
        public CoworkerPosition FirstSignature { get; set; }

        [NotMapped]
        public CoworkerPosition SecondSignature { get; set; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return $"{NumberText}";
        }

        protected override string GetTitle()
        {
            return $"Счет № {ToString()}";
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Возвращает новый номер счета YYYY NNNN как часть формата AA-YYYY NNNN, где YYYY - год, NNNN - порядковый номер счета в году
        /// </summary>
        /// <param name="division"></param>
        /// <param name="dated"></param>
        /// <returns></returns>
        public static int GetNewNumber(Division division, DateTime dated)
        {
            int newBaseNumber = dated.Year * 10000 + 1;
            //if (division.Invoices.Count > 0)
            //{
            //    if (division.Invoices.Max(invoice => invoice.Number) is int currentNumber)
            //    {
            //        if (currentNumber < newBaseNumber)
            //            return newBaseNumber;
            //        else
            //            return currentNumber;
            //    }
            //}
            return newBaseNumber;
        }
        #endregion

        #region DB context config

        public class Configuration : EntityTypeConfiguration<Invoice>
        {
            public Configuration()
            {
                ToTable("Invoice");
                HasKey(p => p.Id);

                Property(p => p.SellerId).HasColumnName("SellerId").IsRequired();
                Property(p => p.ConsignorId).HasColumnName("ConsignorId").IsRequired();
                Property(p => p.BuyerId).HasColumnName("BuyerId").IsRequired();
                Property(p => p.ConsigneeId).HasColumnName("ConsigneeId").IsRequired();
                Property(p => p.InvoiceMeasurementUnitId).HasColumnName("InvoiceMeasurementUnitId").IsRequired();

                Property(p => p.Number).HasColumnName("Number").HasColumnType("int").IsRequired();
                Property(p => p.NumberText).HasColumnName("NumberText").IsRequired();
                Property(p => p.Dated).HasColumnName("Dated").HasColumnType("datetime2").IsRequired();
                Property(p => p.Status).HasColumnName("Status").HasColumnType("int").IsRequired();
                Property(p => p.IcRef).HasColumnName("IcRef").HasMaxLength(50).IsOptional();
                Property(p => p.Comments).HasColumnName("Comments").HasMaxLength(1024).IsOptional();

                HasMany(e => e.Items)
                    .WithRequired(e => e.Invoice)
                    .HasForeignKey(e => e.InvoiceId);

                HasMany(e => e.Payments)
                    .WithRequired(e => e.Invoice)
                    .HasForeignKey(e => e.InvoiceId);

                HasMany(e => e.Items)
                   .WithRequired(e => e.Invoice)
                   .HasForeignKey(e => e.InvoiceId);
            }
        }

        #endregion

        public enum InvoiceStatus
        {
            Unknown = 0,
            Draft = 1,
            Released = 2,
            Payed = 3
        }
    }
}
