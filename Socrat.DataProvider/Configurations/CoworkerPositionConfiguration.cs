using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CoworkerPositionConfiguration : EntityTypeConfiguration<CoworkerPosition>
    {
        public CoworkerPositionConfiguration()
        {
            ToTable("CoworkerPosition");
            HasKey(p => p.Id);

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.WorkPositionId).HasColumnName("WorkPosition_Id").IsOptional();
            Property(p => p.CoworkerId).HasColumnName("Coworker_Id").IsOptional();
            Property(p => p.Default).HasColumnName("Default").HasColumnType("bit").IsOptional();
        }
    }
}
