using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.Core.Entities.Transformations;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomExtEdit : FxBaseSimpleDialog
    {
        public MaterialNom MaterialNom { get; set; }
        public MaterialNomFilter MaterialNomFilter { get; set; }

        private ButtonEditAssistent<MaterialType, FxMaterialTypes, FxMaterialTypeEdit>
            _materialTypeButtonEditAssistent;
        private ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit>
            _materialButtonEditAssistent;
        private ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit>
            _vendorButtonEditAssistent;
        private ButtonEditAssistent<VendorMaterialNom, FxVendorMaterialNoms, FxVendorMaterialNomEdit>
            _vendorMaterialButtonEditAssistent;
        private ButtonEditAssistent<MaterialSizeType, FxMaterialSizeTypeList, FxMaterialSizeTypeEdit>
            _materialSizeTypeButtonEditAssistent;

        private bool _firstLoad = false;

        public FxMaterialNomExtEdit()
        {
            InitializeComponent();
            Load += FxMaterialNomEdit_Load;
            cxMaterialNomTransformationRules1.GettingItems += (o, e) =>
            {
                cxMaterialNomTransformationRules1.MaterialNom = MaterialNom;
                e = MaterialNom.Transformations;
            };

            cxMaterialNomTransformationRules1.DialogOutput += (o, e) => { OnDialogOutput(e); };
            _firstLoad = true;

            beMaterialType.Properties.UseReadOnlyAppearance = false;
            beMaterial.Properties.UseReadOnlyAppearance = false;
            beVendor.Properties.UseReadOnlyAppearance = false;
            beVendorMaterialNom.Properties.UseReadOnlyAppearance = false;
            beThickness.Properties.UseReadOnlyAppearance = false;
        }

        private void FxMaterialNomEdit_Load(object sender, System.EventArgs e)
        {
            MaterialNomFilter.NoValidate = false;

            beMaterialType.ReadOnly = (OpenMode == OpenMode.Default);
            beMaterial.ReadOnly = (OpenMode == OpenMode.Default);
            beVendor.ReadOnly = (OpenMode == OpenMode.Default);

            _materialTypeButtonEditAssistent = new ButtonEditAssistent<MaterialType, FxMaterialTypes, FxMaterialTypeEdit>(
                beMaterialType, MaterialNomFilter.MaterialType, OnDialogOutput, eButtonsType.All, OpenMode == OpenMode.Default);
            _materialTypeButtonEditAssistent.BindProperty(MaterialNomFilter, x => x.MaterialType);

            _materialButtonEditAssistent = new ButtonEditAssistent<Material, FxMaterials, FxMaterialEdit>(
                beMaterial, MaterialNomFilter.Material, OnDialogOutput, eButtonsType.All, OpenMode == OpenMode.Default);
            _materialButtonEditAssistent.BindProperty(MaterialNomFilter, x => x.Material);  
            _materialButtonEditAssistent.SelectionFormFiltersSetup = () =>
            {
                if (MaterialNomFilter.MaterialType != null)
                {
                    Guid _materialTypeId = MaterialNomFilter.MaterialType.Id;
                    return new FxMaterials
                    {
                        ExternalPostFilterExp = material =>   material.MaterialTypeId == _materialTypeId
                    };
                }
                return new FxMaterials();
            };

            _vendorButtonEditAssistent = new ButtonEditAssistent<Vendor, FxVendors, FxVendorEdit>(
                beVendor, MaterialNomFilter.Vendor, OnDialogOutput, eButtonsType.All, OpenMode == OpenMode.Default);
            _vendorButtonEditAssistent.BindProperty(MaterialNomFilter, x => x.Vendor);
            _vendorButtonEditAssistent.SelectionFormFiltersSetup = () =>
            {
                if (MaterialNomFilter.Material != null)
                {
                    Material _material = MaterialNomFilter.Material;
                    return new FxVendors { ExternalPostFilterExp = vendor => vendor.ContainsMaterial(_material) };
                }
                return new FxVendors();
            };

            _vendorMaterialButtonEditAssistent = new ButtonEditAssistent<VendorMaterialNom, FxVendorMaterialNoms, FxVendorMaterialNomEdit>(
                beVendorMaterialNom, MaterialNom.VendorMaterialNom, OnDialogOutput);
            _vendorMaterialButtonEditAssistent.BindProperty(MaterialNom, x => x.VendorMaterialNom);
            _vendorMaterialButtonEditAssistent.EditorFormFiltersSetup = () =>
                new FxVendorMaterialNomEdit{ VendorFilter = MaterialNom.Vendor, MaterialFilter = MaterialNom.Material };
            _vendorMaterialButtonEditAssistent.SelectionFormFiltersSetup =  () =>               
            {
                FxVendorMaterialNoms fx = new FxVendorMaterialNoms { MaterialNomFilter = this.MaterialNomFilter }; 
                //fx.AddNewItemInstancePreset(v => v.Vendor, MaterialNom.Vendor);
                //fx.AddNewItemInstancePreset(v => v.Material, MaterialNom.Material);
                return fx;             
            };
            //_vendorMaterialButtonEditAssistent.FixedReferences.Add(MaterialNom?.Material);

            _materialSizeTypeButtonEditAssistent = new ButtonEditAssistent<MaterialSizeType, FxMaterialSizeTypeList, FxMaterialSizeTypeEdit>(
                beThickness, MaterialNom.MaterialSizeType, OnDialogOutput);
            _materialSizeTypeButtonEditAssistent.BindProperty(MaterialNom, x => x.MaterialSizeType);
            _materialSizeTypeButtonEditAssistent.EditorFormFiltersSetup = () => 
                new FxMaterialSizeTypeEdit { MaterialMarkType = this.MaterialNom?.VendorMaterialNom?.MaterialMarkType };
            _materialSizeTypeButtonEditAssistent.SelectionFormFiltersSetup = 
                () => new FxMaterialSizeTypeList
                {
                    Material = MaterialNomFilter.Material ?? this.MaterialNom.Material,
                    MaterialMarkType = this.MaterialNom?.VendorMaterialNom?.MaterialMarkType
                };

            switch (OpenMode)
            {
                case OpenMode.NewEntity:
                    SetEnableButtonEdit(beMaterialType, true);
                    SetEnableButtonEdit(beMaterial, MaterialNomFilter.Material != null);
                    SetEnableButtonEdit(beVendor, MaterialNomFilter.Vendor != null);
                    SetEnableButtonEdit(beVendorMaterialNom, MaterialNomFilter.Vendor != null);
                    SetEnableButtonEdit(beThickness, (MaterialNom?.VendorMaterialNom != null));
                    break;
                case OpenMode.Default:
                    //SetEnableButtonEdit(beMaterialType, (MaterialNom?.Material?.MaterialType == null));
                    //SetEnableButtonEdit(beMaterial, (MaterialNom?.Material == null));
                    //SetEnableButtonEdit(beVendor, (MaterialNom?.Vendor == null));
                    //SetEnableButtonEdit(beVendorMaterialNom, (MaterialNom?.VendorMaterialNom == null));
                    //SetEnableButtonEdit(beThickness, true);
                    break;

            }

            _firstLoad = false;
        }

        protected override IEntity GetEntity()
        {
            return MaterialNom;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialNom = value as MaterialNom;
        }

        protected override void BindData()
        {
            base.BindData();
            beVendorMaterialNom.EditValue = MaterialNom.VendorMaterialNom;
            beThickness.EditValue = MaterialNom.MaterialSizeType;
            BindEditor(teCode1C, MaterialNom, x => x.Code1C);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ beVendorMaterialNom, beThickness, teCode1C};
        }

        protected override string GetTitle()
        {
            if (MaterialNomFilter?.MaterialMarkType != null)
                return $"Номенклатура материала: {MaterialNomFilter.Material}";
            if (MaterialNomFilter?.Material != null)
                return $"Номенклатура материала: {MaterialNomFilter.Material}";
            return MaterialNom.Title;
        }

        private void CxMaterialNomTransformationRules_EntityCreating(object sender, EntityCreatingEventArgs e)
        {
            if (e.Entity is MaterialNomTransformationRule entity)
                entity.MaterialNom = MaterialNom;
        }

        private void CxMaterialNomTransformationRules_RefreshingData(object sender, System.EventArgs e)
        {
            cxMaterialNomTransformationRules.MaterialNom = MaterialNom;

        }

        private void beVendorMaterialNom_EditValueChanged(object sender, System.EventArgs e)
        {
            //SetEnableButtonEdit(beVendor, beVendorMaterialNom.EditValue == null);
            if (_firstLoad)
                return;
            MaterialNom.MaterialSizeType = null;
            SetEnableButtonEdit(beThickness, beVendorMaterialNom.EditValue != null);
        }

        private void SetEnableButtonEdit(ButtonEdit buttonEdit, bool state)
        {
            buttonEdit.Enabled = state;
            SetEnableButtons(buttonEdit.Properties.Buttons, state);
        }

        private void SetEnableButtons(EditorButtonCollection propertiesButtons, bool state)
        {
            foreach (EditorButton propertiesButton in propertiesButtons)
            {
                propertiesButton.Enabled = state;
            }
        }

        private void beThickness_EditValueChanged(object sender, System.EventArgs e)
        {
            //SetEnableButtonEdit(beVendorMaterialNom, beThickness.EditValue == null);
        }

        private void beMaterialType_EditValueChanged(object sender, EventArgs e)
        {
            if (_firstLoad)
                return;
            if (_materialButtonEditAssistent != null) // т.е. только уже в работе, а не при загрузке формы (ассистенты - устанавливаются в _Load'-е )
            {
                _materialButtonEditAssistent.SelectionFormFiltersSetup = () =>
                {
                    if (MaterialNomFilter.MaterialType != null)
                    {
                        Guid _materialTypeId = MaterialNomFilter.MaterialType.Id;
                        return new FxMaterials
                        {
                            ExternalPostFilterExp = material => material.MaterialTypeId == _materialTypeId
                        };
                    }
                    return new FxMaterials();
                };
            }

            MaterialNomFilter.Material = null;
            MaterialNomFilter.Vendor = null;
            MaterialNom.VendorMaterialNom = null;
            MaterialNom.MaterialSizeType = null;
            SetEnableButtonEdit(beMaterial, beMaterialType.EditValue != null);    
        }

        private void beMaterial_EditValueChanged(object sender, EventArgs e)
        {
            if (_firstLoad)
                return;
            //SetEnableButtonEdit(beMaterialType, beMaterial.EditValue == null);

            if (_vendorButtonEditAssistent != null)  // т.е. только уже в работе, а не при загрузке формы (ассистенты - устанавливаются в _Load'-е )
            {
                _vendorButtonEditAssistent.SelectionFormFiltersSetup = () =>
                {
                    if (MaterialNomFilter.Material != null)
                    {
                        Material _material = MaterialNomFilter.Material;
                        return new FxVendors { ExternalPostFilterExp = vendor => vendor.ContainsMaterial(_material) };
                    }
                    return new FxVendors();
                };
            }

            MaterialNomFilter.Vendor = null;
            MaterialNom.VendorMaterialNom = null;
            MaterialNom.MaterialSizeType = null;
            SetEnableButtonEdit(beVendor, beMaterial.EditValue != null);
        }

        private void beVendor_EditValueChanged(object sender, EventArgs e)
        {
            if (_firstLoad)
                return;
            //SetEnableButtonEdit(beMaterial, beVendor.EditValue == null);
            MaterialNom.VendorMaterialNom = null;
            MaterialNom.MaterialSizeType = null;
            SetEnableButtonEdit(beVendorMaterialNom, beVendor.EditValue != null);
        }
    }
}