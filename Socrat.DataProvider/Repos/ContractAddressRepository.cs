using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class ContractAddressRepository : UniversalRepository<ContractAddress>
    {
        public override bool Save(ContractAddress entity)
        {
            if (entity.Address != null)
                DataHelper.Save(entity.Address);
            return base.Save(entity);
        }
    }
}