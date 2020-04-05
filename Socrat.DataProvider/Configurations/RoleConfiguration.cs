using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Role");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            HasMany(e => e.RoleTreeItems)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId);

            HasMany(e => e.Users)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.RoleId);
        }
    }
}
