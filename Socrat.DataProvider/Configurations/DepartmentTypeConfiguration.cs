using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DepartmentTypeConfiguration : EntityTypeConfiguration<DepartmentType>
    {
        public DepartmentTypeConfiguration()
        {
            ToTable("DepartmentType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsOptional();

            HasMany(e => e.DivisionContacts)
                 .WithOptional(e => e.DepartmentType)
                 .HasForeignKey(e => e.DepartmentTypeId);

        }
    }
}
