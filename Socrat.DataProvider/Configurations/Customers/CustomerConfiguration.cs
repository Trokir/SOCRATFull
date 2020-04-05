using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customer");
            HasKey(p => p.Id);

            Property(p => p.CustomerTypeId).HasColumnName("CustomerType_Id").IsOptional();
            Property(p => p.OpfId).HasColumnName("OPF_Id").IsOptional();
            Property(p => p.AliasName).HasColumnName("NameAlias").HasMaxLength(150).IsOptional();
            Property(p => p.FullName).HasColumnName("NameFull").HasMaxLength(150).IsOptional();
            Property(p => p.ShortName).HasColumnName("NameShort").HasMaxLength(30).IsOptional();
            Property(p => p.ForeignName).HasColumnName("NameForeign").HasMaxLength(150).IsOptional();
            Property(p => p.FirstName).HasColumnName("NameFirst").HasMaxLength(30).IsOptional();
            Property(p => p.MiddleName).HasColumnName("NameMiddle").HasMaxLength(30).IsOptional();
            Property(p => p.LastName).HasColumnName("NameLast").HasMaxLength(30).IsOptional();
            Property(p => p.CurrencyId).HasColumnName("Currency_Id").IsOptional();
            Property(p => p.CountryId).HasColumnName("Country_Id").IsOptional();
            Property(p => p.Inn).HasColumnName("Inn").HasMaxLength(12).IsOptional();
            Property(p => p.Kpp).HasColumnName("Kpp").HasMaxLength(9).IsOptional();
            Property(p => p.Ogrn).HasColumnName("Ogrn").HasMaxLength(15).IsOptional();
            Property(p => p.Okpo).HasColumnName("Okpo").HasMaxLength(10).IsOptional();
            Property(p => p.TaxNumberForeign).HasColumnName("TaxNumberForeign").HasMaxLength(90).IsOptional();
            Property(p => p.DateReg).HasColumnName("DateReg").IsOptional();
            Property(p => p.ManagerId).HasColumnName("Manager_Id").IsOptional();
            Property(p => p.TypeBarcodeId).HasColumnName("TypeBarcode_Id").IsOptional();
            Property(p => p.Code1C).HasColumnName("Code_1C").HasMaxLength(20).IsOptional();
            Property(p => p.OrderLock).HasColumnName("OrderLock").HasColumnType("bit").IsOptional();
            Property(p => p.ProdLoсk).HasColumnName("ProdLoсk").HasColumnType("bit").IsOptional();
            Property(p => p.TaxUsn).HasColumnName("TaxUsn").HasColumnType("bit").IsOptional();
            Property(p => p.TaxEnvd).HasColumnName("TaxEnvd").HasColumnType("bit").IsOptional();
            Property(p => p.IsOwner).HasColumnName("IsOwner").HasColumnType("bit").IsOptional();
            Property(p => p.LegalAddressId).HasColumnName("LegalAddress_Id").IsOptional();
            Property(p => p.ActualAddressId).HasColumnName("ActualAddress_Id").IsOptional();
            Property(p => p.InvoiceMeasurementUnitId).HasColumnName("InvoiceMeasurementUnit_Id").IsOptional();

            HasMany(e => e.Accounts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.Contracts)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerProps)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerAddresses)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerContacts)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete();

            HasMany(e => e.DivisionCustomers)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.DivisionSignatures)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.Prices)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerParsers)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerOrderFiles)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

            HasMany(e => e.CustomerFormulaEquivalents)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(true);

            HasMany(e => e.CustomerMaterialNomEquivalents)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(true);

            HasMany(e => e.TenderCustomers)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(true);

            HasMany(e => e.GlassLabels)
               .WithRequired(e => e.Customer)
               .HasForeignKey(e => e.CustomerId)
               .WillCascadeOnDelete(true);

            //HasMany(e => e.CustomerToTaxPayerRelations)
            //    .WithRequired(e => e.Customer)
            //    .HasForeignKey(e => e.CustomerId);

        }
    }
}
