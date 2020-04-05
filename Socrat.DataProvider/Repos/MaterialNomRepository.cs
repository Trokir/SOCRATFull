using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
using Socrat.Log;


namespace Socrat.DataProvider.Repos
{
    internal class MaterialNomRepository : UniversalRepository<MaterialNom>
    {
        internal List<MaterialNom> GetMaterialNomsByMaterial(Material material)
        {
            List<MaterialNom> _materialsNoms = null;
            try
            {
                _materialsNoms =
                    SocratEntities.MaterialNoms.Where(x => x.VendorMaterialNom != null
                                                            && x.VendorMaterialNom != null
                                                            && x.VendorMaterialNom.Material.Id == material.Id).ToList();
            }
            catch (Exception e)
            {
                Logger.AddErrorEx("MaterialNomRepository.GetMaterialNomsByMaterial", e);
            }
            return _materialsNoms;
        }
    }
}