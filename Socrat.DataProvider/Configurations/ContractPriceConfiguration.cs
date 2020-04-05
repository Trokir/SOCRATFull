using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractPriceConfiguration : EntityTypeConfiguration<ContractPrice>
    {
        public ContractPriceConfiguration()
        {
            ToTable("ContractPrice");
            HasKey(p => p.Id);

            Property(p => p.ContractId).HasColumnName("Contract_Id").IsOptional();
            Property(p => p.PriceTypeId).HasColumnName("PriceType_Id").IsOptional();
            Property(p => p.PriceId).HasColumnName("Price_Id").IsOptional();
            Property(p => p.Discount).HasColumnName("Discount").HasColumnType("float").IsOptional();
            Property(p => p.Delta).HasColumnName("Delta").HasColumnType("float").IsOptional();
            Property(p => p.EditDate).HasColumnName("EditDate").IsOptional();
            Property(p => p.Editor).HasColumnName("Editor").HasMaxLength(31).IsOptional();
        }
    }
}
