using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceConfiguration : EntityTypeConfiguration<Price>
    {
        public PriceConfiguration()
        {
            ToTable("Price");
            HasKey(p => p.Id);
            

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(e => e.Name).HasColumnName("Name").HasMaxLength(50).IsUnicode(false).IsRequired();

            Ignore(p => p.IsCommon);

            HasMany(e => e.PricePeriods)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.ContractPrices)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceForms)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceSquRatios)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceSlozs)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceSelectTypes)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);
        }
    }
}
