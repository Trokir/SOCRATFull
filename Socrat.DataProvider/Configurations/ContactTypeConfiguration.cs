using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContactTypeConfiguration : EntityTypeConfiguration<ContactType>
    {
        public ContactTypeConfiguration()
        {
            ToTable("ContactType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsRequired();
            Property(p => p.RegexMask).HasColumnName("RegexMask").HasMaxLength(150).IsOptional();
            Ignore(p => p.ContactTypeNum);

            HasMany(e => e.AddressContacts)
                .WithOptional(e => e.ContactType)
                .HasForeignKey(e => e.ContactTypeId);

            HasMany(e => e.CoworkerContacts)
                .WithOptional(e => e.ContactType)
                .HasForeignKey(e => e.ContactTypeId);

            HasMany(e => e.CustomerContacts)
                .WithOptional(e => e.ContactType)
                .HasForeignKey(e => e.ContactTypeId);

            HasMany(e => e.DivisionContacts)
                .WithOptional(e => e.ContactType)
                .HasForeignKey(e => e.ContactTypeId);
        }
    }
}
