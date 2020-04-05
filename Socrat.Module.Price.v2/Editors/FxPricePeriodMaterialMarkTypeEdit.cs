using System.Linq;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References;
using Socrat.References.Materials;
using Socrat.UI.Core;

namespace Socrat.Module.Price
{
    public partial class FxPricePeriodMaterialMarkTypeEdit : FxBaseSimpleDialog
    {
        private ButtonEditAssistent<MaterialMarkType, FxGenericListTable2<MaterialMarkType>, FxMaterialMarkTypeEdit> _beaMaterialMarkType;
        private ButtonEditAssistent<MaterialSizeType, FxGenericListTable2<MaterialSizeType>, FxMaterialSizeTypeEdit> _beaMaterialSizeType;
        private ButtonEditAssistent<VendorMaterialNom, FxGenericListTable2<VendorMaterialNom>, FxVendorMaterialNomEdit> _beaVendorMaterialNom;

        public PricePeriodMaterialMarkType PricePeriodMaterialMarkType { get; set; }

        public FxPricePeriodMaterialMarkTypeEdit()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            base.BindData();

            _beaMaterialMarkType = new ButtonEditAssistent<MaterialMarkType, FxGenericListTable2<MaterialMarkType>, FxMaterialMarkTypeEdit>(
                beMaterialMarkType, PricePeriodMaterialMarkType?.MaterialMarkType, OnDialogOutput, eButtonsType.All);
            _beaMaterialMarkType.BindProperty(PricePeriodMaterialMarkType, x => x.MaterialMarkType);

            _beaMaterialSizeType = new ButtonEditAssistent<MaterialSizeType, FxGenericListTable2<MaterialSizeType>, FxMaterialSizeTypeEdit>(
                beMaterialSizeType, PricePeriodMaterialMarkType?.MaterialSizeType, OnDialogOutput, eButtonsType.All);
            _beaMaterialSizeType.BindProperty(PricePeriodMaterialMarkType, x => x.MaterialSizeType);

            _beaVendorMaterialNom = new ButtonEditAssistent<VendorMaterialNom, FxGenericListTable2<VendorMaterialNom>, FxVendorMaterialNomEdit>(
                beVendorMaterialNom, PricePeriodMaterialMarkType?.VendorMaterialNom, OnDialogOutput, eButtonsType.All);
            _beaVendorMaterialNom.BindProperty(PricePeriodMaterialMarkType, x => x.VendorMaterialNom);

            flaggedProductionTypeEditor.DataBindings.Add("FlaggedProductionType", PricePeriodMaterialMarkType, "FlaggedProductionType");

            BindEditor(meAddValueToMeasurementItem, PricePeriodMaterialMarkType, x => x.AddValueToMeasurementItem);
            BindEditor(teMultiplyValueToEntireItem, PricePeriodMaterialMarkType, x => x.MultiplyValueToEntireItemForEditor);
            BindEditor(meAddValueToEntireItem, PricePeriodMaterialMarkType, x => x.AddValueToEntireItem);

            _beaMaterialMarkType.SelectionChanged += (o, e) =>
            {
                if (beMaterialMarkType.EditValue is MaterialMarkType materialMarkType)
                {
                    _beaVendorMaterialNom.ExternalFilterExp = (x) => x.MaterialMarkType == materialMarkType;
                    _beaMaterialSizeType.ExternalFilterExp = (x) => x.MaterialMarkType == materialMarkType;
                }
                else
                {
                    _beaVendorMaterialNom.ExternalFilterExp = null;
                    _beaMaterialSizeType.ExternalFilterExp = null;
                }
            };
        }

        protected override void SetEntity(IEntity value)
        {
            PricePeriodMaterialMarkType = value as PricePeriodMaterialMarkType;
        }

        protected override IEntity GetEntity()
        {
            return PricePeriodMaterialMarkType;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            layoutControl.Controls.OfType<BaseEdit>()
                .ForEach(x => x.ReadOnly = value);
        }
    }
}