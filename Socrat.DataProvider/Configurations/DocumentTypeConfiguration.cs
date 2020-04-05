using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DocumentTypeConfiguration : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeConfiguration()
        {
            ToTable("DocumentType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            Property(p => p.Code).HasColumnName("Code").HasMaxLength(15).IsOptional();

            HasMany(e => e.DivisionSignatures)
                .WithOptional(e => e.DocumentType)
                .HasForeignKey(e => e.DocumentTypeId);

            HasMany(e => e.DocumentSignatures)
                .WithOptional(e => e.DocumentType)
                .HasForeignKey(e => e.DocumentTypeId);
        }
    }
}
