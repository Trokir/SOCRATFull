using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.References.Bank;

namespace Socrat.References.Address
{
    public partial class CxOrderAddresses : CxGenericListTable<Core.Entities.Address>
    {
        public Core.Entities.Order Order { get; set; }

        public List<Core.Entities.Address> _AddressesList;

        public CxOrderAddresses()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<Core.Entities.Address> GetItems()
        {
            _AddressesList = new List<Core.Entities.Address>();
            if (Order.Customer != null
                && Order.Customer.CustomerAddresses != null
                && Order.Customer.CustomerAddresses.Count > 0)
            {
                _AddressesList.AddRange(Order.Customer.CustomerAddresses.Select(x => x.Address).Where(x => x != null));
            }
            if (Order.Contract != null
                && Order.Contract.ContractAddresses != null
                && Order.Contract.ContractAddresses.Count > 0)
            {
                _AddressesList.AddRange(Order.Contract.ContractAddresses.Select(x => x.Address).Where(x => x != null));
            }
            return new ObservableCollection<Core.Entities.Address>(_AddressesList) ;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxAddressEdit();
        }

        protected override void InitColumns()
        {
            AddColumn("Адрес", "Title", 300, 0);
        }

        protected override void AddItem()
        {
            Core.Entities.Address _entity =  new Core.Entities.Address();
            IEntityEditor _fx = GetEditor();
            _fx.Entity = _entity;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes && !this.ReadOnly)
                {
                    bool res = DependedSaving;

                    if (!Items.Contains(_entity))
                    {
                        if (Order.Contract != null)
                        {
                            Order.Contract.ContractAddresses.Add(
                                new ContractAddress { Contract = Order.Contract, Address = _entity});
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                "Адрес не будет сохранен в Адресах доставки договора, поскольку договор не выбран",
                                "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (DependedSaving)
                        {
                            _entity.Changed = false;
                            if (SourceItems != null && !SourceItems.Contains(_entity))
                                SourceItems.Add(_entity);
                        }
                    }
                    if (!DependedSaving)
                        Repository.Save(_entity);
                }
                RefreshData();
                gvGrid.RefreshData();
                UpdateFooter();
                if (_entity != null)
                    SetFocusedRow(_entity.Id);
            };
            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            OnAddItem();
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}
