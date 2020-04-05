using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Common.Enums;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.UI.Core;

namespace Socrat.References.Order
{
    public partial class FxBarcodeTypeEdit : FxBaseSimpleDialog
    {
        public BarcodeType BarcodeType { get; set; }
        public FxBarcodeTypeEdit()
        {
            InitializeComponent();
            Load += FxBarcodeTypeEdit_Load;
        }

        private void FxBarcodeTypeEdit_Load(object sender, System.EventArgs e)
        {
            EnumHelper<BarCodeTypes>.PrepareLookUp(lueEnum);
        }

        protected override IEntity GetEntity()
        {
            return BarcodeType;
        }

        protected override void SetEntity(IEntity value)
        {
            BarcodeType = value as BarcodeType;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teCode, BarcodeType, x => x.Code);
            BindEditor(lueEnum, BarcodeType, x => x.Enumerator);
            BindEditor(meDesc, BarcodeType, x => x.Description);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teCode, lueEnum};
        }
    }
}