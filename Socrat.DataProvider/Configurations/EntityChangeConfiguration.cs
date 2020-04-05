using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class EntityChangeConfiguration : EntityTypeConfiguration<Core.Entities.EntityChange>
    {
        public EntityChangeConfiguration()
        {
            ToTable("EntityChange");
            HasKey(p => p.Id);

            Property(p => p.Guid).HasColumnName("Guid").IsRequired();
            Property(p => p.TypeName).HasColumnName("TypeName").IsRequired();
            Property(p => p.TextPresentation).HasColumnName("TextPresentation").IsRequired();
            Property(p => p.Editor).HasColumnName("Editor").IsRequired();
            Property(p => p.Dated).HasColumnName("Dated").IsRequired();
            Property(p => p.State).HasColumnName("State").IsOptional();
            Property(p => p.Serialized).HasColumnName("Serialized").IsRequired();
        }
    }
}
