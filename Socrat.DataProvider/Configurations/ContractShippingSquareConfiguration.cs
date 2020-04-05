using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractShippingSquareConfiguration : EntityTypeConfiguration<ContractShippingSquare>
    {
        public ContractShippingSquareConfiguration()
        {
            ToTable("ContractShippingSquare");
            HasKey(p => p.Id);

            Property(p => p.ContractId).HasColumnName("Contract_Id").IsOptional();
            Property(p => p.SquAmount).HasColumnName("SquAmount").HasColumnType("float").IsOptional();
            Property(p => p.PriceSqu).HasColumnName("PriceSqu").HasColumnType("float").IsOptional();
            Property(p => p.EditDate).HasColumnName("EditDate").IsOptional();
            Property(p => p.UserId).HasColumnName("User_Id").IsOptional();
        }
    }
}
