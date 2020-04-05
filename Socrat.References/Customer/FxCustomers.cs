using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Lib.Interfaces;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class FxCustomers : FxBaseForm, ISelectionDialogFilterable<Core.Entities.Customer>
    {
        public event EventHandler ItemSelected;

        public FxCustomers()
        {
            InitializeComponent();
            _cxRefCustomers.SelectItemEvent += _cxRefCustomers_SelectItemEvent;
            _cxRefCustomers.DialogOutput += _cxRefCustomers_DialogOutput;
        }

        private void _cxRefCustomers_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        private void _cxRefCustomers_SelectItemEvent(object sender, ListItemEventArgs e)
        {
            OnItemSelected();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tabPane_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane.SelectedPage == tpAll)
                _cxRefCustomers.FilterPreset = FilterPreset.All;
            else if (tabPane.SelectedPage == tpLegals)
                _cxRefCustomers.FilterPreset = FilterPreset.Legal;
            else if (tabPane.SelectedPage == tpIP)
                _cxRefCustomers.FilterPreset = FilterPreset.IP;
            else
                _cxRefCustomers.FilterPreset = FilterPreset.All;
        }

        public IEntity SelectedItem
        {
            get { return GetSelectedItem(); }
        }

        public void SetSingleSelectMode(IEntity selectedItem)
        {
            _cxRefCustomers.SetSingleSelectMode(selectedItem as Core.Entities.Customer);
            Refresh();
            _cxRefCustomers.SetFocusedRow(selectedItem?.Id ?? Guid.Empty);
        }

        private IEntity GetSelectedItem()
        {
            return _cxRefCustomers.SelectedItem;
        }

        private void OnItemSelected()
        {
            ItemSelected?.Invoke(this, EventArgs.Empty);
        }

        protected override string GetTitle()
        {
            return "Контрагенты";
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            _cxRefCustomers.ReadOnly = value;
        }

        public Expression<Func<Core.Entities.Customer, bool>> ExternalFilterExp
        {
            get => _cxRefCustomers.ExternalFilterExp;
            set => _cxRefCustomers.ExternalFilterExp = value;
        }
    }
}
