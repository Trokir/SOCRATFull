using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Materials;

namespace Socrat.DataProvider.Configurations
{
    public class GlassLabelConfiguration : EntityTypeConfiguration<GlassLabel>
    {
        public GlassLabelConfiguration()
        {
            ToTable("GlassLabel");
            HasKey(p => p.Id);

            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsRequired();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsRequired();
            Property(p => p.Text).HasColumnName("Text").IsRequired().HasMaxLength(256);
        }
    }
}