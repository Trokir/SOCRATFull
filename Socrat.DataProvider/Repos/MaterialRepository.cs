using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class MaterialRepository : UniversalRepository<Material>
    {
        public override bool Save(Material entity)
        {
            bool res = base.Save(entity);
            res = res && DataHelper.SaveCollection(entity.MaterialSpecProperties);
            res = res && DataHelper.SaveCollection(entity.MaterialFields);
            return res;
        }
    }
}