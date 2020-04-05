using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class AddressRepository : UniversalRepository<Address>
    {
        public override bool Save(Address entity)
        {
            bool res = base.Save(entity);
            if (entity.AddressItems != null && entity.AddressItems.Count > 0)
                res = res && DataHelper.SaveCollection(entity.AddressItems);
            return res;
        }
    }
}