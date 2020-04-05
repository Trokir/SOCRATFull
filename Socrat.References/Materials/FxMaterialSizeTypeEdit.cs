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
    public partial class FxMaterialSizeTypeEdit : FxBaseSimpleDialog
    {
        public MaterialSizeType MaterialSizeType { get; set; }
        private List<Measure> _measures;
        public Material Material { get; set; }

        public FxMaterialSizeTypeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return MaterialSizeType;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialSizeType = value as MaterialSizeType;
        }

        protected override void BindData()
        {
            LoadData();
            base.BindData();
            beMaterialMark.EditValue = MaterialSizeType.MaterialMarkType;
            BindEditor(seTickness, MaterialSizeType, x => x.Thickness);
            lueMeasure.EditValue = MaterialSizeType.MeasureId;
            beDefaultMaterialNom.EditValue = MaterialSizeType.MaterialNom;
            BindEditor(teMark, MaterialSizeType, x => x.Mark);
        }

        private void LoadData()
        {
            _measures = DataHelper.GetAll<Measure>();
            lueMeasure.Properties.DataSource = _measures;

            if (MaterialSizeType != null && MaterialSizeType.Measure == null)
                MaterialSizeType.Measure =
                    _measures.FirstOrDefault(x => x.Name?.ToLower().Contains("миллиметр") ?? false);

            teMark.Enabled = MaterialSizeType != null && MaterialSizeType.Material != null 
                                                      && (MaterialSizeType.Material.MaterialEnum == MaterialEnum.TriplexFilm 
              || MaterialSizeType.Material.MaterialEnum == MaterialEnum.Film || MaterialSizeType.Material.MaterialEnum == MaterialEnum.Triplex);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beMaterialMark, seTickness, lueMeasure };
        }

        private void lueMeasure_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueMeasure.EditValue != null && Guid.TryParse(lueMeasure.EditValue.ToString(), out _id))
            {
                MaterialSizeType.Measure = _measures.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void beMaterialMark_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialMarkType();
        }

        private void SelectMaterialMarkType()
        {
            FxMaterialMarkTypes _fx = new FxMaterialMarkTypes();
            _fx.SetSingleSelectMode(MaterialSizeType.MaterialMarkType);
            _fx.Material = this.Material;
            _fx.ItemSelected += (sender, args) =>
            {
                MaterialSizeType.MaterialMarkType = _fx.SelectedItem as MaterialMarkType;
                beMaterialMark.EditValue = MaterialSizeType.MaterialMarkType;
            };
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void beDefaultMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxFilteredMaterialNoms _fx = new FxFilteredMaterialNoms();
            _fx.SetSingleSelectMode(MaterialSizeType.MaterialNom);
            _fx.Material = MaterialSizeType?.Material;
            _fx.ItemSelected += (o, args) =>
            {
                MaterialSizeType.MaterialNom = _fx.SelectedItem as MaterialNom;
                beDefaultMaterialNom.EditValue = MaterialSizeType.MaterialNom;
            };
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }
    }
}