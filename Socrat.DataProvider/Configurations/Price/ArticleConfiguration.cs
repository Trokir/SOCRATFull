using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            ToTable("Article");
            HasKey(p => p.Id);

            Property(p => p.Comments).HasColumnName("Name").HasMaxLength(128).IsOptional();
            Property(p => p.FormulaId).HasColumnName("Formula_Id").IsRequired();
            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.VendorMaterialNomId).HasColumnName("VendorMaterialNom_Id").IsOptional();
            Property(p => p.Comments).HasColumnName("Comments").HasMaxLength(2048).IsOptional();
        }
    }
}
