using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order");
            HasKey(p => p.Id);
            

            Property(p => p.Num).HasColumnName("Num").HasMaxLength(60).IsRequired();
            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.DateInput).HasColumnName("DateInput").IsRequired();
            Property(p => p.DateWork).HasColumnName("DateWork").IsOptional();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.NumCustomer).HasColumnName("NumCustomer").HasMaxLength(150).IsOptional();
            Property(p => p.DateCustomer).HasColumnName("DateCustomer").IsOptional();
            Property(p => p.PartyId).HasColumnName("PartyId").IsOptional();
            Property(p => p.ContractId).HasColumnName("Contract_Id").IsOptional();
            Property(p => p.AccountId).HasColumnName("Account_Id").IsOptional();
            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
            Property(p => p.SelfShipping).HasColumnName("SelfShipping").HasColumnType("bit").IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(200).IsOptional();
            Property(p => p.PriceAmount).HasColumnName("PriceAmount").HasColumnType("float").IsOptional();
            Property(p => p.PriceRun).HasColumnName("PriceRun").HasColumnType("float").IsOptional();
            Property(p => p.PaymentTypeId).HasColumnName("PaymentType_Id").IsOptional();
            Property(p => p.OrderStatusId).HasColumnName("OrderStatus_Id").IsOptional();
            Property(p => p.ItemsCount).HasColumnName("ItemsCount").IsOptional();


            HasMany(e => e.OrderRows)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete();

            HasMany(e => e.OrderStatusHistories)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.OrderId);
        }
    }
}
