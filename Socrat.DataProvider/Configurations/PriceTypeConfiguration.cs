using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceTypeConfiguration : EntityTypeConfiguration<PriceType>
    {
        public PriceTypeConfiguration()
        {
            ToTable("PriceType");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsOptional();
            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.MaterialMarkTypeId).HasColumnName("MaterialMarkType_Id").IsOptional();
            Property(p => p.PriceTagTypeId).HasColumnName("PriceTagType_Id").IsOptional();
            Property(p => p.SysType).HasColumnName("SysType").HasColumnType("int").IsOptional();

            HasMany(e => e.PriceLogs)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.PriceTypeId);

            HasMany(e => e.PriceSelectTypes)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.PriceTypeId);

            HasMany(e => e.PriceTypeMarkTypes)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.PriceTypeId);

            HasMany(e => e.PriceValues)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.PriceTypeId);

            HasMany(e => e.ContractPrices)
                .WithOptional(e => e.PriceType)
                .HasForeignKey(e => e.PriceTypeId);

        }
    }
}
