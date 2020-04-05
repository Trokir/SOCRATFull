using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public partial class EMailFileConfiguration : EntityTypeConfiguration<EMailFile>
    {
        public EMailFileConfiguration()
        {
            ToTable("EMailFile");
            HasKey(p => p.Id);

            Property(p => p.EMailId).HasColumnName("EMail_Id").IsRequired();
            Property(p => p.FileFullPath).HasColumnName("FileFullPath").IsRequired();
        }
    }
}
