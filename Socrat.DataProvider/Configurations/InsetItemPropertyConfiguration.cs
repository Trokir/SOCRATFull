using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class InsetItemPropertyConfiguration : EntityTypeConfiguration<InsetItemProperty>
    {
        public InsetItemPropertyConfiguration()
        {
            ToTable("InsetItemProperties");
            HasKey(p => p.Id);

            HasMany(e => e.InsetPositions)
                .WithOptional(e => e.InsetItemProperty)
                .HasForeignKey(e => e.InsetItemPropertyId)
                .WillCascadeOnDelete();
            HasRequired(p => p.InsetItem).WithOptional(p => p.InsetItemProperty);
        }
    }
}
