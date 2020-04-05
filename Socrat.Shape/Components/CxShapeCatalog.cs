using System;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.References;
using Socrat.Shape.Forms;

namespace Socrat.Shape
{
    public partial class CxShapeCatalog : CxGenericListTable<Core.Entities.Shape>
    {
        ObservableCollection<Core.Entities.Shape> _items;
        FxShapeCatalogEditor _fx;
        static Guid Current_Id { get; set; }



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
            var _entity = Items.FirstOrDefault(PointX => PointX.Id == GetCurrentRowId());
            _fx = new FxShapeCatalogEditor(_entity.Id);
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
        //protected override IEntityEditor GetEditor()
        //{
        //    return new FxAddNewShape();
        //}

      
        protected override ObservableCollection<Core.Entities.Shape> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<Core.Entities.Shape>(Repository.GetAll().OrderBy(PointX => PointX.CatalogNumber));
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