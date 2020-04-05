using Socrat.Core.Entities;
using Socrat.Core.Entities.Materials;

namespace Socrat.References.Materials
{
    public class CxGlassLabels : CxGenericListTable<GlassLabel>
    {
        public Core.Entities.Customer Customer { get; set; }
        public MaterialNom MaterialNom { get; set; }

        protected override GlassLabel GetNewInstance()
        {
            GlassLabel glassLabel = new GlassLabel();

            if (Customer != null)
                glassLabel.Customer = Customer;

            if (MaterialNom != null)
                glassLabel.MaterialNom = MaterialNom;
            glassLabel.Loaded = true;
            return glassLabel;
        }
    }
}
