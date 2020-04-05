using System;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class VendorMaterialRepository : UniversalRepository<Core.Entities.VendorMaterial>
    {
        public override void Delete(Guid id)
        {
            Core.Entities.VendorMaterial _vendorMaterial =
                SocratEntities.VendorMaterials.FirstOrDefault(x => x.Id == id);
            if (_vendorMaterial != null)
            {
                Core.Entities.Vendor _vendor = _vendorMaterial.Vendor;

                var _vendorNoms = _vendor.VendorMaterialNoms.Where(x => x.MaterialId == _vendorMaterial.MaterialId)
                    .ToList();
                if (_vendorNoms != null && _vendorNoms.Count > 0)
                {
                    SocratEntities.VendorMaterialNoms.RemoveRange(_vendorNoms);
                    SocratEntities.SafetySaveChanges();
                }

                var _venforTMs = _vendor.TradeMarks.Where(x => x.MaterialId == _vendorMaterial.MaterialId).ToList();
                if (_venforTMs != null && _venforTMs.Count > 0)
                {
                    SocratEntities.Set<TradeMark>().RemoveRange(_venforTMs);
                    SocratEntities.SafetySaveChanges();
                }

                var _vendorMaterialBrands =
                    _vendor.Brands.Where(x => x.MaterialId == _vendorMaterial.MaterialId).ToList();
                if (_vendorMaterialBrands != null && _vendorMaterialBrands.Count > 0)
                {
                    SocratEntities.Brands.RemoveRange(_vendorMaterialBrands);
                    SocratEntities.SafetySaveChanges();
                }
            }
            base.Delete(id);
        }
    }
}