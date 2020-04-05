using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Transformations;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public class FxTransformations : FxGenericListTable2<MaterialNomTransformationRule>
    {
        public MaterialNom MaterialNom { get; set; }
        
        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new Transformation.FxMaterialNomTransformationRuleEdit(MaterialNom);
        }

        protected override IEntityEditor GetEditor(MaterialNomTransformationRule entity, OpenMode openMode = OpenMode.Default)
        {
            entity.MaterialNom = MaterialNom;
            return new Transformation.FxMaterialNomTransformationRuleEdit(MaterialNom);
        }
    }
}
