
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class VendorRepository : UniversalRepository<Core.Entities.Vendor>
    {
        public override bool Save(Vendor entity)
        {
            bool res = base.Save(entity);

            if (res)
            {
                res = res && DataHelper.SaveCollection(entity.VendorMaterials);
                res = res && DataHelper.SaveCollection(entity.Brands);
                res = res && DataHelper.SaveCollection(entity.TradeMarks);
                res = res && DataHelper.SaveCollection(entity.VendorMaterialNoms);
            }

            return res;
        }
    }
}