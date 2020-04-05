using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialSizeEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>
            _materialNomButtonEditAssistent;

        private List<Measure> measures;

        public MaterialMarkType MaterialMarkType { get; set; }
        public MaterialSizeType MaterialSizeType { get; set; }

        public FxMaterialSizeEdit()
        {
            InitializeComponent();
            Load += FxMaterialSizeEdit_Load;
        }

        private void FxMaterialSizeEdit_Load(object sender, System.EventArgs e)
        {
            measures = DataHelper.GetAll<Measure>();
            lueMeasure.Properties.DataSource = null;
            lueMeasure.Properties.DataSource = measures;

            _materialNomButtonEditAssistent = new ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>(
                beDefaultVendorMaterial, MaterialSizeType.DefaultMaterialNom, OnDialogOutput);
            _materialNomButtonEditAssistent.BindProperty(MaterialSizeType, x=> x.DefaultMaterialNom);
            _materialNomButtonEditAssistent.SelectionFormFiltersSetup = () =>  
                new FxFilteredMaterialNoms
                {
                    MaterialMarkType = this.MaterialMarkType
                };   
        }

        protected override IEntity GetEntity()
        {
            return MaterialSizeType;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialSizeType = value as MaterialSizeType;
        }

        protected override string GetTitle()
        {
            return $"Типоразмер материала {MaterialSizeType}";
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(seThickness, MaterialSizeType, x => x.Thickness);
            lueMeasure.EditValue = MaterialSizeType.Measure?.Id;
        }

        private void lueMeasure_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (measures != null && lueMeasure.EditValue != null && Guid.TryParse(lueMeasure.EditValue.ToString(), out _id))
            {
                MaterialSizeType.Measure = measures.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { seThickness, lueMeasure};
        }
    }
}