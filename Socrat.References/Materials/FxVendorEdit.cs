using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxVendorEdit : FxBaseSimpleDialog
    {
        public Vendor Vendor { get; set; }
        private CxVendorMaterialNom _cxVendorMaterialNom;
        private CxVendorMaterials _cxVendorMaterials;
        private CxVendorBrands _cxVendorBrands;
        private CxVendorTradeMarks _cxVendorTradeMarks;

        public FxVendorEdit()
        {
            InitializeComponent();
            Load += FxVendorEdit_Load;
        }

        private void FxVendorEdit_Load(object sender, EventArgs e)
        {
            InitVendorMaterialTypes();
            InitNomenclature();
            InitBrands();
            InitTradeMarks();
            tabbedControlGroup1.SelectedTabPage = layoutControlGroup3;
        }

        private void InitTradeMarks()
        {
            _cxVendorTradeMarks = new CxVendorTradeMarks();
            _cxVendorTradeMarks.DependedSaving = true;
            _cxVendorTradeMarks.Vendor = Vendor;
            pcTradeMarks.Controls.Add(_cxVendorTradeMarks);
            _cxVendorTradeMarks.Dock = DockStyle.Fill;
            _cxVendorTradeMarks.DialogOutput += CxVendorBrandsDialogOutput;
            _cxVendorTradeMarks.DeleteItemEvent += _DeleteItemEvent;
        }

        private void _DeleteItemEvent(object sender, ListItemEventArgs e)
        {
            _cxVendorMaterials.RefreshData();
            _cxVendorBrands.RefreshData();
            _cxVendorTradeMarks.RefreshData();
            _cxVendorMaterialNom.RefreshData();
        }

        private void InitBrands()
        {
            _cxVendorBrands = new CxVendorBrands();
            _cxVendorBrands.Vendor = Vendor;
            _cxVendorBrands.DependedSaving = true;
            pcBrands.Controls.Add(_cxVendorBrands);
            _cxVendorBrands.Dock = DockStyle.Fill;
            _cxVendorBrands.DialogOutput += CxVendorBrandsDialogOutput;
            _cxVendorBrands.DeleteItemEvent += _DeleteItemEvent;
        }

        private void InitVendorMaterialTypes()
        {
            _cxVendorMaterials = new CxVendorMaterials();
            _cxVendorMaterials.Vendor = Vendor;
            _cxVendorMaterials.DependedSaving = true;
            pcVendorMaterialTypes.Controls.Add(_cxVendorMaterials);
            _cxVendorMaterials.Dock = DockStyle.Fill;
            _cxVendorMaterials.DialogOutput += CxVendorBrandsDialogOutput;
            _cxVendorMaterials.DeleteItemEvent += _DeleteItemEvent;
        }

        private void InitNomenclature()
        {
            _cxVendorMaterialNom = new CxVendorMaterialNom();
            _cxVendorMaterialNom.Vendor = Vendor;
            _cxVendorMaterialNom.DependedSaving = true;
            pcMaterials.Controls.Add(_cxVendorMaterialNom);
            _cxVendorMaterialNom.Dock = DockStyle.Fill;
            _cxVendorMaterialNom.DialogOutput += CxVendorBrandsDialogOutput;
            _cxVendorMaterialNom.DeleteItemEvent += _DeleteItemEvent;
        }

        private void CxVendorBrandsDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override IEntity GetEntity()
        {
            return Vendor;
        }

        protected override void SetEntity(IEntity value)
        {
            Vendor = value as Vendor;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(meName, Vendor, x => x.Name);
            BindEditor(meDesc, Vendor, x => x.Description);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { meName, meDesc};
        }

    }
}