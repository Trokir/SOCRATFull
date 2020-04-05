using System.Collections.Generic;
using Socrat.Core.Entities;


namespace Socrat.DataProvider.Repos
{
    internal class MaterialFieldRepository : UniversalRepository<MaterialField>
    {
        public override bool Save(MaterialField entity)
        {
            bool res = DataHelper.Save(entity.Field);
            return res && base.Save(entity);
        }

        public override bool Save(IEnumerable<MaterialField> entities)
        {
            bool res = true;
            foreach (MaterialField entity in entities)
            {
                res = res && Save(entity);
            }
            return res;
        }
    }
}