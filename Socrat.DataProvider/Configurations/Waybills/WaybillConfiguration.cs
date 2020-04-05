using System;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.WayBills;

namespace Socrat.DataProvider.Configurations.Waybills
{
    public class WaybillConfiguration : EntityTypeConfiguration<Waybill>
    {
        public WaybillConfiguration()
        {
            ToTable("Waybill");
            HasKey(p => p.Id);

            
            Property(p => p.IsManagementAccounted).HasColumnName("IsManagementAccounted").IsRequired();
        
            Property(p => p.SellerId).HasColumnName("Seller_Id").IsRequired();
            Property(p => p.ConsigneeId).HasColumnName("Consignee_Id").IsOptional();
            Property(p => p.BuyerId).HasColumnName("Buyer_Id").IsRequired();
            Property(p => p.ConsignorId).HasColumnName("Consignor_Id").IsOptional();
            Property(p => p.DeliveryAddressId).HasColumnName("DeliveryAddress_Id").IsOptional();
            Property(p => p.CustomerCoworkerId).HasColumnName("Driver_Id").IsOptional();
            Property(p => p.VehicleId).HasColumnName("Vehicle_Id").IsOptional();
          
           

            HasRequired(e => e.ProductionMovement)
                .WithOptional()
                .WillCascadeOnDelete();
        }
    }

   
}
