using System;
using Socrat.References;
using System.Collections.ObjectModel;
using Socrat.Core.Entities;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Shape.Shproses;
using Socrat.Lib.Commands;
using System.Collections.Generic;
using Socrat.Shape.Forms;

namespace Socrat.Shape.Components
{
    public partial class CxShprosElement : CxGenericListTable<ShprosElement>
    {

        public event EventHandler CheckContextMenuItem;
        public event EventHandler OnCheckCurrentForm;
        private string PropName { get; set; }
        ObservableCollection<ShprosElement> _items;
        public string ShprosTypeSelector { get; set; }
        public CxShprosElement()
        {
            InitializeComponent();
        }
        protected override void InitCommands()
        {
            ReferenceCommand _addCmd = new ReferenceCommand(MenuCommandType.Group, "Добавить", null, null);
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item,
                "Элемент", AddElementExecute, null));
            _addCmd.Commands.Add(new ReferenceCommand(MenuCommandType.Item,
                "Набор", AddElementPackExecute, null));

            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 },
                _addCmd,
                new ReferenceCommand(MenuCommandType.Item, "Удалить", DeleteItemExecute, null) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true },
                 new ReferenceCommand(MenuCommandType.Item, "Удалить все", DeleteAllExecute, null) { Image = Properties.Resources.deletelist_16x16, IsWriteCommand = true },
            };

        }

        private void AddElementPackExecute(object obj)
        {
            ShprosTypeSelector = "Набор";
            CheckContextMenuItem?.Invoke(this, EventArgs.Empty);
        }

        private void AddElementExecute(object obj)
        {
            ShprosTypeSelector = "Элемент";
            CheckContextMenuItem?.Invoke(this, EventArgs.Empty);
        }
        private void OpenSelectedRow()
        {
            OnCheckCurrentForm?.Invoke(this, EventArgs.Empty);
        }
        protected override void OpenItem()
        {
            OpenSelectedRow();
        }
        protected override void AddItem()
        {
            OnAddItem();
            gvGrid.RefreshData();
        }
        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 20, 0);
            AddColumn("Ориентация", "OrientationType", 20, 0);
            AddColumn("Расположение", "Location", 20, 0);
        }
        public Guid? CurrentId { get; set; }
        protected override ObservableCollection<ShprosElement> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<ShprosElement>(Repository.GetAll().Where(x => x.ShapeId == CurrentId)
                         .OrderBy(x => x.SideVector)
                        .OrderBy(x => x.OrientationType)
                         .OrderBy(x => x.LeftMargin));
            return _items;
        }

      
       
       
      
        public void RefreshGrid()
        {
            base.RefreshData();
            gvGrid.RefreshData();
        }
    }
}
