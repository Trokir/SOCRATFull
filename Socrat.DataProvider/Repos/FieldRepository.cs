using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class FieldRepository : UniversalRepository<Field>
    {
        public override bool Save(Field entity)
        {
            bool res = base.Save(entity);
            res = res && DataHelper.SaveCollection(entity.FieldValues);
            return res;
        }
    }
}