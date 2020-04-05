using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CoworkerContactConfiguration : EntityTypeConfiguration<CoworkerContact>
    {
        public CoworkerContactConfiguration()
        {
            ToTable("CoworkerContact");
            HasKey(p => p.Id);

            Property(p => p.CoworkerId).HasColumnName("Coworker_Id").IsOptional();
            Property(p => p.ContactTypeId).HasColumnName("ContactType_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(50).IsOptional();
            Property(p => p.TimeRangeId).HasColumnName("TimeRange_Id").IsOptional();
        }
    }
}
