using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(p => p.Id);
            

            Property(p => p.Surname).HasColumnName("Surname").HasMaxLength(150).IsRequired();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            Property(p => p.Patronimyc).HasColumnName("Patronimyc").HasMaxLength(150).IsOptional();
            Property(p => p.Login).HasColumnName("Login").HasMaxLength(150).IsRequired();
            Property(p => p.Domain).HasColumnName("Domain").HasMaxLength(50).IsOptional();
            Property(p => p.Mail).HasColumnName("Mail").HasMaxLength(150).IsOptional();
            Property(p => p.RoleId).HasColumnName("Role_Id").IsOptional();
            
            HasMany(e => e.ContractShippingSquares)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            HasMany(e => e.OrderStatusHistories)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
