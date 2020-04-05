using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core.Entities;
using Socrat.DataProvider;


namespace Socrat.References.Formula
{
    public class MaterialFinder : IDisposable
    {
        private Socrat.Core.IRepository<MaterialNom> _repo;
        private List<MaterialNom> _cash = new List<MaterialNom>();

        public MaterialFinder()
        {
            _repo = DataHelper.GetRepository<MaterialNom>();
        }

        public MaterialNom Find(Func<MaterialNom, bool> predicate, Material material)
        {
            MaterialNom regMaterial = null;
            _cash.Clear();
            _cash = _repo.GetAll().Where(x => x.VendorMaterialNom.Material.Id == material.Id).ToList();
            regMaterial = _cash.FirstOrDefault(predicate);
            return regMaterial;
        }

        public MaterialNom Find(Func<MaterialNom, bool> predicate)
        {
            MaterialNom regMaterial = null;
            _cash.Clear();
            _cash = _repo.GetAll().ToList();
            regMaterial = _cash.FirstOrDefault(predicate);
            return regMaterial;
        }

        public void Dispose()
        {
            if (_repo != null)
                _repo.Dispose();
        }
    }
}