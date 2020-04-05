using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceSlozConfiguration : EntityTypeConfiguration<PriceSloz>
    {
        public PriceSlozConfiguration()
        {
            ToTable("PriceSloz");
            HasKey(p => p.Id);
            

            Property(p => p.PriceId).HasColumnName("Price_Id").IsOptional();
            Property(p => p.SlozTypeId).HasColumnName("SlozType_Id").IsOptional();
            Property(p=>p.PriceSlozName).HasColumnName("PriceSloz").HasColumnType("float").IsOptional();
            Property(p => p.Discount).HasColumnName("Discount").HasColumnType("float").IsOptional();
            Property(p => p.Delta).HasColumnName("Delta").HasColumnType("float").IsOptional();
            Property(p => p.Edit).HasColumnName("Edit").IsOptional();
        }
    }
}
