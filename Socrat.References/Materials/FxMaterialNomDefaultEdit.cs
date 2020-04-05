using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomDefaultEdit : FxBaseSimpleDialog
    {
        public MaterialNomDefault MaterialNomDefault { get; set; }
        private ButtonEditAssistent<MaterialNom, FxMaterialNomenclature, FxMaterialNomEdit>
            _materialNomButtonEditAssistent;

        protected override IEntity GetEntity()
        {
            return MaterialNomDefault;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialNomDefault = value as MaterialNomDefault;
        }

        public FxMaterialNomDefaultEdit()
        {
            InitializeComponent();
            Load += FxMaterialNomDefaultEdit_Load;
        }

        protected override void BindData()
        {
            base.BindData();

            lcTitle.DataBindings.Clear();
            lcTitle.DataBindings.Add("Text", MaterialNomDefault, "MaterialTitle", false,
                DataSourceUpdateMode.OnPropertyChanged);

            BindEditor(meDesc, MaterialNomDefault, "Description");
        }

        private void FxMaterialNomDefaultEdit_Load(object sender, System.EventArgs e)
        {
            _materialNomButtonEditAssistent = new ButtonEditAssistent<MaterialNom, FxMaterialNomenclature, FxMaterialNomEdit>(
                beMaterialNom, MaterialNomDefault.MaterialNom, OnDialogOutput);
            _materialNomButtonEditAssistent.BindProperty(MaterialNomDefault, x => x.MaterialNom);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beMaterialNom };
        }
    }
}