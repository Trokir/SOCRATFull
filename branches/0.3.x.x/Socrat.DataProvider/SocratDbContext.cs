using System;
using System.Data.Entity;
using Socrat.Core.Entities;
using Socrat.DataProvider.Configurations;

namespace Socrat.DataProvider
{
    public partial class SocratEntities : DbContext
    {
        public SocratEntities()
            : base("name=SocratDbContext")
        {
            this.Database.Log = Console.WriteLine;
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressContact> AddressContacts { get; set; }
        public virtual DbSet<AddressElement> AddressElements { get; set; }
        public virtual DbSet<AddressElementType> AddressElementTypes { get; set; }
        public virtual DbSet<AddressItem> AddressItems { get; set; }
        public virtual DbSet<AppParam> AppParams { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractAddress> ContractAddresses { get; set; }
        public virtual DbSet<ContractPrice> ContractPrices { get; set; }
        public virtual DbSet<ContractShippingSquare> ContractShippingSquares { get; set; }
        public virtual DbSet<ContractTenderFormula> ContractTenderFormulas { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Coworker> Coworkers { get; set; }
        public virtual DbSet<CoworkerContact> CoworkerContacts { get; set; }
        public virtual DbSet<CoworkerPosition> CoworkerPositions { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<CustomerProp> CustomerProps { get; set; }
        public virtual DbSet<CustomerPropType> CustomerPropTypes { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<DateTimeRange> DateTimeRanges { get; set; }
        public virtual DbSet<DepartmentType> DepartmentTypes { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<DivisionContact> DivisionContacts { get; set; }
        public virtual DbSet<DivisionCustomer> DivisionCustomers { get; set; }
        public virtual DbSet<DivisionSignature> DivisionSignatures { get; set; }
        public virtual DbSet<DocumentSignature> DocumentSignatures { get; set; }
        public virtual DbSet<DocumentSignatureType> DocumentSignatureTypes { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FieldValue> FieldValues { get; set; }
        public virtual DbSet<FormType> FormTypes { get; set; }
        public virtual DbSet<Formula> Formulae { get; set; }
        public virtual DbSet<FormulaItem> FormulaItems { get; set; }
        public virtual DbSet<FrameItemProperty> FrameItemProperties { get; set; }
        public virtual DbSet<GlassItemProperty> GlassItemProperties { get; set; }
        public virtual DbSet<InsetItemProperty> InsetItemProperties { get; set; }
        public virtual DbSet<TriplexItemProperty> TriplexItemProperties { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<InsetPosition> InsetPositions { get; set; }
        public virtual DbSet<Core.Entities.Log> Logs { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialField> MaterialFields { get; set; }
        public virtual DbSet<MaterialMarkType> MaterialMarkTypes { get; set; }
        public virtual DbSet<MaterialNom> MaterialNoms { get; set; }
        public virtual DbSet<MaterialSizeType> MaterialSizeTypes { get; set; }
        public virtual DbSet<MaterialSpecProperty> MaterialSpecProperties { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Opf> Opfs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderRow> OrderRows { get; set; }
        public virtual DbSet<OrderRowSloz> OrderRowSlozs { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PriceForm> PriceForms { get; set; }
        public virtual DbSet<PriceLog> PriceLogs { get; set; }
        public virtual DbSet<PricePeriod> PricePeriods { get; set; }
        public virtual DbSet<PriceProcessing> PriceProcessings { get; set; }
        public virtual DbSet<PriceSelectType> PriceSelectTypes { get; set; }
        public virtual DbSet<PriceSloz> PriceSlozs { get; set; }
        public virtual DbSet<PriceSquRatio> PriceSquRatios { get; set; }
        public virtual DbSet<PriceTagType> PriceTagTypes { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<PriceTypeMarkType> PriceTypeMarkTypes { get; set; }
        public virtual DbSet<PriceValue> PriceValues { get; set; }
        public virtual DbSet<Processing> Processings { get; set; }
        public virtual DbSet<ProcessingType> ProcessingTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleTreeItem> RoleTreeItems { get; set; }
        public virtual DbSet<Shape> Shapes { get; set; }
        public virtual DbSet<Core.Entities.ShapePoint> ShapePoints { get; set; }
        public virtual DbSet<ShapeParam> ShapeParams { get; set; }
        public virtual DbSet<ShapeModifedParam> ShapeModifedParams { get; set; }
        public virtual DbSet<SlozType> SlozTypes { get; set; }
        public virtual DbSet<TimeRange> TimeRanges { get; set; }
        public virtual DbSet<TradeMark> TradeMarks { get; set; }
        public virtual DbSet<TreeItem> TreeItems { get; set; }
        public virtual DbSet<TreeItemType> TreeItemTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorMaterial> VendorMaterials { get; set; }
        public virtual DbSet<VendorMaterialNom> VendorMaterialNoms { get; set; }
        public virtual DbSet<WorkPosition> WorkPositions { get; set; }
        public virtual DbSet<ShprosElement> ShprosElements { get; set; }
        public virtual DbSet<ShprosCircuit> ShprosCircuits { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Where(t => !t.IsSubclassOf(typeof(FormulaItem))).Configure(c => c.Ignore("Title").Ignore("Changed"));
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new AddressContactConfiguration());
            modelBuilder.Configurations.Add(new AddressElementConfiguration());
            modelBuilder.Configurations.Add(new AddressElementTypeConfiguration());
            modelBuilder.Configurations.Add(new AddressItemConfiguration());
            modelBuilder.Configurations.Add(new AppParamConfiguration());
            modelBuilder.Configurations.Add(new BankConfiguration());
            modelBuilder.Configurations.Add(new BrandConfiguration());
            modelBuilder.Configurations.Add(new ContactTypeConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
            modelBuilder.Configurations.Add(new ContractAddressConfiguration());
            modelBuilder.Configurations.Add(new ContractPriceConfiguration());
            modelBuilder.Configurations.Add(new ContractShippingSquareConfiguration());
            modelBuilder.Configurations.Add(new ContractTenderFormulaConfiguration());
            modelBuilder.Configurations.Add(new ContractTypeConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CoworkerConfiguration());
            modelBuilder.Configurations.Add(new CoworkerContactConfiguration());
            modelBuilder.Configurations.Add(new CoworkerPositionConfiguration());
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerAddressConfiguration());
            modelBuilder.Configurations.Add(new CustomerContactConfiguration());
            modelBuilder.Configurations.Add(new CustomerPropConfiguration());
            modelBuilder.Configurations.Add(new CustomerPropTypeConfiguration());
            modelBuilder.Configurations.Add(new CustomerTypeConfiguration());
            modelBuilder.Configurations.Add(new DateTimeRangeConfiguration());
            modelBuilder.Configurations.Add(new DepartmentTypeConfiguration());
            modelBuilder.Configurations.Add(new DivisionConfiguration());
            modelBuilder.Configurations.Add(new DivisionContactConfiguration());
            modelBuilder.Configurations.Add(new DivisionCustomerConfiguration());
            modelBuilder.Configurations.Add(new DivisionSignatureConfiguration());
            modelBuilder.Configurations.Add(new DocumentSignatureConfiguration());
            modelBuilder.Configurations.Add(new DocumentSignatureTypeConfiguration());
            modelBuilder.Configurations.Add(new DocumentTypeConfiguration());
            modelBuilder.Configurations.Add(new FieldConfiguration());
            modelBuilder.Configurations.Add(new FieldValueConfiguration());
            modelBuilder.Configurations.Add(new FormTypeConfiguration());
            modelBuilder.Configurations.Add(new FormulaConfiguration());
            modelBuilder.Configurations.Add(new FormulaItemConfiguration());
            modelBuilder.Configurations.Add(new FrameItemPropertyConfiguration());
            modelBuilder.Configurations.Add(new GlassItemPropertyConfiguration());
            modelBuilder.Configurations.Add(new InsetItemPropertyConfiguration());
            modelBuilder.Configurations.Add(new TriplexItemPropertyConfiguration());
            modelBuilder.Configurations.Add(new GenderConfiguration());
            modelBuilder.Configurations.Add(new InsetPositionConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new MaterialConfiguration());
            modelBuilder.Configurations.Add(new MaterialFieldConfiguration());
            modelBuilder.Configurations.Add(new MaterialMarkTypeConfiguration());
            modelBuilder.Configurations.Add(new MaterialNomConfiguration());
            modelBuilder.Configurations.Add(new MaterialSizeTypeConfiguration());
            modelBuilder.Configurations.Add(new MaterialSpecPropertyConfiguration());
            modelBuilder.Configurations.Add(new MaterialTypeConfiguration());
            modelBuilder.Configurations.Add(new MeasureConfiguration());
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new OpfConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderRowConfiguration());
            modelBuilder.Configurations.Add(new OrderRowSlozConfiguration());
            modelBuilder.Configurations.Add(new OrderStatusConfiguration());
            modelBuilder.Configurations.Add(new OrderStatusHistoryConfiguration());
            modelBuilder.Configurations.Add(new PaymentTypeConfiguration());
            modelBuilder.Configurations.Add(new PriceConfiguration());
            modelBuilder.Configurations.Add(new PriceFormConfiguration());
            modelBuilder.Configurations.Add(new PriceLogConfiguration());
            modelBuilder.Configurations.Add(new PricePeriodConfiguration());
            modelBuilder.Configurations.Add(new PriceProcessingConfiguration());
            modelBuilder.Configurations.Add(new PriceSelectTypeConfiguration());
            modelBuilder.Configurations.Add(new PriceSlozConfiguration());
            modelBuilder.Configurations.Add(new PriceSquRatioConfiguration());
            modelBuilder.Configurations.Add(new PriceTagTypeConfiguration());
            modelBuilder.Configurations.Add(new PriceTypeConfiguration());
            modelBuilder.Configurations.Add(new PriceTypeMarkTypeConfiguration());
            modelBuilder.Configurations.Add(new PriceValueConfiguration());
            modelBuilder.Configurations.Add(new ProcessingConfiguration());
            modelBuilder.Configurations.Add(new ProcessingTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleTreeItemConfiguration());
            modelBuilder.Configurations.Add(new ShapeConfiguration());
            modelBuilder.Configurations.Add(new ShapePointConfiguration());
            modelBuilder.Configurations.Add(new ShapeParamConfiguration());
            modelBuilder.Configurations.Add(new ShapeModifedParamConfiguration());
            modelBuilder.Configurations.Add(new SlozTypeConfiguration());
            modelBuilder.Configurations.Add(new TimeRangeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarkConfiguration());
            modelBuilder.Configurations.Add(new TreeItemConfiguration());
            modelBuilder.Configurations.Add(new TreeItemTypeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new VendorConfiguration());
            modelBuilder.Configurations.Add(new VendorMaterialConfiguration());
            modelBuilder.Configurations.Add(new VendorMaterialNomConfiguration());
            modelBuilder.Configurations.Add(new WorkPositionConfiguration());
            modelBuilder.Configurations.Add(new ShprosElementConfiguration());
            modelBuilder.Configurations.Add(new ShprosCircuitConfiguration());
            
        }
    }
}
