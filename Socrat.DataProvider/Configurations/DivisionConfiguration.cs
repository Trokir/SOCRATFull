using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DivisionConfiguration : EntityTypeConfiguration<Division>
    {
        public DivisionConfiguration()
        {
            ToTable("Division");
            HasKey(p => p.Id);

            Property(p => p.AliasName).HasColumnName("NameAlias").HasMaxLength(20).IsOptional();
            Property(p => p.ShortName).HasColumnName("NameShort").HasMaxLength(30).IsOptional();
            Property(p => p.FullName).HasColumnName("NameFull").HasMaxLength(50).IsOptional();
            Property(p => p.Region).HasColumnName("Region").HasMaxLength(30).IsOptional();
            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
            Property(p => p.Number).HasColumnName("Number").HasMaxLength(2).IsOptional();

            HasMany(e => e.Contracts)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.CoworkerPositions)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.DivisionContacts)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.DivisionCustomers)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.DivisionSignatures)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);

            HasMany(e => e.Prices)
                .WithOptional(e => e.Division)
                .HasForeignKey(e => e.DivisionId);
        }
    }
}
