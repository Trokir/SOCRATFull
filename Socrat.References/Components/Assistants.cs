using Socrat.UI.Core;
using System;
using DevExpress.XtraEditors;
using Socrat.Common.UI;
using Socrat.References.Division;
using Socrat.References.Customer;
using Socrat.References.Materials;
using Socrat.References.Processings;
using Socrat.References.Bank;
using Socrat.References.Contract;
using Socrat.References.Contact;
using Socrat.References.Common;

namespace Socrat.References.Components
{

    #region Division related assists

    public class DivisionButtonEditAssistant 
        : ButtonEditAssistent<Core.Entities.Division, FxGenericListTable2<Core.Entities.Division>, FxDivisionEdit>
    {
        public DivisionButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Division entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class DivisionContactButtonEditAssistant : ButtonEditAssistent<Core.Entities.DivisionContact, FxGenericListTable2<Core.Entities.DivisionContact>, FxDivisionContactEdit>
    {
        public DivisionContactButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.DivisionContact entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class DivisionCustomerButtonEditAssistant : ButtonEditAssistent<Core.Entities.DivisionCustomer, FxGenericListTable2<Core.Entities.DivisionCustomer>, FxDivisionCustomerEdit>
    {
        public DivisionCustomerButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.DivisionCustomer entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class DivisionSignatureButtonEditAssistant : ButtonEditAssistent<Core.Entities.DivisionSignature, FxGenericListTable2<Core.Entities.DivisionSignature>, FxDivisionSignatureEdit>
    {
        public DivisionSignatureButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.DivisionSignature entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    #endregion

    public class CustomerButtonEditAssistant
        : ButtonEditAssistent<Core.Entities.Customer, FxGenericListTable2<Core.Entities.Customer>, FxCustomerEdit>
    {
        public CustomerButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Customer entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class MeasureButtonEditAssistant : ButtonEditAssistent<Core.Entities.Measure, FxGenericListTable2<Core.Entities.Measure>, FxMeasureEdit>
    {
        public MeasureButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Measure entity, 
            Action<WindowOutputEventArgs> onDialogOutput, 
            eButtonsType buttonsType = eButtonsType.All, 
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class BankButtonEditAssistant : ButtonEditAssistent<Core.Entities.Bank, FxGenericListTable2<Core.Entities.Bank>, FxBankEdit>
    {
        public BankButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Bank entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class ContactTypeButtonEditAssistant : ButtonEditAssistent<Core.Entities.ContactType, FxGenericListTable2<Core.Entities.ContactType>, FxContactTypeEdit>
    {
        public ContactTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.ContactType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class ContractButtonEditAssistant : ButtonEditAssistent<Core.Entities.Contract, FxGenericListTable2<Core.Entities.Contract>, FxContractEdit>
    {
        public ContractButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Contract entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class ContractTypeButtonEditAssistant : ButtonEditAssistent<Core.Entities.ContractType, FxGenericListTable2<Core.Entities.ContractType>, FxNamedEntityEdit>
    {
        public ContractTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.ContractType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class CountryButtonEditAssistant : ButtonEditAssistent<Core.Entities.Country, FxGenericListTable2<Core.Entities.Country>, FxCountryEdit>
    {
        public CountryButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Country entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class CoworkerButtonEditAssistant : ButtonEditAssistent<Core.Entities.Coworker, FxGenericListTable2<Core.Entities.Coworker>, Customer.FxCoworkerEdit>
    {
        public CoworkerButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Coworker entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class CoworkerPositionButtonEditAssistant : ButtonEditAssistent<Core.Entities.CoworkerPosition, FxGenericListTable2<Core.Entities.CoworkerPosition>, FxCoworkerPositionEdit>
    {
        public CoworkerPositionButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.CoworkerPosition entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class CurrencyButtonEditAssistant : ButtonEditAssistent<Core.Entities.Currency, FxGenericListTable2<Core.Entities.Currency>, FxCurrencyEdit>
    {
        public CurrencyButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Currency entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class DepartmentTypeButtonEditAssistant : ButtonEditAssistent<Core.Entities.DepartmentType, FxGenericListTable2<Core.Entities.DepartmentType>, FxDepartmentTypeEdit>
    {
        public DepartmentTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.DepartmentType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }


    #region Material related assysts

    public class MaterialTypeButtonEditAssistant
        : ButtonEditAssistent<Core.Entities.MaterialType, FxGenericListTable2<Core.Entities.MaterialType>, FxMaterialTypeEdit>
    {
        public MaterialTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.MaterialType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class MaterialButtonEditAssistant
        : ButtonEditAssistent<Core.Entities.Material, FxGenericListTable2<Core.Entities.Material>, FxMaterialEdit>
    {
        public MaterialButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Material entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class MaterialNomButtonEditAssistant
        : ButtonEditAssistent<Core.Entities.MaterialNom, FxGenericListTable2<Core.Entities.MaterialNom>, FxMaterialNomEdit>
    {
        public MaterialNomButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.MaterialNom entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class MaterialSizeTypeButtonEditAssistant
        : ButtonEditAssistent<Core.Entities.MaterialSizeType, FxGenericListTable2<Core.Entities.MaterialSizeType>, FxMaterialSizeTypeEdit>
    {
        public MaterialSizeTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.MaterialSizeType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class MaterialMarkTypeButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.MaterialMarkType, FxGenericListTable2<Core.Entities.MaterialMarkType>, FxMaterialMarkTypeEdit>
    {
        public MaterialMarkTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.MaterialMarkType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class BrandButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.Brand, FxGenericListTable2<Core.Entities.Brand>, FxBrandEdit>
    {
        public BrandButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Brand entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class VendorButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.Vendor, FxGenericListTable2<Core.Entities.Vendor>, FxVendorEdit>
    {
        public VendorButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Vendor entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class TradeMarkButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.TradeMark, FxGenericListTable2<Core.Entities.TradeMark>, FxTradeMarkEdit>
    {
        public TradeMarkButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.TradeMark entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class VendorMaterialNomButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.VendorMaterialNom, FxGenericListTable2<Core.Entities.VendorMaterialNom>, FxVendorMaterialNomEdit>
    {
        public VendorMaterialNomButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.VendorMaterialNom entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class VendorMaterialButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.VendorMaterial, FxGenericListTable2<Core.Entities.VendorMaterial>, FxVendorMaterialEdit>
    {
        public VendorMaterialButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.VendorMaterial entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    #endregion

    #region Processing related assysts

    public class ProcessingButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.Processing, FxGenericListTable2<Core.Entities.Processing>, Processings.FxProcessingEdit>
    {
        public ProcessingButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.Processing entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class ProcessingNomButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.ProcessingNom, FxGenericListTable2<Core.Entities.ProcessingNom>, FxProcessingNomEdit>
    {
        public ProcessingNomButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.ProcessingNom entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

    public class ProcessingTypeButtonEditAssistant
       : ButtonEditAssistent<Core.Entities.ProcessingType, FxGenericListTable2<Core.Entities.ProcessingType>, FxProcessingTypeEdit>
    {
        public ProcessingTypeButtonEditAssistant(
            ButtonEdit editor,
            Core.Entities.ProcessingType entity,
            Action<WindowOutputEventArgs> onDialogOutput,
            eButtonsType buttonsType = eButtonsType.All,
            bool readOnly = false)
            : base(editor, entity, onDialogOutput, buttonsType, readOnly)
        {

        }
    }

   

    #endregion
}
