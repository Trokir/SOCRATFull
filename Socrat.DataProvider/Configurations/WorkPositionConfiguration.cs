using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class WorkPositionConfiguration : EntityTypeConfiguration<WorkPosition>
    {
        public WorkPositionConfiguration()
        {
            ToTable("WorkPosition");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsOptional();

            HasMany(e => e.AddressContacts)
                .WithOptional(e => e.WorkPosition)
                .HasForeignKey(e => e.WorkPositionId);

            HasMany(e => e.CoworkerPositions)
                .WithOptional(e => e.WorkPosition)
                .HasForeignKey(e => e.WorkPositionId);
        }
    }
}
