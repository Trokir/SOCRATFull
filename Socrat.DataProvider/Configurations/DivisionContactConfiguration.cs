using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DivisionContactConfiguration : EntityTypeConfiguration<DivisionContact>
    {
        public DivisionContactConfiguration()
        {
            ToTable("DivisionContact");
            HasKey(p => p.Id);

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.DepartmentTypeId).HasColumnName("DepartmentType_Id").IsOptional();
            Property(p => p.ContactTypeId).HasColumnName("ContactType_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(50).IsOptional();
        }
    }
}
