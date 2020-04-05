using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DocumentSignatureConfiguration : EntityTypeConfiguration<DocumentSignature>
    {
        public DocumentSignatureConfiguration()
        {
            ToTable("DocumentSignature");
            HasKey(p => p.Id);

            Property(p => p.DocumentTypeId).HasColumnName("DocumentType_Id").IsOptional();
            Property(p => p.DocumentSignatureTypeId).HasColumnName("DocumentSignatureType_Id").IsOptional();
        }
    }
}
