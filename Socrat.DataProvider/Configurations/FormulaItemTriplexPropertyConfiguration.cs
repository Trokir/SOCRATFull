using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Data.Model;

namespace Socrat.DataProvider.Configurations
{
    public class FormulaItemTriplexPropertyConfiguration : EntityTypeConfiguration<FormulaItemTriplexProperty>
    {
        public FormulaItemTriplexPropertyConfiguration()
        {
            ToTable("FormulaItemTriplexProperties");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.FormulaItemId).HasColumnName("FormulaItem_Id").IsRequired();
            Property(p => p.Dent).HasColumnName("Dent").HasColumnType("bit").IsOptional();
            Property(p => p.Tolling).HasColumnName("Tolling").HasColumnType("bit").IsOptional();
        }
    }
}
