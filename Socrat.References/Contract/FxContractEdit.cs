using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.DataProvider;

using Socrat.References.Contact;
using Socrat.References.Customer;
using Socrat.References.Division;
using Socrat.UI.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Contract
{
    public partial class FxContractEdit : FxBaseSimpleDialog
    {
        private Core.Entities.Contract _contract;
        private List<Core.Entities.Division> _divisions;
        private CxContractShippingSquares _contractShippingSquares;
        private CxContractTenderFormulas _cxContractTenderFormulas;
        private CxContractAddresses _cxContractAddresses;
        private CxAgreements _cxAgreements;
        private CxContractPrices _cxContractPrices;
        private PopupMenu popupMenu;
        private BarButtonItem biPrintContract, biPrintPrice, biPrintAddContracts;

        public Core.Entities.Customer Customer { get; set; }
        public Core.Entities.Division Division { get; set; }

        public bool CustomerFixed { get; set; }
        public bool DivisionFixed { get; set; }

        public Core.Entities.Contract Contract
        {
            get { return _contract; }
            set { SetContract(value); }
        }

        private void SetContract(Core.Entities.Contract value)
        {
            _contract = value;

            if (_contract.ContractType != null && _contract.ContractType.Enum == ContractTypeEnum.TenderCustomer)
            {
                lcgPrice.Visibility = LayoutVisibility.Never;
                lcgTender.Visibility = LayoutVisibility.Always;
                InitTenderFormula();
            }
            else
            {
                lcgTender.Visibility = LayoutVisibility.Never;
                lcgPrice.Visibility = LayoutVisibility.Always;
                InitContractShippingSquare();;
            }

            InitAddresses();
            InitAgreements();
            InitPrice();
        }

        private void InitPrice()
        {
            _cxContractPrices = new CxContractPrices();
            _cxContractPrices.DependedSaving = true;
            _cxContractPrices.Contract = this.Contract;
            _cxContractPrices.DialogOutput += _cxContractPrices_DialogOutput;
            pcPrice.Controls.Add(_cxContractPrices);
            _cxContractPrices.Dock = DockStyle.Fill;
        }

        private void _cxContractPrices_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        public FxContractEdit()
        {
            InitializeComponent();

            CustomerFixed = false;

            tabbedControlGroup1.SelectedTabPageIndex = 0;
            tcgPrices.SelectedTabPageIndex = 0;
            Load += CxContracts_Load;
            InitPrintButton();

            beCustomer.Enabled = !CustomerFixed;
            beDivision.Enabled = !DivisionFixed;
        }

        public FxContractEdit(Core.Entities.Contract contract) : this()
        {
            SetContract(contract);
        }

        public FxContractEdit(bool customerFixed = false)
        {
            InitializeComponent();

            CustomerFixed = customerFixed;

            tabbedControlGroup1.SelectedTabPageIndex = 0;
            tcgPrices.SelectedTabPageIndex = 0;
            Load += CxContracts_Load;
            InitPrintButton();

            beCustomer.Enabled = !CustomerFixed;
            beDivision.Enabled = !DivisionFixed;
        }

        private void InitPrintButton()
        {
            popupMenu = new PopupMenu(this.components);
            popupMenu.Manager = barManager;

            biPrintContract = new BarButtonItem();
            barManager.Items.Add(biPrintContract);
            biPrintContract.Caption = "Типовой договор";
            biPrintContract.ItemClick += BiPrintContract_ItemClick;
           
            biPrintPrice = new BarButtonItem();
            barManager.Items.Add(biPrintPrice);
            biPrintPrice.Caption = "Прайс";
            biPrintPrice.ItemClick += BiPrintPrice_ItemClick;
            

            biPrintAddContracts = new BarButtonItem();
            barManager.Items.Add(biPrintAddContracts);
            biPrintAddContracts.Caption = "Список допсоглашений";
            biPrintAddContracts.ItemClick += BiPrintAddContracts_ItemClick;
            

            DropDownButton btnPrint = new DropDownButton();
            btnPrint.Text = "Распечатать";
            btnPrint.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter;
            btnPrint.ImageOptions.Image = Properties.Resources.print_16x16;

            popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
                new DevExpress.XtraBars.LinkPersistInfo(this.biPrintContract),
                new DevExpress.XtraBars.LinkPersistInfo(this.biPrintPrice),
                new DevExpress.XtraBars.LinkPersistInfo(this.biPrintAddContracts)});

            btnPrint.DropDownControl = popupMenu;
            AddPrintButton(btnPrint);
        }

        private void BiPrintAddContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            //todo: Список допсоглашений
        }

        private void BiPrintPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            //todo: Распечатка прайса
        }

        private void BiPrintContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            //todo: Распечатка типового договора
        }

        private void InitAgreements()
        {
            _cxAgreements = new CxAgreements();
            pcAgreements.Controls.Add(_cxAgreements);
            _cxAgreements.Dock = DockStyle.Fill;
            _cxAgreements.Contract = Contract;
        }

        private void CxContracts_Load(object sender, EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<Core.Entities.Division> _repo = _factory.CreateRepository<IRepository<Core.Entities.Division>>();
                if (Customer == null)
                    _divisions = _repo.GetAll().ToList();
                else
                {
                    _divisions = _repo.GetAll(
                        x => x.DivisionCustomers.Count(c => c.CustomerId == Customer.Id) > 0).ToList();
                    if (_divisions != null && _divisions.Count == 1 && Contract.Division == null)
                    {
                        beDivision.EditValue = _divisions.First();
                    }

                }
            }

            if (Customer != null)
            {
                Contract.Customer = Customer;
                beCustomer.EditValue = Customer;
                beCustomer.Enabled = false;
            }

            if (Division != null)
            {
                Contract.Division = Division;
                beDivision.EditValue = Division;
                beDivision.Enabled = false;
            }

            ceSpec.Checked = Contract.Spec ?? false;
            cbeConfirm.SelectedIndex = Contract.Confirmed ?? false ? 1 : 0;
        }

        protected override IEntity GetEntity()
        {
            return Contract;
        }

        protected override void SetEntity(IEntity value)
        {
            Contract = value as Core.Entities.Contract;
        }

        protected override void BindData()
        {
            base.BindData();

            this.DataBindings.Clear();
            this.DataBindings.Add("Text", Contract, "Title", true, DataSourceUpdateMode.OnPropertyChanged);

            BindEditor(teNum, Contract, "Num");
            BindEditor(teComment, Contract, "Comment");
            BindEditor(deBegin, Contract, "DateBegin");
            BindEditor(deEnd, Contract, "DateEnd");
            BindEditor(beDivision, Contract, "Division");
            BindEditor(beManager, Contract, "Coworker");
            BindEditor(beCustomer, Contract, "Customer");
            BindEditor(ceDefault, Contract, x => x.Default);
        }

        private void beDivision_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                int _tag;
                int.TryParse(e.Button.Tag.ToString(), out _tag);
                switch (_tag)
                {
                    case 0:
                        FxDivisions _fx = new FxDivisions();
                        _fx.SetSingleSelectMode(Contract.Division);
                        _fx.ItemSelected += (o, args) =>
                        {
                            Core.Entities.Customer _customer = Contract.Customer;
                            Contract.Division = (Core.Entities.Division) _fx.SelectedItem;
                            Contract.Customer = _customer;
                            beDivision.EditValue = Contract.Division;
                            beCustomer.EditValue = Contract.Customer;
                        };
                        _fx.DialogOutput += (o, ta) => { OnDialogOutput(ta); };
                        OnDialogOutput(_fx, DialogOutputType.Dialog, this);
                        break;
                    case 1:
                        if (Contract.Division != null)
                        {
                            FxDivisionEdit _fxe = new FxDivisionEdit();
                            _fxe.Division = Contract.Division;
                            _fxe.DialogOutput += (o, ta) => { OnDialogOutput(ta); };
                            OnDialogOutput(_fxe, DialogOutputType.Dialog, this);
                        }
                        break;
                }
            }
        }

        private void beManager_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && Contract.Division != null)
            {
                int _tag;
                int.TryParse(e.Button.Tag.ToString(), out _tag);
                switch (_tag)
                {
                    case 0:
                        FxEntitySelector _fx = new FxEntitySelector("Сотрудники подразделения");
                        CxDivisionCoworkers _divisionCoworkers = new CxDivisionCoworkers();
                        _divisionCoworkers.SetSingleSelectMode(null);
                        _divisionCoworkers.Division = Contract.Division;
                        _fx.TableLictControlHost = _divisionCoworkers;
                        ((ITabable) _fx).DialogOutput += (o, ta) => OnDialogOutput(ta);
                        _fx.ItemSelected += (o, args) =>
                        {
                            Contract.Coworker = ((Core.Entities.CoworkerPosition) _fx.SelectedItem).Coworker;
                            beManager.EditValue = Contract.Coworker;
                        };
                        OnDialogOutput(_fx, DialogOutputType.Dialog, this);
                        break;
                    case 1:
                        if (Contract.Coworker != null)
                        {
                            FxCoworkerEdit _fxe = new FxCoworkerEdit();
                            _fxe.Coworker = Contract.Coworker;
                            _fxe.DialogOutput += (o, ta) => OnDialogOutput(ta);
                            OnDialogOutput(_fxe, DialogOutputType.Dialog, this);
                        }
                        break;
                }
            }
        }

        private void beCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && Contract.Division != null)
            {
                int _tag;
                int.TryParse(e.Button.Tag.ToString(), out _tag);
                switch (_tag)
                {
                    case 0:
                        //FxEntitySelector _fx = new FxEntitySelector("Заказчики подразделения");
                        //_fx.ClientSize =new Size(800, 600);
                        //CxDivisionCustomers _divisionCustomers = new CxDivisionCustomers();
                        //_divisionCustomers.SetSingleSelectMode(null);
                        //_divisionCustomers.Division = Contract.Division;
                        //_fx.TableLictControlHost = _divisionCustomers;
                        //((ITabable)_fx).DialogOutput += (o, ta) => OnDialogOutput(ta);
                        //_fx.ItemSelected += (o, args) => Contract.Customer = ((Core.Entities.DivisionCustomer)_fx.SelectedItem).Customer;
                        FxCustomers _fx = new FxCustomers();
                        _fx.SetSingleSelectMode(Contract.Customer);
                        ((ITabable)_fx).DialogOutput += (o, ta) => OnDialogOutput(ta);
                        _fx.ItemSelected += (o, args) =>
                        {
                            Contract.Customer = _fx.SelectedItem as Core.Entities.Customer;
                            beCustomer.EditValue = Contract.Customer;
                        };
                        OnDialogOutput(_fx, DialogOutputType.Dialog, this);
                        break;
                    case 1:
                        if (Contract.Customer != null)
                        {
                            FxCustomerEdit _fxe = new FxCustomerEdit();
                            _fxe.Customer = Contract.Customer;
                            _fxe.DialogOutput += (o, ta) => OnDialogOutput(ta);
                            OnDialogOutput(_fxe, DialogOutputType.Dialog, this);
                        }
                        break;
                }
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ teNum, beDivision , deBegin, deEnd, beManager, beCustomer};
        }

        private void ceSpec_CheckedChanged(object sender, EventArgs e)
        {
            Contract.Spec = ceSpec.Checked;
        }

        private void cbeConfirm_EditValueChanged(object sender, EventArgs e)
        {
            if (cbeConfirm.EditValue != null)
            {
                int _num;
                int.TryParse(cbeConfirm.EditValue.ToString(), out _num);
                Contract.Confirmed = (_num == 1);
            }
        }


        private void cbeConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbeConfirm.SelectedIndex > -1)
            {
                Contract.Confirmed = cbeConfirm.SelectedIndex > 0;
            }
        }

        private void InitContractShippingSquare()
        {
            _contractShippingSquares = new CxContractShippingSquares();
            _contractShippingSquares.DependedSaving = true;
            _contractShippingSquares.Contract = this.Contract;
            pcContractShippingSquare.Controls.Add(_contractShippingSquares);
            _contractShippingSquares.Dock = DockStyle.Fill;
            _contractShippingSquares.DialogOutput += (sender, ta) => OnDialogOutput(ta);
        }

        private void deBegin_EditValueChanged(object sender, EventArgs e)
        {
            deEnd.Properties.MinValue = deBegin.DateTime.AddDays(1);
        }

        private void deEnd_EditValueChanged(object sender, EventArgs e)
        {
            deBegin.Properties.MaxValue = deEnd.DateTime;
        }

        private void InitTenderFormula()
        {
            _cxContractTenderFormulas = new CxContractTenderFormulas();
            _cxContractTenderFormulas.DependedSaving = true;
            _cxContractTenderFormulas.Contract = this.Contract;
            pcTender.Controls.Add(_cxContractTenderFormulas);
            _cxContractTenderFormulas.Dock = DockStyle.Fill;
            _cxContractTenderFormulas.DialogOutput += (sender, ta) => OnDialogOutput(ta);
        }

        private void InitAddresses()
        {
            _cxContractAddresses = new CxContractAddresses();
            _cxContractAddresses.DependedSaving = true;
            _cxContractAddresses.Contract = this.Contract;
            pcAddtress.Controls.Add(_cxContractAddresses);
            _cxContractAddresses.Dock = DockStyle.Fill;
            _cxContractAddresses.DialogOutput += (sender, ta) => OnDialogOutput(ta);
        }
    }
}