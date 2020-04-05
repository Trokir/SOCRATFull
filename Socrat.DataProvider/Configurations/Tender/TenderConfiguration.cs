using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Tender;

namespace Socrat.DataProvider.Configurations
{
    public class TenderConfiguration : EntityTypeConfiguration<Tender>
    {
        public TenderConfiguration()
        {
            ToTable("Tender");
            HasKey(p => p.Id);

            HasMany(e => e.TenderCustomers)
                .WithRequired(e => e.Tender)
                .HasForeignKey(e => e.TenderId)
                .WillCascadeOnDelete(true);
        }
    }
}