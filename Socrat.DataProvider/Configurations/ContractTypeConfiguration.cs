using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractTypeConfiguration : EntityTypeConfiguration<ContractType>
    {
        public ContractTypeConfiguration()
        {
            ToTable("ContractType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.ContractTypeNum).HasColumnName("ContractTypeNum").IsOptional();

            HasMany(e => e.Contracts)
                .WithOptional(e => e.ContractType)
                .HasForeignKey(e => e.ContractTypeId);
        }
    }
}
