using System.Linq;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Formula;
using Socrat.UI.Core;
using Socrat.Common.UI;
using Socrat.Common.Enums;

namespace Socrat.References.Materials
{
    public partial class FxMaterialNomFormulaEdit : FxBaseSimpleDialog  
    {
        public MaterialNomFormula NomFormula { get; set; }

        public MaterialEnum MaterialEnum { get; set; }

        private ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>
            _materialNomButtonEditAssistent;
        //private ButtonEditAssistent<Socrat.Core.Entities.Formula, FxFormulas, FxFormulaEdit>
        //    _formulaButtonEditAssistent;

        public FxMaterialNomFormulaEdit()
        {
            InitializeComponent();
            Load += FxMaterialNomFormulaEdit_Load;
        }

        private void FxMaterialNomFormulaEdit_Load(object sender, System.EventArgs e)
        {
            _materialNomButtonEditAssistent = new ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>(
                beMaterialNom, NomFormula.MaterialNom, OnDialogOutput);
            _materialNomButtonEditAssistent.BindProperty(NomFormula, x =>x.MaterialNom);
            _materialNomButtonEditAssistent.SelectionFormFiltersSetup = () =>
            {
                return new FxFilteredMaterialNoms
                {
                    Material = DataHelper.GetAll<Material>().FirstOrDefault(x => x.MaterialEnum == MaterialEnum.Triplex)
                };
            };

            //_formulaButtonEditAssistent = new ButtonEditAssistent<Core.Entities.Formula, FxFormulas, FxFormulaEdit>(
            //    beFormula, NomFormula.Formula, OnDialogOutput, eButtonsType.Search);
            //_formulaButtonEditAssistent.BindProperty(NomFormula, x => x.Formula);
            //_formulaButtonEditAssistent.EditorFormFiltersSetup = () =>
            //{
            //        return new FxFormulaEdit { ProductionType = ProductionType.Triplex };
            //};
            beFormula.EditValue = NomFormula?.Formula?.FormulaStr;
            UpdateClearButtonVisible();
            meDesc.Text = NomFormula.Description;
        }

        protected override IEntity GetEntity()
        {
            return NomFormula;
        }

        protected override void SetEntity(IEntity value)
        {
            NomFormula = value as MaterialNomFormula;
        }

        private void beFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Search:
                    bool isNew = false;
                    if (NomFormula.Formula == null)
                    {
                        NomFormula.Formula = FormulaParser.GetDefaultTriplex();
                        NomFormula.Formula.Loaded = true;
                        NomFormula.Formula.Changed = true;
                        isNew = true;
                    }
                    FxFormulaEdit _fxe = new FxFormulaEdit();
                    _fxe.Formula = NomFormula.Formula;
                    _fxe.DialogOutput += FxeOnDialogOutput;
                    _fxe.ProductionType = ProductionTypes.Triplex;
                    OnDialogOutput(_fxe, DialogOutputType.Dialog);
                    _fxe.RevertFormula += (o, args) =>
                    {
                        if (!isNew)
                        {
                            //DataHelper.Revert2<Core.Entities.Formula>(NomFormula.Formula);
                            DataHelper.RevertEx(NomFormula.Formula);
                            beFormula.EditValue = NomFormula?.Formula?.FormulaStr;
                        }
                        else
                        {
                            NomFormula.Formula = null;
                            beFormula.EditValue = null;
                        }
                        UpdateClearButtonVisible();
                    };
                    _fxe.SaveButtonClick += delegate(object o, CancelExtEventArgs args)
                    {
                        beFormula.EditValue = NomFormula?.Formula?.FormulaStr;
                        UpdateClearButtonVisible();

                        if (NomFormula != null)
                            NomFormula.Changed = true;
                    };
                    break;
                case ButtonPredefines.Clear:
                    NomFormula.Formula = null;
                    beFormula.EditValue = null;
                    UpdateClearButtonVisible();
                    break;
            }
        }

        private void UpdateClearButtonVisible()
        {
            beFormula.Properties.Buttons
                    .FirstOrDefault(x => x.Kind == ButtonPredefines.Clear)
                    .Visible = NomFormula.Formula != null;
            beFormula.Refresh();
        }

        private void FxeOnDialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        private void meDesc_EditValueChanged(object sender, System.EventArgs e)
        {
            NomFormula.Description = meDesc.Text;
        }
    }
}
