using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractTenderFormulaConfiguration : EntityTypeConfiguration<ContractTenderFormula>
    {
        public ContractTenderFormulaConfiguration()
        {
            ToTable("ContractTenderFormula");
            HasKey(p => p.Id);

            Property(p => p.ContractId).HasColumnName("Contract_Id").IsOptional();
            Property(p => p.FormulaId).HasColumnName("Formula_Id").IsOptional();
            Property(p => p.Price).HasColumnName("Price").HasColumnType("float").IsOptional();
            Property(p => p.SquReady).HasColumnName("SquReady").HasColumnType("float").IsOptional();
            Property(p => p.EditDate).HasColumnName("EditDate").IsOptional();
            Property(p => p.Limit).HasColumnName("Limit").HasColumnType("float").IsOptional();

        }
    }
}
