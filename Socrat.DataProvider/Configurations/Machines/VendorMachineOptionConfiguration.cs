using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Machines;

namespace Socrat.DataProvider.Configurations.Machines
{
    public class VendorMachineOptionConfiguration : EntityTypeConfiguration<VendorMachineOption>
    {
        public VendorMachineOptionConfiguration()
        {
            //ToTable("VendorMachineOption");
            //HasKey(p => p.Id);

            //Property(p => p.VendorMachineNomId).HasColumnName("VendorMachineNom_Id").IsRequired();
            //Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            //Property(p => p.Description).HasColumnName("Description").HasMaxLength(300).IsOptional();

            HasMany(e => e.VendorMachineProcessings)
                .WithOptional(e => e.VendorMachineOption)
                .HasForeignKey(e => e.VendorMachineOptionId);

            HasMany(e => e.MachineNomOptions)
                .WithRequired(e => e.VendorMachineOption)
                .HasForeignKey(e => e.VendorMachineOptionId)
                .WillCascadeOnDelete();

        }
    }
}
