using System;
using System.Collections.Generic;
using Socrat.Data.Model;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class Customer : Entity
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
            Accounts = new HashSet<Account>();
            //CustomerToTaxPayerRelations = new HashSet<CustomerToTaxPayerRelation>();
            CustomerProps = new HashSet<CustomerProp>();
            CustomerAddresses = new HashSet<CustomerAddress>();
            CustomerContacts = new HashSet<CustomerContact>();
            DivisionCustomers = new HashSet<DivisionCustomer>();
            DivisionSignatures = new HashSet<DivisionSignature>();
            CustomerParsers = new HashSet<CustomerParser>();
            CustomerOrderFiles = new HashSet<CustomerOrderFile>();
            Orders = new HashSet<Order>();
            Prices = new HashSet<Price>();
            CustomerFormulaEquivalents = new HashSet<CustomerFormulaEquivalent>();
            CustomerMaterialNomEquivalents = new HashSet<CustomerMaterialNomEquivalent>();
            TenderCustomers = new HashSet<TenderCustomer>();
        }

        public Guid? CustomerTypeId { get; set; }
        public Guid? OpfId { get; set; }
        public string AliasName { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string ForeignName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Guid? CurrencyId { get; set; }
        public Guid? CountryId { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Ogrn { get; set; }
        public string Okpo { get; set; }
        public string TaxNumberForeign { get; set; }
        public DateTime? DateReg { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? TypeBarcodeId { get; set; }
        public Guid? InvoiceMeasurementUnitId { get; set; }
        public virtual InvoiceMeasurementUnit InvoiceMeasurementUnit { get; set; }
        public string Code1C { get; set; }
        public bool? OrderLock { get; set; }
        public bool? ProdLoсk { get; set; }
        public bool? TaxUsn { get; set; }
        public bool? TaxEnvd { get; set; }
        public bool? IsOwner { get; set; }
        public Guid? LegalAddressId { get; set; }
        public Guid? ActualAddressId { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual Address LegalAddress { get; set; }
        public virtual Address ActualAddress { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual BarcodeType BarcodeType { get; set; }
        public Guid? BarcodeTypeId { get; set; }

        /// <summary>
        ///     Тип старта нового пула
        /// </summary>
        public PoolStartEnum PoolStart { get; set; }

        //public virtual ICollection<CustomerToTaxPayerRelation> CustomerToTaxPayerRelations { get; set; }
        public virtual ICollection<CustomerProp> CustomerProps { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<DivisionCustomer> DivisionCustomers { get; set; }
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; }
        public virtual ICollection<CustomerParser> CustomerParsers { get; set; }
        public virtual ICollection<CustomerOrderFile> CustomerOrderFiles { get; set; }
        public virtual Opf Opf { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<CustomerFormulaEquivalent> CustomerFormulaEquivalents { get; set; }
        public virtual ICollection<CustomerMaterialNomEquivalent> CustomerMaterialNomEquivalents { get; set; }
        public virtual ICollection<TenderCustomer> TenderCustomers { get; set; }
    }
}