using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Model.Shapes;
using Socrat.References;
using Socrat.Shape.Factory;
using Socrat.UI.Core;

namespace Socrat.Shape
{
    public partial class CxShapeCatalog : CxGenericListTable<Model.Shapes.Shape>
    {
        ObservableCollection<Model.Shapes.Shape> _items;
        FxShapeCatalogEditor fx;
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
            var _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());
            fx = new FxShapeCatalogEditor(_entity.Id);
           return  _entity.Id;
             
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

      
        protected override ObservableCollection<Model.Shapes.Shape> GetItems()
        {
            if (_items == null)
                _items = new ObservableCollection<Model.Shapes.Shape>(Repository.GetAll().OrderBy(x => x.CatalogNumber.Substring(0,1)));
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