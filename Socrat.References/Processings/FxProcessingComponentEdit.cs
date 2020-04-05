using System.Collections.Generic;
using System.Linq;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Materials;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxProcessingComponentEdit : FxBaseSimpleDialog
    {
        public bool ChoiseNomenclatureOnly { get; set; }

        public ProcessingComponent ProcessingComponent { get; set; }

        private ButtonEditAssistent<MaterialNom, FxMaterialNomenclature, FxMaterialNomEdit> _materialNomAssistent;
        private ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit> _measureAssistent;

        /// <summary>
        /// Исключающий фильтр для списка доступных комплектующих
        /// </summary>
        private  MaterialEnum[] _materialExeptedFilter = new MaterialEnum[]
        {
            MaterialEnum.Frame, MaterialEnum.GU, MaterialEnum.Gas, MaterialEnum.Glass, MaterialEnum.Inset, MaterialEnum.Triplex,
            MaterialEnum.TriplexFilm, MaterialEnum.VolumeConnectors, MaterialEnum.ConerConnectors, MaterialEnum.LineConnectors
        };

        public FxProcessingComponentEdit()
        {
            InitializeComponent();
            Load += FxProcessingComponentEdit_Load;

        }

        private void FxProcessingComponentEdit_Load(object sender, System.EventArgs e)
        {
            _materialNomAssistent = new ButtonEditAssistent<MaterialNom, FxMaterialNomenclature, FxMaterialNomEdit>(beMaterialNom, 
                ProcessingComponent.MaterialNom, OnDialogOutput);
            _materialNomAssistent.BindProperty(ProcessingComponent, x => x.MaterialNom);
            _materialNomAssistent.ExternalFilterExp = nom => nom.Material != null
                                                             && !_materialExeptedFilter.Contains(nom.Material.MaterialEnum); 

            _measureAssistent = new ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit>(beMeasure, 
                ProcessingComponent.Measure, OnDialogOutput);
            _measureAssistent.BindProperty(ProcessingComponent, x => x.Measure);

            beMeasure.Enabled = !ChoiseNomenclatureOnly;
            seQty.Enabled = !ChoiseNomenclatureOnly;
        }

        protected override IEntity GetEntity()
        {
            return ProcessingComponent;
        }

        protected override void SetEntity(IEntity value)
        {
            ProcessingComponent = value as ProcessingComponent;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(seQty, ProcessingComponent, x => x.Qty);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beMaterialNom, seQty, beMeasure };
        }
    }
}