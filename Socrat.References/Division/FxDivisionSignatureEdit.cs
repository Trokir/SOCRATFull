using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Customer;
using Socrat.References.Document;
using Socrat.UI.Core;
using DivisionCustomer = Socrat.Core.Entities.DivisionCustomer;
using DivisionSignature = Socrat.Core.Entities.DivisionSignature;
using DocumentSignatureType = Socrat.Core.Entities.DocumentSignatureType;
using DocumentType = Socrat.Core.Entities.DocumentType;

namespace Socrat.References.Division
{
    public partial class FxDivisionSignatureEdit : FxBaseSimpleDialog
    {
        public DivisionSignature DivisionSignature { get; set; }
        private List<DocumentSignatureType> _documentSignatureTypes;

        public FxDivisionSignatureEdit()
        {
            InitializeComponent();
            Load += FxDivisionSignatureEdit_Load;
        }

        private void FxDivisionSignatureEdit_Load(object sender, System.EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                var _repo = _factory.CreateRepository<Socrat.Core.IRepository<DocumentSignatureType>>();
                _documentSignatureTypes = _repo.GetAll().ToList();
                lueSignatureType.Properties.DataSource = null;
                lueSignatureType.Properties.DataSource = _documentSignatureTypes;
            }
        }

        protected override IEntity GetEntity()
        {
            return DivisionSignature;
        }

        protected override void SetEntity(IEntity value)
        {
            DivisionSignature = value as DivisionSignature;
        }

        private void beCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int _tag;
            if (int.TryParse(e.Button?.Tag?.ToString(), out _tag))
            {
                switch (_tag)
                {
                    case 1:
                        SelectCustomer();
                        break;
                    case 2:
                        OpenCustomer();
                        break;
                }
            }
        }

        private void OpenCustomer()
        {
            Core.Entities.Customer _Customer = beCustomer.EditValue as Core.Entities.Customer;
            if (_Customer != null)
            {
                FxCustomerEdit _fx = new FxCustomerEdit();
                _fx.Customer = _Customer;
                _fx.DialogOutput += (sender, ta) =>
                {
                    OnDialogOutput(ta);
                };
                OnDialogOutput(_fx, DialogOutputType.Dialog, this);
            }
        }

        private void SelectCustomer()
        {
            FxEntitySelector _entitySelector = new FxEntitySelector("Подписи");
            CxDivisionCustomers _cxDivisionSignatures = new CxDivisionCustomers();
            _cxDivisionSignatures.Division = DivisionSignature.Division;
            _cxDivisionSignatures.SetSingleSelectMode(null);
            _entitySelector.TableLictControlHost = _cxDivisionSignatures;

            ((ITabable)_entitySelector).DialogOutput += (sender, ta) =>
           {
               OnDialogOutput(ta);
           };

            _entitySelector.ItemSelected += (sender, args) =>
            {
                beCustomer.EditValue = _entitySelector.SelectedItem;
                DivisionSignature.Customer = ((DivisionCustomer)_entitySelector.SelectedItem).Customer;
                _entitySelector.Close();
            };

            OnDialogOutput(_entitySelector, Socrat.Core.DialogOutputType.Dialog, this);
        }


        private void beDocType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int _tag;
            if (int.TryParse(e.Button?.Tag?.ToString(), out _tag))
            {
                switch (_tag)
                {
                    case 1:
                        SelectDocType();
                        break;
                    case 2:
                        OpenDocType();
                        break;
                }
            }
        }

        private void OpenDocType()
        {
            DocumentType _documentType = beDocType.EditValue as DocumentType;
            if (_documentType != null)
            {
                FxDocumentTypeEdit _fx = new FxDocumentTypeEdit();
                _fx.DocumentType = _documentType;
                OnDialogOutput(_fx, Socrat.Core.DialogOutputType.Dialog, this);
            }
            
        }

        private void SelectDocType()
        {
            FxDocumentTypes _fx = new FxDocumentTypes();
            _fx.SetSingleSelectMode(DivisionSignature.DocumentType);
            _fx.ItemSelected += (sender, args) =>
            {
                DivisionSignature.DocumentType = _fx.SelectedItem as DocumentType;
                beDocType.EditValue = _fx.SelectedItem;
            };
            _fx.DialogOutput += (sender, ta) =>
            {
                OnDialogOutput(ta);
            };
            OnDialogOutput(_fx, Socrat.Core.DialogOutputType.Dialog, this);
        }

        private void beCoworker_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int _tag;
            if (int.TryParse(e.Button?.Tag?.ToString(), out _tag))
            {
                switch (_tag)
                {
                    case 1:
                        SelectCoworker();
                        break;
                    case 2:
                        OpenCoworker();
                        break;
                }
            }
        }

        private void OpenCoworker()
        {
            Coworker _coworker = beCoworker.EditValue as Coworker;
            if (_coworker != null)
            {
                FxCoworkerEdit _fx = new FxCoworkerEdit();
                _fx.Coworker = _coworker;
                OnDialogOutput(_fx, DialogOutputType.Dialog, this);
            }
        }

        private void SelectCoworker()
        {
            FxEntitySelector _entitySelector = new FxEntitySelector("Сотрудники");
            CxDivisionCoworkers _cxDivisionCoworkers = new CxDivisionCoworkers();
            _cxDivisionCoworkers.Division = DivisionSignature.Division;
            _cxDivisionCoworkers.SetSingleSelectMode(null);
            _entitySelector.TableLictControlHost = _cxDivisionCoworkers;

            ((ITabable)_entitySelector).DialogOutput += (sender, ta) =>
            {
                OnDialogOutput(ta);
            };

            _entitySelector.ItemSelected += (sender, args) =>
            {
                beCoworker.EditValue = _entitySelector.SelectedItem;
                DivisionSignature.Coworker = ((CoworkerPosition)_entitySelector.SelectedItem).Coworker;
                _entitySelector.Close();
            };

            OnDialogOutput(_entitySelector, DialogOutputType.Dialog, this);
        }

        protected override void BindData()
        {
            base.BindData();
            lcDivision.DataBindings.Clear();
            lcDivision.DataBindings.Add("Text", DivisionSignature.Division, "AliasName", true, DataSourceUpdateMode.OnPropertyChanged);
            beCustomer.DataBindings.Clear();
            beCustomer.DataBindings.Add("EditValue", DivisionSignature, "Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            beDocType.DataBindings.Clear();
            beDocType.DataBindings.Add("EditValue", DivisionSignature, "DocumentType", true, DataSourceUpdateMode.OnPropertyChanged);
            beCoworker.DataBindings.Clear();
            beCoworker.DataBindings.Add("EditValue", DivisionSignature, "Coworker", true, DataSourceUpdateMode.OnPropertyChanged);
            teDocBase.DataBindings.Clear();
            teDocBase.DataBindings.Add("EditValue", DivisionSignature, "DocBasics", true, DataSourceUpdateMode.OnPropertyChanged);
            teDocPosition.DataBindings.Clear();
            teDocPosition.DataBindings.Add("EditValue", DivisionSignature, "DocCoworkerPosition", true, DataSourceUpdateMode.OnPropertyChanged);

            lueSignatureType.EditValue = DivisionSignature?.DocumentSignatureType?.Id;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beCustomer, beDocType, lueSignatureType, beCoworker, teDocBase, teDocPosition};
        }

        private void lueSignatureType_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (_documentSignatureTypes != null 
                && lueSignatureType.EditValue != null 
                && Guid.TryParse(lueSignatureType.EditValue.ToString(), out _id))
            {
                DivisionSignature.DocumentSignatureType = _documentSignatureTypes.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}