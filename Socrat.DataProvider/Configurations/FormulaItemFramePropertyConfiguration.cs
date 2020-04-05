using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Data.Model;

namespace Socrat.DataProvider.Configurations
{
    public class FormulaItemFramePropertyConfiguration : EntityTypeConfiguration<FormulaItemFrameProperty>
    {
        public FormulaItemFramePropertyConfiguration()
        {
            ToTable("FormulaItemFrameProperties");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.FormulaItemId).HasColumnName("FormulaItem_Id").IsOptional();
            Property(p => p.GermDepth).HasColumnName("GermDepth").HasColumnType("float").IsOptional();
            Property(p => p.Tolling).HasColumnName("Tolling").HasColumnType("bit").IsOptional();
            Property(p => p.Gaz).HasColumnName("Gaz").HasColumnType("bit").IsOptional();
        }
    }
}
