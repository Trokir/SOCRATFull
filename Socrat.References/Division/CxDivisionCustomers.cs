using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Customer;

namespace Socrat.References.Division
{
    public class CxDivisionCustomers: CxGenericListTable<DivisionCustomer>
    {
        public Core.Entities.Division Division { get; set; }

        public CxDivisionCustomers()
        {
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "CustomerName", 200, 0);
            AddColumn("ИНН", "CustomerInn", 120, 1);
            AddColumn("КПП", "CustomerKpp", 120, 2);
            AddColumn("Код 1С", "CustomerCode_1C", 120, 3);
            AddColumn("По умолчанию", "Default", 100, 4);
            AddColumn("Закрыт", "Closed", 100, 5);
        }

        protected override DivisionCustomer GetNewInstance()
        {
            return new DivisionCustomer();
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCustomerEdit();
        }

        protected override ObservableCollection<DivisionCustomer> GetItems()
        {
            return Division?.DivisionCustomers;
        }

        protected override void AddItem()
        {
            FxCustomers _fx = new FxCustomers();
            _fx.SetSingleSelectMode(null);
            _fx.ItemSelected += (sender, args) => 
            {
                Division.DivisionCustomers.Add( 
                    new DivisionCustomer
                    {
                        Customer = _fx.SelectedItem as Core.Entities.Customer,
                        Division = Division
                    });
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            gvGrid.RefreshData();
        }

        protected override void OpenItem()
        {
            if (Items == null)
                return;
            DivisionCustomer _divisionCustomer = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            IEntity _entity = _divisionCustomer?.Customer;
            if (_entity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;
                _fx.ReadOnly = this.ReadOnly;
                _fx.SaveButtonClick += (_sender, args) =>
                {
                    if (!_fx.Entity?.Changed ?? false)
                        return;
                    DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        Repository.Save(_divisionCustomer);
                    }
                    else
                    {
                        _entity = Repository.Revert(_divisionCustomer);
                    }
                    gvGrid.RefreshData();
                };
                _fx.DialogOutput += _fx_DialogOutput;
                _fx.StartPosition = FormStartPosition.CenterParent;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }
    }
}
