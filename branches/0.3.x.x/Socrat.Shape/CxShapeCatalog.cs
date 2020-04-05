using System;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.References;

namespace Socrat.Shape
{
    public partial class CxShapeCatalog : CxGenericListTable<Core.Entities.Shape>
    {
        ObservableCollection<Core.Entities.Shape> _items;
        FxShapeCatalogEditor fx;
        static Guid CurrentId { get; set; }

        public CxShapeCatalog()
        {
            InitializeComponent();
        }

        protected override void OpenItem()
        {
            OnInit();
        }
        public Guid OnInit()
        {
            var _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            fx = new FxShapeCatalogEditor(_entity.Id);
            return _entity.Id;
        }

        protected override void AddItem()
        {
            OnAddItem();
            gvGrid.RefreshData();
        }

        protected override void InitColumns()
        {
            AddColumn("Название фигуры", "CatalogNumber", 20, 0);
        }
        protected override IEntityEditor GetEditor()
        {
            return new FxAddNewShape();
        }

        protected override ObservableCollection<Core.Entities.Shape> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<Core.Entities.Shape>(Repository.GetAll().OrderBy(x => x.CatalogNumber));
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










    }
}