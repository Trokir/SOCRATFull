using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class SlozTypeConfiguration : EntityTypeConfiguration<SlozType>
    {
        public SlozTypeConfiguration()
        {
            ToTable("SlozType");
            HasKey(p => p.Id);
            

            Property(p => p.ShortName).HasColumnName("ShortName").HasMaxLength(10).IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(70).IsOptional();

            HasMany(e => e.OrderRowSlozs)
                .WithOptional(e => e.SlozType)
                .HasForeignKey(e => e.SlozTypeId);
            HasMany(e => e.PriceSlozs)
                .WithOptional(e => e.SlozType)
                .HasForeignKey(e => e.SlozTypeId);
            HasMany(e => e.Processings)
                .WithOptional(e => e.SlozType)
                .HasForeignKey(e => e.SlozTypeId);
        }
    }
}
