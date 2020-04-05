using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Commands;

namespace Socrat.References.Price
{
    public partial class CxPriceList : CxGenericListTable<Core.Entities.Price>
    {
        private ObservableCollection<Core.Entities.Price> _allPrices;
        public CxPriceList()
        {
            InitializeComponent();
            DeleteItemEvent += CxPriceList_DeleteItemEvent;
        }

        private void CxPriceList_DeleteItemEvent(object sender, UI.Core.ListItemEventArgs e)
        {

        }

        protected override ObservableCollection<Core.Entities.Price> GetItems()
        {
            IRepository<Core.Entities.Price> repos = DataHelper.GetRepository<Core.Entities.Price>();
            _allPrices = new ObservableCollection<Core.Entities.Price>(repos.GetAll().ToList());
            return _allPrices;
        }
        protected override void InitColumns()
        {
            AddColumn("Пр.площадка", "Division.FullName", 150, 0);
            AddColumn("Тип", "PriceType", 250, 1);
            AddColumn("Контрагент/Наименование", "PriceName", 150, 2);
        }

        private void Form_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override void InitCommands()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 }
            };

            ReferenceCommand _addCmd = new ReferenceCommand(MenuCommandType.Group, "Добавить", null, null)
            { Image = Properties.Resources.addfile_16x16, BeginGroup = true };
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Общий прайс", AddCommonPrice, null)
            { Image = Properties.Resources.addfile_16x16 });
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item, "Индивидуальный прайс", AddIndividualPrice, null)
            { Image = Properties.Resources.addfile_16x16 });
            _commands.Add(_addCmd);

            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16 });
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Экспорт в Excel", ExpotrtToExcelExecute, null) { Image = Properties.Resources.exporttoxlsx_16x16 });
        }

        private bool isIndividualPrice = false;

        protected override IEntityEditor GetEditor()
        {
            if (Tag != null && Tag.ToString().Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                FxNewPrice edit = new FxNewPrice() { Price = new Core.Entities.Price() };
                edit.beCustomer.Enabled = isIndividualPrice;
                return edit;
            }
            else
            {
                FxPriceSelector form = new FxPriceSelector();
                return form;
            }
        }

        private void AddCommonPrice(object o)
        {
            Tag = "Add";
            isIndividualPrice = false;
            AddNewPrice(new Socrat.Core.Entities.Price());
            Tag = null;
        }

        private void AddIndividualPrice(object o)
        {
            Tag = "Add";
            isIndividualPrice = true;
            AddNewPrice(new Socrat.Core.Entities.Price());
            Tag = null;
        }

        private void AddNewPrice(Socrat.Core.Entities.Price price)
        {
            IEntityEditor _fx = GetEditor();
            _fx.Entity = price;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    Repository.Save(price);
                    if (!Items.Contains(price))
                        Items.Add(price);
                }
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += FxOnDialogOutput;
            _fx.StartPosition = FormStartPosition.CenterParent;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }
    }
}
