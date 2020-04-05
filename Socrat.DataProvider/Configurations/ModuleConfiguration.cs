using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {
            ToTable("Module");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.ModuleName).HasColumnName("Title").HasMaxLength(150).IsOptional();

            HasMany(e => e.TreeItems)
                .WithOptional(e => e.Module)
                .HasForeignKey(e => e.ModuleId)
                .WillCascadeOnDelete();
        }
    }
}
