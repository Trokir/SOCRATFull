using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class EMailConfiguration : EntityTypeConfiguration<EMail>
    {
        public EMailConfiguration()
        {
            ToTable("EMail");
            HasKey(p => p.Id);

            Property(p => p.Id).HasColumnName("Id").IsRequired();
            Property(p => p.DateSend).HasColumnName("DateCreated").IsRequired();
            Property(p => p.DateSend).HasColumnName("DateSend").IsOptional();
            Property(p => p.From).HasColumnName("From").HasMaxLength(50).IsOptional();
            Property(p => p.To).HasColumnName("To").HasMaxLength(50).IsRequired();
            Property(p => p.Subject).HasColumnName("Subject").HasMaxLength(150).IsOptional();
            Property(p => p.Body).HasColumnName("Body").IsOptional();
            Property(p => p.EmailStatusEnum).HasColumnName("EmailStatusEnum").IsRequired();

            HasMany(e => e.EMailFiles)
                .WithRequired(e => e.EMail)
                .HasForeignKey(e => e.EMailId)
                .WillCascadeOnDelete();

        }
    }
}
