using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FormulaItemConfiguration : EntityTypeConfiguration<FormulaItem>
    {
        public FormulaItemConfiguration()
        {
            ToTable("FormulaItem");
            HasKey(p => p.Id);

            Property(p => p.FormulaId).HasColumnName("Formula_Id").IsOptional();
            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsOptional();
            Property(p => p.Position).HasColumnName("Position").HasColumnType("smallint").IsOptional();
            Property(p => p.ParentItemId).HasColumnName("ParentItem_Id").IsOptional();
            Property(p => p.ItemStr).HasColumnName("ItemStr").HasMaxLength(200).IsOptional();
            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Ignore(p => p.Selected);
            Ignore(p => p.CustomerMaterial);
            Ignore(p => p.ProcessingsStr);
            
            HasMany(e => e.FormulaItems)
                .WithOptional(e => e.ParentItem)
                .HasForeignKey(e => e.ParentItemId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.FormulaItemProcessings)
                .WithOptional(e => e.FormulaItem)
                .HasForeignKey(e => e.FormulaItemId)
                .WillCascadeOnDelete(true);
        }
    }
}
