using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DocumentSignatureTypeConfiguration : EntityTypeConfiguration<DocumentSignatureType>
    {
        public DocumentSignatureTypeConfiguration()
        {
            ToTable("DocumentSignatureType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsOptional();

            HasMany(e => e.DivisionSignatures)
                .WithOptional(e => e.DocumentSignatureType)
                .HasForeignKey(e => e.DocumentSignatureTypeId);

            HasMany(e => e.DocumentSignatures)
                .WithOptional(e => e.DocumentSignatureType)
                .HasForeignKey(e => e.DocumentSignatureTypeId);
        }
    }
}
