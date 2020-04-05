using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DivisionSignatureConfiguration : EntityTypeConfiguration<DivisionSignature>
    {
        public DivisionSignatureConfiguration()
        {
            ToTable("DivisionSignature");
            HasKey(p => p.Id);

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.DocumentTypeId).HasColumnName("DocumentType_Id").IsOptional();
            Property(p => p.DocumentSignatureTypeId).HasColumnName("DocumentSignatureType_Id").IsOptional();
            Property(p => p.CoworkerId).HasColumnName("Coworker_Id").IsOptional();
            Property(p => p.DocCoworkerPosition).HasColumnName("DocCoworkerPosition").HasMaxLength(100).IsOptional();
            Property(p => p.DocBasics).HasColumnName("DocBasics").HasMaxLength(50).IsOptional();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
        }
    }
}
