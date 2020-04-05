using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.DataProvider;
using Socrat.Model;
using Material = Socrat.DataProvider.Material;

namespace Socrat.Module.Order
{
    public class MaterialFinder: IDisposable
    {
        private MaterialNomRepository _repo;
        private List<Model.MaterialNom> _cash = new List<Model.MaterialNom>();

        public MaterialFinder()
        {
            _repo = new MaterialNomRepository();
        }

        public Model.MaterialNom Find(Func<Model.MaterialNom, bool> predicate, Model.Material material)
        {
            Model.MaterialNom regMaterial = null;
            _cash.Clear();
            _cash = _repo.GetAll().Where(x => x.Material.Id == material.Id).ToList();
            regMaterial = _cash.FirstOrDefault(predicate);
            return regMaterial;
        }

        public Model.MaterialNom Find(Func<Model.MaterialNom, bool> predicate)
        {
            Model.MaterialNom regMaterial = null;
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