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
            HasIndex(p => p.Name).IsUnique();

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(20).IsRequired();
            Property(e => e.Name).IsUnicode(false);

            HasMany(e => e.PriceForms)
                .WithRequired(e => e.FormType)
                .HasForeignKey(e => e.FormTypeId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Shapes)
                .WithOptional(e => e.FormType)
                .HasForeignKey(e => e.FormTypeId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.CatalogShapes)
               .WithOptional(e => e.FormType)
               .HasForeignKey(e => e.FormTypeId)
               .WillCascadeOnDelete(false);
        }
    }
}
