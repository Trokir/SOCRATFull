using Socrat.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class ShprosCircuitConfiguration : EntityTypeConfiguration<ShprosCircuit>
    {
        public ShprosCircuitConfiguration()
        {
            ToTable("ShprosCircuits");
            HasKey(p => p.Id);
            Property(p => p.Name).HasColumnName("Name").IsOptional();
            Property(p => p.Length).HasColumnName("Length").IsOptional();
            Property(p => p.Square).HasColumnName("Square").IsOptional();
            Property(p => p.ShapeId).HasColumnName("ShapeId").IsOptional();
            HasMany(e => e.ShprosElements)
              .WithOptional(e => e.ShprosCircuit)
              .HasForeignKey(e => e.ShprosCircuitId);

           
        }
    }
}
