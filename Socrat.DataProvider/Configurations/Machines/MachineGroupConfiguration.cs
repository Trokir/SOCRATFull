using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Machines;

namespace Socrat.DataProvider.Configurations.Machines
{
    public class MachineGroupConfiguration : EntityTypeConfiguration<MachineGroup>
    {
        public MachineGroupConfiguration()
        {
            //ToTable("MachineGroup");
            //HasKey(p => p.Id);
            
            //Property(p => p.DivisionId).HasColumnName("Division_Id").IsRequired();
            //Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();

            HasMany(e => e.MachineNoms)
                .WithOptional(e => e.MachineGroup)
                .HasForeignKey(e => e.MachineGroupId);

            HasMany(e => e.ProcessingNoms)
                .WithOptional(e => e.MachineGroup)
                .HasForeignKey(e => e.MachineGroupId);

        }
    }
}
