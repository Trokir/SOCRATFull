using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PricePeriodMaterialMarkTypeConfiguration : EntityTypeConfiguration<PricePeriodMaterialMarkType>
    {
        public PricePeriodMaterialMarkTypeConfiguration()
        {
            ToTable("PricePeriodMaterialMarkType");
            HasKey(p => p.Id);

            Property(p => p.PricePeriodId).HasColumnName("PricePeriodId").IsRequired();
            Property(p => p.MaterialMarkTypeId).HasColumnName("MaterialMarkTypeId").IsOptional();
            Property(p => p.MaterialSizeTypeId).HasColumnName("MaterialSizeTypeId").IsOptional();
            Property(p => p.VendorMaterialNomId).HasColumnName("VendorMaterialNomId").IsOptional();
            Property(p => p.FlaggedProductionType).HasColumnName("FlaggedProductionType").HasColumnType("int").IsRequired();
            Property(p=>p.AddValueToMeasurementItem).HasColumnName("AddValueToMeasurementItem").HasColumnType("float").IsRequired();
            Property(p => p.MultiplyValueToEntireItem).HasColumnName("MultiplyValueToEntireItem").HasColumnType("float").IsRequired();
            Property(p => p.AddValueToEntireItem).HasColumnName("AddValueToEntireItem").HasColumnType("float").IsRequired();
        }
    }
}
