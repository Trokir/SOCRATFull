using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Pools;

namespace Socrat.DataProvider.Configurations
{
    public class PoolConfiguration : EntityTypeConfiguration<Pool>
    {
        public PoolConfiguration()
        {
            ToTable("Pool");
            HasKey(p => p.Id);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Pool)
                .HasForeignKey(e => e.PoolId);
        }
    }
}