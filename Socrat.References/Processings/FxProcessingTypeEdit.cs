using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.References.Materials;
using Socrat.UI.Core;

namespace Socrat.References.Processings
{
    public partial class FxProcessingTypeEdit : FxBaseSimpleDialog
    {
        public ProcessingType ProcessingType { get; set; }
        private List<Material> _materials;
        private ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit> _measureButtonEditAssistent;
        private IDictionary<int, string> _DialogTypes;

        public FxProcessingTypeEdit()
        {
            InitializeComponent();
            Load += FxProcessingTypeEdit_Load;
        }

        private void FxProcessingTypeEdit_Load(object sender, EventArgs e)
        {
            _measureButtonEditAssistent = new ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit>(
                beMeasure, ProcessingType.Measure, OnDialogOutput);
            _measureButtonEditAssistent.BindProperty(ProcessingType, x => x.Measure);

            _DialogTypes = EnumHelper<FormulaItemProcessingEnum>.GetLookUpSource(true);
            lueDialogType.Properties.DataSource = _DialogTypes;
        }

        protected override IEntity GetEntity()
        {
            return ProcessingType;
        }

        protected override void SetEntity(IEntity value)
        {
            ProcessingType = value as ProcessingType;
        }

        protected override void BindData()
        {
            LoadData();
            base.BindData();
            BindEditor(teName, ProcessingType, x => x.Name);
            BindEditor(teShortName, ProcessingType, x =>x.ShortName);
            BindEditor(seStep, ProcessingType, x => x.Step);

            lueMaterial.EditValue = ProcessingType?.Material?.Id;
            beMeasure.EditValue = ProcessingType?.Measure?.Id;
            ceColor.Color = ProcessingType.Color ?? Color.Empty;
            lueDialogType.EditValue = (byte)ProcessingType.Enumerator;
        }

        private void LoadData()
        {
            _materials = DataHelper.GetAll<Material>();
            lueMaterial.Properties.DataSource = null;
            lueMaterial.Properties.DataSource = _materials;

        }

        private void lueMaterial_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (lueMaterial.EditValue != null && Guid.TryParse(lueMaterial.EditValue.ToString(), out _id))
            {
                ProcessingType.Material = _materials.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueMaterial, teName, teShortName, seStep, beMeasure};
        }

        private void ceColor_EditValueChanged(object sender, EventArgs e)
        {
            ProcessingType.Color = ceColor.Color;
        }

        private void lueDialogType_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDialogType.EditValue != null)
            {
                long _num = 0;
                if (long.TryParse(lueDialogType.EditValue.ToString(), out _num))
                    ProcessingType.Enumerator = EnumHelper<FormulaItemProcessingEnum>.FromNum(_num);
            }
        }
    }
}
