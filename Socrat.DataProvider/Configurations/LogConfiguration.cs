using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class LogConfiguration : EntityTypeConfiguration<Socrat.Core.Entities.Log>
    {
        public LogConfiguration()
        {
            ToTable("Log");
            HasKey(p => p.Id);

            Property(p => p.LogType).HasColumnName("LogType").HasColumnType("bigint").IsOptional();
            Property(p => p.Message).HasColumnName("Message").HasMaxLength(2000).IsOptional();
            Property(p => p.DateT).HasColumnName("DateT").IsOptional();
            Property(p => p.UserLogin).HasColumnName("UserLogin").HasMaxLength(50).IsOptional();
            Property(p => p.Header).HasColumnName("Header").HasMaxLength(150).IsOptional();
            Property(p => p.MachineName).HasColumnName("MachineName").HasMaxLength(100).IsOptional();
            Property(p => p.AppName).HasColumnName("AppName").HasMaxLength(100).IsOptional();
            Property(p => p.ExMessage).HasColumnName("ExMessage").HasMaxLength(500).IsOptional();
            Property(p => p.ExSource).HasColumnName("ExSource").HasMaxLength(500).IsOptional();
            Property(p => p.ExStackTrace).HasColumnName("ExStackTrace").HasMaxLength(1000).IsOptional();
            Property(p => p.HelpLink).HasColumnName("HelpLink").HasMaxLength(100).IsOptional();
            Property(p => p.Version).HasColumnName("Version").HasMaxLength(50).IsOptional();
        }
    }
}
