using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References;
using Socrat.References.Materials;
using Socrat.UI.Core;

namespace Socrat.Module.Price
{
    public partial class FxPriceTypeEdit : FxBaseSimpleDialog
    {
        CxMaterialMarkTypeSelector _cxMaterialMarkTypeSelector;

        private ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit> _materialButtonEditAssistant;
        private ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit> _measureButtonEditAssistant;

        public Core.Entities.PriceType PriceType { get; set; }

        public FxPriceTypeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return PriceType;
        }
        protected override void SetEntity(IEntity value)
        {
            PriceType = value as Core.Entities.PriceType;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                teName,
                beMeasurement,
                beMaterial
            };
        }
        protected override void BindData()
        {
            base.BindData();
            lueNomenclatureCalculationOrder.Properties.DataSource = NomenclatureCalculationOrders;
            lueNomenclatureCalculationOrder.Properties.DisplayMember = "Key";
            lueNomenclatureCalculationOrder.Properties.ValueMember = "Value";

            _materialButtonEditAssistant = new ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit>(
                beMaterial, PriceType?.Material, OnDialogOutput, eButtonsType.All);
            _materialButtonEditAssistant.BindProperty(PriceType, x => x.Material);

            _measureButtonEditAssistant = new ButtonEditAssistent<Measure, FxMeasures, FxMeasureEdit>(
                 beMeasurement, PriceType?.Measure, OnDialogOutput, eButtonsType.All);
            _measureButtonEditAssistant.BindProperty(PriceType, x => x.Measure);

            BindEditor(teName, PriceType, x => x.Name);
            BindEditor(lueNomenclatureCalculationOrder, PriceType, x => x.NomenclatureCalculationOrder);


            InitPriceTypeMarkTypeSelector();
        }

        private void InitPriceTypeMarkTypeSelector()
        {
            if (_cxMaterialMarkTypeSelector == null)
            {
                _cxMaterialMarkTypeSelector = new CxMaterialMarkTypeSelector
                {
                    PriceType = PriceType,
                    Dock = DockStyle.Fill
                };
                _cxMaterialMarkTypeSelector.DialogOutput += (o, e) => OnDialogOutput(e);
            }

            if (!pcPriceTypeMarkTypes.Controls.Contains(_cxMaterialMarkTypeSelector))
                pcPriceTypeMarkTypes.Controls.Add(_cxMaterialMarkTypeSelector);
        }

        private void beMaterial_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.OldValue != null && e.NewValue != e.OldValue && PriceType.PriceTypeMarkTypes.Count > 0 )
            {
                if (XtraMessageBox.Show(
                    "Смена типа материалов приведет к сбросу привязанных к разделу типов номенклатуры материалов. Продолжить?",
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                _cxMaterialMarkTypeSelector.Items
                    .Where(selectedMaterialMarkType =>
                        selectedMaterialMarkType.Selected == true)
                            .ForEach(materialMarkType => _cxMaterialMarkTypeSelector.UnSelect(materialMarkType));
            }
        }

        private void beMaterial_EditValueChanged(object sender, System.EventArgs e)
        {
            if (_cxMaterialMarkTypeSelector != null)
            {
                DataHelper.RefreshData<MaterialMarkType>(_cxMaterialMarkTypeSelector.Items);
                _cxMaterialMarkTypeSelector.Refresh();
            }
        }

        private Dictionary<string, int> NomenclatureCalculationOrders { get; } = new Dictionary<string, int>() { { "В разделе А", 0 }, { "В разделе D", 99 } };
            
    }   
}