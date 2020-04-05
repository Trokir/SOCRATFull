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
            

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsRequired();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.CoworkerPositionId).HasColumnName("CoworkerPosition_Id").IsOptional();
            Property(e => e.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            Ignore(p => p.IsCommon);

            HasMany(e => e.PricePeriods)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.Contracts)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceForms)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceSquRatios)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceId);

            HasMany(e => e.PriceSlozs)
                .WithRequired(e => e.Price)
                .HasForeignKey(e => e.PriceId);
        }
    }
}
