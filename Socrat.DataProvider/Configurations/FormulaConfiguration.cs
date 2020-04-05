using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FormulaConfiguration : EntityTypeConfiguration<Formula>
    {
        public FormulaConfiguration()
        {
            ToTable("Formula");
            HasKey(p => p.Id);

            Ignore(p => p.Valid);
            Ignore(p => p.ShowPositionsNumbers);

            HasMany(e => e.ContractTenderFormulas)
                .WithRequired(e => e.Formula)
                .HasForeignKey(e => e.FormulaId)
                .WillCascadeOnDelete();

            HasMany(e => e.FormulaItems)
                .WithOptional(e => e.Formula)
                .HasForeignKey(e => e.FormulaId);

            HasMany(e => e.OrderRows)
                .WithOptional(e => e.Formula)
                .HasForeignKey(e => e.FormulaId);
        }
    }
}
