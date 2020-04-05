using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.DataProvider;
using Socrat.Lib.Interfaces;
using Socrat.References.Params;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxContracts : FxBaseForm, ISelectionDialogFilterable<Core.Entities.Contract>
    {
        private CxContracts cxContracts;
        private List<Core.Entities.Division> _divisions;
        private IRepository<Core.Entities.Contract> _contractRepo;
        private IEntity _selectedItem;

        public FxContracts()
        {
            InitializeComponent();

            cxContracts = new CxContracts();
            cxContracts.DialogOutput += (sender, ta) => OnDialogOutput(ta);
            cxContracts.ItemSelected += CxContracts_ItemSelected;
            pcList.Controls.Add(cxContracts);
            cxContracts.Dock = DockStyle.Fill;
            tabPane.SelectedPageIndex = 0;
            Load += FxContracts_Load;
        }

        private void CxContracts_ItemSelected(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(sender, e);
        }

        private void FxContracts_Load(object sender, EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<Core.Entities.Division> _repo = _factory.CreateRepository<IRepository<Core.Entities.Division>>();
                _divisions = _repo.GetAll().ToList();

                _contractRepo = _factory.CreateRepository<IRepository<Core.Entities.Contract>>();
            }

            Guid _divisionId;
            Guid.TryParse(AppParams.Params[ParamAlias.CurrentDivision], out _divisionId);
            cxContracts.Division = _divisions.FirstOrDefault(x => x.Id == _divisionId);
            cxContracts.Contracts = new ObservableCollection<Core.Entities.Contract>(_contractRepo.GetAll());
        }

        protected override string GetTitle()
        {
            return "Справочник договоров";
        }

        private void tabPane_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            switch (tabPane.Pages.IndexOf(e.Page))
            {
                case 0:
                    cxContracts.Filter.FilterType = ContractFilterType.All;
                    break;
                case 1:
                    cxContracts.Filter.FilterType = ContractFilterType.Supplay;
                    break;
                case 2:
                    cxContracts.Filter.FilterType = ContractFilterType.Customer;
                    break;
            }
            cxContracts.UpdateData();
        }

        public event EventHandler ItemSelected;

        public IEntity SelectedItem
        {
            get => cxContracts.SelectedItem;
            set => cxContracts.SelectedItem = value;
        }

        public void SetSingleSelectMode(IEntity selectedItem)
        {
            cxContracts.SetSingleSelectMode(selectedItem as Core.Entities.Contract);
        }

        public Expression<Func<Core.Entities.Contract, bool>> ExternalFilterExp
        {
            get => cxContracts.ExternalFilterExp;
            set
            {
                cxContracts.ExternalFilterExp = value;
                cxContracts.RefreshData();
            }
        }
    }
}