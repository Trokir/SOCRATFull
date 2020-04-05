using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Model;

namespace Socrat.Module.Order
{
    public partial class CxFrameIteProperies : CxFormulaItemProperties
    {
        private FrameItem _frameItem;
        public FrameItem FrameItem
        {
            get => _frameItem;
            set => SetFrameItem(value);
        }

        private void SetFrameItem(FrameItem value)
        {
            _frameItem = value;
            _frameItem.PropertyChanged -= _frameItem_PropertyChanged;
            _frameItem.PropertyChanged += _frameItem_PropertyChanged;
        }

        private void _frameItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnNeedUpdateParentView();
        }

        public CxFrameIteProperies()
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
            BindEditor(ceGas, FrameItem.FormulaItemFrameProperty, x => x.Gaz);
            BindEditor(ceCustomerFrame, FrameItem.FormulaItemFrameProperty, x => x.Tolling);
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
            beMaterialNom.EditValue = FrameItem.MaterialNom.Code;
        }
    }
}
