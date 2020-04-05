using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class GenderConfiguration : EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            ToTable("Gender");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();

            HasMany(e => e.Coworkers)
                .WithOptional(e => e.Gender)
                .HasForeignKey(e => e.GenderId);
        }
    }
}
