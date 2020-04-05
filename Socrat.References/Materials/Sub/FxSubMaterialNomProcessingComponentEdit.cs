using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials.Sub
{
    public partial class FxSubMaterialNomProcessingComponentEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomExtEdit>
            _materialNomButtonEditAssistent;

        private ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit> _measureButtonEditAssistent;
        public SubMaterialNomProcessingComponent Component { get; set; }
        public FxSubMaterialNomProcessingComponentEdit()
        {
            InitializeComponent();
            Load += FxSubMaterialNomProcessingComponentEdit_Load;
        }

        private void FxSubMaterialNomProcessingComponentEdit_Load(object sender, System.EventArgs e)
        {
            _materialNomButtonEditAssistent = new ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomExtEdit>(
                beMaterialNom, Component.MaterialNom, OnDialogOutput);
            _materialNomButtonEditAssistent.BindProperty(Component, x => x.MaterialNom);
            _materialNomButtonEditAssistent.SelectionFormFiltersSetup =
                () =>
                {
                    return new FxFilteredMaterialNoms
                    {
                        Processing = Component.SubMaterialNomProcessing.ProcessingNom.Processing
                    };
                };

            _measureButtonEditAssistent = new ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit>(
                beMeasure, Component.Measure, OnDialogOutput);
            _measureButtonEditAssistent.BindProperty(Component, x => x.Measure);
        }

        protected override IEntity GetEntity()
        {
            return Component;
        }

        protected override void SetEntity(IEntity value)
        {
            Component = value as SubMaterialNomProcessingComponent;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(seSequence, Component, x => x.Sequence);
            BindEditor(seQty, Component, x => x.Qty);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { seSequence, beMaterialNom, seQty, beMeasure };
        }
    }
}