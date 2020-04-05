using System;
using System.ComponentModel;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;


namespace Socrat.References.Formula
{
    public partial class CxFrameItemProperies : CxFormulaItemProperties
    {
        private FrameItem _frameItem;
        public OrderRow OrderRow { get; set; }
        public event EventHandler NeedUpdateTree;

        public FrameItem FrameItem
        {
            get => _frameItem;
            set => SetFrameItem(value);
        }

        private void SetFrameItem(FrameItem value)
        {
            _frameItem = value;
            if (_frameItem.FrameItemProperty == null)
                _frameItem.FrameItemProperty = new FrameItemProperty { Id = _frameItem.Id, FrameItem = _frameItem};
        }

        public CxFrameItemProperies()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            beMaterialNom.EditValue = MaterialNom.Code;
            BindLabel(lcFullName, FrameItem, "MaterialNomName");
            BindLabel(lcVendor, FrameItem, "VendorName");
            BindEditor(ceCustomerFrame, FrameItem, x => x.CustomerMaterial);
            BindEditor(seGermDepth, FrameItem, x => x.GermDepth);
            BindEditor(ceGas, FrameItem, x => x.Gaz);
           // BindEditor(ceCustomerFrame, FrameItem, x => x.Tolling);
        }

        public MaterialNom MaterialNom
        {
            get { return FrameItem?.MaterialNom; }
        }

        private void beMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialNom();
        }

        private void SelectMaterialNom()
        {
            SetupMaterial(MaterialEnum.Frame, FrameItem);
        }

        protected override void UpdateComponent()
        {
           beMaterialNom.EditValue = FrameItem.MaterialNom.Code;
           OnNeedUpdateParentView(FrameItem);
        }

        private void seGermDepth_EditValueChanged(object sender, System.EventArgs e)
        {
            double _value = 0;
            if (seGermDepth.EditValue != null && double.TryParse(seGermDepth.EditValue.ToString(), out _value))
            {
                if (OrderRow.Shape != null && OrderRow.Shape.ShapeParam != null)
                    OrderRow.Shape.ShapeParam.DepthOfHermetic(_value);
            }
        }

        private void ceGas_CheckedChanged(object sender, System.EventArgs e)
        {
            OnNeedUpdateTree();
        }

        private void OnNeedUpdateTree()
        {
            NeedUpdateTree?.Invoke(this, EventArgs.Empty);
        }
    }
}
