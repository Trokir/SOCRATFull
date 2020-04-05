using System;
using System.Collections.Generic;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Processings
{
    public partial class FxMaterialProcessings : FxGenericListTable<Processing>
    {
        public MaterialEnum MaterialEnum { get; set; }

        private Material _material;
        private Material Material
        {
            get => GetMaterial();
            set => SetMaterial(value);
        }

        private Material GetMaterial()
        {
            if (_material == null)
                using (IRepository<Material> _repo = DataHelper.GetRepository<Material>())
                {
                    _material = _repo.GetItem(x => x.MaterialEnum == MaterialEnum);
                }

            return _material;
        }

        private void SetMaterial(Material value)
        {
            _material = value;
        }

        public FxMaterialProcessings()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наимнование", "Name", 200,0);
        }

        protected override List<Processing> GetItems()
        {
            IEnumerable<Guid> _ids = Material.ProcessingTypes.SelectMany(x => x.Processings).Select(y => y.Id);
            return Repository.GetAll(x => _ids.Contains(x.Id)).ToList();
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingEdit();
        }
    }
}