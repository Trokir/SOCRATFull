using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerFormulaEquivalentConfiguration : EntityTypeConfiguration<CustomerFormulaEquivalent>
    {
        public CustomerFormulaEquivalentConfiguration()
        {
            ToTable("CustomerFormulaEquivalent");
            HasKey(p => p.Id);
        }
    }
}