using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class VendorMaterialNomRepository : UniversalRepository<VendorMaterialNom>
    {
        public override bool Save(Core.Entities.VendorMaterialNom entity)
        {
            bool res = false;

            if (entity.Vendor != null)
                res = DataHelper.Save(entity.Vendor);
            
            if (entity.Brand != null)
                res = DataHelper.Save(entity.Brand);

            if (entity.TradeMark != null)
                res = DataHelper.Save(entity.TradeMark);

            if (entity.MaterialMarkType != null)
                res = DataHelper.Save(entity.MaterialMarkType);

            res = res && base.Save(entity);

            return res;
        }
    }
}