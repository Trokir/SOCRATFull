using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Work;

namespace Socrat.DataProvider.Configurations.Work
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            //ToTable("Team");
            //HasKey(p => p.Id);

            //Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            //Property(p => p.TeamTypeId).HasColumnName("TeamType_Id").IsRequired();
            //Property(p => p.DivisionId).HasColumnName("Division_Id").IsRequired();
            //Property(p => p.Num).HasColumnName("Num").IsOptional();

            HasMany(e => e.WorkShifts)
                .WithOptional(e => e.Team) //.WithRequired(e => e.Team)
                .HasForeignKey(e => e.TeamId);

            HasMany(e => e.CuttedItems)
                .WithOptional(e => e.CuttersTeam)
                .HasForeignKey(e => e.CuttersTeamId);

            HasMany(e => e.AssembledItems)
                .WithOptional(e => e.AssembliesTeam)
                .HasForeignKey(e => e.AssembliesTeamId);
        }
    }
}
