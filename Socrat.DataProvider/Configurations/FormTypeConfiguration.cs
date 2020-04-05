using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FormTypeConfiguration : EntityTypeConfiguration<FormType>
    {
        public FormTypeConfiguration()
        {
            ToTable("FormType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(20).IsRequired();

            Property(e => e.Name)
                .IsUnicode(false);

            HasMany(e => e.PriceForms)
                .WithRequired(e => e.FormType)
                .HasForeignKey(e => e.FormTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
