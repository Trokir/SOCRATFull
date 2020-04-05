using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Machines;

namespace Socrat.DataProvider.Configurations.Machines
{
    public class MachineNomOptionConfiguration : EntityTypeConfiguration<MachineNomOption>
    {
        public MachineNomOptionConfiguration()
        {
            //ToTable("MachineNomOption");
            //HasKey(p => p.Id);

            //Property(p => p.MachineNomId).HasColumnName("MachineNom_Id").IsRequired();
            //Property(p => p.VendorMachineOptionId).HasColumnName("VendorMachineOption_Id").IsRequired();

            HasIndex(p => new { p.MachineNomId, p.VendorMachineOptionId }).IsUnique();
        }
    }
}
