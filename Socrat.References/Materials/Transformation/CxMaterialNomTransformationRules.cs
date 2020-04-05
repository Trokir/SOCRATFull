using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Transformations;
using Socrat.DataProvider;

namespace Socrat.References.Materials.Transformation
{
    public class CxMaterialNomTransformationRules : UI.Core.CxGenericListTable<MaterialNomTransformationRule>
    {
        private AttachedList<MaterialNomTransformationRule> _Items;
        public MaterialNom MaterialNom { get; set; }

        public CxMaterialNomTransformationRules()
        {
            _Items = new AttachedList<MaterialNomTransformationRule>();
        }

        protected override IEntity GetOwner()
        {
            return MaterialNom;
        }

        protected override MaterialNomTransformationRule GetNewInstance()
        {
            return new MaterialNomTransformationRule() { MaterialNom = MaterialNom };
        }

        protected override AttachedList<MaterialNomTransformationRule> GetItems()
        {
            if (MaterialNom == null)
                _Items = new AttachedList<MaterialNomTransformationRule>(
                    DataHelper.GetRepository<MaterialNomTransformationRule>().GetAll());
            else
                _Items = MaterialNom.Transformations;
            return _Items;
        }
    }
}
