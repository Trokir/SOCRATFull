using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OpfConfiguration : EntityTypeConfiguration<Opf>
    {
        public OpfConfiguration()
        {
            ToTable("Opf");
            HasKey(p => p.Id);
            

            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(10).IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(70).IsOptional();

            HasMany(e => e.Customers)
                 .WithOptional(e => e.Opf)
                 .HasForeignKey(e => e.OpfId);
        }
    }
}
