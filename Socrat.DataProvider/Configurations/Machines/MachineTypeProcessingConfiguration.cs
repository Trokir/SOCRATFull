using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Machines;

namespace Socrat.DataProvider.Configurations.Machines
{
    public class MachineTypeProcessingConfiguration : EntityTypeConfiguration<MachineTypeProcessing>
    {
        public MachineTypeProcessingConfiguration()
        {
            //ToTable("MachineTypeProcessing");
            //HasKey(p => p.Id);

            //Property(p => p.MachineTypeId).HasColumnName("MachineType_Id").IsRequired();
            //Property(p => p.ProcessingTypeId).HasColumnName("ProcessingType_Id").IsRequired();

            HasIndex(p => new { p.MachineTypeId, p.ProcessingTypeId }).IsUnique();
        }
    }
}
