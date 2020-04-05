using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Lib;
using Socrat.Model;
using Socrat.References.Materials;

namespace Socrat.Module.Order
{
    public partial class CxGlassItemProperties : CxFormulaItemProperties
    {
        private GlassItem _glassItem;
        public GlassItem GlassItem
        {
            get => _glassItem;
            set => SetGlassItem(value);
        }

        private void SetGlassItem(GlassItem value)
        {
            _glassItem = value;
            _glassItem.PropertyChanged -= _glassItem_PropertyChanged;
            _glassItem.PropertyChanged += _glassItem_PropertyChanged;
        }

        private void _glassItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnNeedUpdateParentView();
        }

        public MaterialNom MaterialNom
        {
            get { return GlassItem?.MaterialNom; }
        }

        public CxGlassItemProperties()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            beMaterialNom.EditValue = MaterialNom.Code;
            BindLabel(lcName, GlassItem, "MaterialNomName");
            BindLabel(lcVendor, GlassItem, "VendorName");
            BindEditor(ceDent, GlassItem, x => x.DentExists);
            BindEditor(ceCustomerGlass, GlassItem, x => x.CustomerMaterial);
            BindEditor(ceDent, GlassItem.FormulaItemGlassProperty, x => x.Dent);
            BindEditor(ceCustomerGlass, GlassItem.FormulaItemGlassProperty, x => x.Tolling);
        }

        private void beMaterialNom_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SelectMaterialNom();
        }

        private void SelectMaterialNom()
        {
            SetupMaterial(MaterialEnum.Glass, GlassItem);
            beMaterialNom.EditValue = GlassItem.MaterialNom.Code;
        }
        
    }
}
