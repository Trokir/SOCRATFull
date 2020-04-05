using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Machines;

namespace Socrat.DataProvider.Configurations.Machines
{
    public class MachineTypeConfiguration : EntityTypeConfiguration<MachineType>
    {
        public MachineTypeConfiguration()
        {
            //ToTable("MachineType");
            //HasKey(p => p.Id);

            //Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();

            HasMany(e => e.VendorMachineTypes)
                .WithRequired(e => e.MachineType)
                .HasForeignKey(e => e.MachineTypeId)
                .WillCascadeOnDelete(true);

            HasMany(e => e.MachineTypeProcessings)
                .WithRequired(e => e.MachineType)
                .HasForeignKey(e => e.MachineTypeId);

            HasMany(e => e.VendorMachineNoms)
                .WithRequired(e => e.MachineType)
                .HasForeignKey(e => e.MachineTypeId);
        }
    }
}
