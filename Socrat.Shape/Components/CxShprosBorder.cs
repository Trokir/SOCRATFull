using System;
using Socrat.References;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Shape.Forms;
using Socrat.Core.Entities;
using Socrat.Lib.Commands;
using Socrat.DataProvider.Repos;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Socrat.Shape.Components
{
    public partial class CxShprosBorder : CxGenericListTable<ShprosCircuit>
    {
        public event EventHandler CheckContextMenuItem;
        ObservableCollection<ShprosCircuit> _items;
        private ShprosCircuitRepository Repository;
        private ShprosCircuit _shprosCircuit;
        public string ShprosTypeSelector { get; set; }
        public CxShprosBorder()
        {
            InitializeComponent();
            Load += CxShprosBorder_Load;
            Repository = new ShprosCircuitRepository();
        }

        private void CxShprosBorder_Load(object sender, EventArgs e)
        {
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 20, 0);
            AddColumn("Длина", "Length", 20, 0);
            AddColumn("Площадь", "Square", 20, 0);
        }

        protected override void InitCommands()
        {

            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.ButtonsOnly, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 },
                new ReferenceCommand(MenuCommandType.ButtonsOnly, "Добавить", AddItemExecute, null) { Image = Properties.Resources.addfile_16x16, IsWriteCommand = true},
                new ReferenceCommand(MenuCommandType.ButtonsOnly, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true },
 
            };
            _commands.Add(
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Элемент", CreateElementExecute , null)
                {  BeginGroup = true });
            _commands.Add(
                new ReferenceCommand(MenuCommandType.ComtextMenuItem, "Набор", CreateElementPackExecute, null)
                { BeginGroup = true });
        }
        
        private void CreateElementExecute(object obj)
        {
            ShprosTypeSelector = "Элемент";
            CheckContextMenuItem?.Invoke(this, EventArgs.Empty);
        }

        private void CreateElementPackExecute(object obj)
        {
            ShprosTypeSelector = "Набор";
            CheckContextMenuItem?.Invoke(this, EventArgs.Empty);
        }
        protected override void OpenItem()
        {
            //var _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            //base.OpenItem();
        }

        protected override void AddItem()
        {
            IEntityEditor _fx = GetEditor();
            _fx.Entity = new ShprosCircuit();
            _fx.SaveButtonClick += (s, es) =>
            {
                _shprosCircuit = _fx.Entity as ShprosCircuit;
                Repository.Save(_shprosCircuit);
                if (!this.Items.Contains(_shprosCircuit))
                    this.Items.Add(_shprosCircuit);
            };

            _fx.DialogOutput += FxOnDialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Dialog);
            OnAddItem();
            gvGrid.RefreshData();
        }

        private void FxOnDialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override ObservableCollection<ShprosCircuit> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<ShprosCircuit>(Repository.GetAll());
            return _items;
        }
        protected override void DeleteItem()
        {
            base.DeleteItem();
            gvGrid.RefreshData();
        }

        public void RefreshGrid()
        {

            base.RefreshData();
            gvGrid.RefreshData();
        }
        protected override IEntityEditor GetEditor()
        {
            return new FxConturForm();
        }
        protected override string GetTitle()
        {
            return $"Контуры";
        }
    }
}
