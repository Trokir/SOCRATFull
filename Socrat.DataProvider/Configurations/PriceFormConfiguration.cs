using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceFormConfiguration : EntityTypeConfiguration<PriceForm>
    {
        public PriceFormConfiguration()
        {
            ToTable("PriceForm");
            HasKey(p => p.Id);

            Property(p => p.PriceId).HasColumnName("Price_Id").IsRequired();
            Property(p => p.FormTypeId).HasColumnName("FormType_Id").IsRequired();
            Property(p => p.Discount).HasColumnName("Discount").HasColumnType("float").IsRequired();
            Property(p => p.Edit).HasColumnName("Edit").IsRequired();
        }
    }
}
