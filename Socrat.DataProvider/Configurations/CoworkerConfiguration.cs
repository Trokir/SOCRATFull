using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CoworkerConfiguration : EntityTypeConfiguration<Coworker>
    {
        public CoworkerConfiguration()
        {
            ToTable("Coworker");
            HasKey(p => p.Id);

            Property(p => p.FirstName).HasColumnName("NameFirst").HasMaxLength(30).IsOptional();
            Property(p => p.MiddleName).HasColumnName("NameMiddle").HasMaxLength(30).IsOptional();
            Property(p => p.LastName).HasColumnName("NameLast").HasMaxLength(30).IsOptional();
            Property(p => p.GenderId).HasColumnName("Gender_Id").IsOptional();
            Property(p => p.BirthDay).HasColumnName("Birth").IsOptional();

            HasMany(e => e.Contracts)
                .WithOptional(e => e.Coworker)
                .HasForeignKey(e => e.CoworkerId);

            HasMany(e => e.CoworkerContacts)
                .WithOptional(e => e.Coworker)
                .HasForeignKey(e => e.CoworkerId);

            HasMany(e => e.CoworkerPositions)
                .WithOptional(e => e.Coworker)
                .HasForeignKey(e => e.CoworkerId);

            HasMany(e => e.DivisionSignatures)
                .WithOptional(e => e.Coworker)
                .HasForeignKey(e => e.CoworkerId);
        }
    }
}
