using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Common.Enums;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Core.Helpers;
using Socrat.References.Formula;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxCustomerMaterialNomEquivalentEdit : FxBaseSimpleDialog
    {
        public CustomerMaterialNomEquivalent CustomerMaterialNomEquivalent { get; set; }

        private ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>
            _materialNomButtonEditAssistent;

        public FxCustomerMaterialNomEquivalentEdit()
        {
            InitializeComponent();
            Load += FxCustomerMaterialNomEquivalentEdit_Load;
        }

        private void FxCustomerMaterialNomEquivalentEdit_Load(object sender, EventArgs e)
        {
            _materialNomButtonEditAssistent = new ButtonEditAssistent<MaterialNom, FxFilteredMaterialNoms, FxMaterialNomEdit>(
                beNom, CustomerMaterialNomEquivalent.MaterialNom, OnDialogOutput);
            _materialNomButtonEditAssistent.BindProperty(CustomerMaterialNomEquivalent, x => x.MaterialNom);
            _materialNomButtonEditAssistent.SelectionFormFiltersSetup = () =>
            {
                //return new FxFilteredMaterialNoms { Material = FormulaParser.GetMaterialByEnum(MaterialEnum)};
                return new FxFilteredMaterialNoms { ExternalPostFilterExp = nom => nom.Material != null 
                                                        && MaterialEnums.Contains(nom.Material.MaterialEnum) };
            };

            beNom.Properties.UseReadOnlyAppearance = false;
            beNom.ReadOnly = true;
            teCode.Properties.UseReadOnlyAppearance = false;
            teCode.ReadOnly = true;
        }

        public MaterialEnum[] MaterialEnums { get; set; }

        protected override IEntity GetEntity()
        {
            return CustomerMaterialNomEquivalent;
        }

        protected override void SetEntity(IEntity value)
        {
            CustomerMaterialNomEquivalent = value as CustomerMaterialNomEquivalent;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teCode, CustomerMaterialNomEquivalent, "NomCode");
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teCode, beNom};
        }

        private string _titleMats = null;
        protected override string GetTitle()
        {
            if (_titleMats == null)
            {
                List<string> _matNames = new AttachedList<string>();
                if (MaterialEnums != null)
                {
                    foreach (MaterialEnum materialEnum in MaterialEnums)
                        _matNames.Add(EnumHelper<MaterialEnum>.GetName(materialEnum));
                    _titleMats = String.Join("/", _matNames);
                }
                else
                {
                    if (CustomerMaterialNomEquivalent?.MaterialNom?.Material != null)
                    {
                        _titleMats =
                            EnumHelper<MaterialEnum>.GetName(CustomerMaterialNomEquivalent.MaterialNom.Material
                                .MaterialEnum);
                    }
                }
            }

            return $"Сопоставление. {_titleMats} с кодом '{CustomerMaterialNomEquivalent?.NomCode}'";
        }
    }
}