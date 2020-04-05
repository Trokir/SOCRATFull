using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractAddressConfiguration : EntityTypeConfiguration<ContractAddress>
    {
        public ContractAddressConfiguration()
        {
            ToTable("ContractAddress");
            HasKey(p => p.Id);

            Property(p => p.ContractId).HasColumnName("Contract_Id").IsOptional();
            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
            Property(p => p.District).HasColumnName("District").HasMaxLength(16).IsOptional();
            Property(p => p.DistanceMark).HasColumnName("DistanceMark").HasMaxLength(16).IsOptional();
            Property(p => p.DistanceLength).HasColumnName("DistanceLength").IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(100).IsOptional();
        }
    }
}
